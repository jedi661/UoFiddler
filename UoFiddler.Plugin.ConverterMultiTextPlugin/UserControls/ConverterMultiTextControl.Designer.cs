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

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.UserControls
{
    partial class ConverterMultiTextControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            BtnMultiOpen = new System.Windows.Forms.Button();
            btnSpeichernTxt = new System.Windows.Forms.Button();
            btnUmwandeln = new System.Windows.Forms.Button();
            btnCopyTBox2 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            textBox2 = new System.Windows.Forms.TextBox();
            openFileDialog = new System.Windows.Forms.OpenFileDialog();
            label3 = new System.Windows.Forms.Label();
            buttonGraficCutterForm = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // BtnMultiOpen
            // 
            BtnMultiOpen.Location = new System.Drawing.Point(358, 301);
            BtnMultiOpen.Name = "BtnMultiOpen";
            BtnMultiOpen.Size = new System.Drawing.Size(76, 23);
            BtnMultiOpen.TabIndex = 0;
            BtnMultiOpen.Text = "Open";
            BtnMultiOpen.UseVisualStyleBackColor = true;
            BtnMultiOpen.Click += BtnMultiOpen_Click;
            // 
            // btnSpeichernTxt
            // 
            btnSpeichernTxt.Location = new System.Drawing.Point(358, 265);
            btnSpeichernTxt.Name = "btnSpeichernTxt";
            btnSpeichernTxt.Size = new System.Drawing.Size(75, 23);
            btnSpeichernTxt.TabIndex = 1;
            btnSpeichernTxt.Text = "Save";
            btnSpeichernTxt.UseVisualStyleBackColor = true;
            btnSpeichernTxt.Click += btnSpeichernTxt_Click;
            // 
            // btnUmwandeln
            // 
            btnUmwandeln.Location = new System.Drawing.Point(358, 41);
            btnUmwandeln.Name = "btnUmwandeln";
            btnUmwandeln.Size = new System.Drawing.Size(75, 23);
            btnUmwandeln.TabIndex = 2;
            btnUmwandeln.Text = "Convert";
            btnUmwandeln.UseVisualStyleBackColor = true;
            btnUmwandeln.Click += btnUmwandeln_Click;
            // 
            // btnCopyTBox2
            // 
            btnCopyTBox2.Location = new System.Drawing.Point(728, 305);
            btnCopyTBox2.Name = "btnCopyTBox2";
            btnCopyTBox2.Size = new System.Drawing.Size(43, 23);
            btnCopyTBox2.TabIndex = 3;
            btnCopyTBox2.Text = "Copy";
            btnCopyTBox2.UseVisualStyleBackColor = true;
            btnCopyTBox2.Click += btnCopyTBox2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(18, 309);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 4;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(453, 309);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "label2";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(18, 21);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox1.Size = new System.Drawing.Size(318, 267);
            textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(453, 21);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBox2.Size = new System.Drawing.Size(318, 267);
            textBox2.TabIndex = 7;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(358, 21);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(76, 15);
            label3.TabIndex = 8;
            label3.Text = "to HexCode :";
            // 
            // buttonGraficCutterForm
            // 
            buttonGraficCutterForm.Location = new System.Drawing.Point(350, 330);
            buttonGraficCutterForm.Name = "buttonGraficCutterForm";
            buttonGraficCutterForm.Size = new System.Drawing.Size(92, 23);
            buttonGraficCutterForm.TabIndex = 9;
            buttonGraficCutterForm.Text = "Grafik Cutter";
            buttonGraficCutterForm.UseVisualStyleBackColor = true;
            buttonGraficCutterForm.Click += buttonGraficCutterForm_Click;
            // 
            // ConverterMultiTextControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(buttonGraficCutterForm);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnCopyTBox2);
            Controls.Add(btnUmwandeln);
            Controls.Add(btnSpeichernTxt);
            Controls.Add(BtnMultiOpen);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ConverterMultiTextControl";
            Size = new System.Drawing.Size(790, 471);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button BtnMultiOpen;
        private System.Windows.Forms.Button btnSpeichernTxt;
        private System.Windows.Forms.Button btnUmwandeln;
        private System.Windows.Forms.Button btnCopyTBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonGraficCutterForm;
    }
}
