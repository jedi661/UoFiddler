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

namespace UoFiddler.Controls.UserControls
{
    partial class ItemsControl
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
            splitContainer2 = new SplitContainer();
            DetailPictureBox = new PictureBox();
            DetailPictureBoxContextMenuStrip = new ContextMenuStrip(components);
            changeBackgroundColorToolStripMenuItemDetail = new ToolStripMenuItem();
            DetailTextBox = new RichTextBox();
            splitContainer1 = new SplitContainer();
            ItemsTileView = new TileView.TileViewControl();
            TileViewContextMenuStrip = new ContextMenuStrip(components);
            showFreeSlotsToolStripMenuItem = new ToolStripMenuItem();
            findNextFreeSlotToolStripMenuItem = new ToolStripMenuItem();
            ChangeBackgroundColorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            selectInTileDataTabToolStripMenuItem = new ToolStripMenuItem();
            selectInRadarColorTabToolStripMenuItem = new ToolStripMenuItem();
            selectInGumpsTabMaleToolStripMenuItem = new ToolStripMenuItem();
            selectInGumpsTabFemaleToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            extractToolStripMenuItem = new ToolStripMenuItem();
            bmpToolStripMenuItem = new ToolStripMenuItem();
            tiffToolStripMenuItem = new ToolStripMenuItem();
            asJpgToolStripMenuItem1 = new ToolStripMenuItem();
            asPngToolStripMenuItem1 = new ToolStripMenuItem();
            replaceToolStripMenuItem = new ToolStripMenuItem();
            replaceStartingFromToolStripMenuItem = new ToolStripMenuItem();
            ReplaceStartingFromText = new ToolStripTextBox();
            removeToolStripMenuItem = new ToolStripMenuItem();
            insertAtToolStripMenuItem = new ToolStripMenuItem();
            InsertText = new ToolStripTextBox();
            toolStripSeparator5 = new ToolStripSeparator();
            mirrorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            copyToolStripMenuItem = new ToolStripMenuItem();
            importToolStripclipboardMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            saveToolStripMenuItem = new ToolStripMenuItem();
            StatusStrip = new StatusStrip();
            NameLabel = new ToolStripStatusLabel();
            GraphicLabel = new ToolStripStatusLabel();
            PreLoader = new System.ComponentModel.BackgroundWorker();
            ToolStrip = new ToolStrip();
            SearchToolStripButton = new ToolStripButton();
            ProgressBar = new ToolStripProgressBar();
            PreloadItemsToolStripButton = new ToolStripButton();
            MiscToolStripDropDownButton = new ToolStripDropDownButton();
            ExportAllToolStripMenuItem = new ToolStripMenuItem();
            asBmpToolStripMenuItem = new ToolStripMenuItem();
            asTiffToolStripMenuItem = new ToolStripMenuItem();
            asJpgToolStripMenuItem = new ToolStripMenuItem();
            asPngToolStripMenuItem = new ToolStripMenuItem();
            colorDialog = new ColorDialog();
            collapsibleSplitter1 = new CollapsibleSplitter();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DetailPictureBox).BeginInit();
            DetailPictureBoxContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            TileViewContextMenuStrip.SuspendLayout();
            StatusStrip.SuspendLayout();
            ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new System.Drawing.Point(0, 0);
            splitContainer2.Margin = new Padding(4, 3, 4, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(DetailPictureBox);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(DetailTextBox);
            splitContainer2.Size = new System.Drawing.Size(194, 342);
            splitContainer2.SplitterDistance = 196;
            splitContainer2.SplitterWidth = 5;
            splitContainer2.TabIndex = 0;
            // 
            // DetailPictureBox
            // 
            DetailPictureBox.ContextMenuStrip = DetailPictureBoxContextMenuStrip;
            DetailPictureBox.Dock = DockStyle.Fill;
            DetailPictureBox.Location = new System.Drawing.Point(0, 0);
            DetailPictureBox.Margin = new Padding(4, 3, 4, 3);
            DetailPictureBox.Name = "DetailPictureBox";
            DetailPictureBox.Size = new System.Drawing.Size(194, 196);
            DetailPictureBox.TabIndex = 0;
            DetailPictureBox.TabStop = false;
            // 
            // DetailPictureBoxContextMenuStrip
            // 
            DetailPictureBoxContextMenuStrip.Items.AddRange(new ToolStripItem[] { changeBackgroundColorToolStripMenuItemDetail });
            DetailPictureBoxContextMenuStrip.Name = "contextMenuStrip2";
            DetailPictureBoxContextMenuStrip.Size = new System.Drawing.Size(213, 26);
            // 
            // changeBackgroundColorToolStripMenuItemDetail
            // 
            changeBackgroundColorToolStripMenuItemDetail.Name = "changeBackgroundColorToolStripMenuItemDetail";
            changeBackgroundColorToolStripMenuItemDetail.Size = new System.Drawing.Size(212, 22);
            changeBackgroundColorToolStripMenuItemDetail.Text = "Change background color";
            changeBackgroundColorToolStripMenuItemDetail.Click += ChangeBackgroundColorToolStripMenuItemDetail_Click;
            // 
            // DetailTextBox
            // 
            DetailTextBox.Dock = DockStyle.Fill;
            DetailTextBox.Location = new System.Drawing.Point(0, 0);
            DetailTextBox.Margin = new Padding(4, 3, 4, 3);
            DetailTextBox.Name = "DetailTextBox";
            DetailTextBox.Size = new System.Drawing.Size(194, 141);
            DetailTextBox.TabIndex = 0;
            DetailTextBox.Text = "";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 36);
            splitContainer1.Margin = new Padding(4, 3, 4, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(ItemsTileView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(splitContainer2);
            splitContainer1.Size = new System.Drawing.Size(758, 342);
            splitContainer1.SplitterDistance = 559;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 6;
            // 
            // ItemsTileView
            // 
            ItemsTileView.AutoScroll = true;
            ItemsTileView.AutoScrollMinSize = new System.Drawing.Size(0, 102);
            ItemsTileView.BackColor = System.Drawing.SystemColors.Window;
            ItemsTileView.ContextMenuStrip = TileViewContextMenuStrip;
            ItemsTileView.Dock = DockStyle.Fill;
            ItemsTileView.FocusIndex = -1;
            ItemsTileView.Location = new System.Drawing.Point(0, 0);
            ItemsTileView.Margin = new Padding(4, 3, 4, 3);
            ItemsTileView.MultiSelect = true;
            ItemsTileView.Name = "ItemsTileView";
            ItemsTileView.Size = new System.Drawing.Size(559, 342);
            ItemsTileView.TabIndex = 0;
            ItemsTileView.TileBackgroundColor = System.Drawing.SystemColors.Window;
            ItemsTileView.TileBorderColor = System.Drawing.Color.Gray;
            ItemsTileView.TileBorderWidth = 1F;
            ItemsTileView.TileFocusColor = System.Drawing.Color.DarkRed;
            ItemsTileView.TileHighlightColor = System.Drawing.SystemColors.Highlight;
            ItemsTileView.TileMargin = new Padding(2, 2, 0, 0);
            ItemsTileView.TilePadding = new Padding(1);
            ItemsTileView.TileSize = new System.Drawing.Size(96, 96);
            ItemsTileView.VirtualListSize = 1;
            ItemsTileView.ItemSelectionChanged += ItemsTileView_ItemSelectionChanged;
            ItemsTileView.FocusSelectionChanged += ItemsTileView_FocusSelectionChanged;
            ItemsTileView.DrawItem += ItemsTileView_DrawItem;
            ItemsTileView.KeyDown += ItemsTileView_KeyDown;
            ItemsTileView.KeyUp += ItemsTileView_KeyUp;
            ItemsTileView.MouseDoubleClick += ItemsTileView_MouseDoubleClick;
            // 
            // TileViewContextMenuStrip
            // 
            TileViewContextMenuStrip.Items.AddRange(new ToolStripItem[] { showFreeSlotsToolStripMenuItem, findNextFreeSlotToolStripMenuItem, ChangeBackgroundColorToolStripMenuItem, toolStripSeparator3, selectInTileDataTabToolStripMenuItem, selectInRadarColorTabToolStripMenuItem, selectInGumpsTabMaleToolStripMenuItem, selectInGumpsTabFemaleToolStripMenuItem, toolStripSeparator2, extractToolStripMenuItem, replaceToolStripMenuItem, replaceStartingFromToolStripMenuItem, removeToolStripMenuItem, insertAtToolStripMenuItem, toolStripSeparator5, mirrorToolStripMenuItem, toolStripSeparator1, copyToolStripMenuItem, importToolStripclipboardMenuItem, toolStripSeparator4, saveToolStripMenuItem });
            TileViewContextMenuStrip.Name = "contextMenuStrip1";
            TileViewContextMenuStrip.Size = new System.Drawing.Size(213, 408);
            TileViewContextMenuStrip.Opening += TileViewContextMenuStrip_Opening;
            // 
            // showFreeSlotsToolStripMenuItem
            // 
            showFreeSlotsToolStripMenuItem.CheckOnClick = true;
            showFreeSlotsToolStripMenuItem.Image = Properties.Resources.show;
            showFreeSlotsToolStripMenuItem.Name = "showFreeSlotsToolStripMenuItem";
            showFreeSlotsToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            showFreeSlotsToolStripMenuItem.Text = "Show Free Slots";
            showFreeSlotsToolStripMenuItem.ToolTipText = "Displays all available ID slots.";
            showFreeSlotsToolStripMenuItem.Click += OnClickShowFreeSlots;
            // 
            // findNextFreeSlotToolStripMenuItem
            // 
            findNextFreeSlotToolStripMenuItem.Image = Properties.Resources.Search;
            findNextFreeSlotToolStripMenuItem.Name = "findNextFreeSlotToolStripMenuItem";
            findNextFreeSlotToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            findNextFreeSlotToolStripMenuItem.Text = "Find Next Free Slot";
            findNextFreeSlotToolStripMenuItem.ToolTipText = "Finds the next ID slot.";
            findNextFreeSlotToolStripMenuItem.Click += OnClickFindFree;
            // 
            // ChangeBackgroundColorToolStripMenuItem
            // 
            ChangeBackgroundColorToolStripMenuItem.Image = Properties.Resources.Color;
            ChangeBackgroundColorToolStripMenuItem.Name = "ChangeBackgroundColorToolStripMenuItem";
            ChangeBackgroundColorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            ChangeBackgroundColorToolStripMenuItem.Text = "Change background color";
            ChangeBackgroundColorToolStripMenuItem.ToolTipText = "Changes the background color.";
            ChangeBackgroundColorToolStripMenuItem.Click += ChangeBackgroundColorToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(209, 6);
            // 
            // selectInTileDataTabToolStripMenuItem
            // 
            selectInTileDataTabToolStripMenuItem.Image = Properties.Resources.Select;
            selectInTileDataTabToolStripMenuItem.Name = "selectInTileDataTabToolStripMenuItem";
            selectInTileDataTabToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            selectInTileDataTabToolStripMenuItem.Text = "Select in TileData tab";
            selectInTileDataTabToolStripMenuItem.ToolTipText = "Highlights the ID in the Tiledata tab.";
            selectInTileDataTabToolStripMenuItem.Click += OnClickSelectTiledata;
            // 
            // selectInRadarColorTabToolStripMenuItem
            // 
            selectInRadarColorTabToolStripMenuItem.Image = Properties.Resources.Select;
            selectInRadarColorTabToolStripMenuItem.Name = "selectInRadarColorTabToolStripMenuItem";
            selectInRadarColorTabToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            selectInRadarColorTabToolStripMenuItem.Text = "Select in RadarColor tab";
            selectInRadarColorTabToolStripMenuItem.ToolTipText = "Highlights the ID in the RadarColor tab.";
            selectInRadarColorTabToolStripMenuItem.Click += OnClickSelectRadarCol;
            // 
            // selectInGumpsTabMaleToolStripMenuItem
            // 
            selectInGumpsTabMaleToolStripMenuItem.Enabled = false;
            selectInGumpsTabMaleToolStripMenuItem.Name = "selectInGumpsTabMaleToolStripMenuItem";
            selectInGumpsTabMaleToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            selectInGumpsTabMaleToolStripMenuItem.Text = "Select in Gumps (M)";
            selectInGumpsTabMaleToolStripMenuItem.Click += SelectInGumpsTabMaleToolStripMenuItem_Click;
            // 
            // selectInGumpsTabFemaleToolStripMenuItem
            // 
            selectInGumpsTabFemaleToolStripMenuItem.Enabled = false;
            selectInGumpsTabFemaleToolStripMenuItem.Name = "selectInGumpsTabFemaleToolStripMenuItem";
            selectInGumpsTabFemaleToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            selectInGumpsTabFemaleToolStripMenuItem.Text = "Select in Gumps (F)";
            selectInGumpsTabFemaleToolStripMenuItem.Click += SelectInGumpsTabFemaleToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(209, 6);
            // 
            // extractToolStripMenuItem
            // 
            extractToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { bmpToolStripMenuItem, tiffToolStripMenuItem, asJpgToolStripMenuItem1, asPngToolStripMenuItem1 });
            extractToolStripMenuItem.Image = Properties.Resources.Export;
            extractToolStripMenuItem.Name = "extractToolStripMenuItem";
            extractToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            extractToolStripMenuItem.Text = "Export Image..";
            extractToolStripMenuItem.ToolTipText = "Export the image to.";
            // 
            // bmpToolStripMenuItem
            // 
            bmpToolStripMenuItem.Name = "bmpToolStripMenuItem";
            bmpToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            bmpToolStripMenuItem.Text = "As Bmp";
            bmpToolStripMenuItem.Click += Extract_Image_ClickBmp;
            // 
            // tiffToolStripMenuItem
            // 
            tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            tiffToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            tiffToolStripMenuItem.Text = "As Tiff";
            tiffToolStripMenuItem.Click += Extract_Image_ClickTiff;
            // 
            // asJpgToolStripMenuItem1
            // 
            asJpgToolStripMenuItem1.Name = "asJpgToolStripMenuItem1";
            asJpgToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            asJpgToolStripMenuItem1.Text = "As Jpg";
            asJpgToolStripMenuItem1.Click += Extract_Image_ClickJpg;
            // 
            // asPngToolStripMenuItem1
            // 
            asPngToolStripMenuItem1.Name = "asPngToolStripMenuItem1";
            asPngToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            asPngToolStripMenuItem1.Text = "As Png";
            asPngToolStripMenuItem1.Click += Extract_Image_ClickPng;
            // 
            // replaceToolStripMenuItem
            // 
            replaceToolStripMenuItem.Image = Properties.Resources.replace;
            replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            replaceToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            replaceToolStripMenuItem.Text = "Replace...";
            replaceToolStripMenuItem.ToolTipText = "Replace the image.";
            replaceToolStripMenuItem.Click += OnClickReplace;
            // 
            // replaceStartingFromToolStripMenuItem
            // 
            replaceStartingFromToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ReplaceStartingFromText });
            replaceStartingFromToolStripMenuItem.Image = Properties.Resources.replace2;
            replaceStartingFromToolStripMenuItem.Name = "replaceStartingFromToolStripMenuItem";
            replaceStartingFromToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            replaceStartingFromToolStripMenuItem.Text = "Replace starting from..";
            replaceStartingFromToolStripMenuItem.ToolTipText = "Replace the image at position id.";
            // 
            // ReplaceStartingFromText
            // 
            ReplaceStartingFromText.Name = "ReplaceStartingFromText";
            ReplaceStartingFromText.Size = new System.Drawing.Size(100, 23);
            ReplaceStartingFromText.KeyDown += ReplaceStartingFromText_KeyDown;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Image = Properties.Resources.Remove;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.ToolTipText = "Remove the image.";
            removeToolStripMenuItem.Click += OnClickRemove;
            // 
            // insertAtToolStripMenuItem
            // 
            insertAtToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { InsertText });
            insertAtToolStripMenuItem.Image = Properties.Resources.import;
            insertAtToolStripMenuItem.Name = "insertAtToolStripMenuItem";
            insertAtToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            insertAtToolStripMenuItem.Text = "Insert At..";
            insertAtToolStripMenuItem.ToolTipText = "Inserts at position id.";
            // 
            // InsertText
            // 
            InsertText.Name = "InsertText";
            InsertText.Size = new System.Drawing.Size(100, 23);
            InsertText.KeyDown += OnKeyDownInsertText;
            InsertText.TextChanged += OnTextChangedInsert;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(209, 6);
            // 
            // mirrorToolStripMenuItem
            // 
            mirrorToolStripMenuItem.Image = Properties.Resources.Mirror;
            mirrorToolStripMenuItem.Name = "mirrorToolStripMenuItem";
            mirrorToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            mirrorToolStripMenuItem.Text = "Mirror";
            mirrorToolStripMenuItem.ToolTipText = "Mirror the image.";
            mirrorToolStripMenuItem.Click += mirrorToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(209, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.Copy;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.ToolTipText = "Copy the graphic to the clipboard.";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // importToolStripclipboardMenuItem
            // 
            importToolStripclipboardMenuItem.Image = Properties.Resources.import;
            importToolStripclipboardMenuItem.Name = "importToolStripclipboardMenuItem";
            importToolStripclipboardMenuItem.Size = new System.Drawing.Size(212, 22);
            importToolStripclipboardMenuItem.Text = "Import";
            importToolStripclipboardMenuItem.ToolTipText = "Import clipbord image";
            importToolStripclipboardMenuItem.Click += importToolStripclipboardMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(209, 6);
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.ToolTipText = "Saves the .mul file.";
            saveToolStripMenuItem.Click += OnClickSave;
            // 
            // StatusStrip
            // 
            StatusStrip.Items.AddRange(new ToolStripItem[] { NameLabel, GraphicLabel });
            StatusStrip.Location = new System.Drawing.Point(0, 378);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Padding = new Padding(1, 0, 16, 0);
            StatusStrip.Size = new System.Drawing.Size(758, 22);
            StatusStrip.TabIndex = 5;
            StatusStrip.Text = "statusStrip1";
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = false;
            NameLabel.BorderStyle = Border3DStyle.SunkenInner;
            NameLabel.DisplayStyle = ToolStripItemDisplayStyle.Text;
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new System.Drawing.Size(200, 17);
            NameLabel.Text = "Name:";
            NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GraphicLabel
            // 
            GraphicLabel.AutoSize = false;
            GraphicLabel.Name = "GraphicLabel";
            GraphicLabel.Size = new System.Drawing.Size(150, 17);
            GraphicLabel.Text = "Graphic:";
            GraphicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PreLoader
            // 
            PreLoader.WorkerReportsProgress = true;
            PreLoader.DoWork += PreLoaderDoWork;
            PreLoader.ProgressChanged += PreLoaderProgressChanged;
            PreLoader.RunWorkerCompleted += PreLoaderCompleted;
            // 
            // ToolStrip
            // 
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.Items.AddRange(new ToolStripItem[] { SearchToolStripButton, ProgressBar, PreloadItemsToolStripButton, MiscToolStripDropDownButton });
            ToolStrip.Location = new System.Drawing.Point(0, 0);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.RenderMode = ToolStripRenderMode.System;
            ToolStrip.Size = new System.Drawing.Size(758, 28);
            ToolStrip.TabIndex = 7;
            // 
            // SearchToolStripButton
            // 
            SearchToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            SearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            SearchToolStripButton.Name = "SearchToolStripButton";
            SearchToolStripButton.Size = new System.Drawing.Size(46, 25);
            SearchToolStripButton.Text = "Search";
            SearchToolStripButton.Click += OnSearchClick;
            // 
            // ProgressBar
            // 
            ProgressBar.Alignment = ToolStripItemAlignment.Right;
            ProgressBar.Name = "ProgressBar";
            ProgressBar.Size = new System.Drawing.Size(117, 25);
            // 
            // PreloadItemsToolStripButton
            // 
            PreloadItemsToolStripButton.Alignment = ToolStripItemAlignment.Right;
            PreloadItemsToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            PreloadItemsToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            PreloadItemsToolStripButton.Name = "PreloadItemsToolStripButton";
            PreloadItemsToolStripButton.Size = new System.Drawing.Size(83, 25);
            PreloadItemsToolStripButton.Text = "Preload Items";
            PreloadItemsToolStripButton.Click += OnClickPreLoad;
            // 
            // MiscToolStripDropDownButton
            // 
            MiscToolStripDropDownButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            MiscToolStripDropDownButton.DropDownItems.AddRange(new ToolStripItem[] { ExportAllToolStripMenuItem });
            MiscToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            MiscToolStripDropDownButton.Name = "MiscToolStripDropDownButton";
            MiscToolStripDropDownButton.Size = new System.Drawing.Size(45, 25);
            MiscToolStripDropDownButton.Text = "Misc";
            // 
            // ExportAllToolStripMenuItem
            // 
            ExportAllToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { asBmpToolStripMenuItem, asTiffToolStripMenuItem, asJpgToolStripMenuItem, asPngToolStripMenuItem });
            ExportAllToolStripMenuItem.Name = "ExportAllToolStripMenuItem";
            ExportAllToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            ExportAllToolStripMenuItem.Text = "Export all..";
            // 
            // asBmpToolStripMenuItem
            // 
            asBmpToolStripMenuItem.Name = "asBmpToolStripMenuItem";
            asBmpToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asBmpToolStripMenuItem.Text = "As Bmp";
            asBmpToolStripMenuItem.Click += OnClick_SaveAllBmp;
            // 
            // asTiffToolStripMenuItem
            // 
            asTiffToolStripMenuItem.Name = "asTiffToolStripMenuItem";
            asTiffToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asTiffToolStripMenuItem.Text = "As Tiff";
            asTiffToolStripMenuItem.Click += OnClick_SaveAllTiff;
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
            // collapsibleSplitter1
            // 
            collapsibleSplitter1.AnimationDelay = 20;
            collapsibleSplitter1.AnimationStep = 20;
            collapsibleSplitter1.BorderStyle3D = Border3DStyle.Flat;
            collapsibleSplitter1.ControlToHide = ToolStrip;
            collapsibleSplitter1.Dock = DockStyle.Top;
            collapsibleSplitter1.ExpandParentForm = false;
            collapsibleSplitter1.Location = new System.Drawing.Point(0, 28);
            collapsibleSplitter1.Margin = new Padding(4, 3, 4, 3);
            collapsibleSplitter1.Name = "collapsibleSplitter1";
            collapsibleSplitter1.Size = new System.Drawing.Size(758, 8);
            collapsibleSplitter1.TabIndex = 8;
            collapsibleSplitter1.TabStop = false;
            collapsibleSplitter1.UseAnimations = false;
            collapsibleSplitter1.VisualStyle = VisualStyles.DoubleDots;
            // 
            // ItemsControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainer1);
            Controls.Add(StatusStrip);
            Controls.Add(collapsibleSplitter1);
            Controls.Add(ToolStrip);
            DoubleBuffered = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ItemsControl";
            Size = new System.Drawing.Size(758, 400);
            Load += OnLoad;
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DetailPictureBox).EndInit();
            DetailPictureBoxContextMenuStrip.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            TileViewContextMenuStrip.ResumeLayout(false);
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStripMenuItem asBmpToolStripMenuItem;
        private ToolStripMenuItem asJpgToolStripMenuItem;
        private ToolStripMenuItem asJpgToolStripMenuItem1;
        private ToolStripMenuItem asPngToolStripMenuItem;
        private ToolStripMenuItem asPngToolStripMenuItem1;
        private ToolStripMenuItem asTiffToolStripMenuItem;
        private ToolStripMenuItem bmpToolStripMenuItem;
        private UoFiddler.Controls.UserControls.CollapsibleSplitter collapsibleSplitter1;
        private ContextMenuStrip TileViewContextMenuStrip;
        private PictureBox DetailPictureBox;
        private ToolStripMenuItem ExportAllToolStripMenuItem;
        private ToolStripMenuItem extractToolStripMenuItem;
        private ToolStripMenuItem findNextFreeSlotToolStripMenuItem;
        private ToolStripStatusLabel GraphicLabel;
        private ToolStripMenuItem insertAtToolStripMenuItem;
        private ToolStripTextBox InsertText;
        private ToolStripStatusLabel NameLabel;
        private System.ComponentModel.BackgroundWorker PreLoader;
        private ToolStripProgressBar ProgressBar;
        private ToolStripMenuItem removeToolStripMenuItem;
        private ToolStripMenuItem replaceToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem selectInRadarColorTabToolStripMenuItem;
        private ToolStripMenuItem selectInTileDataTabToolStripMenuItem;
        private ToolStripMenuItem showFreeSlotsToolStripMenuItem;
        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private StatusStrip StatusStrip;
        private ToolStripMenuItem tiffToolStripMenuItem;
        private ToolStrip ToolStrip;
        private ToolStripButton SearchToolStripButton;
        private ToolStripButton PreloadItemsToolStripButton;
        private ToolStripDropDownButton MiscToolStripDropDownButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ContextMenuStrip DetailPictureBoxContextMenuStrip;
        private ToolStripMenuItem changeBackgroundColorToolStripMenuItemDetail;
        private ColorDialog colorDialog;
        private ToolStripMenuItem ChangeBackgroundColorToolStripMenuItem;
        private TileView.TileViewControl ItemsTileView;
        private RichTextBox DetailTextBox;
        private ToolStripMenuItem selectInGumpsTabMaleToolStripMenuItem;
        private ToolStripMenuItem selectInGumpsTabFemaleToolStripMenuItem;
        private ToolStripMenuItem replaceStartingFromToolStripMenuItem;
        private ToolStripTextBox ReplaceStartingFromText;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem importToolStripclipboardMenuItem;
        private ToolStripMenuItem mirrorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator5;
    }
}
