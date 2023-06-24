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
    partial class GraphicCutterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicCutterForm));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripTextBoxColors = new System.Windows.Forms.ToolStripTextBox();
            PaintPictureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            spiegelnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            toggleGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showBorderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            btnUp = new System.Windows.Forms.Button();
            btnDown = new System.Windows.Forms.Button();
            btnLeft = new System.Windows.Forms.Button();
            btnRight = new System.Windows.Forms.Button();
            moveTimer = new System.Windows.Forms.Timer(components);
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            textBoxWidth = new System.Windows.Forms.TextBox();
            textBoxHeight = new System.Windows.Forms.TextBox();
            textBoxStartX = new System.Windows.Forms.TextBox();
            textBoxStartY = new System.Windows.Forms.TextBox();
            Width = new System.Windows.Forms.Label();
            Height = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            saveImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripDropDownButton1 });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(700, 25);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { openImageToolStripMenuItem, toolStripSeparator1, colorToolStripMenuItem, PaintPictureToolStripMenuItem, toolStripSeparator2, spiegelnToolStripMenuItem, toolStripSeparator3, toggleGridToolStripMenuItem, showBorderToolStripMenuItem });
            toolStripDropDownButton1.Image = Properties.Resources.Shild;
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // openImageToolStripMenuItem
            // 
            openImageToolStripMenuItem.Image = Properties.Resources.Load;
            openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            openImageToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            openImageToolStripMenuItem.Text = "Open Image";
            openImageToolStripMenuItem.Click += openImageToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // colorToolStripMenuItem
            // 
            colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripTextBoxColors });
            colorToolStripMenuItem.Image = Properties.Resources.Color;
            colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            colorToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            colorToolStripMenuItem.Text = "BackGrundColor";
            colorToolStripMenuItem.Click += colorToolStripMenuItem_Click;
            // 
            // toolStripTextBoxColors
            // 
            toolStripTextBoxColors.Name = "toolStripTextBoxColors";
            toolStripTextBoxColors.Size = new System.Drawing.Size(100, 23);
            toolStripTextBoxColors.KeyDown += toolStripTextBoxColors_KeyDown;
            // 
            // PaintPictureToolStripMenuItem
            // 
            PaintPictureToolStripMenuItem.Image = Properties.Resources.createDesign;
            PaintPictureToolStripMenuItem.Name = "PaintPictureToolStripMenuItem";
            PaintPictureToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            PaintPictureToolStripMenuItem.Text = "Grafic Paint";
            PaintPictureToolStripMenuItem.Click += PaintGridToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // spiegelnToolStripMenuItem
            // 
            spiegelnToolStripMenuItem.Image = Properties.Resources.Mirror;
            spiegelnToolStripMenuItem.Name = "spiegelnToolStripMenuItem";
            spiegelnToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            spiegelnToolStripMenuItem.Text = "Mirror";
            spiegelnToolStripMenuItem.Click += spiegelnToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // toggleGridToolStripMenuItem
            // 
            toggleGridToolStripMenuItem.Image = Properties.Resources.Schablone;
            toggleGridToolStripMenuItem.Name = "toggleGridToolStripMenuItem";
            toggleGridToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            toggleGridToolStripMenuItem.Text = "ToggleGrid";
            toggleGridToolStripMenuItem.Click += toggleGridToolStripMenuItem_Click;
            // 
            // showBorderToolStripMenuItem
            // 
            showBorderToolStripMenuItem.Image = Properties.Resources.Rahmen;
            showBorderToolStripMenuItem.Name = "showBorderToolStripMenuItem";
            showBorderToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            showBorderToolStripMenuItem.Text = "Show Border";
            showBorderToolStripMenuItem.Click += showBorderToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = System.Drawing.Color.Black;
            pictureBox1.Enabled = false;
            pictureBox1.ErrorImage = null;
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new System.Drawing.Point(57, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(352, 352);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += pictureBox1_Paint;
            // 
            // btnUp
            // 
            btnUp.BackColor = System.Drawing.SystemColors.ActiveBorder;
            btnUp.Image = Properties.Resources.up;
            btnUp.Location = new System.Drawing.Point(58, 3);
            btnUp.Name = "btnUp";
            btnUp.Size = new System.Drawing.Size(49, 46);
            btnUp.TabIndex = 4;
            btnUp.UseVisualStyleBackColor = false;
            btnUp.Click += btnUp_Click;
            btnUp.MouseDown += btnUp_MouseDown;
            btnUp.MouseUp += btnUp_MouseUp;
            // 
            // btnDown
            // 
            btnDown.BackColor = System.Drawing.SystemColors.ActiveBorder;
            btnDown.BackgroundImage = Properties.Resources.down;
            btnDown.Location = new System.Drawing.Point(58, 64);
            btnDown.Name = "btnDown";
            btnDown.Size = new System.Drawing.Size(49, 43);
            btnDown.TabIndex = 5;
            btnDown.UseVisualStyleBackColor = false;
            btnDown.Click += btnDown_Click;
            btnDown.MouseDown += btnDown_MouseDown;
            btnDown.MouseUp += btnDown_MouseUp;
            // 
            // btnLeft
            // 
            btnLeft.BackColor = System.Drawing.SystemColors.ActiveBorder;
            btnLeft.BackgroundImage = Properties.Resources.left;
            btnLeft.Location = new System.Drawing.Point(1, 30);
            btnLeft.Name = "btnLeft";
            btnLeft.Size = new System.Drawing.Size(50, 49);
            btnLeft.TabIndex = 6;
            btnLeft.UseVisualStyleBackColor = false;
            btnLeft.Click += btnLeft_Click;
            btnLeft.MouseDown += btnLeft_MouseDown;
            btnLeft.MouseUp += btnLeft_MouseUp;
            // 
            // btnRight
            // 
            btnRight.BackColor = System.Drawing.SystemColors.ActiveBorder;
            btnRight.BackgroundImage = Properties.Resources.right;
            btnRight.Location = new System.Drawing.Point(113, 30);
            btnRight.Name = "btnRight";
            btnRight.Size = new System.Drawing.Size(48, 49);
            btnRight.TabIndex = 7;
            btnRight.UseVisualStyleBackColor = false;
            btnRight.Click += btnRight_Click;
            btnRight.MouseDown += btnRight_MouseDown;
            btnRight.MouseUp += btnRight_MouseUp;
            // 
            // moveTimer
            // 
            moveTimer.Interval = 50;
            moveTimer.Tick += moveTimer_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(57, 383);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 9;
            label1.Text = "label1";
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel1.Controls.Add(btnDown);
            panel1.Controls.Add(btnUp);
            panel1.Controls.Add(btnLeft);
            panel1.Controls.Add(btnRight);
            panel1.Location = new System.Drawing.Point(436, 28);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(166, 113);
            panel1.TabIndex = 10;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = System.Drawing.SystemColors.ControlDark;
            pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox2.Location = new System.Drawing.Point(436, 156);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(166, 224);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            pictureBox2.MouseClick += pictureBox2_MouseClick;
            // 
            // textBoxWidth
            // 
            textBoxWidth.Location = new System.Drawing.Point(93, 428);
            textBoxWidth.Name = "textBoxWidth";
            textBoxWidth.Size = new System.Drawing.Size(52, 23);
            textBoxWidth.TabIndex = 12;
            textBoxWidth.Text = "44";
            textBoxWidth.TextChanged += textBoxWidth_TextChanged;
            textBoxWidth.KeyPress += textBox_KeyPress;
            // 
            // textBoxHeight
            // 
            textBoxHeight.Location = new System.Drawing.Point(181, 428);
            textBoxHeight.Name = "textBoxHeight";
            textBoxHeight.Size = new System.Drawing.Size(52, 23);
            textBoxHeight.TabIndex = 13;
            textBoxHeight.Text = "105";
            textBoxHeight.TextChanged += textBoxHeight_TextChanged;
            textBoxHeight.KeyPress += textBox_KeyPress;
            // 
            // textBoxStartX
            // 
            textBoxStartX.Location = new System.Drawing.Point(93, 465);
            textBoxStartX.Name = "textBoxStartX";
            textBoxStartX.Size = new System.Drawing.Size(52, 23);
            textBoxStartX.TabIndex = 14;
            textBoxStartX.Text = "174";
            textBoxStartX.TextChanged += textBoxStartX_TextChanged;
            textBoxStartX.KeyPress += textBox_KeyPress;
            // 
            // textBoxStartY
            // 
            textBoxStartY.Location = new System.Drawing.Point(181, 465);
            textBoxStartY.Name = "textBoxStartY";
            textBoxStartY.Size = new System.Drawing.Size(52, 23);
            textBoxStartY.TabIndex = 15;
            textBoxStartY.Text = "247";
            textBoxStartY.TextChanged += textBoxStartY_TextChanged;
            textBoxStartY.KeyPress += textBox_KeyPress;
            // 
            // Width
            // 
            Width.AutoSize = true;
            Width.Location = new System.Drawing.Point(94, 408);
            Width.Name = "Width";
            Width.Size = new System.Drawing.Size(45, 15);
            Width.TabIndex = 16;
            Width.Text = "Width :";
            // 
            // Height
            // 
            Height.AutoSize = true;
            Height.Location = new System.Drawing.Point(181, 408);
            Height.Name = "Height";
            Height.Size = new System.Drawing.Size(49, 15);
            Height.TabIndex = 17;
            Height.Text = "Height :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(67, 468);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(20, 15);
            label2.TabIndex = 18;
            label2.Text = "X :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(158, 468);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(17, 15);
            label3.TabIndex = 19;
            label3.Text = "Y:";
            // 
            // button1
            // 
            button1.BackgroundImage = Properties.Resources.up1;
            button1.Location = new System.Drawing.Point(308, 392);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(51, 46);
            button1.TabIndex = 20;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.BackgroundImage = Properties.Resources.down;
            button2.Location = new System.Drawing.Point(308, 444);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(49, 46);
            button2.TabIndex = 21;
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.BackgroundImage = Properties.Resources.left;
            button3.Location = new System.Drawing.Point(257, 442);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(49, 48);
            button3.TabIndex = 22;
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackgroundImage = Properties.Resources.right;
            button4.Location = new System.Drawing.Point(358, 442);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(51, 48);
            button4.TabIndex = 23;
            button4.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { saveImageToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(135, 26);
            // 
            // saveImageToolStripMenuItem
            // 
            saveImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripComboBox1 });
            saveImageToolStripMenuItem.Name = "saveImageToolStripMenuItem";
            saveImageToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            saveImageToolStripMenuItem.Text = "Save Image";
            saveImageToolStripMenuItem.Click += saveImageToolStripMenuItem_Click;
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.AccessibleName = "";
            toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            toolStripComboBox1.Items.AddRange(new object[] { "BMP", "TIFF", "PNG", "JPEG" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new System.Drawing.Size(121, 23);
            toolStripComboBox1.Click += saveImageToolStripMenuItem_Click;
            // 
            // GraphicCutterForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(700, 502);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Height);
            Controls.Add(Width);
            Controls.Add(textBoxStartY);
            Controls.Add(textBoxStartX);
            Controls.Add(textBoxHeight);
            Controls.Add(textBoxWidth);
            Controls.Add(pictureBox2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GraphicCutterForm";
            Text = "GraphicCutterForm";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem PaintPictureToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxColors;
        private System.Windows.Forms.ToolStripMenuItem toggleGridToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox textBoxWidth;
        private System.Windows.Forms.TextBox textBoxHeight;
        private System.Windows.Forms.TextBox textBoxStartX;
        private System.Windows.Forms.TextBox textBoxStartY;
        private System.Windows.Forms.ToolStripMenuItem showBorderToolStripMenuItem;
        private System.Windows.Forms.Label Width;
        private System.Windows.Forms.Label Height;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem saveImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem spiegelnToolStripMenuItem;
    }
}