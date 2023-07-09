/***************************************************************************
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;
using UoFiddler.Controls.Forms;
using UoFiddler.Controls.Helpers;

namespace UoFiddler.Controls.UserControls
{
    public partial class GumpControl : UserControl
    {

        public GumpControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint,
                true);
            if (!Files.CacheData)
            {
                Preload.Visible = false;
            }

            ProgressBar.Visible = false;

            _refMarker = this;
        }

        private static GumpControl _refMarker;
        private bool _loaded;
        private bool _showFreeSlots;

        /// <summary>
        /// Reload when loaded (file changed)
        /// </summary>
        private void Reload()
        {
            if (!_loaded)
            {
                return;
            }

            _loaded = false;
            OnLoad(EventArgs.Empty);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (IsAncestorSiteInDesignMode || FormsDesignerHelper.IsInDesignMode())
            {
                return;
            }

            if (_loaded)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Options.LoadedUltimaClass["Gumps"] = true;
            _showFreeSlots = false;
            showFreeSlotsToolStripMenuItem.Checked = false;

            PopulateListBox(true);

            if (!_loaded)
            {
                ControlEvents.FilePathChangeEvent += OnFilePathChangeEvent;
                ControlEvents.GumpChangeEvent += OnGumpChangeEvent;
            }

            _loaded = true;
            Cursor.Current = Cursors.Default;
        }

        private void PopulateListBox(bool showOnlyValid)
        {
            //The update of the ListBox begins.
            listBox.BeginUpdate();
            // Deletes all elements from the ListBox.
            listBox.Items.Clear();
            // Creates a new list to store the elements to be added to the ListBox.
            List<object> cache = new List<object>();
            // Variable f�r die maximale Gump-ID
            int maxGumpID = 0; // Variable f�r die maximale Gump-ID

            // Determining the maximum Gump ID.
            for (int i = 0; i < Gumps.GetCount(); i++)
            {
                if (Gumps.IsValidIndex(i))
                {
                    // Updating the maximum Gump ID.
                    maxGumpID = i;
                }
            }

            // Adding the existing Gump IDs to the ListBox.
            for (int i = 0; i < maxGumpID; i++)
            {
                if (showOnlyValid && !_showFreeSlots)
                {
                    if (Gumps.IsValidIndex(i))
                    {
                        cache.Add(i);
                    }
                }
                else
                {
                    cache.Add(i);
                }
            }

            // If _showFreeSlots is enabled, empty IDs will also be added to the ListBox.
            if (_showFreeSlots)
            {
                for (int i = maxGumpID + 1; i <= Gumps.GetCount(); i++)
                {
                    cache.Add(i);
                }
            }
            // Adds all elements from the list to the ListBox.
            listBox.Items.AddRange(cache.ToArray());

            // Completes the update of the ListBox.
            listBox.EndUpdate();

            // Sets the selection to the first element if the ListBox contains any elements.
            if (listBox.Items.Count > 0)
            {
                listBox.SelectedIndex = 0;
            }
        }

        private void OnFilePathChangeEvent()
        {
            Reload();
        }

        private void OnGumpChangeEvent(object sender, int index)
        {
            if (!_loaded)
            {
                return;
            }

            if (sender.Equals(this))
            {
                return;
            }

            if (Gumps.IsValidIndex(index))
            {
                bool done = false;
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    int j = int.Parse(listBox.Items[i].ToString());
                    if (j > index)
                    {
                        listBox.Items.Insert(i, index);
                        listBox.SelectedIndex = i;
                        done = true;
                        break;
                    }

                    if (j == index)
                    {
                        done = true;
                        break;
                    }
                }

                if (!done)
                {
                    listBox.Items.Add(index);
                }
            }
            else
            {
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    int j = int.Parse(listBox.Items[i].ToString());
                    if (j == index)
                    {
                        listBox.Items.RemoveAt(i);
                        break;
                    }
                }

                listBox.Invalidate();
            }
        }

        private void ListBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0)
            {
                return;
            }

            Brush fontBrush = Brushes.Gray;

            int i = int.Parse(listBox.Items[e.Index].ToString());

            if (Gumps.IsValidIndex(i))
            {
                Bitmap bmp = Gumps.GetGump(i, out bool patched);

                if (bmp != null)
                {
                    int width = bmp.Width > 100 ? 100 : bmp.Width;
                    int height = bmp.Height > 54 ? 54 : bmp.Height;

                    if (listBox.SelectedIndex == e.Index)
                    {
                        e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X, e.Bounds.Y, 105, 60);
                    }
                    else if (patched)
                    {
                        e.Graphics.FillRectangle(Brushes.LightCoral, e.Bounds.X, e.Bounds.Y, 105, 60);
                    }

                    e.Graphics.DrawImage(bmp, new Rectangle(e.Bounds.X + 3, e.Bounds.Y + 3, width, height));
                }
                else
                {
                    fontBrush = Brushes.Red;
                }
            }
            else
            {
                if (listBox.SelectedIndex == e.Index)
                {
                    e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X, e.Bounds.Y, 105, 60);
                }

                fontBrush = Brushes.Red;
            }

            e.Graphics.DrawString($"0x{i:X} ({i})", Font, fontBrush,
                new PointF(105,
                    e.Bounds.Y + ((e.Bounds.Height / 2) -
                                  (e.Graphics.MeasureString($"0x{i:X} ({i})", Font).Height / 2))));
        }

        private void ListBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 60;
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                return;
            }

            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            if (Gumps.IsValidIndex(i))
            {
                Bitmap bmp = Gumps.GetGump(i);
                if (bmp != null)
                {
                    pictureBox.BackgroundImage = bmp;
                    IDLabel.Text = $"ID: 0x{i:X} ({i})";
                    SizeLabel.Text = $"Size: {bmp.Width},{bmp.Height}";
                }
                else
                {
                    pictureBox.BackgroundImage = null;
                }
            }
            else
            {
                pictureBox.BackgroundImage = null;
            }

            listBox.Invalidate();
            JumpToMaleFemaleInvalidate();
        }

        private void JumpToMaleFemaleInvalidate()
        {
            if (listBox.SelectedIndex == -1)
            {
                return;
            }

            int gumpId = (int)listBox.SelectedItem;
            if (gumpId >= 50000)
            {
                if (gumpId >= 60000)
                {
                    jumpToMaleFemale.Text = "Jump to Male";
                    jumpToMaleFemale.Enabled = HasGumpId(gumpId - 10000);
                }
                else
                {
                    jumpToMaleFemale.Text = "Jump to Female";
                    jumpToMaleFemale.Enabled = HasGumpId(gumpId + 10000);
                }
            }
            else
            {
                jumpToMaleFemale.Enabled = false;
                jumpToMaleFemale.Text = "Jump to Male/Female";
            }
        }

        private void OnClickReplace(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 1)
            {
                return;
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Title = "Choose image file to replace";
                dialog.CheckFileExists = true;
                dialog.Filter = "Image files (*.tif;*.tiff;*.bmp)|*.tif;*.tiff;*.bmp";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (var bmpTemp = new Bitmap(dialog.FileName))
                {
                    Bitmap bitmap = new Bitmap(bmpTemp);

                    if (dialog.FileName.Contains(".bmp"))
                    {
                        bitmap = Utils.ConvertBmp(bitmap);
                    }

                    int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());

                    Gumps.ReplaceGump(i, bitmap);

                    ControlEvents.FireGumpChangeEvent(this, i);

                    listBox.Invalidate();
                    ListBox_SelectedIndexChanged(this, EventArgs.Empty);

                    Options.ChangedUltimaClass["Gumps"] = true;
                }
            }
        }

        private void OnClickSave(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure? Will take a while", "Save", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.Yes)
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Gumps.Save(Options.OutputPath);
            Cursor.Current = Cursors.Default;
            MessageBox.Show($"Saved to {Options.OutputPath}", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            Options.ChangedUltimaClass["Gumps"] = false;
        }

        private void OnClickRemove(object sender, EventArgs e)
        {
            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            DialogResult result = MessageBox.Show($"Are you sure to remove {i}", "Remove", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.Yes)
            {
                return;
            }

            Gumps.RemoveGump(i);
            ControlEvents.FireGumpChangeEvent(this, i);
            if (!_showFreeSlots)
            {
                listBox.Items.RemoveAt(listBox.SelectedIndex);
            }

            pictureBox.BackgroundImage = null;
            listBox.Invalidate();
            Options.ChangedUltimaClass["Gumps"] = true;
        }

        private void OnClickFindFree(object sender, EventArgs e)
        {
            int id = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            ++id;
            for (int i = listBox.SelectedIndex + 1; i < listBox.Items.Count; ++i, ++id)
            {
                if (id < int.Parse(listBox.Items[i].ToString()))
                {
                    listBox.SelectedIndex = i;
                    break;
                }

                if (!_showFreeSlots)
                {
                    continue;
                }

                if (!Gumps.IsValidIndex(int.Parse(listBox.Items[i].ToString())))
                {
                    listBox.SelectedIndex = i;
                    break;
                }
            }

            // Falls keine leere ID gefunden wurde und _showFreeSlots aktiviert ist,
            // wird eine neue ID am Ende der ListBox hinzugef�gt
            if (listBox.SelectedIndex == -1 && _showFreeSlots)
            {
                int newId = Gumps.GetCount();
                listBox.Items.Add(newId);
                listBox.SelectedIndex = listBox.Items.Count - 1;
            }
        }

        //Show all free slots
        private void AddShowAllFreeSlotsButton_Click(object sender, EventArgs e)
        {

            _showFreeSlots = !_showFreeSlots;
            PopulateListBox(!_showFreeSlots);
        }

        private void OnTextChanged_InsertAt(object sender, EventArgs e)
        {
            if (Utils.ConvertStringToInt(InsertText.Text, out int index, 0, Gumps.GetCount()))
            {
                InsertText.ForeColor = Gumps.IsValidIndex(index) ? Color.Red : Color.Black;
            }
            else
            {
                InsertText.ForeColor = Color.Red;
            }
        }

        private void OnKeydown_InsertText(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (!Utils.ConvertStringToInt(InsertText.Text, out int index, 0, Gumps.GetCount()))
            {
                return;
            }

            if (Gumps.IsValidIndex(index))
            {
                return;
            }

            contextMenuStrip1.Close();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Title = $"Choose image file to insert at 0x{index:X}";
                dialog.CheckFileExists = true;
                dialog.Filter = "Image files (*.tif;*.tiff;*.bmp)|*.tif;*.tiff;*.bmp";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                using (var bmpTemp = new Bitmap(dialog.FileName))
                {
                    Bitmap bitmap = new Bitmap(bmpTemp);

                    if (dialog.FileName.Contains(".bmp"))
                    {
                        bitmap = Utils.ConvertBmp(bitmap);
                    }

                    Gumps.ReplaceGump(index, bitmap);

                    ControlEvents.FireGumpChangeEvent(this, index);

                    bool done = false;
                    for (int i = 0; i < listBox.Items.Count; ++i)
                    {
                        int j = int.Parse(listBox.Items[i].ToString());
                        if (j > index)
                        {
                            listBox.Items.Insert(i, index);
                            listBox.SelectedIndex = i;
                            done = true;
                            break;
                        }

                        if (!_showFreeSlots)
                        {
                            continue;
                        }

                        if (j != i)
                        {
                            continue;
                        }

                        Search(index);
                        done = true;
                        break;
                    }

                    if (!done)
                    {
                        listBox.Items.Add(index);
                        listBox.SelectedIndex = listBox.Items.Count - 1;
                    }

                    Options.ChangedUltimaClass["Gumps"] = true;
                }
            }
        }

        private void Extract_Image_ClickBmp(object sender, EventArgs e)
        {
            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            ExportGumpImage(i, ImageFormat.Bmp);
        }

        private void Extract_Image_ClickTiff(object sender, EventArgs e)
        {
            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            ExportGumpImage(i, ImageFormat.Tiff);
        }

        private void Extract_Image_ClickJpg(object sender, EventArgs e)
        {
            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            ExportGumpImage(i, ImageFormat.Jpeg);
        }

        private void Extract_Image_ClickPng(object sender, EventArgs e)
        {
            int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
            ExportGumpImage(i, ImageFormat.Png);
        }

        private static void ExportGumpImage(int index, ImageFormat imageFormat)
        {
            string fileExtension = Utils.GetFileExtensionFor(imageFormat);
            string fileName = Path.Combine(Options.OutputPath, $"Gump {index}.{fileExtension}");

            using (Bitmap bit = new Bitmap(Gumps.GetGump(index)))
            {
                bit.Save(fileName, imageFormat);
            }

            MessageBox.Show(
                $"Gump saved to {fileName}",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void OnClick_SaveAllBmp(object sender, EventArgs e)
        {
            ExportAllGumps(ImageFormat.Bmp);
        }

        private void OnClick_SaveAllTiff(object sender, EventArgs e)
        {
            ExportAllGumps(ImageFormat.Tiff);
        }

        private void OnClick_SaveAllJpg(object sender, EventArgs e)
        {
            ExportAllGumps(ImageFormat.Jpeg);
        }

        private void OnClick_SaveAllPng(object sender, EventArgs e)
        {
            ExportAllGumps(ImageFormat.Png);
        }

        private void ExportAllGumps(ImageFormat imageFormat)
        {
            string fileExtension = Utils.GetFileExtensionFor(imageFormat);

            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select directory";
                dialog.ShowNewFolderButton = true;
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    int index = int.Parse(listBox.Items[i].ToString());
                    if (index < 0)
                    {
                        continue;
                    }

                    string fileName = Path.Combine(dialog.SelectedPath, $"Gump {index}.{fileExtension}");
                    using (Bitmap bit = new Bitmap(Gumps.GetGump(index)))
                    {
                        bit.Save(fileName, imageFormat);
                    }
                }

                MessageBox.Show($"All Gumps saved to {dialog.SelectedPath}", "Saved", MessageBoxButtons.OK,
                    MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void OnClickShowFreeSlots(object sender, EventArgs e)
        {
            _showFreeSlots = !_showFreeSlots;
            PopulateListBox(!_showFreeSlots);
        }

        private void OnClickPreLoad(object sender, EventArgs e)
        {
            if (PreLoader.IsBusy)
            {
                return;
            }

            ProgressBar.Minimum = 1;
            ProgressBar.Maximum = Gumps.GetCount();
            ProgressBar.Step = 1;
            ProgressBar.Value = 1;
            ProgressBar.Visible = true;
            PreLoader.RunWorkerAsync();
        }

        private void PreLoaderDoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < Gumps.GetCount(); ++i)
            {
                Gumps.GetGump(i);
                PreLoader.ReportProgress(1);
            }
        }

        private void PreLoaderProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressBar.PerformStep();
        }

        private void PreLoaderCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Visible = false;
        }

        internal static void Select(int gumpId)
        {
            if (!_refMarker._loaded)
            {
                _refMarker.OnLoad(EventArgs.Empty);
            }

            _refMarker.Search(gumpId);
        }

        public static bool HasGumpId(int gumpId)
        {
            if (!_refMarker._loaded)
            {
                _refMarker.OnLoad(EventArgs.Empty);
            }

            return _refMarker.listBox.Items.Cast<object>().Any(id => (int)id == gumpId);
        }

        private void JumpToMaleFemale_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex == -1)
            {
                return;
            }

            int gumpId = (int)listBox.SelectedItem;
            gumpId = gumpId < 60000 ? (gumpId % 10000) + 60000 : (gumpId % 10000) + 50000;

            Select(gumpId);
        }

        private GumpSearchForm _showForm;

        private void Search_Click(object sender, EventArgs e)
        {
            if (_showForm?.IsDisposed == false)
            {
                return;
            }

            _showForm = new GumpSearchForm(Search) { TopMost = true };
            _showForm.Show();
        }

        public bool Search(int graphic)
        {
            if (!_refMarker._loaded)
            {
                _refMarker.OnLoad(EventArgs.Empty);
            }

            for (int i = 0; i < _refMarker.listBox.Items.Count; ++i)
            {
                object id = _refMarker.listBox.Items[i];
                if ((int)id != graphic)
                {
                    continue;
                }

                _refMarker.listBox.SelectedIndex = i;
                _refMarker.listBox.TopIndex = i;
                return true;
            }

            return false;
        }

        private void Gump_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.F || !e.Control)
            {
                return;
            }

            Search_Click(sender, e);
            e.SuppressKeyPress = true;
            e.Handled = true;
        }

        private void InsertStartingFromTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (!Utils.ConvertStringToInt(InsertStartingFromTb.Text, out int index, 0, Gumps.GetCount()))
            {
                return;
            }

            contextMenuStrip1.Close();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = true;
                dialog.Title = $"Choose image file to insert at 0x{index:X}";
                dialog.CheckFileExists = true;
                dialog.Filter = "Image files (*.tif;*.tiff;*.bmp)|*.tif;*.tiff;*.bmp";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                var fileCount = dialog.FileNames.Length;
                if (CheckForIndexes(index, fileCount))
                {
                    for (int i = 0; i < fileCount; i++)
                    {
                        var currentIdx = index + i;
                        AddSingleGump(dialog.FileNames[i], currentIdx);
                    }

                    Search(index + (fileCount - 1));
                }
            }

            Options.ChangedUltimaClass["Gumps"] = true;
        }

        /// <summary>
        /// Check if all the indexes from baseIndex to baseIndex + count are valid
        /// </summary>
        /// <param name="baseIndex">Starting Index</param>
        /// <param name="count">Number of the indexes to check.</param>
        /// <returns></returns>
        private bool CheckForIndexes(int baseIndex, int count)
        {
            for (int i = baseIndex; i < baseIndex + count; i++)
            {
                if (i >= Gumps.GetCount() || Gumps.IsValidIndex(i))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Adds a single Gump.
        /// </summary>
        /// <param name="fileName">Filename of the gump to add</param>
        /// <param name="index">Index where the gump shall be added.</param>
        private void AddSingleGump(string fileName, int index)
        {
            using (var bmpTemp = new Bitmap(fileName))
            {
                Bitmap bitmap = new Bitmap(bmpTemp);

                if (fileName.Contains(".bmp"))
                {
                    bitmap = Utils.ConvertBmp(bitmap);
                }

                Gumps.ReplaceGump(index, bitmap);

                ControlEvents.FireGumpChangeEvent(this, index);

                bool done = false;
                for (int i = 0; i < listBox.Items.Count; ++i)
                {
                    int j = int.Parse(listBox.Items[i].ToString());
                    if (j > index)
                    {
                        listBox.Items.Insert(i, index);
                        listBox.SelectedIndex = i;
                        done = true;
                        break;
                    }

                    if (!_showFreeSlots)
                    {
                        continue;
                    }

                    if (j != i)
                    {
                        continue;
                    }

                    done = true;
                    break;
                }

                if (!done)
                {
                    listBox.Items.Add(index);
                    listBox.SelectedIndex = listBox.Items.Count - 1;
                }
            }
        }

        #region Copy clipboard
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (listBox.SelectedIndex != -1)
            {
                int i = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());
                if (Gumps.IsValidIndex(i))
                {
                    Bitmap bmp = Gumps.GetGump(i);
                    if (bmp != null)
                    {
                        Clipboard.SetImage(bmp);
                        MessageBox.Show("The image has been copied to the clipboard!");
                    }
                    else
                    {
                        MessageBox.Show("No image to copy!");
                    }
                }
                else
                {
                    MessageBox.Show("No image to copy!");
                }
            }
            else
            {
                MessageBox.Show("No image to copy!");
            }
        }
        #endregion

        #region Import Import clipboard - Import graphics from clipboard.
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // �berpr�fen, ob die Zwischenablage ein Bild enth�lt
            if (Clipboard.ContainsImage())
            {
                // Retrieve the image from the clipboard
                using (Bitmap bmp = new Bitmap(Clipboard.GetImage()))
                {
                    // Determine the position of the selected graphic in the listBox.
                    int index = int.Parse(listBox.Items[listBox.SelectedIndex].ToString());

                    if (index >= 0 && index < Gumps.GetCount())
                    {
                        // Create a new bitmap with the same size as the image from the clipboard
                        Bitmap newBmp = new Bitmap(bmp.Width, bmp.Height);

                        // Define the colors to ignore
                        Color[] colorsToIgnore = new Color[]
                        {
                    Color.FromArgb(211, 211, 211), // #D3D3D3
                    Color.FromArgb(0, 0, 0),       // #000000
                    Color.FromArgb(255, 255, 255)  // #FFFFFF
                        };

                        // Iterate through each pixel of the image
                        for (int x = 0; x < bmp.Width; x++)
                        {
                            for (int y = 0; y < bmp.Height; y++)
                            {
                                // Get the color of the current pixel
                                Color pixelColor = bmp.GetPixel(x, y);

                                // Check if the color of the current pixel is one of the colors to ignore
                                if (colorsToIgnore.Contains(pixelColor))
                                {
                                    // Set the color of the current pixel to transparent
                                    newBmp.SetPixel(x, y, Color.Transparent);
                                }
                                else
                                {
                                    // Set the color of the current pixel to the color of the original image
                                    newBmp.SetPixel(x, y, pixelColor);
                                }
                            }
                        }

                        // Call the ReplaceGump method with the selected graphic ID and the new bitmap
                        Gumps.ReplaceGump(index, newBmp);
                        ControlEvents.FireGumpChangeEvent(this, index);

                        listBox.Invalidate();
                        ListBox_SelectedIndexChanged(this, EventArgs.Empty);

                        Options.ChangedUltimaClass["Gumps"] = true;
                    }
                    else
                    {
                        MessageBox.Show("Invalid index.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No image in the clipboard.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Import und Export Strg+V and Strg+X
        private void GumpControl_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Ctrl+V key combination has been pressed
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Calling the importToolStripMenuItem_Click method to import the graphic from the clipboard.
                importToolStripMenuItem_Click(sender, e);
            }
            // Checking if the Ctrl+X key combination has been pressed
            else if (e.Control && e.KeyCode == Keys.X)
            {
                // Calling the copyToolStripMenuItem_Click method to import the graphic from the clipboard.
                copyToolStripMenuItem_Click(sender, e);
            }
        }
        #endregion
    }
}