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

using System.Windows.Forms;

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Forms
{
    public partial class ConverterMultiTextForm : Form
    {
        public ConverterMultiTextForm()
        {
            InitializeComponent();
        }

        private void bnListBox_Click(object sender, System.EventArgs e)
        {
            label1.Text = "Hallo";
        }
    }
}
