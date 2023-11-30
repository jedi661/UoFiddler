﻿// /***************************************************************************
//  *
//  * $Author: Turley
//  * 
//  * "THE BEER-WARE LICENSE"
//  * As long as you retain this notice you can do whatever you want with 
//  * this stuff. If we meet some day, and you think this stuff is worth it,
//  * you can buy me a beer in return.
//  *
//  ***************************************************************************/

namespace UoFiddler.Forms
{
    partial class HelpDokuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpDokuForm));
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            webView2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            toolStripButtonSuche = new System.Windows.Forms.ToolStripButton();
            toolStripTextBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStripButtonSuche, toolStripTextBoxSearch });
            toolStrip1.Location = new System.Drawing.Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(959, 25);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // webView2
            // 
            webView2.AllowExternalDrop = true;
            webView2.CreationProperties = null;
            webView2.DefaultBackgroundColor = System.Drawing.Color.White;
            webView2.Location = new System.Drawing.Point(101, 28);
            webView2.Name = "webView2";
            webView2.Size = new System.Drawing.Size(846, 519);
            webView2.TabIndex = 1;
            webView2.ZoomFactor = 1D;
            // 
            // toolStripButtonSuche
            // 
            toolStripButtonSuche.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonSuche.Image = Properties.Resources.Mirror;
            toolStripButtonSuche.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonSuche.Name = "toolStripButtonSuche";
            toolStripButtonSuche.Size = new System.Drawing.Size(23, 22);
            toolStripButtonSuche.Text = "toolStripButton1";
            toolStripButtonSuche.Click += toolStripButtonSuche_Click;
            // 
            // toolStripTextBoxSearch
            // 
            toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
            toolStripTextBoxSearch.Size = new System.Drawing.Size(100, 25);
            toolStripTextBoxSearch.ToolTipText = "Search Text";
            // 
            // HelpDokuForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(959, 559);
            Controls.Add(webView2);
            Controls.Add(toolStrip1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "HelpDokuForm";
            Text = "Help - Doku";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)webView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView2;
        private System.Windows.Forms.ToolStripButton toolStripButtonSuche;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSearch;
    }
}