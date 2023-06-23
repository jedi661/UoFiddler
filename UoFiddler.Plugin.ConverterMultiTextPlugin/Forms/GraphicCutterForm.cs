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


        private Point startPoint;
        private Rectangle cropArea;

        public GraphicCutterForm()
        {
            InitializeComponent();

            // Verknüpfen Sie das MouseMove-Ereignis der PictureBox1 mit dem Ereignishandler
            pictureBox1.MouseMove += pictureBox1_MouseMove;

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

        }

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

                    pictureBox1.Refresh(); // Neues Bild anzeigen

                    // Setze die Position des Bildes in der PictureBox1
                    SetImagePosition(0, 0);

                    // Setze die Werte in den TextBoxen
                    textBoxWidth.Text = image.Width.ToString();
                    textBoxHeight.Text = image.Height.ToString();
                    textBoxStartX.Text = ((pictureBox1.Width - image.Width) / 2).ToString();
                    textBoxStartY.Text = (pictureBox1.Height - image.Height).ToString();
                }
            }
        }
        #endregion

        #region  Picture Paint
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Überprüfen Sie, ob das Gitter angezeigt werden soll
            if (showGrid)
            {
                int kachelBreite = 32; // Breite der Kachel
                int gridSize = 8; // Anzahl der Kacheln
                float scaleFactor = 250f / (gridSize * kachelBreite);
                Pen pen = new Pen(Color.Red, 1f);
                Brush brush = new SolidBrush(Color.Black);

                // Größe des Gitters berechnen
                int gridSizeInPixels = gridSize * kachelBreite;

                int dx = 0; // Verschieben Sie die Grafiken um 10 Pixel nach rechts
                int dy = -178; // Verschieben Sie die Grafiken um 20 Pixel nach oben

                // Ursprung auf die Mitte der PictureBox verschieben
                e.Graphics.TranslateTransform(pictureBox1.Width / 2 + dx, pictureBox1.Height / 2 + dy);

                // Grafiken skalieren
                e.Graphics.ScaleTransform(scaleFactor, scaleFactor);

                // Grafiken um 45 Grad drehen
                e.Graphics.RotateTransform(45);

                for (int i = gridSize; i >= 0; i--)
                {
                    // Horizontale Linien zeichnen
                    e.Graphics.DrawLine(pen, new Point(0, i * kachelBreite), new Point(gridSize * kachelBreite, i * kachelBreite));

                    // Vertikale Linien zeichnen
                    e.Graphics.DrawLine(pen, new Point(i * kachelBreite, 0), new Point(i * kachelBreite, gridSize * kachelBreite));
                }
            }

            // Zeichnen Sie das Auswahlrechteck auf die PictureBox
            using (Pen selectionPen = new Pen(Color.Yellow))
            {
                e.Graphics.DrawRectangle(selectionPen, cropArea);
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

        private void LoadAndCropImage(string imagePath, Rectangle cropArea)
        {
            // Laden Sie das Bild von der angegebenen Datei
            Bitmap image = new Bitmap(imagePath);

            // Schneiden Sie das Bild auf den angegebenen Bereich zu
            Bitmap croppedImage = image.Clone(cropArea, image.PixelFormat);

            // Laden Sie das zugeschnittene Bild in die PictureBox
            pictureBox1.Image = croppedImage;
        }

        #region Paint

        private void CropImage(Rectangle cropArea)
        {
            // Überprüfen Sie, ob ein Bild in der PictureBox geladen ist
            if (pictureBox1.Image != null)
            {
                // Konvertieren Sie das Bild in der PictureBox in ein Bitmap-Objekt
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Schneiden Sie das Bild auf den angegebenen Bereich zu
                Bitmap croppedImage = image.Clone(cropArea, image.PixelFormat);

                // Laden Sie das zugeschnittene Bild in die PictureBox
                pictureBox1.Image = croppedImage;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Überprüfen Sie, ob die linke Maustaste gedrückt wird
            if (e.Button == MouseButtons.Left)
            {
                // Setze den Startpunkt des Zuschneidens
                textBoxStartX.Text = e.X.ToString();
                textBoxStartY.Text = e.Y.ToString();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Überprüfen Sie, ob die linke Maustaste gedrückt wird
            if (e.Button == MouseButtons.Left)
            {
                // Berechne die Größe des Zuschneidebereichs
                int width = e.X - int.Parse(textBoxStartX.Text);
                int height = e.Y - int.Parse(textBoxStartY.Text);

                // Setze die Größe des Zuschneidebereichs
                textBoxWidth.Text = width.ToString();
                textBoxHeight.Text = height.ToString();
            }

            // Ändern Sie den Mauszeiger in ein Fadenkreuz
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            // Überprüfen Sie, ob die linke Maustaste losgelassen wurde
            if (e.Button == MouseButtons.Left)
            {
                // Rufe die CropImage-Methode auf
                CropImage();
            }
        }
        #endregion

        private void PaintGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Blenden Sie das Gitter aus
            // showGrid = false;

            // Aktualisieren Sie die PictureBox1
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

        private void ChangeCursorToCross()
        {
            // Ändern Sie den Mauszeiger in ein Fadenkreuz
            pictureBox2.Cursor = Cursors.Cross;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen Sie die aktuelle Hintergrundfarbe der PictureBox
            if (pictureBox1.BackColor == Color.FromArgb(0, 0, 0))
            {
                // Wenn die aktuelle Hintergrundfarbe Schwarz ist, ändern Sie sie in Weiß
                pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
            }
            else
            {
                // Andernfalls ändern Sie die Hintergrundfarbe in Schwarz
                pictureBox1.BackColor = Color.FromArgb(0, 0, 0);
            }
        }

        private void spiegelnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                // Spiegeln Sie das Bild horizontal
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Setzen Sie das gespiegelte Bild als neues Bild der PictureBox
                pictureBox1.Image = image;

                // Behalten Sie die aktuelle Position des Bildes bei
                SetImagePosition(imageX, imageY);

                // Aktualisieren Sie das Bild in der PictureBox
                pictureBox1.Refresh();
            }
        }

        // Color
        private void toolStripTextBoxColors_KeyDown(object sender, KeyEventArgs e)
        {
            // Überprüfen Sie, ob die Eingabetaste gedrückt wurde
            if (e.KeyCode == Keys.Enter)
            {
                // Versuchen Sie, den eingegebenen Text als Farbcode zu interpretieren
                try
                {
                    // Entfernen Sie das '#' aus dem eingegebenen Text, falls vorhanden
                    string colorCode = toolStripTextBoxColors.Text.TrimStart('#');

                    // Überprüfen Sie, ob der Farbcode 6 Zeichen lang ist
                    if (colorCode.Length == 6)
                    {
                        // Konvertieren Sie den Farbcode in eine Farbe
                        int argb = Int32.Parse(colorCode, System.Globalization.NumberStyles.HexNumber);
                        Color color = Color.FromArgb(255, Color.FromArgb(argb));

                        // Setzen Sie die Hintergrundfarbe der PictureBox
                        pictureBox1.BackColor = color;
                    }
                    else
                    {
                        // Zeigen Sie eine Fehlermeldung an, wenn der eingegebene Text kein gültiger Farbcode ist
                        MessageBox.Show("Bitte geben Sie einen gültigen 6-stelligen Farbcode ein. Beispiel: FF0000 für Rot.", "Ungültiger Farbcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch
                {
                    // Zeigen Sie eine Fehlermeldung an, wenn der eingegebene Text kein gültiger Farbcode ist
                    MessageBox.Show("Bitte geben Sie einen gültigen 6-stelligen Farbcode ein. Beispiel: FF0000 für Rot.", "Ungültiger Farbcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toggleGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Schalten Sie das Gitter ein oder aus
            showGrid = !showGrid;

            // Aktualisieren Sie die PictureBox1
            pictureBox1.Invalidate();
        }

        //

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

        private void CropImage()
        {
            // Überprüfen Sie, ob ein Bild in der PictureBox1 geladen ist
            if (pictureBox1.Image != null && !string.IsNullOrEmpty(textBoxWidth.Text) && !string.IsNullOrEmpty(textBoxHeight.Text) && !string.IsNullOrEmpty(textBoxStartX.Text) && !string.IsNullOrEmpty(textBoxStartY.Text))
            {
                // Lesen Sie die Breite und Höhe aus den TextBoxen
                int width = int.Parse(textBoxWidth.Text);
                int height = int.Parse(textBoxHeight.Text);

                // Lesen Sie den Startpunkt aus den TextBoxen
                int startX = int.Parse(textBoxStartX.Text);
                int startY = int.Parse(textBoxStartY.Text);

                // Schneiden Sie das Bild aus der PictureBox1 auf die angegebene Größe zu
                Bitmap croppedImage = new Bitmap(width, height);
                using (Graphics g = Graphics.FromImage(croppedImage))
                {
                    g.DrawImage(pictureBox1.Image, new Rectangle(0, 0, width, height), new Rectangle(startX, startY, width, height), GraphicsUnit.Pixel);
                }

                // Laden Sie das zugeschnittene Bild in die PictureBox2
                pictureBox2.Image = croppedImage;
                pictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
            }
        }

        private void showBorderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showBorder = !showBorder;
            MoveImage(0, 0); // Redraw the image to update the border visibility
        }

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


    }
}