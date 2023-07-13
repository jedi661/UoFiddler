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
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Es wurde keine Grafik geladen.");
                return;
            }

            string directory = "tempGrafic";
            Directory.CreateDirectory(directory);

            // Kachelgrößen
            Dictionary<string, Size> tileSizes = new Dictionary<string, Size>
    {
        { "checkBox44x44", new Size(44, 44) },
        { "checkBox64x64", new Size(64, 64) },
        { "checkBox128x128", new Size(128, 128) },
        { "checkBox256x256", new Size(256, 256) }
    };

            int counter = 1; // Zählervariable für die Nummerierung der Dateien

            foreach (var kvp in tileSizes)
            {
                CheckBox checkBox = Controls.Find(kvp.Key, true).FirstOrDefault() as CheckBox;

                if (checkBox != null && checkBox.Checked)
                {
                    Size tileSize = kvp.Value; // Aktuelle Kachelgröße
                    int tileCountX = (int)Math.Ceiling((double)pictureBox1.Image.Width / tileSize.Width);
                    int tileCountY = (int)Math.Ceiling((double)pictureBox1.Image.Height / tileSize.Height);

                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss"); // Zeitstempel für den Dateinamen

                    for (int y = 0; y < tileCountY; y++)
                    {
                        for (int x = 0; x < tileCountX; x++)
                        {
                            string outputFileName = $"TextureImage{counter:D2}_{timestamp}.bmp"; // Dateiname mit fortlaufender Nummer und Zeitstempel
                            string outputPath = Path.Combine(directory, outputFileName);

                            CropImage(pictureBox1.Image, tileSize.Width, tileSize.Height, outputPath, x * tileSize.Width, y * tileSize.Height);

                            counter++;
                        }
                    }
                }
            }

            MessageBox.Show("Die Grafik wurde erfolgreich geschnitten und im temporären Verzeichnis gespeichert.");
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
