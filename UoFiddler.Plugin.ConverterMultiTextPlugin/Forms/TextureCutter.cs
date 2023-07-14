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
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Forms
{
    public partial class TextureCutter : Form
    {
        private Point originalImageLocation;

        public TextureCutter()
        {
            InitializeComponent();

            labelImageSize.Text = "";
        }

        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Bilddateien|*.bmp;*.png;*.jpeg;*.jpg;*.tiff;*.gif|Alle Dateien|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog1.FileName;

                // Setzen Sie das Bild der PictureBox auf null und entfernen Sie es aus dem Controls-Collection des Panels
                pictureBox1.Image = null;
                panel1.Controls.Remove(pictureBox1);
                pictureBox1.Dispose();

                // Erstellen Sie eine neue PictureBox und fügen Sie sie dem Panel hinzu
                pictureBox1 = new PictureBox();
                pictureBox1.Location = originalImageLocation;
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = Image.FromFile(selectedImagePath);
                panel1.Controls.Add(pictureBox1);

                // Zurücksetzen der Scrollposition
                panel1.AutoScrollPosition = new Point(0, 0);

                // Anzeigen der Bildgröße im Label
                Size imageSize = pictureBox1.Image.Size;
                labelImageSize.Text = $"Bildgröße: {imageSize.Width} x {imageSize.Height} Pixel";
            }
        }
        private void buttonTextureCutter_Click(object sender, EventArgs e)
        {
            // Check if an image has been loaded into the picture box
            if (pictureBox1.Image == null)
            {
                // Display a message to the user and exit the method
                MessageBox.Show("Es wurde keine Grafik geladen.");
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

    }
}
