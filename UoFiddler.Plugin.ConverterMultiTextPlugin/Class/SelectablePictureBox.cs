using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Class
{
    internal class SelectablePictureBox : PictureBox
    {
        private bool isDrawing = false;
        private List<Point> points = new List<Point>();
        private Color drawingColor = Color.Black;
        private int brushSize = 1;
        private Bitmap[] drawingBitmaps = new Bitmap[10]; // An array of bitmaps containing 10 images
        private int currentIndex = 0; // Define currentIndex as an instance variable
        private Rectangle selectionRectangle; //Draws the rectangle

        public SelectablePictureBox()
        {
            this.SetStyle(ControlStyles.Selectable | ControlStyles.UserMouse, true);
            this.TabStop = true;

            ContextMenuStrip contextMenu = new ContextMenuStrip();
            ToolStripMenuItem loadItem = new ToolStripMenuItem("Load Image Drive");
            ToolStripMenuItem pasteItem = new ToolStripMenuItem("Paste from clipboard");
            ToolStripSeparator separator = new ToolStripSeparator();
            ToolStripMenuItem saveItem = new ToolStripMenuItem("save Image Drive");
            ToolStripMenuItem copyItem = new ToolStripMenuItem("Copy image Clipbord");
            ToolStripSeparator separator1 = new ToolStripSeparator();
            ToolStripMenuItem clearItem = new ToolStripMenuItem("Empty Picturebox");
            ToolStripMenuItem drawItem = new ToolStripMenuItem("Activate drawing");
            ToolStripMenuItem mirrorItem = new ToolStripMenuItem("Mirror image");
            ToolStripMenuItem selectionRectangleItem = new ToolStripMenuItem("selection rectangle");
            ToolStripSeparator separator2 = new ToolStripSeparator();

            // Adding a new option to select the active image
            ToolStripMenuItem selectItem = new ToolStripMenuItem("choose picture");
            for (int i = 0; i < drawingBitmaps.Length; i++)
            {
                var item = new ToolStripMenuItem($"Picture {i + 1}");
                item.Click += (sender, e) => SelectImage(i);
                selectItem.DropDownItems.Add(item);
            }

            drawItem.Click += (sender, e) =>
            {
                isDrawing = !isDrawing;
                if (isDrawing)
                {
                    drawItem.Text = "Deactivate drawing";
                }
                else
                {
                    drawItem.Text = "Activate drawing";
                }
            };

            contextMenu.Items.Add(loadItem);
            contextMenu.Items.Add(pasteItem);
            contextMenu.Items.Add(separator); //Separator
            contextMenu.Items.Add(saveItem);
            contextMenu.Items.Add(copyItem);
            contextMenu.Items.Add(separator1);
            contextMenu.Items.Add(clearItem);
            contextMenu.Items.Add(drawItem);
            contextMenu.Items.Add(selectionRectangleItem);
            contextMenu.Items.Add(mirrorItem);
            contextMenu.Items.Add(separator2);            
            contextMenu.Items.Add(selectItem);
            

            loadItem.Click += (sender, e) => LoadImage();
            pasteItem.Click += (sender, e) => PasteImage();
            saveItem.Click += (sender, e) => SaveImage();
            drawItem.Click += (sender, e) => isDrawing = !isDrawing;
            mirrorItem.Click += (sender, e) => MirrorImage();
            selectionRectangleItem.Click += (sender, e) => DrawSelectionRectangleAndInsertImage();
            copyItem.Click += (sender, e) => CopyImage();
            clearItem.Click += (sender, e) => ClearImage();


            this.ContextMenuStrip = contextMenu;

            //this.MouseClick += (sender, e) => LoadImage();                        

            this.MouseDown += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        // Start drawing the selection rectangle
                        isDrawing = false;
                        points.Clear();
                        points.Add(e.Location);
                    }
                    else
                    {
                        isDrawing = true;
                        points.Add(e.Location);

                        if (drawingBitmaps[currentIndex] == null && Image != null)
                        {
                            drawingBitmaps[currentIndex] = new Bitmap(Image);

                            if (drawingBitmaps[currentIndex] == null)
                            {
                                MessageBox.Show("Fehler beim Kopieren des Bildes.");
                            }
                        }
                    }
                }
            };

            this.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    isDrawing = Control.ModifierKeys == Keys.Control;
                }
                points.Clear();
            };


            this.MouseUp += (sender, e) =>
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (Control.ModifierKeys == Keys.Control)
                    {
                        // Stop drawing the selection rectangle
                        isDrawing = true;
                    }
                    else
                    {
                        isDrawing = false;
                    }
                }
                points.Clear();
            };
            
            this.MouseMove += (sender, e) =>
            {
                if (isDrawing && Image != null && e.X < Image.Width && e.Y < Image.Height)
                {
                    points.Add(e.Location);

                    if (drawingBitmaps[currentIndex] != null)
                    {
                        using (Graphics g = Graphics.FromImage(drawingBitmaps[currentIndex]))
                        {
                            if (points.Count > 1)
                            {
                                using (Pen pen = new Pen(drawingColor, brushSize))
                                {
                                    g.DrawLines(pen, points.ToArray());
                                }

                                // Creating a copy of the original image
                                Bitmap newImage = new Bitmap(Image);

                                // Draw on the drawn picture on top of the original picture
                                using (Graphics g2 = Graphics.FromImage(newImage))
                                {
                                    g2.DrawImage(drawingBitmaps[currentIndex], 0, 0);
                                }

                                // Set the new image as the image of the PictureBox
                                this.Image = newImage;

                                Refresh();
                            }
                        }
                    }
                }
                else if (!isDrawing && Control.ModifierKeys == Keys.Control)
                {
                    // Update the selection rectangle
                    points.Add(e.Location);
                    selectionRectangle = new Rectangle(points[0], new Size(e.X - points[0].X, e.Y - points[0].Y));
                    this.Invalidate();  // Forces the PictureBox to redraw
                }
            };


            this.Paint += (sender, e) =>
            {
                if (isDrawing && points.Count > 1)
                {
                    using (Pen pen = new Pen(drawingColor, brushSize))
                    {
                        e.Graphics.DrawLines(pen, points.ToArray());
                    }
                }
                else if (!isDrawing && Control.ModifierKeys == Keys.Control)
                {
                    // Draw the selection rectangle
                    using (Pen pen = new Pen(Color.Yellow))
                    {
                        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        e.Graphics.DrawRectangle(pen, selectionRectangle);
                    }
                }
            };

            this.MouseLeave += (sender, e) =>
            {
                // Empty the points list when the mouse leaves the PictureBox
                points.Clear();
            };
        }

        #region LoadImage
        private void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog.Title = "Please select an image file.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                this.Image = image;
                drawingBitmaps[currentIndex] = new Bitmap(image.Width, image.Height);
            }
        }
        #endregion

        #region DrawSelevtRectangleAndInsertImage

        private void DrawSelectionRectangleAndInsertImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog.Title = "Please select an image file.";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image insertedImage = Image.FromFile(openFileDialog.FileName);

                if (this.Image != null)
                {
                    Bitmap bitmap = new Bitmap(this.Image);

                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        // Paste the image inside the selection rectangle
                        g.DrawImage(insertedImage, selectionRectangle);
                    }

                    this.Image = bitmap;
                }
            }
        }
        #endregion

        #region OnPictureBoxSelected
        private void OnPictureBoxSelected(int index)
        {
            currentIndex = index; // Set currentIndex to the index of the selected PictureBox
        }
        #endregion

        #region MouseDown
        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            base.OnMouseDown(e);
        }
        #endregion

        #region IsInputKey
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            return base.IsInputKey(keyData);
        }
        #endregion

        #region OnEnter
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        #endregion

        #region OnLeave
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        #endregion

        #region Painting
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
            if (drawingBitmaps[currentIndex] != null) // If a drawn image exists
            {
                pe.Graphics.DrawImage(drawingBitmaps[currentIndex], 0, 0); // Draw the drawn picture
            }
            else if (this.Image != null) // If no drawn image exists
            {
                pe.Graphics.DrawImage(this.Image, 0, 0); // Draw the original image
            }
        }
        #endregion

        #region OnPreviewKeyDown
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Control && e.KeyCode == Keys.X)
            {
                if (isDrawing && drawingBitmaps[currentIndex] != null) // Use the current bitmap
                {
                    Clipboard.SetImage(drawingBitmaps[currentIndex]);
                }
                else if (this.Image != null)
                {
                    Clipboard.SetImage(this.Image);
                }
                else
                {
                    MessageBox.Show("There is no image to copy.");
                }
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                if (Clipboard.ContainsImage())
                {
                    Image image = Clipboard.GetImage();
                    this.Image = image;
                    drawingBitmaps[currentIndex] = new Bitmap(image.Width, image.Height);
                }
                else
                {
                    MessageBox.Show("The clipboard does not contain an image.");
                }
            }
        }
        #endregion

        #region Set Color
        public void SetDrawingColor(Color color)
        {
            drawingColor = color;
        }
        #endregion

        #region Set Brush Size
        public void SetBrushSize(int size)
        {
            brushSize = size;
        }
        #endregion

        #region GetTransparentImage
        public Bitmap GetTransparentImage()
        {
            if (this.Image == null)
            {
                return null;
            }

            // Convert the image to a bitmap
            Bitmap bitmap = new Bitmap(this.Image);

            // Define the colors you want to make transparent
            Color[] colorsToMakeTransparent = new Color[]
            {
                Color.FromArgb(0, 0, 0),      // Black
                Color.FromArgb(255, 255, 255),// White
                Color.FromArgb(211, 211, 211) // Light gray (d3d3d3 in RGB)
            };

            // Make every color in the image transparent
            foreach (Color color in colorsToMakeTransparent)
            {
                bitmap = MakeTransparent(bitmap, color);
            }

            return bitmap;
        }
        #endregion

        #region Toggle Drawing
        public void ToggleDrawing()
        {
            isDrawing = !isDrawing;
        }
        #endregion

        #region SaveImage
        private void SaveImage()
        {
            if (drawingBitmaps[currentIndex] != null)
            {
                // Make a copy of the original image
                Bitmap newImage = new Bitmap(Image);

                // Draw the drawn image on top of the original image
                using (Graphics g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(drawingBitmaps[currentIndex], 0, 0);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bitmap Image|*.bmp|JPEG Image|*.jpg|GIF Image|*.gif|PNG Image|*.png";
                saveFileDialog.Title = "Please select a location to save the image.";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (MemoryStream memory = new MemoryStream())
                    {
                        switch (saveFileDialog.FilterIndex)
                        {
                            case 1:
                                newImage.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                                break;
                            case 2:
                                newImage.Save(memory, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            case 3:
                                newImage.Save(memory, System.Drawing.Imaging.ImageFormat.Gif);
                                break;
                            case 4:
                                newImage.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                        }
                        using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                        {
                            memory.WriteTo(fs);
                        }
                    }
                }
            }
        }
        #endregion

        #region paste Image
        private void PasteImage()
        {
            if (Clipboard.ContainsImage())
            {
                Image image = Clipboard.GetImage();
                this.Image = image;
                drawingBitmaps[currentIndex] = new Bitmap(image.Width, image.Height);
            }
            else
            {
                MessageBox.Show("The clipboard does not contain an image.");
            }
        }
        #endregion

        #region Copy image
        private void CopyImage()
        {
            if (isDrawing && drawingBitmaps[currentIndex] != null) // Use the current bitmap
            {
                Clipboard.SetImage(drawingBitmaps[currentIndex]);
            }
            else if (this.Image != null)
            {
                Clipboard.SetImage(this.Image);
            }
            else
            {
                MessageBox.Show("There is no image to copy.");
            }
        }
        #endregion
        // A new way to select the active image
        #region SelectImage
        private void SelectImage(int index)
        {
            if (index >= 0 && index < drawingBitmaps.Length)
            {
                currentIndex = index;

                if (drawingBitmaps[currentIndex] != null)
                    this.Image = drawingBitmaps[currentIndex];
            }
            else
            {
                // Handle the error case here
            }
        }
        #endregion
        #region Clear Image
        public void ClearImage()
        {
            this.Image = null;
            if (drawingBitmaps[currentIndex] != null)
            {
                drawingBitmaps[currentIndex].Dispose();
                drawingBitmaps[currentIndex] = null;
            }
        }
        #endregion

        #region Public IsDrawing
        public bool IsDrawing()
        {
            return isDrawing;
        }
        #endregion
        #region Mirror 
        private void MirrorImage()
        {
            if (this.Image != null)
            {
                this.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                this.Invalidate(); // Forces the control to be redrawn
            }
        }
        #endregion

        #region Make Transparent
        private Bitmap MakeTransparent(Bitmap original, Color color)
        {
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    Color originalColor = original.GetPixel(i, j);
                    if (originalColor == color)
                    {
                        newBitmap.SetPixel(i, j, Color.Transparent);
                    }
                    else
                    {
                        newBitmap.SetPixel(i, j, originalColor);
                    }
                }
            }
            return newBitmap;
        }
        #endregion

        #region GetPixelColor
        public Color GetPixelColor(Point location)
        {
            if (this.Image != null && location.X < this.Image.Width && location.Y < this.Image.Height)
            {
                // Create a bitmap from the image and get the color at the specified position
                Bitmap bitmap = new Bitmap(this.Image);
                return bitmap.GetPixel(location.X, location.Y);
            }
            return Color.Transparent;
        }
        #endregion
    }
}
