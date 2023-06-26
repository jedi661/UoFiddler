using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Microsoft.Win32;
using Ultima;
using System.Drawing.Drawing2D;


namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Forms
{
    public partial class GraphicCutterForm : Form
    {
        private Bitmap image;
        private bool showGrid = true;

        private bool showBorder = true;

        private int imageX = 0;
        private int imageY = 0;

        private int moveX = 0;
        private int moveY = 0;

        //PictureBox2
        private Point startPoint;
        private Rectangle cropArea;
        private bool isDragging = false;
        private bool showGrid2 = false;
        private Rectangle selectedRectangle; // Der ausgewählte Bereich

        public GraphicCutterForm()
        {
            InitializeComponent();

            // Verknüpfen Sie das MouseMove-Ereignis der PictureBox1 mit dem Ereignishandler
            pictureBox1.MouseMove += pictureBox2_MouseMove;

            // Setze die Werte in den TextBoxen
            textBoxWidth.Text = "44";
            textBoxHeight.Text = "105";
            textBoxStartX.Text = "174";
            textBoxStartY.Text = "247";

            // Set KeyPreview to true to allow the form to receive keyboard input
            this.KeyPreview = true;

            // Link the KeyDown event of the form to the event handler
            this.KeyDown += Form1_KeyDown;

            // Rufe die CropImage-Methode auf
            CropImage();

            // Link the Click event of each button to the event handler
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
            button4.Click += button4_Click;

            // Link the Click event of the ToolStripMenuItem to the event handler
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;

            // Set the default selected item
            toolStripComboBox1.SelectedIndex = 0;

            label1.Text = "";

            // Register the Paint event handler for the PictureBox2 control.
            pictureBox2.Paint += pictureBox3_Paint;

        }

        // Keys to Textbox
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check which key was pressed
            switch (e.KeyCode)
            {
                case Keys.Up:
                    // Increase the value in the textBoxStartY
                    textBoxStartY.Text = (int.Parse(textBoxStartY.Text) + 1).ToString();
                    break;
                case Keys.Down:
                    // Decrease the value in the textBoxStartY
                    textBoxStartY.Text = (int.Parse(textBoxStartY.Text) - 1).ToString();
                    break;
                case Keys.Left:
                    // Decrease the value in the textBoxStartX
                    textBoxStartX.Text = (int.Parse(textBoxStartX.Text) - 1).ToString();
                    break;
                case Keys.Right:
                    // Increase the value in the textBoxStartX
                    textBoxStartX.Text = (int.Parse(textBoxStartX.Text) + 1).ToString();
                    break;
            }
        }

        //Disables character input.
        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is a number.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Discard the input.
                e.Handled = true;
            }
        }

        #region Opendialog

        private void openImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    image = new Bitmap(openFileDialog.FileName);
                    pictureBox1.Image = image;
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;

                    // Display the image in PictureBox2 as well.
                    pictureBox2.Image = image;
                    pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;

                    pictureBox1.Refresh(); // Display a new image.

                    // Set the position of the image in PictureBox1.
                    SetImagePosition(0, 0);

                    // Set the values in the text boxes.
                    textBoxWidth.Text = image.Width.ToString();
                    textBoxHeight.Text = image.Height.ToString();
                    textBoxStartX.Text = ((pictureBox1.Width - image.Width) / 2).ToString();
                    textBoxStartY.Text = (pictureBox1.Height - image.Height).ToString();
                }
            }
        }

        #endregion

        #region  Picture Paint
        //Paint Grid
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Check if the grid should be displayed.
            if (showGrid)
            {
                int kachelBreite = 32; // Tile width.
                int gridSize = 8; // Number of tiles.
                float scaleFactor = 250f / (gridSize * kachelBreite);
                Pen pen = new Pen(Color.Red, 1f);
                Brush brush = new SolidBrush(Color.Black);

                // Calculate grid size.
                int gridSizeInPixels = gridSize * kachelBreite;

                int dx = 0; // Move the graphics 10 pixels to the right.
                int dy = -178; // Move the graphics 20 pixels upwards.

                // Move the origin to the center of the PictureBox.
                e.Graphics.TranslateTransform(pictureBox1.Width / 2 + dx, pictureBox1.Height / 2 + dy);

                // Scale the graphics.
                e.Graphics.ScaleTransform(scaleFactor, scaleFactor);

                // Rotate the graphics by 45 degrees.
                e.Graphics.RotateTransform(45);

                for (int i = gridSize; i >= 0; i--)
                {
                    // Draw horizontal lines.
                    e.Graphics.DrawLine(pen, new Point(0, i * kachelBreite), new Point(gridSize * kachelBreite, i * kachelBreite));

                    // Draw vertical lines.
                    e.Graphics.DrawLine(pen, new Point(i * kachelBreite, 0), new Point(i * kachelBreite, gridSize * kachelBreite));
                }
            }
        }

        #endregion

        #region Move
        private void MoveImage(int dx, int dy)
        {
            if (image != null)
            {
                Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.Clear(Color.Transparent);
                    imageX += dx;
                    imageY += dy;

                    // Calculate the position to center the image
                    int x = (canvas.Width - image.Width) / 2 + imageX;
                    int y = canvas.Height - image.Height + imageY;

                    // Make sure the image stays within the bounds of the picture box
                    x = Math.Max(x, 0);
                    x = Math.Min(x, canvas.Width - image.Width);
                    y = Math.Max(y, 0);
                    y = Math.Min(y, canvas.Height - image.Height);

                    // Update the imageX and imageY values
                    imageX = x - (canvas.Width - image.Width) / 2;
                    imageY = y - (canvas.Height - image.Height);

                    g.DrawImage(image, x, y);

                    // Draw a border around the image if showBorder is true
                    if (showBorder)
                    {
                        using (Pen borderPen = new Pen(Color.Red))
                        {
                            g.DrawRectangle(borderPen, x, y, image.Width, image.Height);
                        }
                    }

                    // Update the values in the text boxes
                    textBoxStartX.Text = x.ToString();
                    textBoxStartY.Text = y.ToString();

                    // Update the coordinates in the label
                    label1.Text = "X: " + x + ", Y: " + y;
                }
                pictureBox1.Image = canvas;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveImage(0, -1);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveImage(0, 1);
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            MoveImage(-1, 0);
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveImage(1, 0);
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            // Bewegen Sie das Bild in die gewünschte Richtung
            MoveImage(moveX, moveY);
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            // Setzen Sie die Bewegungsrichtung
            moveX = 0;
            moveY = -1;
            // Starten Sie den Timer
            moveTimer.Start();
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            // Stoppen Sie den Timer
            moveTimer.Stop();
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            // Setzen Sie die Bewegungsrichtung
            moveX = 0;
            moveY = 1;
            // Starten Sie den Timer
            moveTimer.Start();
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            // Stoppen Sie den Timer
            moveTimer.Stop();
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            // Setzen Sie die Bewegungsrichtung
            moveX = -1;
            moveY = 0;
            // Starten Sie den Timer
            moveTimer.Start();
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            // Stoppen Sie den Timer
            moveTimer.Stop();
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            // Setzen Sie die Bewegungsrichtung
            moveX = 1;
            moveY = 0;
            // Starten Sie den Timer
            moveTimer.Start();
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            // Stoppen Sie den Timer
            moveTimer.Stop();
        }
        #endregion

        #region Position

        private void SetImagePosition(int x, int y)
        {
            if (image != null)
            {
                Bitmap canvas = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics g = Graphics.FromImage(canvas))
                {
                    g.Clear(Color.Transparent);
                    imageX = x;
                    imageY = y;
                    // Calculate the position to center the image
                    int xPos = (canvas.Width - image.Width) / 2 + imageX;
                    int yPos = canvas.Height - image.Height + imageY;
                    // Make sure the image stays within the bounds of the picture box
                    xPos = Math.Max(xPos, 0);
                    xPos = Math.Min(xPos, canvas.Width - image.Width);
                    yPos = Math.Max(yPos, 0);
                    yPos = Math.Min(yPos, canvas.Height - image.Height);
                    g.DrawImage(image, xPos, yPos);
                }
                pictureBox1.Image = canvas;
                pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Increase the value in the textBoxStartY
            textBoxStartY.Text = (int.Parse(textBoxStartY.Text) + 1).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Decrease the value in the textBoxStartY
            textBoxStartY.Text = (int.Parse(textBoxStartY.Text) - 1).ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Decrease the value in the textBoxStartX
            textBoxStartX.Text = (int.Parse(textBoxStartX.Text) - 1).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Increase the value in the textBoxStartX
            textBoxStartX.Text = (int.Parse(textBoxStartX.Text) + 1).ToString();
        }



        #endregion

        #region Paint 
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is pressed.
            if (e.Button == MouseButtons.Left)
            {
                // Set the starting point of the crop.
                startPoint = e.Location;
                isDragging = true;
            }
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button is pressed and the user is dragging the mouse.
            if (e.Button == MouseButtons.Left && isDragging)
            {
                // Calculate the size of the cropping area.
                int width = e.X - startPoint.X;
                int height = e.Y - startPoint.Y;

                // Set the size of the cropping area.
                textBoxWidth.Text = width.ToString();
                textBoxHeight.Text = height.ToString();

                // Set the starting point of the crop.
                textBoxStartX.Text = startPoint.X.ToString();
                textBoxStartY.Text = startPoint.Y.ToString();

                // Update the cropping area.
                cropArea = new Rectangle(startPoint.X, startPoint.Y, width, height);

                // Redraw the PictureBox to show the cropping area.
                pictureBox2.Invalidate();
            }
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            // Check if the left mouse button has been released.
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            // Draw a dashed line around the cropping area.
            using (Pen pen = new Pen(Color.Yellow))
            {
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, cropArea);
            }
        }
        #endregion

        #region funktions Menu
        //Create a screenshot image.
        private void PaintGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hide the grid.
            // showGrid = false;

            // Update the PictureBox1.
            pictureBox1.Invalidate();
            pictureBox1.Update();

            // Check if an image is loaded in the pictureBox1
            if (pictureBox1.Image != null)
            {
                // Create a screenshot of the current pictureBox1
                Bitmap screenshot = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(screenshot, new Rectangle(0, 0, screenshot.Width, screenshot.Height));

                // Set the screenshot as the image of the pictureBox1
                pictureBox1.Image = screenshot;
            }

            // Call the CropImage method
            CropImage();
        }

        // Mouse cursor.
        private void ChangeCursorToCross()
        {
            // Change the mouse cursor to a crosshair.
            pictureBox2.Cursor = Cursors.Cross;
        }

        // Color Black and White
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check the current background color of the PictureBox
            if (pictureBox1.BackColor == Color.FromArgb(0, 0, 0))
            {
                // If the current background color is black, change it to white.
                pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                // Otherwise, change the background color to black.
                pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
            }
        }

        //Mirror
        private void spiegelnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                // Mirror the image horizontally.
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Set the mirrored image as the new image of the PictureBox.
                pictureBox1.Image = image;

                // Keep the current position of the image.
                SetImagePosition(imageX, imageY);

                // Update the image in the PictureBox.
                pictureBox1.Refresh();
            }
        }

        // Color
        private void toolStripTextBoxColors_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if the Enter key was pressed.
            if (e.KeyCode == Keys.Enter)
            {
                // Try to interpret the entered text as a color code.
                try
                {
                    // Remove the '#' from the entered text, if present.
                    string colorCode = toolStripTextBoxColors.Text.TrimStart('#');

                    // Check if the color code is 6 characters long.
                    if (colorCode.Length == 6)
                    {
                        // Convert the color code to a color.
                        int argb = Int32.Parse(colorCode, System.Globalization.NumberStyles.HexNumber);
                        Color color = Color.FromArgb(255, Color.FromArgb(argb));

                        // Set the background color of the PictureBox.
                        pictureBox1.BackColor = color;
                    }
                    else
                    {
                        // Display an error message if the entered text is not a valid color code.
                        MessageBox.Show("Please enter a valid 6-digit color code. Example: FF0000 for red.", "Invalid color code.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    // Zeigen Sie eine Fehlermeldung an, wenn der eingegebene Text kein gültiger Farbcode ist
                    MessageBox.Show("Please enter a valid 6-digit color code. Example: FF0000 for red.", "Invalid color code.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Grid on and off
        private void toggleGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the grid on or off.
            showGrid = !showGrid;

            // Refresh the PictureBox1.
            pictureBox1.Invalidate();
        }
        private void unloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob ein Bild geladen ist
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Es wurde kein Bild geladen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PictureBox leeren
            pictureBox1.Image = null;
            pictureBox1.Refresh();
        }

        #endregion

        // Imput 

        private void textBoxWidth_TextChanged(object sender, EventArgs e)
        {
            CropImage();
        }

        private void textBoxHeight_TextChanged(object sender, EventArgs e)
        {
            CropImage();
        }

        private void textBoxStartX_TextChanged(object sender, EventArgs e)
        {
            CropImage();
        }

        private void textBoxStartY_TextChanged(object sender, EventArgs e)
        {
            CropImage();
        }

        #region CromImage        

        private void CropImage()
        {
            // Check if an image is loaded in PictureBox1.
            if (pictureBox1.Image != null && !string.IsNullOrEmpty(textBoxWidth.Text) && !string.IsNullOrEmpty(textBoxHeight.Text) && !string.IsNullOrEmpty(textBoxStartX.Text) && !string.IsNullOrEmpty(textBoxStartY.Text))
            {
                // Load the image from PictureBox1 into PictureBox2.
                pictureBox2.Image = pictureBox1.Image;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;

                // Read the width and height from the text boxes.
                int width = int.Parse(textBoxWidth.Text);
                int height = int.Parse(textBoxHeight.Text);

                // Check if the width and height are greater than 0.
                if (width > 0 && height > 0)
                {
                    // Read the starting point from the text boxes.
                    int startX = int.Parse(textBoxStartX.Text);
                    int startY = int.Parse(textBoxStartY.Text);

                    // Crop the image from PictureBox2 to the specified size.
                    Bitmap croppedImage = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(croppedImage))
                    {
                        g.DrawImage(pictureBox2.Image, new Rectangle(0, 0, width, height), new Rectangle(startX, startY, width, height), GraphicsUnit.Pixel);
                    }

                    // Load the cropped image into PictureBox2.
                    pictureBox2.Image = croppedImage;
                    pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
                }
            }
        }

        #endregion
        // Show Border Image und die Sichtbarkeit des Rahmens zu aktualisieren.
        private void showBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showBorder = !showBorder;
            MoveImage(0, 0); // Redraw the image to update the border visibility
        }

        #region Save
        private void saveImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the pictureBox2
            if (pictureBox2.Image != null)
            {
                // Get the selected image format from the toolStripComboBox1
                string format = toolStripComboBox1.SelectedItem.ToString();

                // Create the directory if it doesn't exist
                string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tempGrafic");
                Directory.CreateDirectory(directory);

                // Create the file name with a timestamp
                string fileName = "ArtItem_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

                // Set the file extension based on the selected format
                switch (format)
                {
                    case "BMP":
                        fileName += ".bmp";
                        break;
                    case "TIFF":
                        fileName += ".tiff";
                        break;
                    case "PNG":
                        fileName += ".png";
                        break;
                    case "JPEG":
                        fileName += ".jpeg";
                        break;
                }

                // Combine the directory and file name
                string filePath = Path.Combine(directory, fileName);

                // Save the image in the selected format
                switch (format)
                {
                    case "BMP":
                        pictureBox2.Image.Save(filePath, ImageFormat.Bmp);
                        break;
                    case "TIFF":
                        pictureBox2.Image.Save(filePath, ImageFormat.Tiff);
                        break;
                    case "PNG":
                        pictureBox2.Image.Save(filePath, ImageFormat.Png);
                        break;
                    case "JPEG":
                        pictureBox2.Image.Save(filePath, ImageFormat.Jpeg);
                        break;
                }

                // Show a message box to indicate that the image was saved
                MessageBox.Show("Das Bild wurde gespeichert in: " + filePath);
            }
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the right mouse button was clicked
            if (e.Button == MouseButtons.Right)
            {
                // Show the contextMenuStrip1 at the current mouse position
                contextMenuStrip1.Show(pictureBox2, e.Location);
            }
        }
        #endregion

        #region Picturebox2
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(openFileDialog.FileName);
                    pictureBox2.Image = image;
                    pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox2.Refresh();
                }
            }

        }

        private void openToolStrip2MenuItem_Click(object sender, EventArgs e)
        {
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Bitmap image = new Bitmap(openFileDialog.FileName);
                    pictureBox2.Image = image;
                    // Change the size of the PictureBox2 to match the size of the image.
                    pictureBox2.Size = pictureBox2.Image.Size;
                    pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
                    pictureBox2.Refresh();
                }
            }
        }

        private void buttonCrop_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in PictureBox1 or PictureBox2.
            if (pictureBox1.Image != null || pictureBox2.Image != null)
            {
                // Load the image from PictureBox2 into PictureBox2 if it is not null, otherwise load the image from PictureBox1.
                Bitmap image = pictureBox2.Image != null ? new Bitmap(pictureBox2.Image) : new Bitmap(pictureBox1.Image);

                // Declare variables for the width, height, startX and startY values.
                int width, height, startX, startY;

                // Check if the text boxes are empty.
                if (string.IsNullOrEmpty(textBoxWidth.Text) || string.IsNullOrEmpty(textBoxHeight.Text) || string.IsNullOrEmpty(textBoxStartX.Text) || string.IsNullOrEmpty(textBoxStartY.Text))
                {
                    // Use the entire image if the text boxes are empty.
                    width = image.Width;
                    height = image.Height;
                    startX = 0;
                    startY = 0;
                }
                else
                {
                    // Read the width and height from the text boxes.
                    width = int.Parse(textBoxWidth.Text);
                    height = int.Parse(textBoxHeight.Text);

                    // Check if the width and height are greater than 0.
                    if (width <= 0 || height <= 0)
                    {
                        // Display an error message or perform a different action for invalid width or height value
                        // For example: MessageBox.Show("Invalid width or height value.");
                        return;
                    }

                    // Read the starting point from the text boxes.
                    startX = int.Parse(textBoxStartX.Text);
                    startY = int.Parse(textBoxStartY.Text);
                }

                // Crop the image to the specified size.
                Bitmap croppedImage = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    g.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(startX, startY, width, height), GraphicsUnit.Pixel);
                }

                // Create the directory if it doesn't exist
                string directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tempGrafic");
                Directory.CreateDirectory(directory);

                // Create the file name with a timestamp
                string fileName = "ArtItem_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bmp";

                // Combine the directory and file name
                string filePath = Path.Combine(directory, fileName);

                // Save the cropped image as a BMP file
                croppedImage.Save(filePath, ImageFormat.Bmp);

                // Show a message box to indicate that the image was saved
                MessageBox.Show("Das Bild wurde gespeichert in: " + filePath);
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle the value of the showGrid field.
            showGrid2 = !showGrid2;

            // Redraw the PictureBox2.
            pictureBox2.Invalidate();
        }

        private void pictureBox3_Paint(object sender, PaintEventArgs e)
        {
            // Check if the grid should be displayed.
            if (showGrid2)
            {
                int kachelBreite = 32; // Tile width.
                int gridSize = 8; // Number of tiles.
                float scaleFactor = 250f / (gridSize * kachelBreite);
                Pen pen = new Pen(Color.Red, 1f);
                Brush brush = new SolidBrush(Color.Black);

                // Calculate grid size.
                int gridSizeInPixels = gridSize * kachelBreite;

                int dx = 0; // Move the graphics 10 pixels to the right.
                int dy = -178; // Move the graphics 20 pixels upwards.

                // Move the origin to the center of the PictureBox.
                e.Graphics.TranslateTransform(pictureBox2.Width / 2 + dx, pictureBox2.Height / 2 + dy);

                // Scale the graphics.
                e.Graphics.ScaleTransform(scaleFactor, scaleFactor);

                // Rotate the graphics by 45 degrees.
                e.Graphics.RotateTransform(45);

                for (int i = gridSize; i >= 0; i--)
                {
                    // Draw horizontal lines.
                    e.Graphics.DrawLine(pen, new Point(0, i * kachelBreite), new Point(gridSize * kachelBreite, i * kachelBreite));

                    // Draw vertical lines.
                    e.Graphics.DrawLine(pen, new Point(i * kachelBreite, 0), new Point(i * kachelBreite, gridSize * kachelBreite));
                }
            }
        }
        private void mirror2ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Überprüfen Sie, ob ein Bild in PictureBox2 vorhanden ist
            if (pictureBox2.Image != null)
            {
                // Erstellen Sie eine Kopie des aktuellen Bildes
                Bitmap originalImage = new Bitmap(pictureBox2.Image);

                // Spiegeln Sie das Bild horizontal
                originalImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Setzen Sie das gespiegelte Bild zurück in PictureBox2
                pictureBox2.Image = originalImage;
            }
        }
        private void toolStripMenuItemrotate90degrees_Click(object sender, EventArgs e)
        {
            // Überprüfen Sie, ob ein Bild in PictureBox2 vorhanden ist
            if (pictureBox2.Image != null)
            {
                // Erstellen Sie eine Kopie des aktuellen Bildes
                Bitmap originalImage = new Bitmap(pictureBox2.Image);

                // Drehen Sie das Bild um 90 Grad nach links
                originalImage.RotateFlip(RotateFlipType.Rotate270FlipNone);

                // Setzen Sie das gedrehte Bild zurück in PictureBox2
                pictureBox2.Image = originalImage;
            }
        }

        private void cutImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob ein Bild ausgewählt ist
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Es wurde kein Bild ausgewählt.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Bitmap originalImage = new Bitmap(pictureBox2.Image);
            int width = originalImage.Width;
            int height = originalImage.Height;
            int count = (int)Math.Ceiling((double)width / 44);
            int lastImageWidth = width % 44;
            Color fillColor = Color.White; // Beispiel: Weiße Farbe (FFFFFF)

            // Überprüfen, ob das Bild schmaler als 44 Pixel ist
            if (width < 44)
            {
                MessageBox.Show("Das Bild ist schmaler als 44 Pixel.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Erstellen Sie das Verzeichnis, wenn es nicht existiert
            string directory = "tempGrafic";
            Directory.CreateDirectory(directory);

            // Schneiden und speichern Sie die Teilbilder
            for (int i = 0; i < count; i++)
            {
                int cropWidth = (i == count - 1 && lastImageWidth > 0) ? lastImageWidth : 44;
                int offsetX = i * 44;

                // Ausschnitt erstellen
                Rectangle cropRect = new Rectangle(offsetX, 0, cropWidth, height);
                Bitmap croppedImage = originalImage.Clone(cropRect, originalImage.PixelFormat);

                // Überprüfen, ob das letzte Bild geschnitten wird
                if (i == count - 1 && lastImageWidth < 44)
                {
                    // Fehlenden Bereich mit der angegebenen Farbe auffüllen
                    int missingWidth = 44 - lastImageWidth;
                    Bitmap lastImage = new Bitmap(44, height);
                    using (Graphics g = Graphics.FromImage(lastImage))
                    {
                        // Transparenten Hintergrund zeichnen
                        g.Clear(Color.Transparent);

                        // Letztes Bild am linken Rand platzieren
                        int x = 0;
                        g.DrawImage(croppedImage, x, 0);

                        // Fehlenden Bereich mit der angegebenen Farbe auffüllen
                        FillMissingArea(lastImage, missingWidth, height, fillColor);
                    }
                    croppedImage = lastImage;
                }

                // Inhalt auffüllen
                FillContent(croppedImage, fillColor);

                // Dateinamen generieren
                string fileName = Path.Combine(directory, "art" + (i + 1) + ".bmp");

                // Bild speichern
                croppedImage.Save(fileName, ImageFormat.Bmp);

                // Freigabe von Ressourcen
                croppedImage.Dispose();
            }

            // Erfolgsmeldung anzeigen
            MessageBox.Show("Das Bild wurde erfolgreich geschnitten und gespeichert.", "Erfolg", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Fehlenden Bereich mit der angegebenen Farbe auffüllen
        private void FillMissingArea(Bitmap image, int width, int height, Color color)
        {
            using (Graphics g = Graphics.FromImage(image))
            {
                Rectangle missingAreaRect = new Rectangle(image.Width - width, 0, width, height);
                using (Brush brush = new SolidBrush(color))
                {
                    g.FillRectangle(brush, missingAreaRect);
                }
            }
        }

        // Bildinhalt mit der angegebenen Farbe auffüllen
        private void FillContent(Bitmap image, Color color)
        {
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    if (image.GetPixel(x, y) == Color.Transparent || image.GetPixel(x, y).A == 0)
                    {
                        image.SetPixel(x, y, color);
                    }
                }
            }
        }

        private void fillTextureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob ein Bild geladen ist
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Es wurde kein Bild geladen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Überprüfen, ob ein Bereich ausgewählt wurde
            int width = int.Parse(textBoxWidth.Text);
            int height = int.Parse(textBoxHeight.Text);
            int startX = int.Parse(textBoxStartX.Text);
            int startY = int.Parse(textBoxStartY.Text);
            if (width <= 0 || height <= 0)
            {
                MessageBox.Show("Es wurde kein Bereich ausgewählt.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Den Benutzer auffordern, eine neue Textur auszuwählen
            using (System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog())
            {
                openFileDialog.Filter = "Bilddateien|*.bmp;*.jpg;*.jpeg;*.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Die neue Textur laden
                    Bitmap newTexture = new Bitmap(openFileDialog.FileName);

                    // Eine Kopie des aktuellen Bildes in der PictureBox erstellen
                    Bitmap imageCopy = (Bitmap)pictureBox2.Image.Clone();

                    // Den ausgewählten Bereich mit der neuen Textur füllen
                    using (Graphics g = Graphics.FromImage(imageCopy))
                    {
                        // Den ausgewählten Bereich mit der neuen Textur auffüllen
                        g.DrawImage(newTexture, new Rectangle(startX, startY, width, height));
                    }

                    // Die PictureBox aktualisieren
                    pictureBox2.Image = imageCopy;
                    pictureBox2.Refresh();
                }
            }
        }
        private void unloadimageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen, ob ein Bild geladen ist
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Es wurde kein Bild geladen.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PictureBox leeren
            pictureBox2.Image = null;
            pictureBox2.Refresh();
        }

        #endregion
    }
}