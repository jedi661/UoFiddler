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

namespace UoFiddler.Controls.UserControls
{
    partial class GumpControl
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
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            listBox = new System.Windows.Forms.ListBox();
            contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            extractImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asBmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asTiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asJpgToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            asPngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            AddShowAllFreeSlotsButton = new System.Windows.Forms.ToolStripMenuItem();
            findNextFreeSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            jumpToMaleFemale = new System.Windows.Forms.ToolStripMenuItem();
            replaceGumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            InsertText = new System.Windows.Forms.ToolStripTextBox();
            toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            InsertStartingFromTb = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            addIDNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            topMenuToolStrip = new System.Windows.Forms.ToolStrip();
            IndexToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            searchByIdToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            toolStripButtonSearch = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asBmpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            asTiffToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            asJpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            showFreeSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            toolStripButtonSoundMessage = new System.Windows.Forms.ToolStripButton();
            pictureBox = new System.Windows.Forms.PictureBox();
            bottomMenuToolStrip = new System.Windows.Forms.ToolStrip();
            IDLabel = new System.Windows.Forms.ToolStripLabel();
            SizeLabel = new System.Windows.Forms.ToolStripLabel();
            ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            Preload = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            PreLoader = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            contextMenuStrip.SuspendLayout();
            topMenuToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            bottomMenuToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listBox);
            splitContainer1.Panel1.Controls.Add(topMenuToolStrip);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox);
            splitContainer1.Panel2.Controls.Add(bottomMenuToolStrip);
            splitContainer1.Size = new System.Drawing.Size(738, 382);
            splitContainer1.SplitterDistance = 293;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // listBox
            // 
            listBox.ContextMenuStrip = contextMenuStrip;
            listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            listBox.FormattingEnabled = true;
            listBox.IntegralHeight = false;
            listBox.ItemHeight = 60;
            listBox.Location = new System.Drawing.Point(0, 25);
            listBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBox.Name = "listBox";
            listBox.Size = new System.Drawing.Size(293, 357);
            listBox.TabIndex = 0;
            listBox.DrawItem += ListBox_DrawItem;
            listBox.MeasureItem += ListBox_MeasureItem;
            listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;
            listBox.KeyDown += GumpControl_KeyDown;
            listBox.KeyUp += Gump_KeyUp;
            // 
            // contextMenuStrip
            // 
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { extractImageToolStripMenuItem, toolStripSeparator2, AddShowAllFreeSlotsButton, findNextFreeSlotToolStripMenuItem, jumpToMaleFemale, replaceGumpToolStripMenuItem, removeToolStripMenuItem, insertToolStripMenuItem, toolStripMenuItem1, toolStripSeparator1, saveToolStripMenuItem, toolStripSeparator4, copyToolStripMenuItem, importToolStripMenuItem, toolStripSeparator7, addIDNamesToolStripMenuItem });
            contextMenuStrip.Name = "contextMenuStrip1";
            contextMenuStrip.Size = new System.Drawing.Size(190, 314);
            // 
            // extractImageToolStripMenuItem
            // 
            extractImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { asBmpToolStripMenuItem, asTiffToolStripMenuItem, asJpgToolStripMenuItem1, asPngToolStripMenuItem1 });
            extractImageToolStripMenuItem.Image = Properties.Resources.Export;
            extractImageToolStripMenuItem.Name = "extractImageToolStripMenuItem";
            extractImageToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            extractImageToolStripMenuItem.Text = "Export Image..";
            extractImageToolStripMenuItem.ToolTipText = "Exports the graphic to the respective format.";
            // 
            // asBmpToolStripMenuItem
            // 
            asBmpToolStripMenuItem.Name = "asBmpToolStripMenuItem";
            asBmpToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asBmpToolStripMenuItem.Text = "As Bmp";
            asBmpToolStripMenuItem.Click += Extract_Image_ClickBmp;
            // 
            // asTiffToolStripMenuItem
            // 
            asTiffToolStripMenuItem.Name = "asTiffToolStripMenuItem";
            asTiffToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asTiffToolStripMenuItem.Text = "As Tiff";
            asTiffToolStripMenuItem.Click += Extract_Image_ClickTiff;
            // 
            // asJpgToolStripMenuItem1
            // 
            asJpgToolStripMenuItem1.Name = "asJpgToolStripMenuItem1";
            asJpgToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asJpgToolStripMenuItem1.Text = "As Jpg";
            asJpgToolStripMenuItem1.Click += Extract_Image_ClickJpg;
            // 
            // asPngToolStripMenuItem1
            // 
            asPngToolStripMenuItem1.Name = "asPngToolStripMenuItem1";
            asPngToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asPngToolStripMenuItem1.Text = "As Png";
            asPngToolStripMenuItem1.Click += Extract_Image_ClickPng;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(186, 6);
            // 
            // AddShowAllFreeSlotsButton
            // 
            AddShowAllFreeSlotsButton.Image = Properties.Resources.Search;
            AddShowAllFreeSlotsButton.Name = "AddShowAllFreeSlotsButton";
            AddShowAllFreeSlotsButton.Size = new System.Drawing.Size(189, 22);
            AddShowAllFreeSlotsButton.Text = "Show all Free Slots";
            AddShowAllFreeSlotsButton.ToolTipText = "Displays all available IDs in the list.";
            AddShowAllFreeSlotsButton.Click += AddShowAllFreeSlotsButton_Click;
            // 
            // findNextFreeSlotToolStripMenuItem
            // 
            findNextFreeSlotToolStripMenuItem.Image = Properties.Resources.Search;
            findNextFreeSlotToolStripMenuItem.Name = "findNextFreeSlotToolStripMenuItem";
            findNextFreeSlotToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            findNextFreeSlotToolStripMenuItem.Text = "Find Next Free Slot";
            findNextFreeSlotToolStripMenuItem.ToolTipText = "Finds the next available ID position.";
            findNextFreeSlotToolStripMenuItem.Click += OnClickFindFree;
            // 
            // jumpToMaleFemale
            // 
            jumpToMaleFemale.Image = Properties.Resources.jump;
            jumpToMaleFemale.Name = "jumpToMaleFemale";
            jumpToMaleFemale.Size = new System.Drawing.Size(189, 22);
            jumpToMaleFemale.Text = "Jump to Male/Female";
            jumpToMaleFemale.ToolTipText = "Jumps to the male or female position.";
            jumpToMaleFemale.Click += JumpToMaleFemale_Click;
            // 
            // replaceGumpToolStripMenuItem
            // 
            replaceGumpToolStripMenuItem.Image = Properties.Resources.replace;
            replaceGumpToolStripMenuItem.Name = "replaceGumpToolStripMenuItem";
            replaceGumpToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            replaceGumpToolStripMenuItem.Text = "Replace";
            replaceGumpToolStripMenuItem.ToolTipText = "Replaces the graphic at the ID position.";
            replaceGumpToolStripMenuItem.Click += OnClickReplace;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Image = Properties.Resources.Remove;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.ToolTipText = "Removes the graphic from the ID position.";
            removeToolStripMenuItem.Click += OnClickRemove;
            // 
            // insertToolStripMenuItem
            // 
            insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { InsertText });
            insertToolStripMenuItem.Image = Properties.Resources.import;
            insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            insertToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            insertToolStripMenuItem.Text = "Insert At..";
            insertToolStripMenuItem.ToolTipText = "Imports the graphic at the specified decimal position.";
            // 
            // InsertText
            // 
            InsertText.Name = "InsertText";
            InsertText.Size = new System.Drawing.Size(100, 23);
            InsertText.KeyDown += OnKeydown_InsertText;
            InsertText.TextChanged += OnTextChanged_InsertAt;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { InsertStartingFromTb });
            toolStripMenuItem1.Image = Properties.Resources.import;
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new System.Drawing.Size(189, 22);
            toolStripMenuItem1.Text = "Insert Starting From";
            toolStripMenuItem1.ToolTipText = "Imports the graphics at the specified ID positions from the given position.";
            // 
            // InsertStartingFromTb
            // 
            InsertStartingFromTb.Name = "InsertStartingFromTb";
            InsertStartingFromTb.Size = new System.Drawing.Size(100, 23);
            InsertStartingFromTb.KeyDown += InsertStartingFromTb_KeyDown;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(186, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Image = Properties.Resources.Save2;
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.ToolTipText = "Saves the Gump.mul file.";
            saveToolStripMenuItem.Click += OnClickSave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(186, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.Copy;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.ToolTipText = "The graphic is being saved to the clipboard.";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Image = Properties.Resources.import;
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.ToolTipText = "Paste graphic from clipboard.";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(186, 6);
            // 
            // addIDNamesToolStripMenuItem
            // 
            addIDNamesToolStripMenuItem.Image = Properties.Resources.Add;
            addIDNamesToolStripMenuItem.Name = "addIDNamesToolStripMenuItem";
            addIDNamesToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            addIDNamesToolStripMenuItem.Text = "Add ID Names";
            addIDNamesToolStripMenuItem.Click += addIDNamesToolStripMenuItem_Click;
            // 
            // topMenuToolStrip
            // 
            topMenuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            topMenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { IndexToolStripLabel, searchByIdToolStripTextBox, toolStripButtonSearch, toolStripSeparator5, toolStripDropDownButton1, toolStripSeparator6, saveToolStripButton, toolStripButtonSoundMessage });
            topMenuToolStrip.Location = new System.Drawing.Point(0, 0);
            topMenuToolStrip.Name = "topMenuToolStrip";
            topMenuToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            topMenuToolStrip.Size = new System.Drawing.Size(293, 25);
            topMenuToolStrip.TabIndex = 1;
            topMenuToolStrip.Text = "toolStrip2";
            // 
            // IndexToolStripLabel
            // 
            IndexToolStripLabel.Name = "IndexToolStripLabel";
            IndexToolStripLabel.Size = new System.Drawing.Size(39, 22);
            IndexToolStripLabel.Text = "Index:";
            // 
            // searchByIdToolStripTextBox
            // 
            searchByIdToolStripTextBox.Name = "searchByIdToolStripTextBox";
            searchByIdToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            searchByIdToolStripTextBox.KeyUp += SearchByIdToolStripTextBox_KeyUp;
            // 
            // toolStripButtonSearch
            // 
            toolStripButtonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonSearch.Image = Properties.Resources.Search;
            toolStripButtonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonSearch.Name = "toolStripButtonSearch";
            toolStripButtonSearch.Size = new System.Drawing.Size(23, 22);
            toolStripButtonSearch.Text = "Search";
            toolStripButtonSearch.ToolTipText = "Old Search";
            toolStripButtonSearch.Click += Search_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exportAllToolStripMenuItem, showFreeSlotsToolStripMenuItem });
            toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            toolStripDropDownButton1.Size = new System.Drawing.Size(45, 22);
            toolStripDropDownButton1.Text = "Misc";
            // 
            // exportAllToolStripMenuItem
            // 
            exportAllToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { asBmpToolStripMenuItem1, asTiffToolStripMenuItem1, asJpgToolStripMenuItem, asPngToolStripMenuItem });
            exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            exportAllToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            exportAllToolStripMenuItem.Text = "Export All..";
            // 
            // asBmpToolStripMenuItem1
            // 
            asBmpToolStripMenuItem1.Name = "asBmpToolStripMenuItem1";
            asBmpToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asBmpToolStripMenuItem1.Text = "As Bmp";
            asBmpToolStripMenuItem1.Click += OnClick_SaveAllBmp;
            // 
            // asTiffToolStripMenuItem1
            // 
            asTiffToolStripMenuItem1.Name = "asTiffToolStripMenuItem1";
            asTiffToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asTiffToolStripMenuItem1.Text = "As Tiff";
            asTiffToolStripMenuItem1.Click += OnClick_SaveAllTiff;
            // 
            // asJpgToolStripMenuItem
            // 
            asJpgToolStripMenuItem.Name = "asJpgToolStripMenuItem";
            asJpgToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asJpgToolStripMenuItem.Text = "As Jpg";
            asJpgToolStripMenuItem.Click += OnClick_SaveAllJpg;
            // 
            // asPngToolStripMenuItem
            // 
            asPngToolStripMenuItem.Name = "asPngToolStripMenuItem";
            asPngToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asPngToolStripMenuItem.Text = "As Png";
            asPngToolStripMenuItem.Click += OnClick_SaveAllPng;
            // 
            // showFreeSlotsToolStripMenuItem
            // 
            showFreeSlotsToolStripMenuItem.CheckOnClick = true;
            showFreeSlotsToolStripMenuItem.Name = "showFreeSlotsToolStripMenuItem";
            showFreeSlotsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            showFreeSlotsToolStripMenuItem.Text = "Show Free Slots";
            showFreeSlotsToolStripMenuItem.Click += OnClickShowFreeSlots;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // saveToolStripButton
            // 
            saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveToolStripButton.Image = Properties.Resources.Save2;
            saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveToolStripButton.Name = "saveToolStripButton";
            saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            saveToolStripButton.Text = "Save";
            saveToolStripButton.ToolTipText = "Save Gump.mul File";
            saveToolStripButton.Click += OnClickSave;
            // 
            // toolStripButtonSoundMessage
            // 
            toolStripButtonSoundMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolStripButtonSoundMessage.Image = Properties.Resources.volume;
            toolStripButtonSoundMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStripButtonSoundMessage.Name = "toolStripButtonSoundMessage";
            toolStripButtonSoundMessage.Size = new System.Drawing.Size(23, 22);
            toolStripButtonSoundMessage.Text = "toolStripButton1";
            toolStripButtonSoundMessage.Click += toolStripButtonSoundMessage_Click;
            // 
            // pictureBox
            // 
            pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            pictureBox.ContextMenuStrip = contextMenuStrip;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(440, 357);
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            // 
            // bottomMenuToolStrip
            // 
            bottomMenuToolStrip.AutoSize = false;
            bottomMenuToolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            bottomMenuToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            bottomMenuToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { IDLabel, SizeLabel, ProgressBar, Preload, toolStripSeparator3 });
            bottomMenuToolStrip.Location = new System.Drawing.Point(0, 357);
            bottomMenuToolStrip.Name = "bottomMenuToolStrip";
            bottomMenuToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            bottomMenuToolStrip.Size = new System.Drawing.Size(440, 25);
            bottomMenuToolStrip.TabIndex = 2;
            bottomMenuToolStrip.Text = "toolStrip1";
            // 
            // IDLabel
            // 
            IDLabel.AutoSize = false;
            IDLabel.Name = "IDLabel";
            IDLabel.Size = new System.Drawing.Size(110, 17);
            IDLabel.Text = "ID:";
            IDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SizeLabel
            // 
            SizeLabel.AutoSize = false;
            SizeLabel.Name = "SizeLabel";
            SizeLabel.Size = new System.Drawing.Size(100, 17);
            SizeLabel.Text = "Size:";
            SizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgressBar
            // 
            ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new System.Drawing.Size(117, 22);
            // 
            // Preload
            // 
            Preload.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            Preload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            Preload.ImageTransparentColor = System.Drawing.Color.Magenta;
            Preload.Name = "Preload";
            Preload.Size = new System.Drawing.Size(51, 22);
            Preload.Text = "Preload";
            Preload.Click += OnClickPreLoad;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // PreLoader
            // 
            PreLoader.WorkerReportsProgress = true;
            PreLoader.DoWork += PreLoaderDoWork;
            PreLoader.ProgressChanged += PreLoaderProgressChanged;
            PreLoader.RunWorkerCompleted += PreLoaderCompleted;
            // 
            // GumpControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "GumpControl";
            Size = new System.Drawing.Size(738, 382);
            KeyUp += Gump_KeyUp;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            contextMenuStrip.ResumeLayout(false);
            topMenuToolStrip.ResumeLayout(false);
            topMenuToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            bottomMenuToolStrip.ResumeLayout(false);
            bottomMenuToolStrip.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem asBmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asBmpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asJpgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asJpgToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asTiffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asTiffToolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findNextFreeSlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel IDLabel;
        private System.Windows.Forms.ToolStripTextBox InsertText;
        private System.Windows.Forms.ToolStripMenuItem insertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToMaleFemale;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ToolStripButton Preload;
        private System.ComponentModel.BackgroundWorker PreLoader;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceGumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFreeSlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel SizeLabel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip bottomMenuToolStrip;
        private System.Windows.Forms.ToolStrip topMenuToolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearch;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripTextBox InsertStartingFromTb;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddShowAllFreeSlotsButton;
        private System.Windows.Forms.ToolStripLabel IndexToolStripLabel;
        private System.Windows.Forms.ToolStripTextBox searchByIdToolStripTextBox;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem addIDNamesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton toolStripButtonSoundMessage;
    }
}
