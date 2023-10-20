using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Ultima;
using UoFiddler.Controls.Classes;
using UoFiddler.Plugin.ConverterMultiTextPlugin.Class;

namespace UoFiddler.Controls.Forms
{
    public partial class AnimationEditFormButton : Form
    {

        int currentIndex = 0; // The index of the current image
        SelectablePictureBox[] boxes;
        CheckBox[] checks;
        private bool pipetteMode = false;

        //Zoom
        private int zoomLevel1 = 0;
        private int zoomLevel2 = 0;
        private int zoomLevel3 = 0;
        private int zoomLevel4 = 0;
        private int zoomLevel5 = 0;
        private int zoomLevel6 = 0;
        private int zoomLevel7 = 0;
        private int zoomLevel8 = 0;
        private int zoomLevel9 = 0;
        private int zoomLevel10 = 0;

        public AnimationEditFormButton()
        {
            InitializeComponent();
            Icon = Options.GetFiddlerIcon();
            this.KeyPreview = true; // Enable the key preview

            // Initialize the boxes and checks arrays
            boxes = new SelectablePictureBox[]
            {
            selectablePictureBox1,
            selectablePictureBox2,
            selectablePictureBox3,
            selectablePictureBox4,
            selectablePictureBox5,
            selectablePictureBox6,
            selectablePictureBox7,
            selectablePictureBox8,
            selectablePictureBox9,
            selectablePictureBox10
            };

            checks = new CheckBox[]
            {
            checkBox1,
            checkBox2,
            checkBox3,
            checkBox4,
            checkBox5,
            checkBox6,
            checkBox7,
            checkBox8,
            checkBox9,
            checkBox10
            };

            timer.Interval = 1000; // Set the initial interval to 1 second
            timer.Tick += new EventHandler(timer_Tick);

            // Add the ValueChanged event handler to numericUpDownFrameDelay
            numericUpDownFrameDelay.ValueChanged += new EventHandler(numericUpDownFrameDelay_ValueChanged);

            // Add the click event handler to btColordialog
            btColordialog.Click += (sender, e) => SelectColor();

            tboxColorCode.TextChanged += tboxColorCode_TextChanged;


            // Zoom Tags
            zoomInButton1.Tag = selectablePictureBox1;
            zoomOutButton1.Tag = selectablePictureBox1;

            zoomInButton2.Tag = selectablePictureBox2;
            zoomOutButton2.Tag = selectablePictureBox2;

            zoomInButton3.Tag = selectablePictureBox3;
            zoomOutButton3.Tag = selectablePictureBox3;

            zoomInButton4.Tag = selectablePictureBox4;
            zoomOutButton4.Tag = selectablePictureBox4;

            zoomInButton5.Tag = selectablePictureBox5;
            zoomOutButton5.Tag = selectablePictureBox5;

            zoomInButton6.Tag = selectablePictureBox6;
            zoomOutButton6.Tag = selectablePictureBox6;

            zoomInButton7.Tag = selectablePictureBox7;
            zoomOutButton7.Tag = selectablePictureBox7;

            zoomInButton8.Tag = selectablePictureBox8;
            zoomOutButton8.Tag = selectablePictureBox8;

            zoomInButton9.Tag = selectablePictureBox9;
            zoomOutButton9.Tag = selectablePictureBox9;

            zoomInButton10.Tag = selectablePictureBox10;
            zoomOutButton10.Tag = selectablePictureBox10;

        }
        #region Time_Tick 

        private void timer_Tick(object sender, EventArgs e)
        {
            // Get the next image index
            currentIndex++;
            if (currentIndex >= boxes.Length)
                currentIndex = (int)numericUpDownStartDelay.Value - 1; // Subtrahieren Sie 1 vom Wert von numericUpDownStartDelay

            // Check if the current PictureBox has an image and is active
            if (boxes[currentIndex].Image != null && checks[currentIndex].Checked)
            {
                // Check if the image exists in the PictureBox
                if (boxes[currentIndex].Image != null)
                {
                    // Get the image from the corresponding selectablePictureBox
                    Bitmap imageBitmap = new Bitmap(boxes[currentIndex].Image);

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
                        imageBitmap = MakeTransparent(imageBitmap, color);
                    }

                    // Display the transparent bitmap in your PictureBox
                    AnimationPictureBox.Image = imageBitmap;
                    frameLabel.Text = (currentIndex + 1).ToString();

                    // Create a copy of the image and flip it
                    Bitmap flippedImageBitmap = new Bitmap(imageBitmap);
                    flippedImageBitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    // Display the flipped transparent bitmap in your second PictureBox
                    AnimationPictureBox2.Image = flippedImageBitmap;
                }
                else
                {
                    // If there is no image in the PictureBox, set the images in the PictureBox controls to null
                    AnimationPictureBox.Image = null;
                    AnimationPictureBox2.Image = null;
                }
            }
        }


        #endregion

        private void OnLoad(object sender, EventArgs e)
        {

        }

        private void AnimationEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        #region LoadToolStripMenuItem
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Array of selectablePictureBox and CheckBoxes
            PictureBox[] boxes = { selectablePictureBox1, selectablePictureBox2, selectablePictureBox3, selectablePictureBox4, selectablePictureBox5, selectablePictureBox6, selectablePictureBox7, selectablePictureBox8, selectablePictureBox9, selectablePictureBox10 };
            CheckBox[] checks = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };

            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Properties of the OpenFileDialog
            openFileDialog1.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog1.Title = "Please select an image file.";

            // Displays the dialog and check if the user clicked OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Loads the image
                Image image = Image.FromFile(openFileDialog1.FileName);

                // Clear all PictureBoxes before loading the new image
                for (int i = 0; i < boxes.Length; i++)
                {
                    boxes[i].Image = null;
                    if (boxes[i] is SelectablePictureBox)
                    {
                        ((SelectablePictureBox)boxes[i]).ClearImage();
                    }
                }

                // Use a loop to load the image into the PictureBoxes,
                // if the corresponding checkbox is activated
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (checks[i].Checked)
                    {
                        boxes[i].Image = image;
                    }
                }
            }
        }
        #endregion

        #region LoadToolStripMenuItem
        private void loadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Array of selectablePictureBox and CheckBoxes
            PictureBox[] boxes = { selectablePictureBox1, selectablePictureBox2, selectablePictureBox3, selectablePictureBox4, selectablePictureBox5, selectablePictureBox6, selectablePictureBox7, selectablePictureBox8, selectablePictureBox9, selectablePictureBox10 };
            CheckBox[] checks = { checkBox1, checkBox2, checkBox3, checkBox4, checkBox5, checkBox6, checkBox7, checkBox8, checkBox9, checkBox10 };

            // Create an instance of OpenFileDialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Properties of the OpenFileDialog
            openFileDialog1.Filter = "Image files (*.bmp;*.jpg;*.jpeg;*.gif;*.png)|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            openFileDialog1.Title = "Please select an image file.";

            // Displays the dialog and check if the user clicked OK
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Loads the image
                Image image = Image.FromFile(openFileDialog1.FileName);

                // Clear all PictureBoxes before loading the new image
                for (int i = 0; i < boxes.Length; i++)
                {
                    boxes[i].Image = null;
                    if (boxes[i] is SelectablePictureBox)
                    {
                        ((SelectablePictureBox)boxes[i]).ClearImage();
                    }
                }

                // Use a loop to load the image into the PictureBoxes,
                // if the corresponding checkbox is activated
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (checks[i].Checked)
                    {
                        boxes[i].Image = image;
                    }
                }
            }
        }
        #endregion
        private void pictureBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        #region PictureBox_PrevieKeyDown
        private void pictureBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Cast the sender object into a SelectablePictureBox
                SelectablePictureBox currentBox = sender as SelectablePictureBox;

                if (Clipboard.ContainsImage())
                {
                    currentBox.Image = Clipboard.GetImage();
                }
                else
                {
                    MessageBox.Show("The clipboard does not contain an image.");
                }
            }
        }
        #endregion

        #region NumericUpDownFrameDelay
        private void numericUpDownFrameDelay_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDownFrameDelay.Value > 0)
            {
                timer.Interval = 1000 / (int)numericUpDownFrameDelay.Value;
                delayLabel.Text = $"Processing speed: {timer.Interval} ms"; // Ads in label

                // Restart the timer if it's enabled
                if (timer.Enabled)
                {
                    timer.Stop();
                    timer.Start();
                }
            }
            else
            {
                MessageBox.Show("Frame delay must be greater than zero.");
            }
        }
        #endregion

        #region Start Animation


        private void startAnimationButton_Click(object sender, EventArgs e)
        {
            // Start or stop the slideshow
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                if (numericUpDownFrameDelay.Value > 0)
                {
                    timer.Interval = 1000 / (int)numericUpDownFrameDelay.Value;
                    // Setzen Sie currentIndex auf den Wert von numericUpDownStartDelay
                    currentIndex = (int)numericUpDownStartDelay.Value;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Frame delay must be greater than zero.");
                }
            }
        }
        #endregion

        #region MakeTransparent
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

        #region SelectColor

        private void SelectColor()
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                Color color = colorDialog.Color;
                tboxColorCode.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
                foreach (SelectablePictureBox box in boxes)
                {
                    box.SetDrawingColor(color);
                }
            }
        }
        #endregion

        #region UdateColor
        private void UpdateColor()
        {
            string code = tboxColorCode.Text;

            if (code.StartsWith("#"))
                code = code.Substring(1);

            if (code.Length == 6 && int.TryParse(code, System.Globalization.NumberStyles.HexNumber, null, out int number))
            {
                Color color = Color.FromArgb(number >> 16, (number >> 8) & 255, number & 255);
                foreach (SelectablePictureBox box in boxes)
                {
                    box.SetDrawingColor(color);
                }
            }
        }
        #endregion

        #region Draw all
        private void btDrawAllSelectableBox_Click(object sender, EventArgs e)
        {
            bool isActive = false;
            foreach (SelectablePictureBox box in boxes)
            {
                box.ToggleDrawing(); // Toggles the drawing mode for each box
                if (box.IsDrawing()) // Checks whether drawing mode is active
                {
                    isActive = true;
                }
            }

            if (isActive)
            {
                btDrawAllSelectableBox.BackColor = Color.Green; // Sets the background color of the button to green
                labelDrawAll.Text = "Active"; // Sets the text of the label to "Active"
            }
            else
            {
                btDrawAllSelectableBox.BackColor = SystemColors.Control; // Sets the background color of the button to the default color
                labelDrawAll.Text = "Not active"; // Sets the text of the label to "Not active"
            }
        }
        #endregion

        #region BrushSize
        private void numericUpDownBrushSize_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDownBrushSize.Value;
            foreach (SelectablePictureBox box in boxes)
            {
                box.SetBrushSize(size);
            }
        }
        #endregion

        #region Combobox Images
        private void comboBoxImageBackgrund_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxImageBackgrund.SelectedIndex != -1)
            {
                string selectedItem = comboBoxImageBackgrund.SelectedItem.ToString();

                if (selectedItem == "Green")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Green2;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Green2;
                }
                else if (selectedItem == "Water")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.water2;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.water2;
                }
                else if (selectedItem == "Sand")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Sand;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Sand;
                }
                else if (selectedItem == "Street")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Street;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Street;
                }
                else if (selectedItem == "Forest")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Forest;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Forest;
                }
                else if (selectedItem == "Dirt")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Dirt;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Dirt;
                }
                else if (selectedItem == "Dungeon")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Dungeon;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.Dungeon;
                }
                else if (selectedItem == "Cave")
                {
                    AnimationPictureBox.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.cave;
                    AnimationPictureBox2.BackgroundImage = UoFiddler.Plugin.ConverterMultiTextPlugin.Properties.Resources.cave;
                }
                else if (selectedItem == "Clear")
                {
                    AnimationPictureBox.BackgroundImage = null;
                    AnimationPictureBox2.BackgroundImage = null;
                }
            }
        }
        #endregion

        #region NumericUpDownImageShow
        private void numericUpDownImageShow_ValueChanged(object sender, EventArgs e)
        {
            // Holen Sie den Index des aktuellen Bildes aus numericUpDownImageShow
            int index = (int)numericUpDownImageShow.Value - 1;

            // Überprüfen Sie, ob der Index gültig ist
            if (index >= 0 && index < boxes.Length)
            {
                // Überprüfen Sie, ob das Bild in der PictureBox existiert
                if (boxes[index].Image != null)
                {
                    // Holen Sie das Bild aus der entsprechenden selectablePictureBox
                    Bitmap imageBitmap = new Bitmap(boxes[index].Image);

                    // Definieren Sie die Farben, die Sie transparent machen möchten
                    Color[] colorsToMakeTransparent = new Color[]
                    {
                Color.FromArgb(0, 0, 0),      // Schwarz
                Color.FromArgb(255, 255, 255),// Weiß
                Color.FromArgb(211, 211, 211) // Hellgrau (d3d3d3 in RGB)
                    };

                    // Machen Sie jede Farbe im Bild transparent
                    foreach (Color color in colorsToMakeTransparent)
                    {
                        imageBitmap = MakeTransparent(imageBitmap, color);
                    }

                    // Setzen Sie das transparente Bitmap als Bild für die PictureBox-Steuerelemente
                    AnimationPictureBox.Image = imageBitmap;
                    AnimationPictureBox2.Image = imageBitmap;
                }
                else
                {
                    // Wenn kein Bild in der PictureBox ist, setzen Sie die Bilder in den PictureBox-Steuerelementen auf null
                    AnimationPictureBox.Image = null;
                    AnimationPictureBox2.Image = null;
                }
            }
            else
            {
                // Wenn der Index ungültig ist (z.B. 0), löschen Sie die Bilder aus den PictureBox-Steuerelementen
                AnimationPictureBox.Image = null;
                AnimationPictureBox2.Image = null;
            }
        }
        #endregion

        #region Start Contextmenu
        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Start or stop the slideshow
            if (timer.Enabled)
            {
                timer.Stop();
            }
            else
            {
                if (numericUpDownFrameDelay.Value > 0)
                {
                    timer.Interval = 1000 / (int)numericUpDownFrameDelay.Value;
                    // Setzen Sie currentIndex auf den Wert von numericUpDownStartDelay
                    currentIndex = (int)numericUpDownStartDelay.Value;
                    timer.Start();
                }
                else
                {
                    MessageBox.Show("Frame delay must be greater than zero.");
                }
            }
        }
        #endregion

        #region SelevtabePictureBox_MouseClick 

        private void selectablePictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender is SelectablePictureBox box)
            {
                if (pipetteMode)
                {
                    // Get the color at the position where the user clicked
                    Color color = box.GetPixelColor(e.Location);

                    // Put the hexadecimal value of the color in tboxColorCode
                    tboxColorCode.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";

                    // Exit pipette mode
                    pipetteMode = false;

                    // Reset the color of the button to the default color
                    btPipette.BackColor = SystemColors.Control;
                }
                else
                {
                    // Run your normal MouseClick code here...
                }
            }
        }
        #endregion

        #region Pipette
        private void btPipette_Click(object sender, EventArgs e)
        {
            // Switch to eyedropper mode when the button is clicked
            pipetteMode = !pipetteMode;

            if (pipetteMode)
            {
                // Color the button green when pipette mode is active
                btPipette.BackColor = Color.Green;
            }
            else
            {
                // Reset the button color to the default color when eyedropper mode is finished
                btPipette.BackColor = SystemColors.Control;
            }
        }
        #endregion

        #region SelebtabePictureBoxMouseMove
        private void selectablePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender is SelectablePictureBox box)
            {
                // Get the color at the position where the mouse is currently
                Color color = box.GetPixelColor(e.Location);

                // Put the hexadecimal value of the color in panel color code
                panelFarbcode.BackColor = color;
            }
        }
        #endregion

        #region TextBox Color
        private void tboxColorCode_TextChanged(object sender, EventArgs e)
        {
            string colorCode = tboxColorCode.Text;

            // If the # is missing, add it
            if (!colorCode.StartsWith("#"))
            {
                colorCode = "#" + colorCode;
            }

            // Check whether the text in colorCode is a valid hexadecimal color value
            if (Regex.IsMatch(colorCode, "^#[0-9A-Fa-f]{6}$"))
            {
                // Convert the hexadecimal color value to a Color object
                Color color = ColorTranslator.FromHtml(colorCode);

                // Set the background color of panelColorCodeTB to the selected color
                panelFarbCodeTB.BackColor = color;
            }
        }
        #endregion

        #region Zoom        

        private void ZoomIn(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is SelectablePictureBox pictureBox)
            {
                if (pictureBox == selectablePictureBox1)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel1, true);
                }
                else if (pictureBox == selectablePictureBox2)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel2, true);
                }
                else if (pictureBox == selectablePictureBox3)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel3, true);
                }
                else if (pictureBox == selectablePictureBox4)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel4, true);
                }
                else if (pictureBox == selectablePictureBox5)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel5, true);
                }
                else if (pictureBox == selectablePictureBox6)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel6, true);
                }
                else if (pictureBox == selectablePictureBox7)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel7, true);
                }
                else if (pictureBox == selectablePictureBox8)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel8, true);
                }
                else if (pictureBox == selectablePictureBox9)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel9, true);
                }
                else if (pictureBox == selectablePictureBox10)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel10, true);
                }
                // Add more conditions for all your PictureBoxes
            }
        }

        private void ZoomOut(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is SelectablePictureBox pictureBox)
            {
                if (pictureBox == selectablePictureBox1)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel1, false);
                }
                else if (pictureBox == selectablePictureBox2)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel2, false);
                }
                else if (pictureBox == selectablePictureBox3)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel3, false);
                }
                else if (pictureBox == selectablePictureBox4)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel4, false);
                }
                else if (pictureBox == selectablePictureBox5)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel5, false);
                }
                else if (pictureBox == selectablePictureBox6)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel6, false);
                }
                else if (pictureBox == selectablePictureBox7)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel7, false);
                }
                else if (pictureBox == selectablePictureBox8)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel8, false);
                }
                else if (pictureBox == selectablePictureBox9)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel9, false);
                }
                else if (pictureBox == selectablePictureBox10)
                {
                    ChangeZoomLevel(pictureBox, ref zoomLevel10, false);
                }
                // Add more conditions for all your PictureBoxes
            }
        }

        private void ChangeZoomLevel(SelectablePictureBox pictureBox, ref int zoomLevel, bool zoomIn)
        {
            if (pictureBox.Image != null)
            {
                if (zoomIn && zoomLevel < 2)
                {
                    pictureBox.Image = new Bitmap(pictureBox.Image, new Size(pictureBox.Image.Width * 2, pictureBox.Image.Height * 2));
                    zoomLevel++;
                }
                else if (!zoomIn && zoomLevel > 0)
                {
                    pictureBox.Image = new Bitmap(pictureBox.Image, new Size(pictureBox.Image.Width / 2, pictureBox.Image.Height / 2));
                    zoomLevel--;
                }
            }
        }
        #endregion
    }
}
