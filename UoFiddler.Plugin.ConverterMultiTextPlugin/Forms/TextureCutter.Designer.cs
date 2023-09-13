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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextureCutter));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            copyClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importClipbordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            textBoxColorAdress = new System.Windows.Forms.TextBox();
            textBoxColorErase = new System.Windows.Forms.TextBox();
            textBoxColorToAdress = new System.Windows.Forms.TextBox();
            lbColorValue01 = new System.Windows.Forms.Label();
            lbColorValue02 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            lbColorValueDelete = new System.Windows.Forms.Label();
            comboBoxColorValue = new System.Windows.Forms.ComboBox();
            lbColorValue03 = new System.Windows.Forms.Label();
            panel3 = new System.Windows.Forms.Panel();
            btModusColorChange = new System.Windows.Forms.Button();
            btEvaluateColor = new System.Windows.Forms.Button();
            btcolorlistimage = new System.Windows.Forms.Button();
            checkBoxtoleranz35 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz30 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz10 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz15 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz5 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz100 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz75 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz50 = new System.Windows.Forms.CheckBox();
            checkBoxtoleranz25 = new System.Windows.Forms.CheckBox();
            eraseButton = new System.Windows.Forms.Button();
            drawButton = new System.Windows.Forms.Button();
            convertToIndexedButton = new System.Windows.Forms.Button();
            selectColorButton = new System.Windows.Forms.Button();
            BtMirroImage = new System.Windows.Forms.Button();
            btPickColor = new System.Windows.Forms.Button();
            btToUpdate = new System.Windows.Forms.Button();
            checkBoxDelete = new System.Windows.Forms.CheckBox();
            checkBoxChange = new System.Windows.Forms.CheckBox();
            zoomInButton = new System.Windows.Forms.Button();
            zoomOutButton = new System.Windows.Forms.Button();
            resetButton = new System.Windows.Forms.Button();
            coordinatesLabel = new System.Windows.Forms.Label();
            colorLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.ContextMenuStrip = contextMenuStrip1;
            pictureBox1.Location = new System.Drawing.Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(427, 366);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyClipboardToolStripMenuItem, importClipbordToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(160, 48);
            // 
            // copyClipboardToolStripMenuItem
            // 
            copyClipboardToolStripMenuItem.Name = "copyClipboardToolStripMenuItem";
            copyClipboardToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            copyClipboardToolStripMenuItem.Text = "Copy Clipboard";
            copyClipboardToolStripMenuItem.Click += copyClipboardToolStripMenuItem_Click;
            // 
            // importClipbordToolStripMenuItem
            // 
            importClipbordToolStripMenuItem.Name = "importClipbordToolStripMenuItem";
            importClipbordToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            importClipbordToolStripMenuItem.Text = "Import Clipbord";
            importClipbordToolStripMenuItem.Click += importClipbordToolStripMenuItem_Click;
            // 
            // buttonLoadImage
            // 
            buttonLoadImage.Location = new System.Drawing.Point(12, 384);
            buttonLoadImage.Name = "buttonLoadImage";
            buttonLoadImage.Size = new System.Drawing.Size(75, 23);
            buttonLoadImage.TabIndex = 1;
            buttonLoadImage.Text = "Load";
            buttonLoadImage.UseVisualStyleBackColor = true;
            buttonLoadImage.Click += buttonLoadImage_Click;
            // 
            // buttonTextureCutter
            // 
            buttonTextureCutter.Location = new System.Drawing.Point(93, 384);
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
            labelImageSize.Location = new System.Drawing.Point(549, 125);
            labelImageSize.Name = "labelImageSize";
            labelImageSize.Size = new System.Drawing.Size(26, 15);
            labelImageSize.TabIndex = 10;
            labelImageSize.Text = "size";
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
            buttonOpenTempGrafic.Location = new System.Drawing.Point(365, 384);
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
            panel2.Location = new System.Drawing.Point(456, 143);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(414, 100);
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
            buttonWhite.Location = new System.Drawing.Point(154, 66);
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
            ButtonAutoTexture.Location = new System.Drawing.Point(154, 37);
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
            // textBoxColorAdress
            // 
            textBoxColorAdress.Location = new System.Drawing.Point(9, 24);
            textBoxColorAdress.Name = "textBoxColorAdress";
            textBoxColorAdress.Size = new System.Drawing.Size(100, 23);
            textBoxColorAdress.TabIndex = 22;
            textBoxColorAdress.TextChanged += textBoxColorAdress_TextChanged;
            // 
            // textBoxColorErase
            // 
            textBoxColorErase.Location = new System.Drawing.Point(9, 78);
            textBoxColorErase.Name = "textBoxColorErase";
            textBoxColorErase.Size = new System.Drawing.Size(100, 23);
            textBoxColorErase.TabIndex = 23;
            textBoxColorErase.TextChanged += textBoxColorErase_TextChanged;
            // 
            // textBoxColorToAdress
            // 
            textBoxColorToAdress.Location = new System.Drawing.Point(140, 24);
            textBoxColorToAdress.Name = "textBoxColorToAdress";
            textBoxColorToAdress.Size = new System.Drawing.Size(100, 23);
            textBoxColorToAdress.TabIndex = 24;
            textBoxColorToAdress.TextChanged += textBoxColorToAdress_TextChanged;
            // 
            // lbColorValue01
            // 
            lbColorValue01.AutoSize = true;
            lbColorValue01.Location = new System.Drawing.Point(9, 6);
            lbColorValue01.Name = "lbColorValue01";
            lbColorValue01.Size = new System.Drawing.Size(67, 15);
            lbColorValue01.TabIndex = 25;
            lbColorValue01.Text = "Color Value";
            // 
            // lbColorValue02
            // 
            lbColorValue02.AutoSize = true;
            lbColorValue02.Location = new System.Drawing.Point(140, 6);
            lbColorValue02.Name = "lbColorValue02";
            lbColorValue02.Size = new System.Drawing.Size(67, 15);
            lbColorValue02.TabIndex = 26;
            lbColorValue02.Text = "Color Value";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(116, 27);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(18, 15);
            label5.TabIndex = 27;
            label5.Text = "to";
            // 
            // lbColorValueDelete
            // 
            lbColorValueDelete.AutoSize = true;
            lbColorValueDelete.Location = new System.Drawing.Point(9, 60);
            lbColorValueDelete.Name = "lbColorValueDelete";
            lbColorValueDelete.Size = new System.Drawing.Size(103, 15);
            lbColorValueDelete.TabIndex = 28;
            lbColorValueDelete.Text = "Delete Color Value";
            // 
            // comboBoxColorValue
            // 
            comboBoxColorValue.FormattingEnabled = true;
            comboBoxColorValue.Items.AddRange(new object[] { "ffffff", "000000", "f456ea" });
            comboBoxColorValue.Location = new System.Drawing.Point(246, 24);
            comboBoxColorValue.Name = "comboBoxColorValue";
            comboBoxColorValue.Size = new System.Drawing.Size(103, 23);
            comboBoxColorValue.TabIndex = 29;
            comboBoxColorValue.SelectedIndexChanged += comboBoxColorValue_SelectedIndexChanged;
            // 
            // lbColorValue03
            // 
            lbColorValue03.AutoSize = true;
            lbColorValue03.Location = new System.Drawing.Point(246, 6);
            lbColorValue03.Name = "lbColorValue03";
            lbColorValue03.Size = new System.Drawing.Size(87, 15);
            lbColorValue03.TabIndex = 30;
            lbColorValue03.Text = "Color Selection";
            // 
            // panel3
            // 
            panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel3.Controls.Add(btModusColorChange);
            panel3.Controls.Add(btEvaluateColor);
            panel3.Controls.Add(btcolorlistimage);
            panel3.Controls.Add(checkBoxtoleranz35);
            panel3.Controls.Add(checkBoxtoleranz30);
            panel3.Controls.Add(checkBoxtoleranz10);
            panel3.Controls.Add(checkBoxtoleranz15);
            panel3.Controls.Add(checkBoxtoleranz5);
            panel3.Controls.Add(checkBoxtoleranz100);
            panel3.Controls.Add(checkBoxtoleranz75);
            panel3.Controls.Add(checkBoxtoleranz50);
            panel3.Controls.Add(checkBoxtoleranz25);
            panel3.Controls.Add(eraseButton);
            panel3.Controls.Add(drawButton);
            panel3.Controls.Add(convertToIndexedButton);
            panel3.Controls.Add(selectColorButton);
            panel3.Controls.Add(BtMirroImage);
            panel3.Controls.Add(btPickColor);
            panel3.Controls.Add(btToUpdate);
            panel3.Controls.Add(checkBoxDelete);
            panel3.Controls.Add(checkBoxChange);
            panel3.Controls.Add(textBoxColorToAdress);
            panel3.Controls.Add(lbColorValue03);
            panel3.Controls.Add(textBoxColorAdress);
            panel3.Controls.Add(textBoxColorErase);
            panel3.Controls.Add(comboBoxColorValue);
            panel3.Controls.Add(lbColorValue01);
            panel3.Controls.Add(lbColorValueDelete);
            panel3.Controls.Add(lbColorValue02);
            panel3.Controls.Add(label5);
            panel3.Location = new System.Drawing.Point(456, 253);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(414, 228);
            panel3.TabIndex = 31;
            // 
            // btModusColorChange
            // 
            btModusColorChange.Location = new System.Drawing.Point(326, 143);
            btModusColorChange.Name = "btModusColorChange";
            btModusColorChange.Size = new System.Drawing.Size(75, 23);
            btModusColorChange.TabIndex = 51;
            btModusColorChange.Text = "Modus";
            btModusColorChange.UseVisualStyleBackColor = true;
            btModusColorChange.Click += btModusColorChange_Click;
            // 
            // btEvaluateColor
            // 
            btEvaluateColor.Location = new System.Drawing.Point(245, 172);
            btEvaluateColor.Name = "btEvaluateColor";
            btEvaluateColor.Size = new System.Drawing.Size(104, 23);
            btEvaluateColor.TabIndex = 50;
            btEvaluateColor.Text = "Evaluate Color";
            btEvaluateColor.UseVisualStyleBackColor = true;
            btEvaluateColor.Click += btEvaluateColor_Click;
            // 
            // btcolorlistimage
            // 
            btcolorlistimage.Location = new System.Drawing.Point(245, 143);
            btcolorlistimage.Name = "btcolorlistimage";
            btcolorlistimage.Size = new System.Drawing.Size(75, 23);
            btcolorlistimage.TabIndex = 49;
            btcolorlistimage.Text = "Color List";
            btcolorlistimage.UseVisualStyleBackColor = true;
            btcolorlistimage.Click += btcolorlistimage_Click;
            // 
            // checkBoxtoleranz35
            // 
            checkBoxtoleranz35.AutoSize = true;
            checkBoxtoleranz35.Location = new System.Drawing.Point(206, 118);
            checkBoxtoleranz35.Name = "checkBoxtoleranz35";
            checkBoxtoleranz35.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz35.TabIndex = 48;
            checkBoxtoleranz35.Text = "35";
            checkBoxtoleranz35.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz30
            // 
            checkBoxtoleranz30.AutoSize = true;
            checkBoxtoleranz30.Location = new System.Drawing.Point(165, 118);
            checkBoxtoleranz30.Name = "checkBoxtoleranz30";
            checkBoxtoleranz30.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz30.TabIndex = 47;
            checkBoxtoleranz30.Text = "30";
            checkBoxtoleranz30.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz10
            // 
            checkBoxtoleranz10.AutoSize = true;
            checkBoxtoleranz10.Location = new System.Drawing.Point(42, 118);
            checkBoxtoleranz10.Name = "checkBoxtoleranz10";
            checkBoxtoleranz10.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz10.TabIndex = 46;
            checkBoxtoleranz10.Text = "10";
            checkBoxtoleranz10.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz15
            // 
            checkBoxtoleranz15.AutoSize = true;
            checkBoxtoleranz15.Location = new System.Drawing.Point(83, 118);
            checkBoxtoleranz15.Name = "checkBoxtoleranz15";
            checkBoxtoleranz15.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz15.TabIndex = 45;
            checkBoxtoleranz15.Text = "15";
            checkBoxtoleranz15.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz5
            // 
            checkBoxtoleranz5.AutoSize = true;
            checkBoxtoleranz5.Location = new System.Drawing.Point(8, 118);
            checkBoxtoleranz5.Name = "checkBoxtoleranz5";
            checkBoxtoleranz5.Size = new System.Drawing.Size(32, 19);
            checkBoxtoleranz5.TabIndex = 44;
            checkBoxtoleranz5.Text = "5";
            checkBoxtoleranz5.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz100
            // 
            checkBoxtoleranz100.AutoSize = true;
            checkBoxtoleranz100.Location = new System.Drawing.Point(328, 118);
            checkBoxtoleranz100.Name = "checkBoxtoleranz100";
            checkBoxtoleranz100.Size = new System.Drawing.Size(44, 19);
            checkBoxtoleranz100.TabIndex = 43;
            checkBoxtoleranz100.Text = "100";
            checkBoxtoleranz100.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz75
            // 
            checkBoxtoleranz75.AutoSize = true;
            checkBoxtoleranz75.Location = new System.Drawing.Point(287, 118);
            checkBoxtoleranz75.Name = "checkBoxtoleranz75";
            checkBoxtoleranz75.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz75.TabIndex = 42;
            checkBoxtoleranz75.Text = "75";
            checkBoxtoleranz75.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz50
            // 
            checkBoxtoleranz50.AutoSize = true;
            checkBoxtoleranz50.Location = new System.Drawing.Point(246, 118);
            checkBoxtoleranz50.Name = "checkBoxtoleranz50";
            checkBoxtoleranz50.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz50.TabIndex = 41;
            checkBoxtoleranz50.Text = "50";
            checkBoxtoleranz50.UseVisualStyleBackColor = true;
            // 
            // checkBoxtoleranz25
            // 
            checkBoxtoleranz25.AutoSize = true;
            checkBoxtoleranz25.Location = new System.Drawing.Point(124, 118);
            checkBoxtoleranz25.Name = "checkBoxtoleranz25";
            checkBoxtoleranz25.Size = new System.Drawing.Size(38, 19);
            checkBoxtoleranz25.TabIndex = 40;
            checkBoxtoleranz25.Text = "25";
            checkBoxtoleranz25.UseVisualStyleBackColor = true;
            // 
            // eraseButton
            // 
            eraseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            eraseButton.Location = new System.Drawing.Point(86, 172);
            eraseButton.Name = "eraseButton";
            eraseButton.Size = new System.Drawing.Size(75, 23);
            eraseButton.TabIndex = 39;
            eraseButton.Text = "Erase";
            eraseButton.UseVisualStyleBackColor = true;
            eraseButton.Click += eraseButton_Click;
            // 
            // drawButton
            // 
            drawButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            drawButton.Location = new System.Drawing.Point(6, 172);
            drawButton.Name = "drawButton";
            drawButton.Size = new System.Drawing.Size(75, 23);
            drawButton.TabIndex = 38;
            drawButton.Text = "zeichnen";
            drawButton.UseVisualStyleBackColor = true;
            drawButton.Click += drawButton_Click;
            // 
            // convertToIndexedButton
            // 
            convertToIndexedButton.Location = new System.Drawing.Point(165, 143);
            convertToIndexedButton.Name = "convertToIndexedButton";
            convertToIndexedButton.Size = new System.Drawing.Size(75, 23);
            convertToIndexedButton.TabIndex = 37;
            convertToIndexedButton.Text = "indexed";
            convertToIndexedButton.UseVisualStyleBackColor = true;
            convertToIndexedButton.Click += convertToIndexedButton_Click;
            // 
            // selectColorButton
            // 
            selectColorButton.Location = new System.Drawing.Point(140, 56);
            selectColorButton.Name = "selectColorButton";
            selectColorButton.Size = new System.Drawing.Size(84, 23);
            selectColorButton.TabIndex = 36;
            selectColorButton.Text = "ColorDialog";
            selectColorButton.UseVisualStyleBackColor = true;
            selectColorButton.Click += selectColorButton_Click;
            // 
            // BtMirroImage
            // 
            BtMirroImage.Location = new System.Drawing.Point(165, 172);
            BtMirroImage.Name = "BtMirroImage";
            BtMirroImage.Size = new System.Drawing.Size(75, 23);
            BtMirroImage.TabIndex = 35;
            BtMirroImage.Text = "Mirror";
            BtMirroImage.UseVisualStyleBackColor = true;
            BtMirroImage.Click += BtMirroImage_Click;
            // 
            // btPickColor
            // 
            btPickColor.Location = new System.Drawing.Point(86, 143);
            btPickColor.Name = "btPickColor";
            btPickColor.Size = new System.Drawing.Size(75, 23);
            btPickColor.TabIndex = 34;
            btPickColor.Text = "Pipette";
            btPickColor.UseVisualStyleBackColor = true;
            btPickColor.Click += btPickColor_Click;
            // 
            // btToUpdate
            // 
            btToUpdate.Location = new System.Drawing.Point(6, 143);
            btToUpdate.Name = "btToUpdate";
            btToUpdate.Size = new System.Drawing.Size(75, 23);
            btToUpdate.TabIndex = 33;
            btToUpdate.Text = "To update";
            btToUpdate.UseVisualStyleBackColor = true;
            btToUpdate.Click += btToUpdate_Click;
            // 
            // checkBoxDelete
            // 
            checkBoxDelete.AutoSize = true;
            checkBoxDelete.Location = new System.Drawing.Point(246, 78);
            checkBoxDelete.Name = "checkBoxDelete";
            checkBoxDelete.Size = new System.Drawing.Size(59, 19);
            checkBoxDelete.TabIndex = 32;
            checkBoxDelete.Text = "Delete";
            checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // checkBoxChange
            // 
            checkBoxChange.AutoSize = true;
            checkBoxChange.Location = new System.Drawing.Point(246, 56);
            checkBoxChange.Name = "checkBoxChange";
            checkBoxChange.Size = new System.Drawing.Size(67, 19);
            checkBoxChange.TabIndex = 31;
            checkBoxChange.Text = "Change";
            checkBoxChange.UseVisualStyleBackColor = true;
            // 
            // zoomInButton
            // 
            zoomInButton.Location = new System.Drawing.Point(174, 384);
            zoomInButton.Name = "zoomInButton";
            zoomInButton.Size = new System.Drawing.Size(75, 23);
            zoomInButton.TabIndex = 32;
            zoomInButton.Text = "Zoom In";
            zoomInButton.UseVisualStyleBackColor = true;
            zoomInButton.Click += zoomInButton_Click;
            // 
            // zoomOutButton
            // 
            zoomOutButton.Location = new System.Drawing.Point(255, 384);
            zoomOutButton.Name = "zoomOutButton";
            zoomOutButton.Size = new System.Drawing.Size(75, 23);
            zoomOutButton.TabIndex = 33;
            zoomOutButton.Text = "Zoom Out";
            zoomOutButton.UseVisualStyleBackColor = true;
            zoomOutButton.Click += zoomOutButton_Click;
            // 
            // resetButton
            // 
            resetButton.Location = new System.Drawing.Point(174, 413);
            resetButton.Name = "resetButton";
            resetButton.Size = new System.Drawing.Size(75, 23);
            resetButton.TabIndex = 34;
            resetButton.Text = "Reset";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // coordinatesLabel
            // 
            coordinatesLabel.AutoSize = true;
            coordinatesLabel.Location = new System.Drawing.Point(12, 417);
            coordinatesLabel.Name = "coordinatesLabel";
            coordinatesLabel.Size = new System.Drawing.Size(71, 15);
            coordinatesLabel.TabIndex = 35;
            coordinatesLabel.Text = "Coordinates";
            // 
            // colorLabel
            // 
            colorLabel.AutoSize = true;
            colorLabel.Location = new System.Drawing.Point(93, 417);
            colorLabel.Name = "colorLabel";
            colorLabel.Size = new System.Drawing.Size(36, 15);
            colorLabel.TabIndex = 36;
            colorLabel.Text = "Color";
            // 
            // TextureCutter
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(882, 493);
            Controls.Add(colorLabel);
            Controls.Add(coordinatesLabel);
            Controls.Add(resetButton);
            Controls.Add(zoomOutButton);
            Controls.Add(zoomInButton);
            Controls.Add(panel3);
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
            KeyPreview = true;
            Name = "TextureCutter";
            Text = "TextureCutter and Color Changer Clipboard";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyClipboardToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxColorAdress;
        private System.Windows.Forms.TextBox textBoxColorErase;
        private System.Windows.Forms.TextBox textBoxColorToAdress;
        private System.Windows.Forms.Label lbColorValue01;
        private System.Windows.Forms.Label lbColorValue02;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbColorValueDelete;
        private System.Windows.Forms.ComboBox comboBoxColorValue;
        private System.Windows.Forms.Label lbColorValue03;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.CheckBox checkBoxChange;
        private System.Windows.Forms.ToolStripMenuItem importClipbordToolStripMenuItem;
        private System.Windows.Forms.Button btToUpdate;
        private System.Windows.Forms.Button btPickColor;
        private System.Windows.Forms.Button BtMirroImage;
        private System.Windows.Forms.Button zoomInButton;
        private System.Windows.Forms.Button zoomOutButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button selectColorButton;
        private System.Windows.Forms.Label coordinatesLabel;
        private System.Windows.Forms.Button convertToIndexedButton;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.Button eraseButton;
        private System.Windows.Forms.CheckBox checkBoxtoleranz25;
        private System.Windows.Forms.CheckBox checkBoxtoleranz100;
        private System.Windows.Forms.CheckBox checkBoxtoleranz75;
        private System.Windows.Forms.CheckBox checkBoxtoleranz50;
        private System.Windows.Forms.CheckBox checkBoxtoleranz5;
        private System.Windows.Forms.CheckBox checkBoxtoleranz35;
        private System.Windows.Forms.CheckBox checkBoxtoleranz30;
        private System.Windows.Forms.CheckBox checkBoxtoleranz10;
        private System.Windows.Forms.CheckBox checkBoxtoleranz15;
        private System.Windows.Forms.Button btcolorlistimage;
        private System.Windows.Forms.Button btEvaluateColor;
        private System.Windows.Forms.Button btModusColorChange;
    }
}