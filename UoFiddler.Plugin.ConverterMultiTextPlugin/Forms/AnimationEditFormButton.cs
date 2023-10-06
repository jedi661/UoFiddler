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
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using Ultima;
using UoFiddler.Controls.Classes;

namespace UoFiddler.Controls.Forms
{
    public partial class AnimationEditFormButton : Form
    {
        
        public AnimationEditFormButton()
        {
            InitializeComponent();
            Icon = Options.GetFiddlerIcon();

            
        }        

        private void OnLoad(object sender, EventArgs e)
        {
            
        }

        private void AnimationEdit_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

    }
}
