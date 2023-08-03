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

using System.Drawing;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;

namespace UoFiddler.Controls.Forms
{
    public partial class MapDetailsForm : Form
    {
        private int _currentStaticIndex = 0;
        private HuedTile[] _staticsAtPoint;

        public MapDetailsForm(Map currentMap, Point point)
        {
            InitializeComponent();

            Icon = Options.GetFiddlerIcon();
            TopMost = true;

            Tile currentTile = currentMap.Tiles.GetLandTile(point.X, point.Y);
            richTextBox.AppendText($"X: {point.X} Y: {point.Y}\n\n");
            richTextBox.AppendText("LandTile:\n");
            richTextBox.AppendText($"{TileData.LandTable[currentTile.Id].Name}: 0x{currentTile.Id:X} Altitude: {currentTile.Z}\n\n");
            HuedTile[] staticsAtPoint = currentMap.Tiles.GetStaticTiles(point.X, point.Y);
            _staticsAtPoint = currentMap.Tiles.GetStaticTiles(point.X, point.Y);
            richTextBox.AppendText("Statics:\n");
            foreach (HuedTile @static in staticsAtPoint)
            {
                ushort id = @static.Id;
                richTextBox.AppendText($"{TileData.ItemTable[id].Name}: 0x{id:X} Hue: {@static.Hue} Altitude: {@static.Z}\n");
            }
            // Update texture information
            if (Textures.TestTexture(point.X) && Textures.TestTexture(point.Y))
            {
                Bitmap currentTexture = Textures.GetTexture(point.X);
                if (currentTexture != null)
                {
                    richTextBox.AppendText("Texture:\n");
                    richTextBox.AppendText($"Width: {currentTexture.Width} Height: {currentTexture.Height}\n");
                    richTextBox.AppendText($"Hex-Adresse: 0x{point.X:X}\n\n");
                    pictureBox3.Image = currentTexture;
                }
            }




            // Display of the land tiles in pictureBox1
            Bitmap landTileBitmap = Art.GetLand(currentTile.Id);
            pictureBox1.Image = landTileBitmap;

            // Display of the current statics in pictureBox2
            if (staticsAtPoint.Length > 0)
            {
                HuedTile currentStatic = staticsAtPoint[_currentStaticIndex];
                Bitmap staticBitmap = Art.GetStatic(currentStatic.Id);
                pictureBox2.Image = staticBitmap;
            }
        }

        private void buttonNext_Click_1(object sender, System.EventArgs e)
        {
            if (_currentStaticIndex < _staticsAtPoint.Length - 1)
            {
                _currentStaticIndex++;
                HuedTile currentStatic = _staticsAtPoint[_currentStaticIndex];
                Bitmap staticBitmap = Art.GetStatic(currentStatic.Id);
                pictureBox2.Image = staticBitmap;
            }
        }

        private void buttonPrevious_Click_1(object sender, System.EventArgs e)
        {
            if (_currentStaticIndex > 0)
            {
                _currentStaticIndex--;
                HuedTile currentStatic = _staticsAtPoint[_currentStaticIndex];
                Bitmap staticBitmap = Art.GetStatic(currentStatic.Id);
                pictureBox2.Image = staticBitmap;
            }
        }
    }
}