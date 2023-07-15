// /***************************************************************************
//  *
//  * $Author: Turley
//  * 
//  * "THE BEER-WARE LICENSE"
//  * As long as you retain this notice you can do whatever you want with 
//  * this stuff. If we meet some day, and you think this stuff is worth it,
//  * you can buy me a beer in return.
//  *
//  ***************************************************************************/

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.Forms
{
    partial class TextureCutter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureCutter));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            buttonLoadImage = new System.Windows.Forms.Button();
            buttonTextureCutter = new System.Windows.Forms.Button();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            checkBox44x44 = new System.Windows.Forms.CheckBox();
            checkBox64x64 = new System.Windows.Forms.CheckBox();
            checkBox128x128 = new System.Windows.Forms.CheckBox();
            checkBox256x256 = new System.Windows.Forms.CheckBox();
            panel1 = new System.Windows.Forms.Panel();
            labelImageSize = new System.Windows.Forms.Label();
            textBoxSizeH = new System.Windows.Forms.TextBox();
            textBoxSizeW = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            checkBox1 = new System.Windows.Forms.CheckBox();
            buttonOpenTempGrafic = new System.Windows.Forms.Button();
            ButtonShrinkTexture = new System.Windows.Forms.Button();
            buttonsharp = new System.Windows.Forms.Button();
            buttonSaveImage = new System.Windows.Forms.Button();
            panel2 = new System.Windows.Forms.Panel();
            button45Degrees = new System.Windows.Forms.Button();
            buttonWhite = new System.Windows.Forms.Button();
            ButtonRotateTexture = new System.Windows.Forms.Button();
            ButtonAutoTexture = new System.Windows.Forms.Button();
            textBoxBorderWidth = new System.Windows.Forms.TextBox();
            buttonResize = new System.Windows.Forms.Button();
            checkBox33x33 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(427, 366);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonLoadImage
            // 
            buttonLoadImage.Location = new System.Drawing.Point(12, 398);
            buttonLoadImage.Name = "buttonLoadImage";
            buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            buttonLoadImage.TabIndex = 1;
            buttonLoadImage.Text = "Load";
            buttonLoadImage.UseVisualStyleBackColor = true;
            buttonLoadImage.Click += buttonLoadImage_Click;
            // 
            // buttonTextureCutter
            // 
            buttonTextureCutter.Location = new System.Drawing.Point(93, 398);
            buttonTextureCutter.Name = "buttonTextureCutter";
            buttonTextureCutter.Size = new System.Drawing.Size(75, 23);
            buttonTextureCutter.TabIndex = 2;
            buttonTextureCutter.Text = "Cut";
            buttonTextureCutter.UseVisualStyleBackColor = true;
            buttonTextureCutter.Click += buttonTextureCutter_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkBox44x44
            // 
            checkBox44x44.AutoSize = true;
            checkBox44x44.Location = new System.Drawing.Point(456, 36);
            checkBox44x44.Name = "checkBox44x44";
            checkBox44x44.Size = new System.Drawing.Size(62, 19);
            checkBox44x44.TabIndex = 3;
            checkBox44x44.Text = "44 x 44";
            checkBox44x44.UseVisualStyleBackColor = true;
            // 
            // checkBox64x64
            // 
            checkBox64x64.AutoSize = true;
            checkBox64x64.Location = new System.Drawing.Point(456, 61);
            checkBox64x64.Name = "checkBox64x64";
            checkBox64x64.Size = new System.Drawing.Size(62, 19);
            checkBox64x64.TabIndex = 4;
            checkBox64x64.Text = "64 x 64";
            checkBox64x64.UseVisualStyleBackColor = true;
            // 
            // checkBox128x128
            // 
            checkBox128x128.AutoSize = true;
            checkBox128x128.Location = new System.Drawing.Point(456, 86);
            checkBox128x128.Name = "checkBox128x128";
            checkBox128x128.Size = new System.Drawing.Size(71, 19);
            checkBox128x128.TabIndex = 5;
            checkBox128x128.Text = "128 x128";
            checkBox128x128.UseVisualStyleBackColor = true;
            // 
            // checkBox256x256
            // 
            checkBox256x256.AutoSize = true;
            checkBox256x256.Location = new System.Drawing.Point(456, 111);
            checkBox256x256.Name = "checkBox256x256";
            checkBox256x256.Size = new System.Drawing.Size(74, 19);
            checkBox256x256.TabIndex = 6;
            checkBox256x256.Text = "256 x 256";
            checkBox256x256.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new System.Drawing.Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(427, 366);
            panel1.TabIndex = 9;
            // 
            // labelImageSize
            // 
            labelImageSize.AutoSize = true;
            labelImageSize.Location = new System.Drawing.Point(578, 125);
            labelImageSize.Name = "labelImageSize";
            labelImageSize.Size = new System.Drawing.Size(38, 15);
            labelImageSize.TabIndex = 10;
            labelImageSize.Text = "label1";
            // 
            // textBoxSizeH
            // 
            textBoxSizeH.Location = new System.Drawing.Point(549, 12);
            textBoxSizeH.Name = "textBoxSizeH";
            textBoxSizeH.Size = new System.Drawing.Size(67, 23);
            textBoxSizeH.TabIndex = 11;
            // 
            // textBoxSizeW
            // 
            textBoxSizeW.Location = new System.Drawing.Point(549, 55);
            textBoxSizeW.Name = "textBoxSizeW";
            textBoxSizeW.Size = new System.Drawing.Size(67, 23);
            textBoxSizeW.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(622, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 15);
            label1.TabIndex = 13;
            label1.Text = "height";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(626, 62);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(37, 15);
            label2.TabIndex = 14;
            label2.Text = "width";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new System.Drawing.Point(678, 14);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(78, 19);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "Allow size";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonOpenTempGrafic
            // 
            buttonOpenTempGrafic.Location = new System.Drawing.Point(456, 398);
            buttonOpenTempGrafic.Name = "buttonOpenTempGrafic";
            buttonOpenTempGrafic.Size = new System.Drawing.Size(74, 23);
            buttonOpenTempGrafic.TabIndex = 16;
            buttonOpenTempGrafic.Text = "Open Dir";
            buttonOpenTempGrafic.UseVisualStyleBackColor = true;
            buttonOpenTempGrafic.Click += buttonOpenTempGrafic_Click;
            // 
            // ButtonShrinkTexture
            // 
            ButtonShrinkTexture.Location = new System.Drawing.Point(13, 9);
            ButtonShrinkTexture.Name = "ButtonShrinkTexture";
            ButtonShrinkTexture.Size = new System.Drawing.Size(75, 23);
            ButtonShrinkTexture.TabIndex = 17;
            ButtonShrinkTexture.Text = "Resolution";
            ButtonShrinkTexture.UseVisualStyleBackColor = true;
            ButtonShrinkTexture.Click += ButtonShrinkTexture_Click;
            // 
            // buttonsharp
            // 
            buttonsharp.Location = new System.Drawing.Point(13, 38);
            buttonsharp.Name = "buttonsharp";
            buttonsharp.Size = new System.Drawing.Size(75, 23);
            buttonsharp.TabIndex = 18;
            buttonsharp.Text = "Sharp";
            buttonsharp.UseVisualStyleBackColor = true;
            buttonsharp.Click += buttonsharp_Click;
            // 
            // buttonSaveImage
            // 
            buttonSaveImage.Location = new System.Drawing.Point(91, 67);
            buttonSaveImage.Name = "buttonSaveImage";
            buttonSaveImage.Size = new System.Drawing.Size(57, 23);
            buttonSaveImage.TabIndex = 19;
            buttonSaveImage.Text = "Save";
            buttonSaveImage.UseVisualStyleBackColor = true;
            buttonSaveImage.Click += buttonSaveImage_Click;
            // 
            // panel2
            // 
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel2.Controls.Add(button45Degrees);
            panel2.Controls.Add(buttonWhite);
            panel2.Controls.Add(ButtonRotateTexture);
            panel2.Controls.Add(ButtonAutoTexture);
            panel2.Controls.Add(textBoxBorderWidth);
            panel2.Controls.Add(buttonResize);
            panel2.Controls.Add(buttonsharp);
            panel2.Controls.Add(buttonSaveImage);
            panel2.Controls.Add(ButtonShrinkTexture);
            panel2.Location = new System.Drawing.Point(456, 154);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(332, 100);
            panel2.TabIndex = 20;
            // 
            // button45Degrees
            // 
            button45Degrees.Location = new System.Drawing.Point(13, 67);
            button45Degrees.Name = "button45Degrees";
            button45Degrees.Size = new System.Drawing.Size(75, 23);
            button45Degrees.TabIndex = 25;
            button45Degrees.Text = "Create Tiles";
            button45Degrees.UseVisualStyleBackColor = true;
            button45Degrees.Click += button45Degrees_Click;
            // 
            // buttonWhite
            // 
            buttonWhite.Location = new System.Drawing.Point(180, 67);
            buttonWhite.Name = "buttonWhite";
            buttonWhite.Size = new System.Drawing.Size(124, 23);
            buttonWhite.TabIndex = 24;
            buttonWhite.Text = "white balance";
            buttonWhite.UseVisualStyleBackColor = true;
            buttonWhite.Click += buttonWhite_Click;
            // 
            // ButtonRotateTexture
            // 
            ButtonRotateTexture.Location = new System.Drawing.Point(91, 38);
            ButtonRotateTexture.Name = "ButtonRotateTexture";
            ButtonRotateTexture.Size = new System.Drawing.Size(57, 23);
            ButtonRotateTexture.TabIndex = 23;
            ButtonRotateTexture.Text = "Rotate";
            ButtonRotateTexture.UseVisualStyleBackColor = true;
            ButtonRotateTexture.Click += ButtonRotateTexture_Click;
            // 
            // ButtonAutoTexture
            // 
            ButtonAutoTexture.Location = new System.Drawing.Point(180, 37);
            ButtonAutoTexture.Name = "ButtonAutoTexture";
            ButtonAutoTexture.Size = new System.Drawing.Size(124, 23);
            ButtonAutoTexture.TabIndex = 22;
            ButtonAutoTexture.Text = "color enhancement";
            ButtonAutoTexture.UseVisualStyleBackColor = true;
            ButtonAutoTexture.Click += ButtonAutoTexture_Click;
            // 
            // textBoxBorderWidth
            // 
            textBoxBorderWidth.Location = new System.Drawing.Point(154, 8);
            textBoxBorderWidth.Name = "textBoxBorderWidth";
            textBoxBorderWidth.Size = new System.Drawing.Size(42, 23);
            textBoxBorderWidth.TabIndex = 21;
            textBoxBorderWidth.Text = "0";
            // 
            // buttonResize
            // 
            buttonResize.Location = new System.Drawing.Point(91, 9);
            buttonResize.Name = "buttonResize";
            buttonResize.Size = new System.Drawing.Size(57, 23);
            buttonResize.TabIndex = 20;
            buttonResize.Text = "Resize";
            buttonResize.UseVisualStyleBackColor = true;
            buttonResize.Click += buttonResize_Click;
            // 
            // checkBox33x33
            // 
            checkBox33x33.AutoSize = true;
            checkBox33x33.Location = new System.Drawing.Point(456, 14);
            checkBox33x33.Name = "checkBox33x33";
            checkBox33x33.Size = new System.Drawing.Size(62, 19);
            checkBox33x33.TabIndex = 21;
            checkBox33x33.Text = "33 x 33";
            checkBox33x33.UseVisualStyleBackColor = true;
            // 
            // TextureCutter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(checkBox33x33);
            Controls.Add(panel2);
            Controls.Add(buttonOpenTempGrafic);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBoxSizeW);
            Controls.Add(textBoxSizeH);
            Controls.Add(labelImageSize);
            Controls.Add(panel1);
            Controls.Add(checkBox256x256);
            Controls.Add(checkBox128x128);
            Controls.Add(checkBox64x64);
            Controls.Add(checkBox44x44);
            Controls.Add(buttonTextureCutter);
            Controls.Add(buttonLoadImage);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "TextureCutter";
            Text = "TextureCutter";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonLoadImage;
        private System.Windows.Forms.Button buttonTextureCutter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox44x44;
        private System.Windows.Forms.CheckBox checkBox64x64;
        private System.Windows.Forms.CheckBox checkBox128x128;
        private System.Windows.Forms.CheckBox checkBox256x256;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelImageSize;
        private System.Windows.Forms.TextBox textBoxSizeH;
        private System.Windows.Forms.TextBox textBoxSizeW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonOpenTempGrafic;
        private System.Windows.Forms.Button ButtonShrinkTexture;
        private System.Windows.Forms.Button buttonsharp;
        private System.Windows.Forms.Button buttonSaveImage;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonResize;
        private System.Windows.Forms.TextBox textBoxBorderWidth;
        private System.Windows.Forms.Button ButtonAutoTexture;
        private System.Windows.Forms.Button ButtonRotateTexture;
        private System.Windows.Forms.Button buttonWhite;
        private System.Windows.Forms.CheckBox checkBox33x33;
        private System.Windows.Forms.Button button45Degrees;
    }
}