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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using UoFiddler.Controls.Classes;
using UoFiddler.Controls.Helpers;

namespace UoFiddler.Controls.UserControls
{
    public partial class LightControl : UserControl
    {
        public LightControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);

            LandTileText.Text = _landTile.ToString();
            LightTileText.Text = _lightTile.ToString();
        }

        private bool _loaded;
        private int _landTile = 0x3;
        private int _lightTile = 0x0B20;

        /// <summary>
        /// ReLoads if loaded
        /// </summary>
        private void Reload()
        {
            if (_loaded)
            {
                OnLoad(this, EventArgs.Empty);
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (IsAncestorSiteInDesignMode || FormsDesignerHelper.IsInDesignMode())
            {
                return;
            }

            Cursor.Current = Cursors.WaitCursor;
            Options.LoadedUltimaClass["Light"] = true;

            treeView1.BeginUpdate();
            try
            {
                treeView1.Nodes.Clear();
                for (int i = 0; i < Ultima.Light.GetCount(); ++i)
                {
                    if (!Ultima.Light.TestLight(i))
                    {
                        continue;
                    }

                    TreeNode treeNode = new TreeNode(i.ToString())
                    {
                        Tag = i
                    };
                    treeView1.Nodes.Add(treeNode);
                }
            }
            finally
            {
                treeView1.EndUpdate();
            }

            if (treeView1.Nodes.Count > 0)
            {
                treeView1.SelectedNode = treeView1.Nodes[0];
            }

            if (!_loaded)
            {
                ControlEvents.FilePathChangeEvent += OnFilePathChangeEvent;
            }

            _loaded = true;
            Cursor.Current = Cursors.Default;
        }

        private void OnFilePathChangeEvent()
        {
            Reload();
        }
        private unsafe Bitmap GetImage()
        {
            if (treeView1.SelectedNode == null)
            {
                return null;
            }

            if (!iGPreviewToolStripMenuItem.Checked)
            {
                Bitmap image = Ultima.Light.GetLight((int)treeView1.SelectedNode.Tag);
                // Check if the image is valid
                if (image != null && image.Width > 0 && image.Height > 0)
                {
                    return image;
                }
                else
                {
                    // Show an error message if the image is invalid
                    MessageBox.Show("Error: Invalid image!");
                    return null;
                }
            }

            Bitmap bit = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            using (Graphics g = Graphics.FromImage(bit))
            {
                Bitmap background = Ultima.Art.GetLand(_landTile);
                if (background != null)
                {
                    int i = 0;
                    for (int y = -22; y <= bit.Height; y += 22)
                    {
                        int x = i % 2 == 0 ? 0 : -22;
                        for (; x <= bit.Width; x += 44)
                        {
                            g.DrawImage(background, x, y);
                        }
                        ++i;
                    }
                }

                Bitmap lightBit = Ultima.Art.GetStatic(_lightTile);
                if (lightBit != null)
                {
                    g.DrawImage(lightBit, (bit.Width - lightBit.Width) / 2, (bit.Height - lightBit.Height) / 2);
                }
            }

            byte[] light = Ultima.Light.GetRawLight((int)treeView1.SelectedNode.Tag, out int lightWidth, out int lightHeight);

            if (light == null)
            {
                return bit;
            }

            BitmapData bd = bit.LockBits(new Rectangle(0, 0, bit.Width, bit.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* imgPtr = (byte*)bd.Scan0;

            int lightStartX = (bit.Width / 2) - (lightWidth / 2);
            int lightStartY = 30 + (bit.Height / 2) - (lightHeight / 2);

            int lightEndX = lightStartX + lightWidth;
            int lightEndY = lightStartY + lightWidth;

            for (int y = 0; y < bd.Height; ++y)
            {
                for (int x = 0; x < bd.Width; ++x)
                {
                    byte b = *(imgPtr + 0);
                    byte g = *(imgPtr + 1);
                    byte r = *(imgPtr + 2);

                    double lightC = 0;

                    if (x >= lightStartX && x < lightEndX && y >= lightStartY && y < lightEndY)
                    {
                        int offset = ((y - lightStartY) * lightHeight) + (x - lightStartX);
                        if (offset < light.Length)
                        {
                            lightC = light[offset];
                            if (lightC > 31)
                            {
                                lightC = 0;
                            }
                            else
                            {
                                lightC *= 3 / 31D;
                            }
                        }
                    }
                    r /= 3;
                    g /= 3;
                    b /= 3;
                    r += (byte)(r * lightC);
                    g += (byte)(g * lightC);
                    b += (byte)(b * lightC);

                    *imgPtr++ = b;
                    *imgPtr++ = g;
                    *imgPtr++ = r;
                }
                imgPtr += bd.Stride - (bd.Width * 3);
            }
            bit.UnlockBits(bd);

            return bit;
        }

        private void AfterSelect(object sender, TreeViewEventArgs e)
        {
            pictureBox1.Image?.Dispose();
            // Get the image from the GetImage method
            Bitmap image = GetImage();
            // Check if the image is valid
            if (image != null && image.Width > 0 && image.Height > 0)
            {
                // Display the image in the pictureBox1
                pictureBox1.Image = image;
            }
            else
            {
                // Show an error message if the image is invalid
                MessageBox.Show("Error: Invalid image!");
            }
        }

        private void OnClickRemove(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }

            int i = (int)treeView1.SelectedNode.Tag;
            DialogResult result = MessageBox.Show(string.Format("Are you sure to remove {0} (0x{0:X})", i), "Remove",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (result != DialogResult.Yes)
            {
                return;
            }

            Ultima.Light.Remove(i);
            treeView1.Nodes.Remove(treeView1.SelectedNode);
            treeView1.Invalidate();
            Options.ChangedUltimaClass["Light"] = true;
        }

        private void OnClickReplace(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
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

                    int i = (int)treeView1.SelectedNode.Tag;

                    Ultima.Light.Replace(i, bitmap);

                    treeView1.Invalidate();
                    AfterSelect(this, null);

                    Options.ChangedUltimaClass["Light"] = true;
                }
            }
        }

        private void OnTextChangedInsert(object sender, EventArgs e)
        {
            if (Utils.ConvertStringToInt(InsertText.Text, out int index, 0, 99))
            {
                InsertText.ForeColor = Ultima.Light.TestLight(index) ? Color.Red : Color.Black;
            }
            else
            {
                InsertText.ForeColor = Color.Red;
            }
        }

        private void OnKeyDownInsert(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (!Utils.ConvertStringToInt(InsertText.Text, out int index, 0, 99))
            {
                return;
            }

            if (Ultima.Light.TestLight(index))
            {
                return;
            }

            contextMenuStrip1.Close();
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.Title = string.Format("Choose image file to insert at {0} (0x{0:X})", index);
                dialog.CheckFileExists = true;
                dialog.Filter = "Image files (*.tif;*.tiff;*.bmp)|*.tif;*.tiff;*.bmp";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                Bitmap bmp = new Bitmap(dialog.FileName);
                Ultima.Light.Replace(index, bmp);
                TreeNode treeNode = new TreeNode(index.ToString())
                {
                    Tag = index
                };
                bool done = false;
                foreach (TreeNode node in treeView1.Nodes)
                {
                    if ((int)node.Tag <= index)
                    {
                        continue;
                    }

                    treeView1.Nodes.Insert(node.Index, treeNode);
                    done = true;
                    break;
                }
                if (!done)
                {
                    treeView1.Nodes.Add(treeNode);
                }

                treeView1.Invalidate();
                treeView1.SelectedNode = treeNode;
                Options.ChangedUltimaClass["Light"] = true;
            }
        }

        private void OnClickSave(object sender, EventArgs e)
        {
            Ultima.Light.Save(Options.OutputPath);
            MessageBox.Show($"Saved to {Options.OutputPath}", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
            Options.ChangedUltimaClass["Light"] = false;
        }

        private void OnClickExportBmp(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }

            string path = Options.OutputPath;
            int i = (int)treeView1.SelectedNode.Tag;
            string fileName = Path.Combine(path, $"Light {i}.bmp");
            Ultima.Light.GetLight(i).Save(fileName, ImageFormat.Bmp);
            MessageBox.Show($"Light saved to {fileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void OnClickExportTiff(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }

            string path = Options.OutputPath;
            int i = (int)treeView1.SelectedNode.Tag;
            string fileName = Path.Combine(path, $"Light {i}.tiff");
            Ultima.Light.GetLight(i).Save(fileName, ImageFormat.Tiff);
            MessageBox.Show($"Light saved to {fileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void OnClickExportJpg(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode == null)
            {
                return;
            }

            string path = Options.OutputPath;
            int i = (int)treeView1.SelectedNode.Tag;
            string fileName = Path.Combine(path, $"Light {i}.jpg");
            Ultima.Light.GetLight(i).Save(fileName, ImageFormat.Jpeg);
            MessageBox.Show($"Light saved to {fileName}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void IgPreviewClicked(object sender, EventArgs e)
        {
            iGPreviewToolStripMenuItem.Checked = !iGPreviewToolStripMenuItem.Checked;
            pictureBox1.Image = GetImage();
        }

        private void OnPictureSizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Image = GetImage();
        }

        private void LandTileTextChanged(object sender, EventArgs e)
        {
            if (!_loaded)
            {
                return;
            }

            if (Utils.ConvertStringToInt(LandTileText.Text, out int index, 0, 0x3FFF))
            {
                LandTileText.ForeColor = !Ultima.Art.IsValidLand(index) ? Color.Red : Color.Black;
            }
            else
            {
                LandTileText.ForeColor = Color.Red;
            }
        }

        private void LandTileKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            if (!Utils.ConvertStringToInt(LandTileText.Text, out int index, 0, 0x3FFF))
            {
                return;
            }

            if (!Ultima.Art.IsValidLand(index))
            {
                return;
            }

            contextMenuStrip2.Close();
            _landTile = index;
            pictureBox1.Image = GetImage();
        }

        private void LightTileTextChanged(object sender, EventArgs e)
        {
            if (!_loaded)
            {
                return;
            }

            if (Utils.ConvertStringToInt(LightTileText.Text, out int index, 0, Ultima.Art.GetMaxItemId()))
            {
                LightTileText.ForeColor = !Ultima.Art.IsValidStatic(index) ? Color.Red : Color.Black;
            }
            else
            {
                LightTileText.ForeColor = Color.Red;
            }
        }

        private void LightTileKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Utils.ConvertStringToInt(LightTileText.Text, out int index, 0, Ultima.Art.GetMaxItemId()))
                {
                    if (!Ultima.Art.IsValidStatic(index))
                    {
                        return;
                    }

                    contextMenuStrip2.Close();
                    _lightTile = index;
                    pictureBox1.Image = GetImage();
                }
            }
        }

        #region Copy Clipbord     
        // Aktuelle
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if an item is selected in the treeView1
            if (treeView1.SelectedNode == null)
            {
                MessageBox.Show("Please select an item first.");
                return;
            }

            // Get the selected item
            int selectedIndex = (int)treeView1.SelectedNode.Tag;
            // Get the bitmap for the selected item
            Bitmap bitmap = Ultima.Light.GetLight(selectedIndex);
            // Check if the bitmap exists
            if (bitmap != null)
            {
                // Change the color #D3D3D3 to #FFFFFF
                for (int x = 0; x < bitmap.Width; x++)
                {
                    for (int y = 0; y < bitmap.Height; y++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        if (pixelColor.R == 211 && pixelColor.G == 211 && pixelColor.B == 211)
                        {
                            bitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        }
                    }
                }

                // Convert the image to a 16-bit color depth
                Bitmap bmp16bit = new Bitmap(bitmap.Width, bitmap.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb555);
                using (Graphics g = Graphics.FromImage(bmp16bit))
                {
                    g.DrawImage(bitmap, new Rectangle(0, 0, bmp16bit.Width, bmp16bit.Height));
                }

                // Copy the graphic to the clipboard
                Clipboard.SetImage(bmp16bit);
                MessageBox.Show("The image has been copied to the clipboard!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Show a MessageBox to inform the user that the image was successfully copied
                MessageBox.Show("No image to copy!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Import Clipborad 
        /*private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Retrieve the image from the clipboard
            if (Clipboard.ContainsImage())
            {
                Bitmap clipboardImage = new Bitmap(Clipboard.GetImage());

                // Check if an item is selected in the treeView1
                if (treeView1.SelectedNode != null)
                {
                    // Get the selected item
                    int index = (int)treeView1.SelectedNode.Tag;

                    // Define the colors to replace
                    Dictionary<Color, Color> colorsToReplace = new Dictionary<Color, Color>
            {
                { Color.FromArgb(211, 211, 211), Color.FromArgb(255, 255, 255) }, // Replace #D3D3D3 with #ffffff
                { Color.FromArgb(255, 255, 247), Color.FromArgb(255, 255, 255) }  // Replace #fffff7 with #ffffff
            };

                    // Iterate through each pixel of the image
                    for (int x = 0; x < clipboardImage.Width; x++)
                    {
                        for (int y = 0; y < clipboardImage.Height; y++)
                        {
                            // Get the color of the current pixel
                            Color pixelColor = clipboardImage.GetPixel(x, y);

                            // Check if the color of the current pixel is one of the colors to replace
                            if (colorsToReplace.ContainsKey(pixelColor))
                            {
                                // Set the color of the current pixel to the replacement color
                                clipboardImage.SetPixel(x, y, colorsToReplace[pixelColor]);
                            }
                        }
                    }

                    // Save the image from the clipboard to a temporary file in BMP format
                    string tempFile = Path.GetTempFileName();
                    clipboardImage.Save(tempFile, ImageFormat.Bmp);

                    // Load the image from the temporary file
                    Bitmap bmp = new Bitmap(tempFile);

                    // Convert the image to 16-bit
                    Bitmap newBmp = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format16bppRgb565);

                    // Replace the selected image with the image from the clipboard
                    Ultima.Light.Replace(index, newBmp);

                    // Refresh the image in the pictureBox1
                    pictureBox1.Image = GetImage();

                    // Show a MessageBox to inform the user that the image was successfully imported
                    MessageBox.Show("Image imported successfully!");
                }
            }
        }*/
        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Retrieve the image from the clipboard
            if (Clipboard.ContainsImage())
            {
                Bitmap clipboardImage = new Bitmap(Clipboard.GetImage());

                // Check if the text in the InsertText2 control can be converted to an integer
                if (Utils.ConvertStringToInt(InsertText2.Text, out int index, 0, 99))
                {
                    // Define the colors to replace
                    Dictionary<Color, Color> colorsToReplace = new Dictionary<Color, Color>
            {
                { Color.FromArgb(211, 211, 211), Color.FromArgb(255, 255, 255) }, // Replace #D3D3D3 with #ffffff
                { Color.FromArgb(255, 255, 247), Color.FromArgb(255, 255, 255) }  // Replace #fffff7 with #ffffff
            };

                    // Iterate through each pixel of the image
                    for (int x = 0; x < clipboardImage.Width; x++)
                    {
                        for (int y = 0; y < clipboardImage.Height; y++)
                        {
                            // Get the color of the current pixel
                            Color pixelColor = clipboardImage.GetPixel(x, y);

                            // Check if the color of the current pixel is one of the colors to replace
                            if (colorsToReplace.ContainsKey(pixelColor))
                            {
                                // Set the color of the current pixel to the replacement color
                                clipboardImage.SetPixel(x, y, colorsToReplace[pixelColor]);
                            }
                        }
                    }

                    // Save the image from the clipboard to a temporary file in BMP format
                    string tempFile = Path.GetTempFileName();
                    clipboardImage.Save(tempFile, ImageFormat.Bmp);

                    // Load the image from the temporary file
                    Bitmap bmp = new Bitmap(tempFile);

                    // Convert the image to 16-bit
                    Bitmap newBmp = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), PixelFormat.Format16bppRgb565);

                    // Replace the selected image with the image from the clipboard
                    Ultima.Light.Replace(index, newBmp);

                    // Refresh the image in the pictureBox1
                    pictureBox1.Image = GetImage();

                    // Show a MessageBox to inform the user that the image was successfully imported
                    MessageBox.Show("Image imported successfully!");
                }
            }
        }

        private void InsertText2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the key pressed is not a control key and not a digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Set the Handled property to true to cancel the key press
                e.Handled = true;
            }
        }

        private void InsertText2_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the key pressed is the Enter key
            if (e.KeyCode == Keys.Enter)
            {
                // Call the importToolStripMenuItem_Click method
                importToolStripMenuItem_Click(sender, e);
            }
        }

        private void InsertText2_Click(object sender, EventArgs e)
        {
            // Call the importToolStripMenuItem_Click method
            importToolStripMenuItem_Click(sender, e);
        }


        #endregion
    }
}
