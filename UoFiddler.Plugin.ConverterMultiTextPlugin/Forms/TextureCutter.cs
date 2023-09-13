// /***************************************************************************
//  *
//  * $Author: Nikodemus
//  * 
//  * "THE BEER-WARE LICENSE"
//  * As long as you retain this notice you can do whatever you want with 
//  * this stuff. If we meet some day, and you think this stuff is worth it,
//  * you can buy me a beer in return.
//  *
//  ***************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Forms
{
    public partial class TextureCutter : Form
    {
        private Point originalImageLocation;

        private Bitmap resizedImage;

        private bool isPickingColor = false;

        // Save OrginalImage
        private Bitmap originalImage;
        // Save Orginal Size
        private Size originalSize;

        // Define a variable to store the custom colors
        private int[] customColors;

        // Draw
        private bool isDrawing = false;
        private Point lastPoint;

        // Delete
        private bool isErasing = false;

        public TextureCutter()
        {
            InitializeComponent();

            labelImageSize.Text = "";

            checkBoxChange.CheckedChanged += checkBoxChange_CheckedChanged;

            // Set the KeyPreview property of the form to true.
            this.KeyPreview = true;

            // Add a keyboard event handler to the form.
            this.KeyDown += Form1_KeyDown;

            //zoom
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "image files|*.bmp;*.png;*.jpeg;*.jpg;*.tiff;*.gif|All files|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog1.FileName;

                // Set the image of the PictureBox to null and remove it from the Controls collection of the Panel.
                pictureBox1.Image = null;
                panel1.Controls.Remove(pictureBox1);
                pictureBox1.Dispose();

                // Create a new PictureBox and add it to the Panel.
                pictureBox1 = new PictureBox();
                pictureBox1.Location = originalImageLocation;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                panel1.Controls.Add(pictureBox1);

                // Link the MouseClick event of the new pictureBox1 with the pictureBox1_MouseClick event handler.
                pictureBox1.MouseClick += pictureBox1_MouseClick;

                // Resetting the scroll position.
                panel1.AutoScrollPosition = new Point(0, 0);

                // Displaying the image size in the label.
                Size imageSize = pictureBox1.Image.Size;
                labelImageSize.Text = $"Image size: {imageSize.Width} x {imageSize.Height} Pixel";

                // Make sure that the ContextMenuStrip of pictureBox1 is assigned.
                if (pictureBox1.ContextMenuStrip == null)
                {
                    pictureBox1.ContextMenuStrip = contextMenuStrip1;
                }
            }
        }
        private void buttonTextureCutter_Click(object sender, EventArgs e)
        {
            // Check if an image has been loaded into the picture box
            if (pictureBox1.Image == null)
            {
                // Display a message to the user and exit the method
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Create a temporary directory to store the output images
            string directory = "tempGrafic";
            Directory.CreateDirectory(directory);

            int counter = 1;
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Define a dictionary of tile sizes and their corresponding checkbox names
            Dictionary<string, Size> tileSizes = new Dictionary<string, Size>
            {
                { "checkBox33x33", new Size(33, 33) },
                { "checkBox44x44", new Size(44, 44) },
                { "checkBox64x64", new Size(64, 64) },
                { "checkBox128x128", new Size(128, 128) },
                { "checkBox256x256", new Size(256, 256) }
            };

            // Iterate through the dictionary
            foreach (var kvp in tileSizes)
            {
                // Find the corresponding checkbox control
                CheckBox checkBox = Controls.Find(kvp.Key, true).FirstOrDefault() as CheckBox;

                // Check if the checkbox is not null and is checked
                if (checkBox != null && checkBox.Checked)
                {
                    // Get the tile size from the dictionary value
                    Size tileSize = kvp.Value;

                    // Calculate the number of tiles needed to cover the image in both the x and y directions
                    int tileCountX = (int)Math.Ceiling((double)pictureBox1.Image.Width / tileSize.Width);
                    int tileCountY = (int)Math.Ceiling((double)pictureBox1.Image.Height / tileSize.Height);

                    // Use nested loops to iterate through each tile position
                    for (int y = 0; y < tileCountY; y++)
                    {
                        for (int x = 0; x < tileCountX; x++)
                        {
                            // Define the output file name and path
                            string outputFileName = $"TextureImage{counter:D2}_{timestamp}.bmp";
                            string outputPath = Path.Combine(directory, outputFileName);

                            // Call the CropImage method to crop the image and save it to the temporary directory
                            CropImage(pictureBox1.Image, tileSize.Width, tileSize.Height, outputPath, x * tileSize.Width, y * tileSize.Height);
                            counter++;
                        }
                    }
                }
            }

            int customTileSizeW, customTileSizeH;

            // Check if custom tile sizes have been entered by the user
            if (int.TryParse(textBoxSizeW.Text, out customTileSizeW) && int.TryParse(textBoxSizeH.Text, out customTileSizeH))
            {
                // Ensure that the custom tile size does not exceed the size of the image
                customTileSizeW = Math.Min(customTileSizeW, pictureBox1.Image.Width);
                customTileSizeH = Math.Min(customTileSizeH, pictureBox1.Image.Height);

                // Find the checkBox1 control
                CheckBox checkBox1 = Controls.Find("checkBox1", true).FirstOrDefault() as CheckBox;

                // Check if checkBox1 is not checked
                if (checkBox1 == null || !checkBox1.Checked)
                {
                    // Define a list of disallowed custom tile sizes
                    List<Size> disallowedCustomTileSizes = new List<Size>
            {
                new Size(1, 1),
                new Size(1, 2),
                new Size(2, 1),
                new Size(2, 2),
                new Size(3, 3),
                new Size(3, 4),
                new Size(4, 4),
                new Size(5, 5)
            };

                    // Check if the custom tile size is in the list of disallowed custom tile sizes
                    if (disallowedCustomTileSizes.Contains(new Size(customTileSizeW, customTileSizeH)))
                    {
                        // Display a message to the user and exit the method
                        MessageBox.Show("This tile size is only allowed at your own risk by enabling checkBox.");
                        return;
                    }
                }

                // Calculate the number of tiles needed to cover the image in both the x and y directions based on the custom tile size
                int customTileCountX = (int)Math.Ceiling((double)pictureBox1.Image.Width / customTileSizeW);
                int customTileCountY = (int)Math.Ceiling((double)pictureBox1.Image.Height / customTileSizeH);

                // Use nested loops to iterate through each tile position
                for (int y = 0; y < customTileCountY; y++)
                {
                    for (int x = 0; x < customTileCountX; x++)
                    {
                        // Define the output file name and path
                        string outputFileName = $"TextureImageCustom{counter:D2}_{timestamp}.bmp";
                        string outputPath = Path.Combine(directory, outputFileName);

                        // Call the CropImage method to crop the image and save it to the temporary directory
                        CropImage(pictureBox1.Image, customTileSizeW, customTileSizeH, outputPath, x * customTileSizeW, y * customTileSizeH);
                        counter++;
                    }
                }
            }

            // Display a message to the user indicating that the graphic was successfully cropped and saved in the temporary directory.
            MessageBox.Show("The graphic has been successfully cropped and saved in the temporary directory.");
        }

        private void CropImage(Image image, int width, int height, string outputPath, int x, int y)
        {
            using (Bitmap bitmap = new Bitmap(width, height))
            {
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
                }

                bitmap.Save(outputPath, ImageFormat.Bmp);
            }
        }

        private void buttonOpenTempGrafic_Click(object sender, EventArgs e)
        {
            // Get the path to the program directory
            string programDirectory = Application.StartupPath;

            // Define the path to the temporary directory in the program directory
            string directory = Path.Combine(programDirectory, "tempGrafic");

            // Check if the directory exists
            if (Directory.Exists(directory))
            {
                // Open the directory in the file explorer
                Process.Start("explorer.exe", directory);
            }
            else
            {
                // Display a message to the user indicating that the directory does not exist
                MessageBox.Show("The directory tempGraphic does not exist.");
            }
        }

        private void ButtonShrinkTexture_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox.
            if (pictureBox1.Image == null)
            {
                // Display a message and exit the method.
                MessageBox.Show("No image was loaded..");
                return;
            }

            // Dictionary for the sizes and their corresponding checkbox names.
            Dictionary<string, Size> tileSizes = new Dictionary<string, Size>
            {
                { "checkBox33x33", new Size(33, 33) },
                { "checkBox44x44", new Size(44, 44) },
                { "checkBox64x64", new Size(64, 64) },
                { "checkBox128x128", new Size(128, 128) },
                { "checkBox256x256", new Size(256, 256) }
            };

            // Iterating through the dictionary
            foreach (var kvp in tileSizes)
            {
                // Finding the CheckBox control based on the key
                CheckBox checkBox = Controls.Find(kvp.Key, true).FirstOrDefault() as CheckBox;

                // Check if the CheckBox is selected
                if (checkBox != null && checkBox.Checked)
                {
                    // Retrieve target size from the dictionary value.
                    Size targetSize = kvp.Value;

                    // Copy the original graphic.
                    Bitmap originalImage = new Bitmap(pictureBox1.Image);

                    try
                    {
                        // Improve the image using a super-resolution algorithm.
                        Image improvedImage = ImproveImageUsingSuperResolution(originalImage);

                        // Convert the improved image to a bitmap format.
                        Bitmap improvedBitmap = improvedImage as Bitmap;

                        // Resize the improved image to the target size.
                        Bitmap resizedImage = new Bitmap(improvedBitmap, targetSize.Width, targetSize.Height);

                        // Remove the current image from the PictureBox and set the improved image.
                        pictureBox1.Image = null;
                        pictureBox1.Image = resizedImage;

                        // Update the display.
                        Size imageSize = resizedImage.Size;
                        labelImageSize.Text = $"Image size.: {imageSize.Width} x {imageSize.Height} Pixel";
                    }
                    catch (Exception ex)
                    {
                        // An error has occurred - display an error message and proceed to the next step.
                        MessageBox.Show($"Error occurred while improving the image: {ex.Message}");
                    }
                }
            }
        }

        private Image ImproveImageUsingSuperResolution(Image image)
        {
            // Set the new width and height of the image.
            int newWidth = image.Width * 2;
            int newHeight = image.Height * 2;

            // Create a new bitmap with the new size.
            Bitmap result = new Bitmap(newWidth, newHeight);

            // Draw the original image onto the new bitmap with bicubic interpolation.
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);
            }

            // Return the improved image.
            return result;
        }

        private Bitmap SharpenImage(Bitmap image)
        {
            // Create a copy of the image.
            Bitmap sharpenedImage = (Bitmap)image.Clone();

            // Create an unsharp mask matrix.
            double[,] sharpenMatrix = new double[,]
            {
                { -1, -1, -1 },
                { -1, 9, -1 },
                { -1, -1, -1 }

                /*{ -0.1, -0.1, -0.1 },
                 * { -0.1, 1.9, -0.1 },
                 * { -0.1, -0.1, -0.1 }*/
            };

            // Apply the unsharp mask to the image.
            for (int x = 1; x < image.Width - 1; x++)
            {
                for (int y = 1; y < image.Height - 1; y++)
                {
                    double r = 0;
                    double g = 0;
                    double b = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            int offsetX = x + i - 1;
                            int offsetY = y + j - 1;

                            Color pixel = image.GetPixel(offsetX, offsetY);

                            r += pixel.R * sharpenMatrix[i, j];
                            g += pixel.G * sharpenMatrix[i, j];
                            b += pixel.B * sharpenMatrix[i, j];
                        }
                    }

                    r = Math.Max(0, Math.Min(255, r));
                    g = Math.Max(0, Math.Min(255, g));
                    b = Math.Max(0, Math.Min(255, b));

                    Color newPixel = Color.FromArgb((int)r, (int)g, (int)b);
                    sharpenedImage.SetPixel(x, y, newPixel);
                }
            }

            // Return the sharpened image.
            return sharpenedImage;
        }

        private void buttonsharp_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox.
            if (pictureBox1.Image == null)
            {
                // Display a message and exit the method.
                MessageBox.Show("No image has been loaded.");
                return;
            }

            // Copy the original graphic.
            Bitmap originalImage = new Bitmap(pictureBox1.Image);

            try
            {
                // Sharpen the image.
                Bitmap sharpenedImage = SharpenImage(originalImage);

                // Remove the current image from the PictureBox and set the sharpened image.
                pictureBox1.Image = null;
                pictureBox1.Image = sharpenedImage;

                // Update the display.
                Size imageSize = sharpenedImage.Size;
                labelImageSize.Text = $"Image Size: {imageSize.Width} x {imageSize.Height} Pixel";
            }
            catch (Exception ex)
            {
                // An error has occurred - display an error message and proceed to the next step.
                MessageBox.Show($"Error occurred while sharpening the image.: {ex.Message}");
            }
        }

        private void buttonSaveImage_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image has been loaded..");
                return;
            }

            // Create the filename with the current time.
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string fileName = $"TextureSingleImage_{timestamp}.bmp";

            string directory = Path.Combine(Application.StartupPath, "tempGrafic");
            Directory.CreateDirectory(directory);
            string filePath = Path.Combine(directory, fileName);

            // Save the image to the specified path
            pictureBox1.Image.Save(filePath, ImageFormat.Bmp);

            MessageBox.Show("The graphic was saved successfully.");
        }
        private Bitmap ResizeImageWithFixedBorder(Bitmap image, int borderWidth)
        {
            // Calculate the new width and height of the inner part of the image
            int newInnerWidth = (image.Width - borderWidth * 2) * 2;
            int newInnerHeight = (image.Height - borderWidth * 2) * 2;

            // Calculate the new overall width and height of the image
            int newWidth = newInnerWidth + borderWidth * 2;
            int newHeight = newInnerHeight + borderWidth * 2;

            // Create a new bitmap with the new size
            Bitmap result = new Bitmap(newWidth, newHeight);

            // Draw the border of the original image onto the new bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                // Draw the top border
                graphics.DrawImage(image, 0, 0, new Rectangle(0, 0, image.Width, borderWidth), GraphicsUnit.Pixel);

                // Draw the bottom edge
                graphics.DrawImage(image, 0, newHeight - borderWidth, new Rectangle(0, image.Height - borderWidth, image.Width, borderWidth), GraphicsUnit.Pixel);

                // Draw the left border
                graphics.DrawImage(image, 0, borderWidth, new Rectangle(0, borderWidth, borderWidth, image.Height - borderWidth * 2), GraphicsUnit.Pixel);

                // Draw the right edge
                graphics.DrawImage(image, newWidth - borderWidth, borderWidth, new Rectangle(image.Width - borderWidth, borderWidth, borderWidth, image.Height - borderWidth * 2), GraphicsUnit.Pixel);
            }

            // Cut out the inner part of the picture
            Rectangle innerRect = new Rectangle(borderWidth, borderWidth, image.Width - borderWidth * 2, image.Height - borderWidth * 2);
            Bitmap innerImage = image.Clone(innerRect, image.PixelFormat);

            // Resize the inner part of the image with Bicubic Interpolation
            Bitmap resizedInnerImage = new Bitmap(newInnerWidth, newInnerHeight);
            using (Graphics graphics = Graphics.FromImage(resizedInnerImage))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bicubic;
                graphics.DrawImage(innerImage, 0, 0, newInnerWidth, newInnerHeight);
            }

            // Draw the enlarged inner part of the image onto the new bitmap
            using (Graphics graphics = Graphics.FromImage(result))
            {
                graphics.DrawImage(resizedInnerImage, borderWidth, borderWidth);
            }

            // Return the resulting image
            return result;
        }

        private TextBox GetBorderWidthTextBox()
        {
            // Check if the control already exists
            if (textBoxBorderWidth != null)
            {
                // Return the existing control
                return textBoxBorderWidth;
            }
            else
            {
                // The control was not found, so a search is performed in the form's controls
                foreach (Control control in Controls)
                {
                    // Check that it is a TextBox control and has the appropriate name
                    if (control is TextBox textBox && textBox.Name == "textBoxBorderWidth")
                    {
                        // Return the found control
                        return textBox;
                    }
                }
            }

            // Returns null if the control is not found
            return null;
        }

        private void buttonResize_Click(object sender, EventArgs e)
        {
            TextBox borderWidthTextBox = GetBorderWidthTextBox();

            if (borderWidthTextBox == null)
            {
                MessageBox.Show("The textBoxBorderWidth control was not found.");
                return;
            }

            // Check if an image is loaded in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Read the desired margin width value (e.g. from a TextBox control)
            int borderWidth;
            if (!int.TryParse(textBoxBorderWidth.Text, out borderWidth))
            {
                MessageBox.Show("Invalid border width value.");
                return;
            }

            // Copy the original image in the PictureBox
            Bitmap originalImage = new Bitmap(pictureBox1.Image);

            try
            {
                // Enlarge the image with a fixed margin
                Bitmap resizedImage = ResizeImageWithFixedBorder(originalImage, borderWidth);

                // Remove the current image in the PictureBox and set the enlarged image
                pictureBox1.Image = null;
                pictureBox1.Image = resizedImage;

                // update display
                Size imageSize = resizedImage.Size;
                labelImageSize.Text = $"image size: {imageSize.Width} x {imageSize.Height} Pixel";
            }
            catch (Exception ex)
            {
                // An error has occurred - display a message
                MessageBox.Show($"Error enlarging the image: {ex.Message}");
            }
        }

        private void ButtonRotateTexture_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Enhance image automatically
            Image enhancedImage = RotateeImage(pictureBox1.Image);

            // Replace the current image in the PictureBox with the improved image
            pictureBox1.Image = enhancedImage;

            // update display
            Size imageSize = enhancedImage.Size;
            labelImageSize.Text = $"image size: {imageSize.Width} x {imageSize.Height} Pixel";
        }

        private Image RotateeImage(Image image)
        {
            // Example: Only the image is rotated here
            Bitmap enhancedImage = new Bitmap(image);
            enhancedImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return enhancedImage;
        }

        private void ButtonAutoTexture_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Enhance image automatically
            Image enhancedImage = AutoEnhanceImage(pictureBox1.Image);

            // Replace the current image in the PictureBox with the improved image
            pictureBox1.Image = enhancedImage;

            // update display
            Size imageSize = enhancedImage.Size;
            labelImageSize.Text = $"image size: {imageSize.Width} x {imageSize.Height} Pixel";

        }

        private Image AutoEnhanceImage(Image image)
        {
            // color enhancement
            Bitmap enhancedImage = AdjustColors(image);

            return enhancedImage;
        }

        private Bitmap AdjustColors(Image image)
        {
            Bitmap bitmap = new Bitmap(image);

            // Implement color enhancement algorithm here

            // Example: Increase color saturation by 20%
            float saturationFactor = 1.2f;
            ImageAttributes attributes = new ImageAttributes();
            ColorMatrix colorMatrix = new ColorMatrix(new float[][] {
        new float[] { saturationFactor, 0, 0, 0, 0 },
        new float[] { 0, saturationFactor, 0, 0, 0 },
        new float[] { 0, 0, saturationFactor, 0, 0 },
        new float[] { 0, 0, 0, 1, 0 },
        new float[] { 0, 0, 0, 0, 1 }
    });
            attributes.SetColorMatrix(colorMatrix);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);

            return bitmap;
        }

        private void buttonWhite_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Enhance image automatically
            Bitmap image = new Bitmap(pictureBox1.Image);
            WhiteBalance(image);

            // Display the enhanced image in the PictureBox
            pictureBox1.Image = image;

            // update display
            Size imageSize = image.Size;
            labelImageSize.Text = $"Image Size: {imageSize.Width} x {imageSize.Height} Pixel";
        }

        private void WhiteBalance(Bitmap bitmap)
        {
            // White balance calculation code here

            // Example: white balance with fixed values
            int red = 200; // valid value between 0 and 255
            int green = 200; // valid value between 0 and 255
            int blue = 200; // valid value between 0 and 255

            if (red < 0 || red > 255)
            {
                // Handling of the invalid red value
                // Here you can implement appropriate error handling, e.g. B. use a default color or throw an exception.
                // Example: red = 255; // Default color white
            }

            if (green < 0 || green > 255)
            {
                // Handling of the invalid green value
            }

            if (blue < 0 || blue > 255)
            {
                // Handling of the invalid blue value
            }

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);

                    // Calculate new RGB values ​​after white balance
                    int newRed = (pixelColor.R * red) / 255;
                    int newGreen = (pixelColor.G * green) / 255;
                    int newBlue = (pixelColor.B * blue) / 255;

                    // Update pixels with the new RGB values
                    bitmap.SetPixel(x, y, Color.FromArgb(newRed, newGreen, newBlue));
                }
            }
        }

        private void button45Degrees_Click(object sender, EventArgs e)
        {
            // Check if an image is loaded in the PictureBox
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image was loaded.");
                return;
            }

            // Resize the image to 33x33 pixels if it hasn't been resized yet
            if (resizedImage == null)
            {
                resizedImage = new Bitmap(pictureBox1.Image, new Size(33, 33));
            }

            // Rotate the resized image by -45 degrees
            Image rotatedImage = RotateImageByAngle(resizedImage, -45);

            // Create a new Bitmap with size 44x44 and black background
            Bitmap newBackground = new Bitmap(44, 44);
            using (Graphics graphics = Graphics.FromImage(newBackground))
            {
                graphics.Clear(Color.Black);

                // Calculate the coordinates to center the rotated image within the 44x44 frame
                int x = (newBackground.Width - rotatedImage.Width) / 2;
                int y = (newBackground.Height - rotatedImage.Height) / 2;

                // Draw the rotated image onto the new background graphic
                graphics.DrawImage(rotatedImage, x, y);
            }

            // Display the new image in the PictureBox
            pictureBox1.Image = newBackground;

            // Free the previous image (optional to free up memory)
            resizedImage.Dispose();

            // Reset the resized image as a new image has now been loaded
            resizedImage = null;

            // Refresh the display
            Size imageSize = newBackground.Size;
            labelImageSize.Text = $"image size: {imageSize.Width} x {imageSize.Height} Pixel";
        }

        private Image RotateImageByAngle(Image image, float angle)
        {
            // Calculate the size of the new Bitmap
            int bitmapSize = (int)Math.Ceiling(Math.Sqrt(image.Width * image.Width + image.Height * image.Height));

            // Create a new Bitmap with the calculated size
            Bitmap rotatedImage = new Bitmap(bitmapSize, bitmapSize);

            // Create a Graphics instance to draw the image
            using (Graphics graphics = Graphics.FromImage(rotatedImage))
            {
                // Set the rotation
                graphics.TranslateTransform(rotatedImage.Width / 2, rotatedImage.Height / 2);
                graphics.RotateTransform(angle);
                graphics.TranslateTransform(-rotatedImage.Width / 2, -rotatedImage.Height / 2);

                // Draw the image centered within the Bitmap
                graphics.DrawImage(image, (bitmapSize - image.Width) / 2, (bitmapSize - image.Height) / 2);
            }

            return rotatedImage;
        }
        #region Copy to Clipbord Image        

        private void copyClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Make a copy of the picture in pictureBox1
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Verify that valid color values ​​were entered in the textBoxColorAdress and textBoxColorToAdress
                if (IsValidColor(textBoxColorAdress.Text) && IsValidColor(textBoxColorToAdress.Text))
                {
                    // Add the # to the color code if it's not already there
                    string fromColorCode = textBoxColorAdress.Text;
                    if (!fromColorCode.StartsWith("#"))
                    {
                        fromColorCode = "#" + fromColorCode;
                    }

                    string toColorCode = textBoxColorToAdress.Text;
                    if (!toColorCode.StartsWith("#"))
                    {
                        toColorCode = "#" + toColorCode;
                    }

                    // Convert the entered color values ​​into Color objects
                    Color fromColor = ColorTranslator.FromHtml(fromColorCode);
                    Color toColor = ColorTranslator.FromHtml(toColorCode);

                    // Replace the color value in the image
                    ReplaceColor(image, fromColor, toColor);
                }

                // Verify that a valid color value was entered in the textBoxColorErase
                if (IsValidColor(textBoxColorErase.Text))
                {
                    // Add the # to the color code if it's not already there
                    string eraseColorCode = textBoxColorErase.Text;
                    if (!eraseColorCode.StartsWith("#"))
                    {
                        eraseColorCode = "#" + eraseColorCode;
                    }

                    // Convert the entered color value to a Color object
                    Color eraseColor = ColorTranslator.FromHtml(eraseColorCode);

                    // Replace the color value in the image with white
                    ReplaceWithWhite(image, eraseColor);
                }

                // Copy the image to the clipboard
                Clipboard.SetImage(image);
            }
        }
        private void importClipbordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Überprüfen Sie, ob sich ein Bild in der Zwischenablage befindet
            if (Clipboard.ContainsImage())
            {
                // Fügen Sie das Bild aus der Zwischenablage in die PictureBox ein
                pictureBox1.Image = Clipboard.GetImage();

                // Speichern Sie das ursprüngliche Bild und seine Größe
                originalImage = new Bitmap(pictureBox1.Image);
                originalSize = pictureBox1.Image.Size;
            }
        }

        //Old function that sets to transparent not active
        private void MakeTransparent(Bitmap image, Color color)
        {
            // Loop through each pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Check if the pixel is the color you want to erase
                    if (image.GetPixel(x, y) == color)
                    {
                        // Set the pixel to transparent
                        image.SetPixel(x, y, Color.Transparent);
                    }
                }
            }
        }
        //replaces the color with the given one
        private void ReplaceColor(Bitmap image, Color fromColor, Color toColor)
        {
            // Loop through each pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Verify that the pixel is the color to be replaced
                    if (image.GetPixel(x, y) == fromColor)
                    {
                        // Set the pixel to the new color
                        image.SetPixel(x, y, toColor);
                    }
                }
            }
        }

        //Replaces the color with ffffff
        private void ReplaceWithWhite(Bitmap image, Color color)
        {
            // Loop through each pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Verify that the pixel is the color to be replaced
                    if (image.GetPixel(x, y) == color)
                    {
                        // Set the pixel to white
                        image.SetPixel(x, y, Color.White);
                    }
                }
            }
        }
        #endregion

        #region Textbox Color
        private void textBoxColorAdress_TextChanged(object sender, EventArgs e)
        {
            // Verify that the text you entered is a valid color value
            if (textBoxColorAdress.Text.Length == 7 && !IsValidColor(textBoxColorAdress.Text))
            {
                // The text you entered is not a valid color value - display an error message
                MessageBox.Show("Please enter a valid color value.");
            }
        }
        private void textBoxColorToAdress_TextChanged(object sender, EventArgs e)
        {
            // Verify that the text you entered is a valid color value
            if (textBoxColorToAdress.Text.Length == 7 && !IsValidColor(textBoxColorToAdress.Text))
            {
                // The text you entered is not a valid color value - display an error message
                MessageBox.Show("Please enter a valid color value.");
            }
        }

        private void textBoxColorErase_TextChanged(object sender, EventArgs e)
        {
            // Verify that the text you entered is a valid color value
            if (textBoxColorErase.Text.Length == 7 && !IsValidColor(textBoxColorErase.Text))
            {
                // The text you entered is not a valid color value - display an error message
                MessageBox.Show("Please enter a valid color value.");
            }
        }
        private bool IsValidColor(string color)
        {
            // Check if the color value starts with a #
            if (color.StartsWith("#"))
            {
                // Remove the # from the beginning of the color value
                color = color.Substring(1);
            }

            // Verify that the color value is 6 characters long
            if (color.Length == 6)
            {
                // Verify that all characters are valid hexadecimal characters
                for (int i = 0; i < color.Length; i++)
                {
                    if (!IsHexChar(color[i]))
                    {
                        return false;
                    }
                }

                // The color value is valid
                return true;
            }

            // The color value is invalid
            return false;
        }
        private bool IsHexChar(char c)
        {
            return (c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f');
        }
        #endregion

        #region Checkbox
        private void checkBoxChange_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the checkBoxChange is checked
            if (checkBoxChange.Checked)
            {
                // Transfer the value of comboBoxColorValue to textBoxColorToAdress
                textBoxColorToAdress.Text = comboBoxColorValue.Text;
            }
        }
        private void comboBoxColorValue_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if the checkBoxChange is checked
            if (checkBoxChange.Checked)
            {
                // Transfer the value of comboBoxColorValue to textBoxColorToAdress
                textBoxColorToAdress.Text = comboBoxColorValue.Text;
            }

            // Check if the checkBoxChange is checked
            if (checkBoxDelete.Checked)
            {
                // Transfer the value of comboBoxColorValue to textBoxColorToAdress
                textBoxColorErase.Text = comboBoxColorValue.Text;
            }
        }
        #endregion

        #region To Update
        private void btToUpdate_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Create a copy of the image in pictureBox1.
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Check if valid color values have been entered in both textBoxColorAdress and textBoxColorToAdress.
                if (IsValidColor(textBoxColorAdress.Text) && IsValidColor(textBoxColorToAdress.Text))
                {
                    // Add the "#" symbol to the color code if it's not already present.
                    string fromColorCode = textBoxColorAdress.Text;
                    if (!fromColorCode.StartsWith("#"))
                    {
                        fromColorCode = "#" + fromColorCode;
                    }

                    string toColorCode = textBoxColorToAdress.Text;
                    if (!toColorCode.StartsWith("#"))
                    {
                        toColorCode = "#" + toColorCode;
                    }

                    // Convert the entered color values into Color objects.
                    Color fromColor = ColorTranslator.FromHtml(fromColorCode);
                    Color toColor = ColorTranslator.FromHtml(toColorCode);


                    int tolerance = 0;
                    if (checkBoxtoleranz5.Checked) tolerance = 13; // 5% von 255
                    else if (checkBoxtoleranz10.Checked) tolerance = 26; // 10% von 255
                    else if (checkBoxtoleranz15.Checked) tolerance = 38; // 15% von 255
                    else if (checkBoxtoleranz25.Checked) tolerance = 64; // 25% von 255
                    else if (checkBoxtoleranz30.Checked) tolerance = 77; // 30% von 255
                    else if (checkBoxtoleranz35.Checked) tolerance = 89; // 35% von 255
                    else if (checkBoxtoleranz50.Checked) tolerance = 127; // 50% von 255
                    else if (checkBoxtoleranz75.Checked) tolerance = 191; // 75% von 255
                    else if (checkBoxtoleranz100.Checked) tolerance = 255; // 100% von 255
                    // Replace the color value in the image.
                    ReplaceColorWithTolerance(image, fromColor, toColor, tolerance);
                }

                // Check if a valid color value has been entered in the textBoxColorErase.
                if (IsValidColor(textBoxColorErase.Text))
                {
                    // Add the "#" symbol to the color code if it's not already present.
                    string eraseColorCode = textBoxColorErase.Text;
                    if (!eraseColorCode.StartsWith("#"))
                    {
                        eraseColorCode = "#" + eraseColorCode;
                    }

                    // Convert the entered color value into a Color object.
                    Color eraseColor = ColorTranslator.FromHtml(eraseColorCode);

                    // Replace the color value in the image with white.
                    ReplaceWithWhite(image, eraseColor);
                }

                // Update the image in pictureBox1.
                pictureBox1.Image = image;

                // Update the originalImage object
                originalImage = new Bitmap(image);
            }
        }
        #endregion

        #region Keydown
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Ctrl+V was pressed.
            if (e.Control && e.KeyCode == Keys.X)
            {
                // Invoke the copyClipboardToolStripMenuItem_Click method.
                copyClipboardToolStripMenuItem_Click(sender, e);
            }
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Invoke the importClipbordToolStripMenuItem_Click method.
                importClipbordToolStripMenuItem_Click(sender, e);
            }
        }
        #endregion

        #region Pipette
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            // Check if the dropper mode is activated.
            if (isPickingColor)
            {
                // Check if there is an image in pictureBox1.
                if (pictureBox1.Image != null)
                {
                    // Convert the mouse coordinates to image coordinates.
                    int x = e.X * pictureBox1.Image.Width / pictureBox1.Width;
                    int y = e.Y * pictureBox1.Image.Height / pictureBox1.Height;

                    // Create a copy of the image in pictureBox1.
                    Bitmap image = new Bitmap(pictureBox1.Image);

                    // Check if the coordinates are within the image bounds.
                    if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                    {
                        // Retrieve the color value of the pixel at the specified coordinates.
                        Color color = image.GetPixel(x, y);

                        // Convert the color value to a hexadecimal code.
                        string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                        // Set the color code in the textBoxColorAdress.
                        textBoxColorAdress.Text = colorCode;
                    }
                }

                // Disable eyedropper mode
                isPickingColor = false;
            }
        }

        private void btPickColor_Click(object sender, EventArgs e)
        {
            // Activate eyedropper mode
            isPickingColor = true;
        }
        #endregion
        #region Mirror
        private void BtMirroImage_Click(object sender, EventArgs e)
        {
            // Check if there is an image in pictureBox1.
            if (pictureBox1.Image != null)
            {
                // Create a copy of the image in pictureBox1.
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Mirror the image horizontally.
                image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                // Update the image in pictureBox1.
                pictureBox1.Image = image;
            }
        }
        #endregion

        #region Zoom
        private void zoomInButton_Click(object sender, EventArgs e)
        {
            // Check that the Image object is not null
            if (originalImage != null)
            {
                //  Enlarge
                pictureBox1.Image = new Bitmap(originalImage, new Size(pictureBox1.Image.Width + 10, pictureBox1.Image.Height + 10));
            }
        }

        private void zoomOutButton_Click(object sender, EventArgs e)
        {
            // zoom out
            pictureBox1.Image = new Bitmap(originalImage, new Size(pictureBox1.Image.Width - 10, pictureBox1.Image.Height - 10));
        }
        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check whether the mouse wheel has been rotated up or down
            if (e.Delta > 0)
            {
                // Enlarge
                pictureBox1.Image = new Bitmap(originalImage, new Size(pictureBox1.Image.Width + 10, pictureBox1.Image.Height + 10));
            }
            else
            {
                // zoom out
                pictureBox1.Image = new Bitmap(originalImage, new Size(pictureBox1.Image.Width - 10, pictureBox1.Image.Height - 10));
            }
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            // Resize the image in the PictureBox to its original size
            pictureBox1.Image = new Bitmap(originalImage, originalSize);
        }
        #endregion

        #region Color Dialog
        private void selectColorButton_Click(object sender, EventArgs e)
        {
            // Create a new ColorDialog object
            ColorDialog colorDialog = new ColorDialog();

            // Restore the custom colors, if any
            if (customColors != null)
            {
                colorDialog.CustomColors = customColors;
            }

            // Display the ColorDialog and verify that the user clicked OK
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // Convert the selected color to a hexadecimal code
                string colorCode = "#" + colorDialog.Color.R.ToString("X2") + colorDialog.Color.G.ToString("X2") + colorDialog.Color.B.ToString("X2");

                // Put the color code in the textBoxColorToAdress
                textBoxColorToAdress.Text = colorCode;

                // Save the custom colors
                customColors = colorDialog.CustomColors;
            }
        }
        #endregion
        #region Coordinates of the mouse cursor.
        /*private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Checking if an image has been loaded in the PictureBox.
            if (pictureBox1.Image != null)
            {
                // Converting the mouse coordinates to image coordinates.
                int x = e.X * pictureBox1.Image.Width / pictureBox1.Width;
                int y = e.Y * pictureBox1.Image.Height / pictureBox1.Height;

                // Creating a copy of the image in pictureBox1.
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Checking if the coordinates are within the image boundaries.
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    // Retrieving the color value of the pixel at the specified coordinates.
                    Color color = image.GetPixel(x, y);

                    // Converting the color value to a hexadecimal code.
                    string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                    // Setting the color code in the label control.
                    colorLabel.Text = colorCode;
                }
            }

            // Displaying the coordinates of the mouse cursor in the label.
            coordinatesLabel.Text = $"X: {e.X}, Y: {e.Y}";
        }*/

        /*private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Überprüfen Sie, ob ein Bild in der PictureBox geladen wurde
            if (pictureBox1.Image != null)
            {
                // Konvertieren Sie die Mauskoordinaten in Bildkoordinaten
                int x = e.X * pictureBox1.Image.Width / pictureBox1.Width;
                int y = e.Y * pictureBox1.Image.Height / pictureBox1.Height;

                // Erstellen Sie eine Kopie des Bildes in pictureBox1
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Überprüfen Sie, ob die Koordinaten innerhalb der Bildgrenzen liegen
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    // Abrufen des Farbwerts des Pixels an den angegebenen Koordinaten
                    Color color = image.GetPixel(x, y);

                    // Konvertieren Sie den Farbwert in einen Hexadezimalcode
                    string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                    // Setzen Sie den Farbcode im Label-Steuerelement
                    colorLabel.Text = colorCode;
                }
            }            
        }*/

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            // Überprüfen Sie, ob ein Bild in der PictureBox geladen wurde
            if (pictureBox1.Image != null)
            {
                // Konvertieren Sie die Mauskoordinaten in Bildkoordinaten
                int x = e.X * pictureBox1.Image.Width / pictureBox1.Width;
                int y = e.Y * pictureBox1.Image.Height / pictureBox1.Height;

                // Erstellen Sie eine Kopie des Bildes in pictureBox1
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Überprüfen Sie, ob die Koordinaten innerhalb der Bildgrenzen liegen
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    // Abrufen des Farbwerts des Pixels an den angegebenen Koordinaten
                    Color color = image.GetPixel(x, y);

                    // Konvertieren Sie den Farbwert in einen Hexadezimalcode
                    string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                    // Setzen Sie den Farbcode im Label-Steuerelement
                    colorLabel.Text = colorCode;
                }
            }

            // Überprüfen Sie, ob der Löschmodus aktiviert ist und ob die linke Maustaste gedrückt wird
            if (isErasing && e.Button == MouseButtons.Left)
            {
                // Erstellen Sie eine Kopie des Bildes in pictureBox1
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Erstellen Sie ein Graphics-Objekt aus dem Bild
                using (Graphics g = Graphics.FromImage(image))
                {
                    // Löschen Sie einen Bereich um die aktuelle Mausposition
                    g.FillEllipse(Brushes.White, e.X - 5, e.Y - 5, 10, 10);
                }

                // Aktualisieren Sie das Bild in pictureBox1
                pictureBox1.Image = image;
            }
            else if (isDrawing && e.Button == MouseButtons.Left)
            {
                // Erstellen Sie eine Kopie des Bildes in pictureBox1
                Bitmap image = new Bitmap(pictureBox1.Image);

                // Erstellen Sie ein Graphics-Objekt aus dem Bild
                using (Graphics g = Graphics.FromImage(image))
                {
                    // Konvertieren Sie den Text in textBoxColorToAdress in einen Farbwert
                    Color penColor = ColorTranslator.FromHtml(textBoxColorToAdress.Text);

                    // Erstellen Sie einen Stift mit der angegebenen Farbe
                    Pen pen = new Pen(penColor);

                    // Zeichnen Sie eine Linie von der letzten Position zur aktuellen Position
                    g.DrawLine(pen, lastPoint.X, lastPoint.Y, e.X, e.Y);
                }

                // Aktualisieren Sie das Bild in pictureBox1
                pictureBox1.Image = image;

                // Setzen Sie den letzten Punkt auf die aktuelle Position
                lastPoint = e.Location;
            }
            else if (e.Button == MouseButtons.None)
            {
                // Setzen Sie den letzten Punkt auf die aktuelle Position
                lastPoint = e.Location;
            }
            // Displaying the coordinates of the mouse cursor in the label.
            coordinatesLabel.Text = $"X: {e.X}, Y: {e.Y}";
        }
        #endregion

        #region indexed colors
        private void convertToIndexedButton_Click(object sender, EventArgs e)
        {
            // Check if there is an image on the clipboard
            if (Clipboard.ContainsImage())
            {
                // Paste the image from the clipboard into the PictureBox
                Bitmap source = new Bitmap(Clipboard.GetImage());
                pictureBox1.Image = source;

                // Convert the image to indexed colors
                Bitmap result = source.Clone(new Rectangle(0, 0, source.Width, source.Height), PixelFormat.Format8bppIndexed);

                // Update the image in the PictureBox
                pictureBox1.Image = result;
            }
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            // Switch to drawing mode
            isDrawing = true;

            // Disable delete mode
            isErasing = false;

            drawButton.FlatAppearance.MouseDownBackColor = Color.Red;
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check whether drawing mode is activated
            if (isDrawing)
            {
                // Set the last point to the current mouse position
                lastPoint = e.Location;
            }
        }

        private void eraseButton_Click(object sender, EventArgs e)
        {
            // Enter delete mode
            isErasing = true;

            // Disable drawing mode
            isDrawing = false;

            eraseButton.FlatAppearance.MouseDownBackColor = Color.Red;
        }

        #endregion

        #region ColorWithTolerance
        private void ReplaceColorWithTolerance(Bitmap image, Color fromColor, Color toColor, int tolerance)
        {
            // Loop through every pixel in the image
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    // Check whether the pixel is within the tolerance range of the color to be replaced
                    Color pixelColor = image.GetPixel(x, y);
                    if (IsWithinTolerance(pixelColor, fromColor, tolerance))
                    {
                        // Set the pixel to the new color
                        image.SetPixel(x, y, toColor);
                    }
                }
            }
        }

        private bool IsWithinTolerance(Color color1, Color color2, int tolerance)
        {
            int rDiff = Math.Abs(color1.R - color2.R);
            int gDiff = Math.Abs(color1.G - color2.G);
            int bDiff = Math.Abs(color1.B - color2.B);

            // Check whether the difference in each color channel is within tolerance
            return rDiff <= tolerance && gDiff <= tolerance && bDiff <= tolerance;
        }
        #endregion

        #region Color Evaluate
        private Form colorForm = null;
        private Label mostCommonColorLabel = null;

        private void btEvaluateColor_Click(object sender, EventArgs e)
        {
            if (colorForm != null && !colorForm.IsDisposed)
            {
                colorForm.Close();
            }

            if (pictureBox1.Image != null)
            {
                Bitmap image = new Bitmap(pictureBox1.Image);
                Dictionary<string, int> colors = new Dictionary<string, int>();
                for (int x = 0; x < image.Width; x++)
                {
                    for (int y = 0; y < image.Height; y++)
                    {
                        Color color = image.GetPixel(x, y);
                        string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
                        if (colorCode == "#FFFFFF" || colorCode == "#000000") continue;
                        if (colors.ContainsKey(colorCode))
                        {
                            colors[colorCode]++;
                        }
                        else
                        {
                            colors.Add(colorCode, 1);
                        }
                    }
                }
                var sortedColors = from pair in colors orderby pair.Value descending select pair;
                int totalPixels = image.Width * image.Height;
                colorForm = new Form();
                colorForm.Text = "Evaluate Color";

                colorForm.ShowIcon = false;

                mostCommonColorLabel = new Label();
                mostCommonColorLabel.Dock = DockStyle.Top;

                Button refreshButton = new Button();
                refreshButton.Text = "Refresh";
                refreshButton.Dock = DockStyle.Top;
                refreshButton.Click += btEvaluateColor_Click;

                TreeView treeView = new TreeView();
                treeView.Dock = DockStyle.Fill;

                // Setzen Sie DrawMode auf OwnerDrawAll
                treeView.DrawMode = TreeViewDrawMode.OwnerDrawAll;

                treeView.DrawNode += (s, evt) =>
                {
                    evt.DrawDefault = false;
                    using (var brush = new SolidBrush(ColorTranslator.FromHtml(evt.Node.Text.Split(' ')[0])))
                    {
                        var rect = new Rectangle(evt.Bounds.Left + 2, evt.Bounds.Top + 2, evt.Bounds.Height - 4, evt.Bounds.Height - 4);
                        evt.Graphics.FillRectangle(brush, rect);
                    }

                    // Set DrawMode to OwnerDrawAll
                    Color textColor = Color.Black;

                    // With the node selected, change the background color
                    if ((evt.State & TreeNodeStates.Selected) != 0)
                    {
                        using (var brush = new SolidBrush(Color.FromArgb(128, Color.LightBlue))) // Change this to the highlight color you want
                        {
                            evt.Graphics.FillRectangle(brush, new Rectangle(0, evt.Node.Bounds.Top, treeView.Width, evt.Node.Bounds.Height));
                        }
                    }

                    TextRenderer.DrawText(evt.Graphics, evt.Node.Text, evt.Node.TreeView.Font,
                        new Rectangle(evt.Bounds.Left + evt.Bounds.Height, evt.Bounds.Top, evt.Bounds.Width - evt.Bounds.Height, evt.Bounds.Height),
                        textColor);
                };


                treeView.NodeMouseClick += (s, evt) =>
                {
                    string hexCode = evt.Node.Text.Split(' ')[0];
                    textBoxColorAdress.Text = hexCode;
                    Clipboard.SetText(hexCode);
                };

                int count = 0;
                foreach (KeyValuePair<string, int> pair in sortedColors)
                {
                    if (count >= 20) break;
                    double percentage = (double)pair.Value / totalPixels * 100;
                    string nodeText = pair.Key + " - " + percentage.ToString("F2") + "%";
                    TreeNode colorNode = new TreeNode(nodeText);
                    treeView.Nodes.Add(colorNode);

                    if (count == 0)
                    {
                        mostCommonColorLabel.Text = "Most common color: " + pair.Key;
                    }

                    count++;
                }

                colorForm.Controls.Add(treeView);
                colorForm.Controls.Add(refreshButton);
                colorForm.Controls.Add(mostCommonColorLabel);

                colorForm.Show();
            }
        }

        #endregion

        #region Color List
        // Global variable to store the form
        Form colorListForm = null;

        private void btcolorlistimage_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (colorListForm != null)
            {
                // The form is already open, so just return
                return;
            }

            // Check whether an image has been loaded in the PictureBox
            if (pictureBox1.Image != null)
            {
                // Create a new shape
                colorListForm = new Form();
                colorListForm.Text = "Color List";
                colorListForm.FormClosed += (s, e) => { colorListForm = null; };

                // Create a TreeView and add it to the shape
                TreeView treeView = new TreeView();
                treeView.Dock = DockStyle.Fill;
                colorListForm.Controls.Add(treeView);

                // Create a label to display the total number of colors
                Label label = new Label();
                label.Dock = DockStyle.Top;
                colorListForm.Controls.Add(label);

                // Function to load the colors from the image
                Action loadColors = () =>
                {
                    // Delete all existing nodes in the TreeView
                    treeView.Nodes.Clear();

                    // Make a copy of the image in pictureBox1
                    Bitmap image = new Bitmap(pictureBox1.Image);

                    // Create a HashSet to store the unique colors in the image
                    HashSet<string> uniqueColors = new HashSet<string>();

                    // Create a list to store the colors and their brightness values
                    List<Tuple<string, float>> colors = new List<Tuple<string, float>>();

                    // Loop through every pixel in the image
                    for (int x = 0; x < image.Width; x++)
                    {
                        for (int y = 0; y < image.Height; y++)
                        {
                            // Get the color value of the pixel at the specified coordinates
                            Color color = image.GetPixel(x, y);

                            // Convert the color value to a hexadecimal code
                            string colorCode = "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");

                            // Check if the color code already exists in the HashSet
                            if (!uniqueColors.Contains(colorCode))
                            {
                                // If not, add it to the HashSet and List
                                uniqueColors.Add(colorCode);

                                // Convert the RGB color value to an HSL value and get the brightness
                                float brightness = color.GetBrightness();

                                // Add the color code and brightness to the list
                                colors.Add(new Tuple<string, float>(colorCode, brightness));
                            }
                        }
                    }

                    // Sort the list by the brightness of the colors in reverse order
                    colors.Sort((a, b) => b.Item2.CompareTo(a.Item2));

                    // Add all color codes to the TreeView
                    foreach (var color in colors)
                    {
                        TreeNode node = new TreeNode();
                        node.Text = color.Item1;
                        node.BackColor = ColorTranslator.FromHtml(color.Item1);
                        treeView.Nodes.Add(node);
                    }

                    // Update the label with the total number of colors
                    label.Text = "Total unique colors: " + colors.Count;
                };

                // Load the colors when you first open the form
                loadColors();

                // Highlight the node when hovering over it with the mouse
                treeView.NodeMouseHover += (s, e) =>
                {
                    treeView.SelectedNode = e.Node;
                };

                // Create a button and add it to the shape
                Button buttonSendToTextBoxColorAdress = new Button();
                buttonSendToTextBoxColorAdress.Text = "Send ColorAdress";
                buttonSendToTextBoxColorAdress.Dock = DockStyle.Bottom;

                buttonSendToTextBoxColorAdress.Click += (s, e) =>
                {
                    // Check if an item is selected
                    if (treeView.SelectedNode != null)
                    {
                        // Take the selected text from the TreeView
                        string selectedColor = treeView.SelectedNode.Text;

                        // Put the text in textBoxColorAdress
                        textBoxColorAdress.Text = selectedColor;
                    }
                };

                colorListForm.Controls.Add(buttonSendToTextBoxColorAdress);

                // Create a btToUpdate button and add it to the shape
                Button buttonBtToUpdate = new Button();
                buttonBtToUpdate.Text = "Update";
                buttonBtToUpdate.Dock = DockStyle.Bottom;

                buttonBtToUpdate.Click += btToUpdate_Click;

                colorListForm.Controls.Add(buttonBtToUpdate);

                // Create an update button and add it to the shape
                Button buttonRefresh = new Button();
                buttonRefresh.Text = "Refresh List";
                buttonRefresh.Dock = DockStyle.Bottom;

                buttonRefresh.Click += (s, e) =>
                {
                    loadColors();
                };

                colorListForm.Controls.Add(buttonRefresh);

                // Display the shape
                colorListForm.Show();
            }
        }
        #endregion

        #region Modus

        private Form colorChangeForm; // Instance variable for the shape
        private void btModusColorChange_Click(object sender, EventArgs e)
        {
            // Check if the shape already exists
            if (colorChangeForm != null && colorChangeForm.Visible)
            {
                // The shape is already open, so bring it to the foreground
                colorChangeForm.BringToFront();
            }
            else
            {
                // The form does not exist or has been closed, so create a new one
                colorChangeForm = new Form();

                colorChangeForm.Size = new Size(250, 400); // Default is 800 pixels wide and 600 pixels high

                // Set the title of the form
                colorChangeForm.Text = "Modus";

                // Remove the icon
                colorChangeForm.ShowIcon = false;

                // Add the FormClosing event handler
                colorChangeForm.FormClosing += (s, e) =>
                {
                    e.Cancel = true;  // Prevents the mold from closing
                    colorChangeForm.Hide();  // Instead, hides the shape
                };

                // Create the checkbox
                RadioButton grayscaleCheckbox = new RadioButton();
                grayscaleCheckbox.Text = "Grayscale";
                grayscaleCheckbox.Location = new Point(10, 10); // Set position

                // Create the TrackBar to change brightness
                TrackBar brightnessTrackBar = new TrackBar();
                brightnessTrackBar.Location = new Point(10, 40); // Set position
                brightnessTrackBar.Minimum = -100;
                brightnessTrackBar.Maximum = 100;

                // Create the TrackBar to change contrast
                TrackBar contrastTrackBar = new TrackBar();
                contrastTrackBar.Location = new Point(10, 85); // Set position
                contrastTrackBar.Minimum = -100;
                contrastTrackBar.Maximum = 100;
                contrastTrackBar.Value = 0; // Set the initial value to 0

                // Create the TrackBar for gamma correction
                TrackBar gammaTrackBar = new TrackBar();
                gammaTrackBar.Location = new Point(10, 130); // Set position
                gammaTrackBar.Minimum = -97;
                gammaTrackBar.Maximum = 400;
                gammaTrackBar.Value = 0; // Set the initial value to 0

                // Create the Saturation TrackBar
                TrackBar saturationTrackBar = new TrackBar();
                saturationTrackBar.Location = new Point(10, 175); // Set position
                saturationTrackBar.Minimum = -100;
                saturationTrackBar.Maximum = 100;
                saturationTrackBar.Value = 0; // Set the initial value to 0

                // Create the TrackBar for color change
                TrackBar colorTrackBar = new TrackBar();
                colorTrackBar.Location = new Point(10, 220); // Set position
                colorTrackBar.Minimum = -180;
                colorTrackBar.Maximum = 180;
                colorTrackBar.Value = 0; // Set the initial value to 0

                // Create the label to display the current value of the TrackBar
                Label brightnessLabel = new Label();
                brightnessLabel.Location = new Point(120, 40); // Set position 40 is height 120 from the right

                // Create the label to display the current value of the TrackBar
                Label contrastLabel = new Label();
                contrastLabel.Location = new Point(120, 85); // Set position

                // Create the label to display the current value of the TrackBar
                Label gammaLabel = new Label();
                gammaLabel.Location = new Point(120, 130); // Set position

                // Create the label to display the current value of the TrackBar
                Label saturationLabel = new Label();
                saturationLabel.Location = new Point(120, 175); // Set position

                // Create the label to display the current value of the TrackBar
                Label colorLabel = new Label();
                colorLabel.Location = new Point(120, 220); // Set position

                // Add an event handler to change brightness in real time
                brightnessTrackBar.Scroll += (s, e) =>
                {
                    if (originalImage != null)
                    {
                        Bitmap image = new Bitmap(originalImage);

                        // Change the brightness of the image
                        float brightness = brightnessTrackBar.Value * 0.01f;
                        float[][] ptsArray ={
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1.0f, 0},
                    new float[] {brightness, brightness, brightness, 1.0f, 1}
                        };
                        ImageAttributes attributes = new ImageAttributes();
                        attributes.ClearColorMatrix();
                        attributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        Graphics g = Graphics.FromImage(image);
                        g.DrawImage(image,
                            new Rectangle(0, 0, image.Width, image.Height),
                            0,
                            0,
                            image.Width,
                            image.Height,
                            GraphicsUnit.Pixel,
                            attributes);

                        pictureBox1.Image = image;

                        // Update the label with the current value of the TrackBar
                        brightnessLabel.Text = "Brightness: " + brightnessTrackBar.Value.ToString();
                    }
                };

                // Add an event handler to change the contrast in real time
                contrastTrackBar.Scroll += (s, e) =>
                {
                    if (originalImage != null)
                    {
                        Bitmap image = new Bitmap(originalImage);
                        // Change the contrast of the image
                        float contrast = (contrastTrackBar.Value + 100) * 0.01f;
                        float[][] ptsArray ={
                    new float[] {contrast, 0, 0, 0, 0},
                    new float[] {0, contrast, 0, 0, 0},
                    new float[] {0, 0, contrast, 0, 0},
                    new float[] {0, 0, 0, 1.0f, 0},
                    new float[] {0.001f, 0.001f, 0.001f, 1.0f, 1}
                };
                        ImageAttributes attributes = new ImageAttributes();
                        attributes.ClearColorMatrix();
                        attributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                        Graphics g = Graphics.FromImage(image);
                        g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height), 0, 0,
                            image.Width, image.Height,
                            GraphicsUnit.Pixel,
                            attributes);
                        pictureBox1.Image = image;

                        // Update the label with the current value of the TrackBar
                        contrastLabel.Text = "Contrast: " + contrastTrackBar.Value.ToString();

                    }
                };

                // Method of adjusting the gamma value of an image
                Bitmap AdjustGamma(Image image, float gamma)
                {
                    Bitmap adjustedImage = new Bitmap(image.Width, image.Height);
                    Graphics g = Graphics.FromImage(adjustedImage);
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetGamma(gamma);
                    g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                                0, 0, image.Width, image.Height,
                                GraphicsUnit.Pixel, attributes);
                    return adjustedImage;
                }

                // Add an event handler to change gamma correction in real time
                gammaTrackBar.Scroll += (s, e) => {
                    if (originalImage != null)
                    {
                        Bitmap image = new Bitmap(originalImage);
                        // Change the gamma of the image
                        float gamma = 1.0f + gammaTrackBar.Value * 0.01f; // Adjust gamma value
                        Bitmap adjustedImage = AdjustGamma(image, gamma);
                        pictureBox1.Image = adjustedImage;
                        // Update the label with the current value of the TrackBar
                        gammaLabel.Text = "Gamma: " + gammaTrackBar.Value.ToString();
                    }
                };

                // Add an event handler to change saturation in real time
                saturationTrackBar.Scroll += (s, e) => {
                    if (originalImage != null)
                    {
                        Bitmap image = new Bitmap(originalImage);
                        // Change the saturation of the image
                        float saturation = 1.0f + saturationTrackBar.Value * 0.01f; // Adjust saturation value
                        for (int y = 0; y < image.Height; y++)
                        {
                            for (int x = 0; x < image.Width; x++)
                            {
                                Color originalColor = image.GetPixel(x, y);
                                float grayScale = (originalColor.R * 0.3f) + (originalColor.G * 0.59f) + (originalColor.B * 0.11f);
                                int r = Clamp((int)(grayScale + saturation * (originalColor.R - grayScale)));
                                int g = Clamp((int)(grayScale + saturation * (originalColor.G - grayScale)));
                                int b = Clamp((int)(grayScale + saturation * (originalColor.B - grayScale)));
                                Color newColor = Color.FromArgb(r, g, b);
                                image.SetPixel(x, y, newColor);
                            }
                        }
                        pictureBox1.Image = image;
                        // Update the label with the current value of the TrackBar
                        saturationLabel.Text = "Saturation: " + saturationTrackBar.Value.ToString();
                    }

                    // Method for limiting values ​​between 0 and 255
                    int Clamp(int value)
                    {
                        if (value < 0) return 0;
                        if (value > 255) return 255;
                        return value;
                    }
                };

                // Add an event handler to change the color in real time
                colorTrackBar.Scroll += (sender, eventArgs) => {
                    if (originalImage != null)
                    {
                        Bitmap image = new Bitmap(originalImage);
                        // Change the color of the image
                        float hueChange = colorTrackBar.Value / 360.0f; // Adjust hue change value

                        // Local function to limit values ​​between 0 and 255
                        int Clamp(int value)
                        {
                            if (value < 0) return 0;
                            if (value > 255) return 255;
                            return value;
                        }

                        // Local function to convert RGB to HSL
                        void RgbToHsl(int r, int g, int b, out double h, out double s, out double l)
                        {
                            double r_ = r / 255.0;
                            double g_ = g / 255.0;
                            double b_ = b / 255.0;

                            double max = Math.Max(r_, Math.Max(g_, b_));
                            double min = Math.Min(r_, Math.Min(g_, b_));

                            h = (max + min) / 2.0;
                            l = h;
                            s = h;

                            if (max == min)
                            {
                                h = s = 0; // achromatic
                            }
                            else
                            {
                                double d = max - min;
                                s = l > 0.5 ? d / (2.0 - max - min) : d / (max + min);
                                if (max == r_)
                                {
                                    h = (g_ - b_) / d + (g_ < b_ ? 6 : 0);
                                }
                                else if (max == g_)
                                {
                                    h = (b_ - r_) / d + 2;
                                }
                                else if (max == b_)
                                {
                                    h = (r_ - g_) / d + 4;
                                }
                                h /= 6;
                            }
                        }

                        // Local function to convert HSL to RGB
                        void HslToRgb(double h, double s, double l, out int r, out int g, out int b)
                        {
                            double r_, g_, b_;

                            if (s == 0)
                            {
                                r_ = g_ = b_ = l; // achromatic
                            }
                            else
                            {
                                Func<double, double, double, double> hue2rgb = (p, q, t) =>
                                {
                                    if (t < 0) t += 1;
                                    if (t > 1) t -= 1;
                                    if (t < 1 / 6.0) return p + (q - p) * 6 * t;
                                    if (t < 1 / 2.0) return q;
                                    if (t < 2 / 3.0) return p + (q - p) * (2 / 3.0 - t) * 6;
                                    return p;
                                };

                                var q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                                var p = 2 * l - q;
                                r_ = hue2rgb(p, q, h + hueChange);
                                g_ = hue2rgb(p, q, h);
                                b_ = hue2rgb(p, q, h - hueChange);
                            }

                            r = Clamp((int)(r_ * 255.0));
                            g = Clamp((int)(g_ * 255.0));
                            b = Clamp((int)(b_ * 255.0));
                        }

                        for (int y = 0; y < image.Height; y++)
                        {
                            for (int x = 0; x < image.Width; x++)
                            {
                                Color originalColor = image.GetPixel(x, y);
                                // Convert the color to HSL color space
                                double h;
                                double s;
                                double l;
                                RgbToHsl(originalColor.R, originalColor.G, originalColor.B, out h, out s, out l);

                                // Convert the color back to the RGB color space
                                int r;
                                int g;
                                int b;
                                HslToRgb(h, s, l, out r, out g, out b);

                                Color newColor = Color.FromArgb(r, g, b);
                                image.SetPixel(x, y, newColor);
                            }
                        }
                        pictureBox1.Image = image;
                        // Update the label with the current value of the TrackBar
                        pictureBox1.Refresh();  // Update the PictureBox
                        colorLabel.Text = "Color: " + colorTrackBar.Value.ToString();
                    }
                };

                // Create the button to apply the grayscale changes
                Button applyButton = new Button();
                applyButton.Text = "Apply";
                applyButton.Location = new Point(10, 320); // Set position
                applyButton.Click += (s, e) =>
                {
                    if (originalImage != null && grayscaleCheckbox.Checked)
                    {
                        Bitmap image = new Bitmap(originalImage);

                        // Convert the image to grayscale
                        for (int y = 0; y < image.Height; y++)
                        {
                            for (int x = 0; x < image.Width; x++)
                            {
                                Color originalColor = image.GetPixel(x, y);
                                int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59) + (originalColor.B * .11));
                                Color newColor = Color.FromArgb(grayScale, grayScale, grayScale);
                                image.SetPixel(x, y, newColor);
                            }
                        }

                        pictureBox1.Image = image;
                    }
                };

                // Add the checkbox and button to the shape
                colorChangeForm.Controls.Add(grayscaleCheckbox);
                colorChangeForm.Controls.Add(brightnessTrackBar);
                colorChangeForm.Controls.Add(brightnessLabel);
                colorChangeForm.Controls.Add(applyButton);
                // Add the new TrackBar and Label to the shape
                colorChangeForm.Controls.Add(contrastTrackBar);
                colorChangeForm.Controls.Add(contrastLabel);
                // Add the new TrackBar and Label to the shape
                colorChangeForm.Controls.Add(gammaTrackBar);
                colorChangeForm.Controls.Add(gammaLabel);
                // Add the new TrackBar and Label to the shape
                colorChangeForm.Controls.Add(saturationTrackBar);
                colorChangeForm.Controls.Add(saturationLabel);
                // Add the new TrackBar and Label to the shape
                colorChangeForm.Controls.Add(colorTrackBar);
                colorChangeForm.Controls.Add(colorLabel);

                // Display the shape
                colorChangeForm.Show();
            }
        }
        #endregion
    }
}
