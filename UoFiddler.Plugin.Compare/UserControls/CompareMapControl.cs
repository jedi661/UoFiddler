﻿/***************************************************************************
 *
 * $Author: Turley
 * 
 * "THE BEER-WARE LICENSE"
 * As long as you retain this notice you can do whatever you want with 
 * this stuff. If we meet some day, and you think this stuff is worth it,
 * you can buy me a beer in return.
 *
 ***************************************************************************/

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;

namespace UoFiddler.Plugin.Compare.UserControls
{
    public partial class CompareMapControl : UserControl
    {
        public CompareMapControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            pictureBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel); // MouseWeel
        }

        private bool _loaded;
        private bool _moving;
        private Point _movingPoint;
        private Point _currentPoint;
        private Map _currentMap;
        private Map _originalMap;
        private int _currentMapId;
        private Bitmap _map;
        private static double _zoom = 1;
        private bool[][][][] _diffs;

        private void OnLoad(object sender, EventArgs e)
        {
            _currentMap = Map.Custom;
            _originalMap = Map.Felucca;
            feluccaToolStripMenuItem.Checked = true;
            trammelToolStripMenuItem.Checked = false;
            ilshenarToolStripMenuItem.Checked = false;
            malasToolStripMenuItem.Checked = false;
            tokunoToolStripMenuItem.Checked = false;
            terMurToolStripMenuItem.Checked = false;
            showDifferencesToolStripMenuItem.Checked = true;
            showMap1ToolStripMenuItem.Checked = true;
            showMap2ToolStripMenuItem.Checked = false;
            SetScrollBarValues();
            ChangeMapNames();
            ZoomLabel.Text = $"Zoom: {_zoom}";

            Options.LoadedUltimaClass["Map"] = true;
            Options.LoadedUltimaClass["RadarColor"] = true;

            if (!_loaded)
            {
                ControlEvents.MapDiffChangeEvent += OnMapDiffChangeEvent;
                ControlEvents.MapNameChangeEvent += OnMapNameChangeEvent;
                ControlEvents.MapSizeChangeEvent += OnMapSizeChangeEvent;
                ControlEvents.FilePathChangeEvent += OnFilePathChangeEvent;
            }
            _loaded = true;
        }

        private void OnMapDiffChangeEvent()
        {
            CalculateDiffs();
            pictureBox.Invalidate();
        }

        private void OnMapNameChangeEvent()
        {
            ChangeMapNames();
        }

        private void OnMapSizeChangeEvent()
        {
            InternalUpdate();
        }

        private void OnFilePathChangeEvent()
        {
            InternalUpdate();
        }

        private void InternalUpdate()
        {
            SetScrollBarValues();
            if (_currentMap != null)
            {
                ChangeMap();
            }

            pictureBox.Invalidate();
        }

        private void ChangeMapNames()
        {
            if (!_loaded)
            {
                return;
            }

            feluccaToolStripMenuItem.Text = Options.MapNames[0];
            trammelToolStripMenuItem.Text = Options.MapNames[1];
            ilshenarToolStripMenuItem.Text = Options.MapNames[2];
            malasToolStripMenuItem.Text = Options.MapNames[3];
            tokunoToolStripMenuItem.Text = Options.MapNames[4];
            terMurToolStripMenuItem.Text = Options.MapNames[5];
        }

        private static int Round(int x)
        {
            return (x >> 3) << 3;
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _moving = true;
                _movingPoint.X = e.X;
                _movingPoint.Y = e.Y;
                Cursor = Cursors.Hand;
            }
            else
            {
                _moving = false;
                Cursor = Cursors.Default;
            }
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            int xDelta = Math.Min(_originalMap.Width, (int)(e.X / _zoom) + Round(hScrollBar.Value));
            int yDelta = Math.Min(_originalMap.Height, (int)(e.Y / _zoom) + Round(vScrollBar.Value));

            CoordsLabel.Text = $"Coords: {xDelta},{yDelta}";

            string diff = string.Empty;

            if (_moving)
            {
                toolTip1.RemoveAll();

                int deltaX = (int)(-1 * (e.X - _movingPoint.X) / _zoom);
                int deltaY = (int)(-1 * (e.Y - _movingPoint.Y) / _zoom);

                _movingPoint.X = e.X;
                _movingPoint.Y = e.Y;

                hScrollBar.Value = Math.Max(0, Math.Min(hScrollBar.Maximum, hScrollBar.Value + deltaX));
                vScrollBar.Value = Math.Max(0, Math.Min(vScrollBar.Maximum, vScrollBar.Value + deltaY));

                pictureBox.Invalidate();
            }
            else if (_zoom >= 2 && _currentMap != null)
            {
                if (BlockDiff(xDelta >> 3, yDelta >> 3))
                {
                    Tile customTile = _currentMap.Tiles.GetLandTile(xDelta, yDelta);
                    Tile origTile = _originalMap.Tiles.GetLandTile(xDelta, yDelta);

                    if (customTile.Id != origTile.Id || customTile.Z != origTile.Z)
                    {
                        diff = $"Tile:\n\r0x{origTile.Id:X} {origTile.Z} -> 0x{customTile.Id:X} {customTile.Z}\n\r";
                    }

                    HuedTile[] customStatics = _currentMap.Tiles.GetStaticTiles(xDelta, yDelta);
                    HuedTile[] origStatics = _originalMap.Tiles.GetStaticTiles(xDelta, yDelta);

                    if (customStatics.Length != origStatics.Length)
                    {
                        diff += "Statics:\n\rorig:\n\r";

                        foreach (HuedTile tile in origStatics)
                        {
                            diff += $"0x{tile.Id:X} {tile.Z} {tile.Hue}\n\r";
                        }

                        diff += "new:\n\r";

                        foreach (HuedTile tile in customStatics)
                        {
                            diff += $"0x{tile.Id:X} {tile.Z} {tile.Hue}\n\r";
                        }
                    }
                    else
                    {
                        bool changed = false;
                        for (int i = 0; i < customStatics.Length; i++)
                        {
                            if (customStatics[i].Id != origStatics[i].Id
                                || customStatics[i].Z != origStatics[i].Z
                                || customStatics[i].Hue != origStatics[i].Hue)
                            {
                                if (!changed)
                                {
                                    diff += "Statics diff:\n\r";

                                    changed = true;
                                }
                                diff += $"0x{origStatics[i].Id:X} {origStatics[i].Z} {origStatics[i].Hue} -> 0x{customStatics[i].Id:X} {customStatics[i].Z} {customStatics[i].Hue}\n\r";
                            }
                        }
                    }
                }
                toolTip1.SetToolTip(pictureBox, diff);
                pictureBox.Invalidate();
            }

            if ((_zoom < 2) || !markDiffToolStripMenuItem.Checked || !string.IsNullOrEmpty(diff))
            {
                return;
            }

            Map drawMap = showMap1ToolStripMenuItem.Checked
                ? _originalMap
                : _currentMap;

            if (drawMap?.Tiles.Patch.LandBlocksCount > 0 && drawMap.Tiles.Patch.IsLandBlockPatched(xDelta >> 3, yDelta >> 3))
            {
                Tile patchTile = drawMap.Tiles.Patch.GetLandTile(xDelta, yDelta);
                Tile origTile = drawMap.Tiles.GetLandTile(xDelta, yDelta, false);
                diff = $"Tile:\n\r0x{origTile.Id:X} {origTile.Z} -> 0x{patchTile.Id:X} {patchTile.Z}\n\r";
            }

            if (drawMap?.Tiles.Patch.StaticBlocksCount > 0 && drawMap.Tiles.Patch.IsStaticBlockPatched(xDelta >> 3, yDelta >> 3))
            {
                HuedTile[] patchStatics = drawMap.Tiles.Patch.GetStaticTiles(xDelta, yDelta);
                HuedTile[] origStatics = drawMap.Tiles.GetStaticTiles(xDelta, yDelta, false);

                diff += "Statics:\n\rorig:\n\r";

                foreach (HuedTile tile in origStatics)
                {
                    diff += $"0x{tile.Id:X} {tile.Z} {tile.Hue}\n\r";
                }

                diff += "patch:\n\r";

                foreach (HuedTile tile in patchStatics)
                {
                    diff += $"0x{tile.Id:X} {tile.Z} {tile.Hue}\n\r";
                }
            }

            toolTip1.SetToolTip(pictureBox, diff);

            pictureBox.Invalidate();
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            _moving = false;
            Cursor = Cursors.Default;
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            if (!_loaded)
            {
                return;
            }

            if (showMap1ToolStripMenuItem.Checked)
            {
                _map = _originalMap.GetImage(hScrollBar.Value >> 3, vScrollBar.Value >> 3,
                   (int)((e.ClipRectangle.Width / _zoom) + 8) >> 3, (int)((e.ClipRectangle.Height / _zoom) + 8) >> 3,
                   true);
            }
            else
            {
                _map = _currentMap.GetImage(hScrollBar.Value >> 3, vScrollBar.Value >> 3,
                   (int)((e.ClipRectangle.Width / _zoom) + 8) >> 3, (int)((e.ClipRectangle.Height / _zoom) + 8) >> 3,
                   true);
            }

            if (_currentMap != null && showDifferencesToolStripMenuItem.Checked)
            {
                using (Graphics mapg = Graphics.FromImage(_map))
                {
                    int maxx = ((int)((e.ClipRectangle.Width / _zoom) + 8) >> 3) + (hScrollBar.Value >> 3);
                    int maxy = ((int)((e.ClipRectangle.Height / _zoom) + 8) >> 3) + (vScrollBar.Value >> 3);
                    if (maxx > _originalMap.Width >> 3)
                    {
                        maxx = _originalMap.Width >> 3;
                    }

                    if (maxy > _originalMap.Height >> 3)
                    {
                        maxy = _originalMap.Height >> 3;
                    }

                    int gx = 0;
                    for (int x = hScrollBar.Value >> 3; x < maxx; x++, gx += 8)
                    {
                        int gy = 0;
                        for (int y = vScrollBar.Value >> 3; y < maxy; y++, gy += 8)
                        {
                            for (int xb = 0; xb < 8; xb++)
                            {
                                for (int yb = 0; yb < 8; yb++)
                                {
                                    if (_diffs[x][y][xb][yb])
                                    {
                                        mapg.DrawRectangle(Pens.Red, gx + xb, gy + yb, 1, 1);
                                        mapg.DrawRectangle(Pens.Red, gx + xb, 0, 1, 2);
                                        mapg.DrawRectangle(Pens.Red, 0, gy + yb, 2, 1);
                                    }
                                }
                            }
                        }
                    }
                    mapg.Save();
                }
            }

            if (markDiffToolStripMenuItem.Checked)
            {
                Map drawMap = showMap1ToolStripMenuItem.Checked
                    ? _originalMap
                    : _currentMap;

                if (drawMap != null)
                {
                    int count = drawMap.Tiles.Patch.LandBlocksCount + drawMap.Tiles.Patch.StaticBlocksCount;
                    if (count > 0)
                    {
                        using (Graphics graphics = Graphics.FromImage(_map))
                        {
                            int maxX = ((int)((e.ClipRectangle.Width / _zoom) + 8) >> 3) + (hScrollBar.Value >> 3);
                            int maxY = ((int)((e.ClipRectangle.Height / _zoom) + 8) >> 3) + (vScrollBar.Value >> 3);

                            if (maxX > drawMap.Width >> 3)
                            {
                                maxX = drawMap.Width >> 3;
                            }

                            if (maxY > drawMap.Height >> 3)
                            {
                                maxY = drawMap.Height >> 3;
                            }

                            int gx = 0;
                            for (int x = hScrollBar.Value >> 3; x < maxX; x++, gx += 8)
                            {
                                int gy = 0;
                                for (int y = vScrollBar.Value >> 3; y < maxY; y++, gy += 8)
                                {
                                    if (drawMap.Tiles.Patch.IsLandBlockPatched(x, y))
                                    {
                                        graphics.FillRectangle(Brushes.Azure, gx, gy, 8, 8);
                                        graphics.FillRectangle(Brushes.Azure, gx, 0, 8, 2);
                                        graphics.FillRectangle(Brushes.Azure, 0, gy, 2, 8);
                                    }

                                    if (drawMap.Tiles.Patch.IsStaticBlockPatched(x, y))
                                    {
                                        graphics.FillRectangle(Brushes.Azure, gx, gy, 8, 8);
                                        graphics.FillRectangle(Brushes.Azure, gx, 0, 8, 2);
                                        graphics.FillRectangle(Brushes.Azure, 0, gy, 2, 8);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ZoomMap(ref _map);

            e.Graphics.DrawImageUnscaledAndClipped(_map, e.ClipRectangle);
        }

        private void ZoomMap(ref Bitmap bmp0)
        {
            Bitmap bmp1 = new Bitmap((int)(_map.Width * _zoom), (int)(_map.Height * _zoom));
            using (Graphics graph = Graphics.FromImage(bmp1))
            {
                graph.InterpolationMode = InterpolationMode.NearestNeighbor;
                graph.PixelOffsetMode = PixelOffsetMode.Half;
                graph.DrawImage(bmp0, new Rectangle(0, 0, bmp1.Width, bmp1.Height));
            }

            bmp0 = bmp1;
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (!_loaded)
            {
                return;
            }

            ChangeScrollBar();
            pictureBox.Invalidate();
        }

        private void ChangeScrollBar()
        {
            hScrollBar.Maximum = _originalMap.Width;
            hScrollBar.Maximum -= Round((int)(pictureBox.ClientSize.Width / _zoom) - 8);

            if (_zoom >= 1)
            {
                hScrollBar.Maximum += (int)(40 * _zoom);
            }
            else if (_zoom < 1)
            {
                hScrollBar.Maximum += (int)(40 / _zoom);
            }

            hScrollBar.Maximum = Math.Max(0, Round(hScrollBar.Maximum));
            vScrollBar.Maximum = _originalMap.Height;
            vScrollBar.Maximum -= Round((int)(pictureBox.ClientSize.Height / _zoom) - 8);

            if (_zoom >= 1)
            {
                vScrollBar.Maximum += (int)(40 * _zoom);
            }
            else if (_zoom < 1)
            {
                vScrollBar.Maximum += (int)(40 / _zoom);
            }

            vScrollBar.Maximum = Math.Max(0, Round(vScrollBar.Maximum));
        }

        private void SetScrollBarValues()
        {
            hScrollBar.Minimum = 0;
            vScrollBar.Minimum = 0;

            ChangeScrollBar();

            hScrollBar.LargeChange = 40;
            hScrollBar.SmallChange = 8;
            hScrollBar.Value = 0;

            vScrollBar.LargeChange = 40;
            vScrollBar.SmallChange = 8;
            vScrollBar.Value = 0;
        }

        private void OnZoomPlus(object sender, EventArgs e)
        {
            if (_zoom < 18) // 18 zoom
            {
                _zoom *= 2;
                DoZoom();
            }
        }

        private void OnZoomMinus(object sender, EventArgs e)
        {
            if (_zoom > 0.25) //0.25 Zoom
            {
                _zoom /= 2;
                DoZoom();
            }
        }

        private void DoZoom()
        {
            ChangeScrollBar();

            ZoomLabel.Text = $"Zoom: {_zoom}";

            Point mousePosition = pictureBox.PointToClient(MousePosition);
            int x = Math.Max(0, (int)(mousePosition.X / _zoom + hScrollBar.Value) - (int)(pictureBox.ClientSize.Width / _zoom / 2));
            int y = Math.Max(0, (int)(mousePosition.Y / _zoom + vScrollBar.Value) - (int)(pictureBox.ClientSize.Height / _zoom / 2));

            x = Math.Min(x, hScrollBar.Maximum);
            y = Math.Min(y, vScrollBar.Maximum);

            hScrollBar.Value = Round(x);
            vScrollBar.Value = Round(y);

            pictureBox.Invalidate();
        }

        private void OnOpeningContext(object sender, CancelEventArgs e)
        {
            _currentPoint = pictureBox.PointToClient(MousePosition);

            _currentPoint.X = (int)(_currentPoint.X / _zoom);
            _currentPoint.Y = (int)(_currentPoint.Y / _zoom);

            _currentPoint.X += hScrollBar.Value;
            _currentPoint.Y += vScrollBar.Value;
        }

        private void OnClickBrowseLoc(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select directory containing the map files";
                dialog.ShowNewFolderButton = false;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    toolStripTextBox1.Text = dialog.SelectedPath;
                }
            }
        }

        private void OnClickLoad(object sender, EventArgs e)
        {
            ChangeMap();
        }

        private void ChangeMap()
        {
            SetScrollBarValues();

            string path = toolStripTextBox1.Text;

            if (Directory.Exists(path))
            {
                _currentMap = Map.Custom = new Map(path, _originalMap.FileIndex, _currentMapId, _originalMap.Width, _originalMap.Height);
            }

            CalculateDiffs();

            pictureBox.Invalidate();
        }

        private void ResetCheckedMap()
        {
            feluccaToolStripMenuItem.Checked = false;
            trammelToolStripMenuItem.Checked = false;
            malasToolStripMenuItem.Checked = false;
            ilshenarToolStripMenuItem.Checked = false;
            tokunoToolStripMenuItem.Checked = false;
            terMurToolStripMenuItem.Checked = false;
        }

        private void OnClickChangeFelucca(object sender, EventArgs e)
        {
            if (feluccaToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            feluccaToolStripMenuItem.Checked = true;

            _originalMap = Map.Felucca;
            _currentMapId = 0;

            ChangeMap();
        }

        private void OnClickChangeTrammel(object sender, EventArgs e)
        {
            if (trammelToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            trammelToolStripMenuItem.Checked = true;

            _originalMap = Map.Trammel;
            _currentMapId = 1;

            ChangeMap();
        }

        private void OnClickChangeIlshenar(object sender, EventArgs e)
        {
            if (ilshenarToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            ilshenarToolStripMenuItem.Checked = true;

            _originalMap = Map.Ilshenar;
            _currentMapId = 2;

            ChangeMap();
        }

        private void OnClickChangeMalas(object sender, EventArgs e)
        {
            if (malasToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            malasToolStripMenuItem.Checked = true;

            _originalMap = Map.Malas;
            _currentMapId = 3;

            ChangeMap();
        }

        private void OnClickChangeTokuno(object sender, EventArgs e)
        {
            if (tokunoToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            tokunoToolStripMenuItem.Checked = true;

            _originalMap = Map.Tokuno;
            _currentMapId = 4;

            ChangeMap();
        }

        private void OnClickChangeTerMur(object sender, EventArgs e)
        {
            if (terMurToolStripMenuItem.Checked)
            {
                return;
            }

            ResetCheckedMap();

            terMurToolStripMenuItem.Checked = true;

            _originalMap = Map.TerMur;
            _currentMapId = 5;

            ChangeMap();
        }

        private void OnClickShowDiff(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private void OnClickShowMap2(object sender, EventArgs e)
        {
            if (showMap2ToolStripMenuItem.Checked || _currentMap == null)
            {
                return;
            }

            showMap1ToolStripMenuItem.Checked = false;
            showMap2ToolStripMenuItem.Checked = true;

            pictureBox.Invalidate();
        }

        private void OnClickShowMap1(object sender, EventArgs e)
        {
            if (showMap1ToolStripMenuItem.Checked)
            {
                return;
            }

            showMap2ToolStripMenuItem.Checked = false;
            showMap1ToolStripMenuItem.Checked = true;

            pictureBox.Invalidate();
        }

        private void OnClickMarkDiff(object sender, EventArgs e)
        {
            pictureBox.Invalidate();
        }

        private bool BlockDiff(int x, int y)
        {
            if (_diffs == null)
            {
                return false;
            }

            if (x < 0 || y < 0 || x >= _diffs.GetLength(0) || y >= _diffs[x].GetLength(0))
            {
                return false;
            }

            for (int xb = 0; xb < 8; xb++)
            {
                for (int yb = 0; yb < 8; yb++)
                {
                    if (_diffs[x][y][xb][yb])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void CalculateDiffs()
        {
            int width = _currentMap.Width >> 3;
            int height = _currentMap.Height >> 3;

            _diffs = new bool[width][][][];

            if (_currentMap == null || _originalMap == null)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            for (int x = 0; x < width; ++x)
            {
                _diffs[x] = new bool[height][][];

                for (int y = 0; y < height; ++y)
                {
                    _diffs[x][y] = new bool[8][];

                    Tile[] customTiles = _currentMap.Tiles.GetLandBlock(x, y);
                    Tile[] origTiles = _originalMap.Tiles.GetLandBlock(x, y);

                    HuedTile[][][] customStatics = _currentMap.Tiles.GetStaticBlock(x, y);
                    HuedTile[][][] origStatics = _originalMap.Tiles.GetStaticBlock(x, y);

                    for (int xb = 0; xb < 8; xb++)
                    {
                        _diffs[x][y][xb] = new bool[8];

                        for (int yb = 0; yb < 8; yb++)
                        {
                            if (customTiles[((yb & 0x7) << 3) + (xb & 0x7)].Id != origTiles[((yb & 0x7) << 3) + (xb & 0x7)].Id
                             || customTiles[((yb & 0x7) << 3) + (xb & 0x7)].Z != origTiles[((yb & 0x7) << 3) + (xb & 0x7)].Z)
                            {
                                _diffs[x][y][xb][yb] = true;
                            }
                            else
                            {
                                if (customStatics[xb][yb].Length != origStatics[xb][yb].Length)
                                {
                                    _diffs[x][y][xb][yb] = true;
                                }
                                else
                                {
                                    for (int i = 0; i < customStatics[xb][yb].Length; i++)
                                    {
                                        if (customStatics[xb][yb][i].Id != origStatics[xb][yb][i].Id
                                            || customStatics[xb][yb][i].Z != origStatics[xb][yb][i].Z
                                            || customStatics[xb][yb][i].Hue != origStatics[xb][yb][i].Hue)
                                        {
                                            _diffs[x][y][xb][yb] = true;

                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void HandleScroll(object sender, ScrollEventArgs e)
        {
            pictureBox.Invalidate();
        }

        #region MouseWeel Zoom
        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                OnZoomPlus(sender, e);
            }
            else if (e.Delta < 0)
            {
                OnZoomMinus(sender, e);
            }
        }
        #endregion
    }
}
