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
using UoFiddler.Controls.UserControls.TileView;

namespace UoFiddler.Controls.UserControls
{
    partial class LandTilesControl
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
            LandTilesContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            showFreeSlotsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            exportImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asBmpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asTiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asJpgToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            asPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            selectInTileDataTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            selectInRadarColorTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            findNextFreeSlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            replaceStartingFromToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ReplaceStartingFromTb = new System.Windows.Forms.ToolStripTextBox();
            insertAtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            InsertText = new System.Windows.Forms.ToolStripTextBox();
            toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            importToTempToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            rotateBy90DegreesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            LandTilesToolStrip = new System.Windows.Forms.ToolStrip();
            NameLabel = new System.Windows.Forms.ToolStripLabel();
            GraphicLabel = new System.Windows.Forms.ToolStripLabel();
            FlagsLabel = new System.Windows.Forms.ToolStripLabel();
            MiscToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            exportAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ExportAllAsBmp = new System.Windows.Forms.ToolStripMenuItem();
            ExportAllAsTiff = new System.Windows.Forms.ToolStripMenuItem();
            asJpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            asPngToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            SearchButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            SaveButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            LandTilesTileView = new TileViewControl();
            LandTilesContextMenuStrip.SuspendLayout();
            LandTilesToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // LandTilesContextMenuStrip
            // 
            LandTilesContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { showFreeSlotsToolStripMenuItem, toolStripSeparator6, exportImageToolStripMenuItem, toolStripSeparator3, selectInTileDataTabToolStripMenuItem, selectInRadarColorTabToolStripMenuItem, toolStripSeparator2, findNextFreeSlotToolStripMenuItem, removeToolStripMenuItem, replaceToolStripMenuItem, replaceStartingFromToolStripMenuItem, insertAtToolStripMenuItem, toolStripSeparator7, copyToolStripMenuItem, importToolStripMenuItem, importToTempToolStripMenuItem, toolStripSeparator8, rotateBy90DegreesToolStripMenuItem });
            LandTilesContextMenuStrip.Name = "contextMenuStrip1";
            LandTilesContextMenuStrip.Size = new System.Drawing.Size(201, 342);
            // 
            // showFreeSlotsToolStripMenuItem
            // 
            showFreeSlotsToolStripMenuItem.CheckOnClick = true;
            showFreeSlotsToolStripMenuItem.Image = Properties.Resources.Search;
            showFreeSlotsToolStripMenuItem.Name = "showFreeSlotsToolStripMenuItem";
            showFreeSlotsToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            showFreeSlotsToolStripMenuItem.Text = "Show Free Slots";
            showFreeSlotsToolStripMenuItem.Click += ShowFreeSlotsToolStripMenuItem_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(197, 6);
            // 
            // exportImageToolStripMenuItem
            // 
            exportImageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { asBmpToolStripMenuItem, asTiffToolStripMenuItem, asJpgToolStripMenuItem1, asPngToolStripMenuItem });
            exportImageToolStripMenuItem.Image = Properties.Resources.Export;
            exportImageToolStripMenuItem.Name = "exportImageToolStripMenuItem";
            exportImageToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            exportImageToolStripMenuItem.Text = "Export Image..";
            // 
            // asBmpToolStripMenuItem
            // 
            asBmpToolStripMenuItem.Name = "asBmpToolStripMenuItem";
            asBmpToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asBmpToolStripMenuItem.Text = "As Bmp";
            asBmpToolStripMenuItem.Click += OnClickExportBmp;
            // 
            // asTiffToolStripMenuItem
            // 
            asTiffToolStripMenuItem.Name = "asTiffToolStripMenuItem";
            asTiffToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asTiffToolStripMenuItem.Text = "As Tiff";
            asTiffToolStripMenuItem.Click += OnClickExportTiff;
            // 
            // asJpgToolStripMenuItem1
            // 
            asJpgToolStripMenuItem1.Name = "asJpgToolStripMenuItem1";
            asJpgToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asJpgToolStripMenuItem1.Text = "As Jpg";
            asJpgToolStripMenuItem1.Click += OnClickExportJpg;
            // 
            // asPngToolStripMenuItem
            // 
            asPngToolStripMenuItem.Name = "asPngToolStripMenuItem";
            asPngToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asPngToolStripMenuItem.Text = "As Png";
            asPngToolStripMenuItem.Click += OnClickExportPng;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(197, 6);
            // 
            // selectInTileDataTabToolStripMenuItem
            // 
            selectInTileDataTabToolStripMenuItem.Image = Properties.Resources.Select;
            selectInTileDataTabToolStripMenuItem.Name = "selectInTileDataTabToolStripMenuItem";
            selectInTileDataTabToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            selectInTileDataTabToolStripMenuItem.Text = "Select in TileData tab";
            selectInTileDataTabToolStripMenuItem.Click += OnClickSelectTiledata;
            // 
            // selectInRadarColorTabToolStripMenuItem
            // 
            selectInRadarColorTabToolStripMenuItem.Image = Properties.Resources.Select;
            selectInRadarColorTabToolStripMenuItem.Name = "selectInRadarColorTabToolStripMenuItem";
            selectInRadarColorTabToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            selectInRadarColorTabToolStripMenuItem.Text = "Select in RadarColor tab";
            selectInRadarColorTabToolStripMenuItem.Click += OnClickSelectRadarCol;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // findNextFreeSlotToolStripMenuItem
            // 
            findNextFreeSlotToolStripMenuItem.Image = Properties.Resources.Search;
            findNextFreeSlotToolStripMenuItem.Name = "findNextFreeSlotToolStripMenuItem";
            findNextFreeSlotToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            findNextFreeSlotToolStripMenuItem.Text = "Find Next Free Slot";
            findNextFreeSlotToolStripMenuItem.Click += OnClickFindFree;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Image = Properties.Resources.Remove;
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            removeToolStripMenuItem.Text = "Remove";
            removeToolStripMenuItem.Click += OnClickRemove;
            // 
            // replaceToolStripMenuItem
            // 
            replaceToolStripMenuItem.Image = Properties.Resources.replace;
            replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            replaceToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            replaceToolStripMenuItem.Text = "Replace";
            replaceToolStripMenuItem.Click += OnClickReplace;
            // 
            // replaceStartingFromToolStripMenuItem
            // 
            replaceStartingFromToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ReplaceStartingFromTb });
            replaceStartingFromToolStripMenuItem.Image = Properties.Resources.replace2;
            replaceStartingFromToolStripMenuItem.Name = "replaceStartingFromToolStripMenuItem";
            replaceStartingFromToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            replaceStartingFromToolStripMenuItem.Text = "Replace starting from..";
            // 
            // ReplaceStartingFromTb
            // 
            ReplaceStartingFromTb.Name = "ReplaceStartingFromTb";
            ReplaceStartingFromTb.Size = new System.Drawing.Size(100, 23);
            ReplaceStartingFromTb.KeyDown += ReplaceStartingFromTb_KeyDown;
            // 
            // insertAtToolStripMenuItem
            // 
            insertAtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { InsertText });
            insertAtToolStripMenuItem.Image = Properties.Resources.import;
            insertAtToolStripMenuItem.Name = "insertAtToolStripMenuItem";
            insertAtToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            insertAtToolStripMenuItem.Text = "Insert At..";
            // 
            // InsertText
            // 
            InsertText.Name = "InsertText";
            InsertText.Size = new System.Drawing.Size(100, 23);
            InsertText.KeyDown += OnKeyDownInsert;
            InsertText.TextChanged += OnTextChangedInsert;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new System.Drawing.Size(197, 6);
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Image = Properties.Resources.Copy;
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.ToolTipText = "Copy the graphic to the clipboard.";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Image = Properties.Resources.import;
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.ToolTipText = "Import the graphic from the clipboard.";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click;
            // 
            // importToTempToolStripMenuItem
            // 
            importToTempToolStripMenuItem.Image = Properties.Resources.import;
            importToTempToolStripMenuItem.Name = "importToTempToolStripMenuItem";
            importToTempToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            importToTempToolStripMenuItem.Text = "Import to Temp";
            importToTempToolStripMenuItem.Click += importToTempToolStripMenuItem_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(197, 6);
            // 
            // rotateBy90DegreesToolStripMenuItem
            // 
            rotateBy90DegreesToolStripMenuItem.Image = Properties.Resources.Rotate;
            rotateBy90DegreesToolStripMenuItem.Name = "rotateBy90DegreesToolStripMenuItem";
            rotateBy90DegreesToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            rotateBy90DegreesToolStripMenuItem.Text = "Rotate by 90 degrees.";
            rotateBy90DegreesToolStripMenuItem.Click += rotateBy90DegreesToolStripMenuItem_Click;
            // 
            // LandTilesToolStrip
            // 
            LandTilesToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            LandTilesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { NameLabel, GraphicLabel, FlagsLabel, MiscToolStripDropDownButton, toolStripSeparator5, SearchButton, toolStripSeparator1, SaveButton, toolStripSeparator4 });
            LandTilesToolStrip.Location = new System.Drawing.Point(0, 0);
            LandTilesToolStrip.Name = "LandTilesToolStrip";
            LandTilesToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            LandTilesToolStrip.Size = new System.Drawing.Size(716, 25);
            LandTilesToolStrip.TabIndex = 5;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = false;
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new System.Drawing.Size(140, 22);
            NameLabel.Text = "Name:";
            NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GraphicLabel
            // 
            GraphicLabel.AutoSize = false;
            GraphicLabel.Name = "GraphicLabel";
            GraphicLabel.Size = new System.Drawing.Size(120, 22);
            GraphicLabel.Text = "Graphic:";
            GraphicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FlagsLabel
            // 
            FlagsLabel.Name = "FlagsLabel";
            FlagsLabel.Size = new System.Drawing.Size(37, 22);
            FlagsLabel.Text = "Flags:";
            FlagsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MiscToolStripDropDownButton
            // 
            MiscToolStripDropDownButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            MiscToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            MiscToolStripDropDownButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { exportAllToolStripMenuItem });
            MiscToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            MiscToolStripDropDownButton.Margin = new System.Windows.Forms.Padding(0, 1, 20, 2);
            MiscToolStripDropDownButton.Name = "MiscToolStripDropDownButton";
            MiscToolStripDropDownButton.Size = new System.Drawing.Size(45, 22);
            MiscToolStripDropDownButton.Text = "Misc";
            // 
            // exportAllToolStripMenuItem
            // 
            exportAllToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { ExportAllAsBmp, ExportAllAsTiff, asJpgToolStripMenuItem, asPngToolStripMenuItem1 });
            exportAllToolStripMenuItem.Name = "exportAllToolStripMenuItem";
            exportAllToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            exportAllToolStripMenuItem.Text = "Export All..";
            // 
            // ExportAllAsBmp
            // 
            ExportAllAsBmp.Name = "ExportAllAsBmp";
            ExportAllAsBmp.Size = new System.Drawing.Size(115, 22);
            ExportAllAsBmp.Text = "As Bmp";
            ExportAllAsBmp.Click += OnClick_SaveAllBmp;
            // 
            // ExportAllAsTiff
            // 
            ExportAllAsTiff.Name = "ExportAllAsTiff";
            ExportAllAsTiff.Size = new System.Drawing.Size(115, 22);
            ExportAllAsTiff.Text = "As Tiff";
            ExportAllAsTiff.Click += OnClick_SaveAllTiff;
            // 
            // asJpgToolStripMenuItem
            // 
            asJpgToolStripMenuItem.Name = "asJpgToolStripMenuItem";
            asJpgToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            asJpgToolStripMenuItem.Text = "As Jpg";
            asJpgToolStripMenuItem.Click += OnClick_SaveAllJpg;
            // 
            // asPngToolStripMenuItem1
            // 
            asPngToolStripMenuItem1.Name = "asPngToolStripMenuItem1";
            asPngToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            asPngToolStripMenuItem1.Text = "As Png";
            asPngToolStripMenuItem1.Click += OnClick_SaveAllPng;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // SearchButton
            // 
            SearchButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            SearchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            SearchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new System.Drawing.Size(46, 22);
            SearchButton.Text = "Search";
            SearchButton.Click += OnClickSearch;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveButton
            // 
            SaveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            SaveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            SaveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new System.Drawing.Size(35, 22);
            SaveButton.Text = "Save";
            SaveButton.Click += OnClickSave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // LandTilesTileView
            // 
            LandTilesTileView.AutoScroll = true;
            LandTilesTileView.AutoScrollMinSize = new System.Drawing.Size(0, 50);
            LandTilesTileView.BackColor = System.Drawing.SystemColors.Window;
            LandTilesTileView.ContextMenuStrip = LandTilesContextMenuStrip;
            LandTilesTileView.Dock = System.Windows.Forms.DockStyle.Fill;
            LandTilesTileView.FocusIndex = -1;
            LandTilesTileView.Location = new System.Drawing.Point(0, 25);
            LandTilesTileView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            LandTilesTileView.MultiSelect = false;
            LandTilesTileView.Name = "LandTilesTileView";
            LandTilesTileView.Size = new System.Drawing.Size(716, 376);
            LandTilesTileView.TabIndex = 8;
            LandTilesTileView.TileBackgroundColor = System.Drawing.SystemColors.Window;
            LandTilesTileView.TileBorderColor = System.Drawing.Color.Gray;
            LandTilesTileView.TileBorderWidth = 1F;
            LandTilesTileView.TileFocusColor = System.Drawing.Color.DarkRed;
            LandTilesTileView.TileHighlightColor = System.Drawing.SystemColors.Highlight;
            LandTilesTileView.TileMargin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            LandTilesTileView.TilePadding = new System.Windows.Forms.Padding(1);
            LandTilesTileView.TileSize = new System.Drawing.Size(44, 44);
            LandTilesTileView.VirtualListSize = 1;
            LandTilesTileView.ItemSelectionChanged += LandTilesTileView_ItemSelectionChanged;
            LandTilesTileView.DrawItem += LandTilesTileView_DrawItem;
            LandTilesTileView.KeyDown += LandTilesControl_KeyDown;
            // 
            // LandTilesControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(LandTilesTileView);
            Controls.Add(LandTilesToolStrip);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "LandTilesControl";
            Size = new System.Drawing.Size(716, 401);
            Load += OnLoad;
            LandTilesContextMenuStrip.ResumeLayout(false);
            LandTilesToolStrip.ResumeLayout(false);
            LandTilesToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem asBmpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asJpgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asJpgToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asPngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asPngToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem asTiffToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LandTilesContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ExportAllAsBmp;
        private System.Windows.Forms.ToolStripMenuItem ExportAllAsTiff;
        private System.Windows.Forms.ToolStripMenuItem exportAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findNextFreeSlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel FlagsLabel;
        private System.Windows.Forms.ToolStripLabel GraphicLabel;
        private System.Windows.Forms.ToolStripMenuItem insertAtToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox InsertText;
        private System.Windows.Forms.ToolStripLabel NameLabel;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveButton;
        private System.Windows.Forms.ToolStripButton SearchButton;
        private System.Windows.Forms.ToolStripMenuItem selectInRadarColorTabToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectInTileDataTabToolStripMenuItem;
        private System.Windows.Forms.ToolStrip LandTilesToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton MiscToolStripDropDownButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private TileView.TileViewControl LandTilesTileView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem replaceStartingFromToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox ReplaceStartingFromTb;
        private System.Windows.Forms.ToolStripMenuItem showFreeSlotsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToTempToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem rotateBy90DegreesToolStripMenuItem;
    }
}
