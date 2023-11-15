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
            components = new System.ComponentModel.Container();
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
            TextureCutter = new System.Windows.Forms.Button();
            btDecriptClient = new System.Windows.Forms.Button();
            btMapMaker = new System.Windows.Forms.Button();
            btAnimationVDForm = new System.Windows.Forms.Button();
            btAnimationEditFormButton = new System.Windows.Forms.Button();
            btBinaryCode = new System.Windows.Forms.Button();
            checkBoxASCII = new System.Windows.Forms.CheckBox();
            btMorseCode = new System.Windows.Forms.Button();
            btclear = new System.Windows.Forms.Button();
            contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(components);
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importClipbordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BtnMultiOpen
            // 
            BtnMultiOpen.Location = new System.Drawing.Point(350, 218);
            BtnMultiOpen.Name = "BtnMultiOpen";
            BtnMultiOpen.Size = new System.Drawing.Size(92, 23);
            BtnMultiOpen.TabIndex = 0;
            BtnMultiOpen.Text = "Open";
            BtnMultiOpen.UseVisualStyleBackColor = true;
            BtnMultiOpen.Click += BtnMultiOpen_Click;
            // 
            // btnSpeichernTxt
            // 
            btnSpeichernTxt.Location = new System.Drawing.Point(350, 189);
            btnSpeichernTxt.Name = "btnSpeichernTxt";
            btnSpeichernTxt.Size = new System.Drawing.Size(92, 23);
            btnSpeichernTxt.TabIndex = 1;
            btnSpeichernTxt.Text = "Save";
            btnSpeichernTxt.UseVisualStyleBackColor = true;
            btnSpeichernTxt.Click += btnSpeichernTxt_Click;
            // 
            // btnUmwandeln
            // 
            btnUmwandeln.Location = new System.Drawing.Point(350, 41);
            btnUmwandeln.Name = "btnUmwandeln";
            btnUmwandeln.Size = new System.Drawing.Size(92, 23);
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
            textBox1.ContextMenuStrip = contextMenuStrip1;
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
            buttonGraficCutterForm.Location = new System.Drawing.Point(350, 247);
            buttonGraficCutterForm.Name = "buttonGraficCutterForm";
            buttonGraficCutterForm.Size = new System.Drawing.Size(92, 23);
            buttonGraficCutterForm.TabIndex = 9;
            buttonGraficCutterForm.Text = "Grafik Cutter";
            buttonGraficCutterForm.UseVisualStyleBackColor = true;
            buttonGraficCutterForm.Click += buttonGraficCutterForm_Click;
            // 
            // TextureCutter
            // 
            TextureCutter.Location = new System.Drawing.Point(350, 274);
            TextureCutter.Name = "TextureCutter";
            TextureCutter.Size = new System.Drawing.Size(92, 23);
            TextureCutter.TabIndex = 10;
            TextureCutter.Text = "Texture Cutter";
            TextureCutter.UseVisualStyleBackColor = true;
            TextureCutter.Click += TextureCutter_Click;
            // 
            // btDecriptClient
            // 
            btDecriptClient.Location = new System.Drawing.Point(350, 328);
            btDecriptClient.Name = "btDecriptClient";
            btDecriptClient.Size = new System.Drawing.Size(92, 23);
            btDecriptClient.TabIndex = 11;
            btDecriptClient.Text = "Decript";
            btDecriptClient.UseVisualStyleBackColor = true;
            btDecriptClient.Click += btDecriptClient_Click;
            // 
            // btMapMaker
            // 
            btMapMaker.Location = new System.Drawing.Point(350, 301);
            btMapMaker.Name = "btMapMaker";
            btMapMaker.Size = new System.Drawing.Size(92, 23);
            btMapMaker.TabIndex = 12;
            btMapMaker.Text = "MapMaker";
            btMapMaker.UseVisualStyleBackColor = true;
            btMapMaker.Click += btMapMaker_Click;
            // 
            // btAnimationVDForm
            // 
            btAnimationVDForm.Location = new System.Drawing.Point(350, 357);
            btAnimationVDForm.Name = "btAnimationVDForm";
            btAnimationVDForm.Size = new System.Drawing.Size(92, 23);
            btAnimationVDForm.TabIndex = 13;
            btAnimationVDForm.Text = "VD Edit";
            btAnimationVDForm.UseVisualStyleBackColor = true;
            btAnimationVDForm.Click += btAnimationVDForm_Click;
            // 
            // btAnimationEditFormButton
            // 
            btAnimationEditFormButton.Location = new System.Drawing.Point(350, 386);
            btAnimationEditFormButton.Name = "btAnimationEditFormButton";
            btAnimationEditFormButton.Size = new System.Drawing.Size(92, 23);
            btAnimationEditFormButton.TabIndex = 14;
            btAnimationEditFormButton.Text = "Amin Edit";
            btAnimationEditFormButton.UseVisualStyleBackColor = true;
            btAnimationEditFormButton.Click += btAnimationEditFormButton_Click;
            // 
            // btBinaryCode
            // 
            btBinaryCode.Location = new System.Drawing.Point(350, 70);
            btBinaryCode.Name = "btBinaryCode";
            btBinaryCode.Size = new System.Drawing.Size(92, 23);
            btBinaryCode.TabIndex = 15;
            btBinaryCode.Text = "Binary Code";
            btBinaryCode.UseVisualStyleBackColor = true;
            btBinaryCode.Click += btBinaryCode_Click;
            // 
            // checkBoxASCII
            // 
            checkBoxASCII.AutoSize = true;
            checkBoxASCII.Location = new System.Drawing.Point(350, 164);
            checkBoxASCII.Name = "checkBoxASCII";
            checkBoxASCII.Size = new System.Drawing.Size(94, 19);
            checkBoxASCII.TabIndex = 16;
            checkBoxASCII.Text = "back original";
            checkBoxASCII.UseVisualStyleBackColor = true;
            // 
            // btMorseCode
            // 
            btMorseCode.Location = new System.Drawing.Point(350, 99);
            btMorseCode.Name = "btMorseCode";
            btMorseCode.Size = new System.Drawing.Size(92, 23);
            btMorseCode.TabIndex = 17;
            btMorseCode.Text = "Morse code";
            btMorseCode.UseVisualStyleBackColor = true;
            btMorseCode.Click += btMorseCode_Click;
            // 
            // btclear
            // 
            btclear.Location = new System.Drawing.Point(295, 305);
            btclear.Name = "btclear";
            btclear.Size = new System.Drawing.Size(41, 23);
            btclear.TabIndex = 18;
            btclear.Text = "clear";
            btclear.UseVisualStyleBackColor = true;
            btclear.Click += btclear_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { copyToolStripMenuItem, clearToolStripMenuItem, importClipbordToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new System.Drawing.Size(169, 70);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += btnCopyTBox2_Click;
            // 
            // clearToolStripMenuItem
            // 
            clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            clearToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            clearToolStripMenuItem.Text = "Clear";
            clearToolStripMenuItem.Click += btclear_Click;
            // 
            // importClipbordToolStripMenuItem
            // 
            importClipbordToolStripMenuItem.Name = "importClipbordToolStripMenuItem";
            importClipbordToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            importClipbordToolStripMenuItem.Text = "Import Clipboard ";
            importClipbordToolStripMenuItem.Click += importClipboardToolStripMenuItem_Click;
            // 
            // ConverterMultiTextControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(btclear);
            Controls.Add(btMorseCode);
            Controls.Add(checkBoxASCII);
            Controls.Add(btBinaryCode);
            Controls.Add(btAnimationEditFormButton);
            Controls.Add(btAnimationVDForm);
            Controls.Add(btMapMaker);
            Controls.Add(btDecriptClient);
            Controls.Add(TextureCutter);
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
            contextMenuStrip1.ResumeLayout(false);
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
        private System.Windows.Forms.Button TextureCutter;
        private System.Windows.Forms.Button btDecriptClient;
        private System.Windows.Forms.Button btMapMaker;
        private System.Windows.Forms.Button btAnimationVDForm;
        private System.Windows.Forms.Button btAnimationEditFormButton;
        private System.Windows.Forms.Button btBinaryCode;
        private System.Windows.Forms.CheckBox checkBoxASCII;
        private System.Windows.Forms.Button btMorseCode;
        private System.Windows.Forms.Button btclear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importClipbordToolStripMenuItem;
    }
}
