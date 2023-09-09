﻿/***************************************************************************
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
using System.Security.Cryptography;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Classes;
using UoFiddler.Plugin.Compare.Classes;

namespace UoFiddler.Plugin.Compare.UserControls
{
    public partial class CompareItemControl : UserControl
    {
        private readonly Dictionary<int, bool> _mCompare = new Dictionary<int, bool>();
        private readonly ImageConverter _ic = new ImageConverter();
        private readonly SHA256 _sha256 = SHA256.Create();

        public CompareItemControl()
        {
            InitializeComponent();
            listBoxSec.SelectedIndexChanged += OnSelectedIndexChangedSec; //Replace graphic

        }

        private void OnLoad(object sender, EventArgs e)
        {
            listBoxOrg.Items.Clear();
            listBoxOrg.BeginUpdate();
            List<object> cache = new List<object>();
            int staticsLength = Art.GetMaxItemId() + 1;
            for (int i = 0; i < staticsLength; i++)
            {
                cache.Add(i);
            }
            listBoxOrg.Items.AddRange(cache.ToArray());
            listBoxOrg.EndUpdate();

            // CompareiItemsDirectoryisSettings Directory last directory is loaded
            if (!Directory.Exists(settingsDirectory))
            {
                Directory.CreateDirectory(settingsDirectory);
            }
            settingsFilePath = Path.Combine(settingsDirectory, settingsFileName);

            if (File.Exists(settingsFilePath))
            {
                lastSelectedPath = File.ReadAllText(settingsFilePath);
                textBoxSecondDir.Text = lastSelectedPath;
            }

            //Load the settings for Combobox
            LoadSettingsDirectoryComboBox();
        }

        private void LoadSettingsDirectoryComboBox()
        {
            string settingsDirectory = "DirectoryisSettings";
            string lastDirectoriesFileName = "CompareiItemsLastDirectories.txt";
            string lastDirectoriesFilePath = Path.Combine(settingsDirectory, lastDirectoriesFileName);
            if (File.Exists(lastDirectoriesFilePath))
            {
                string[] lines = File.ReadAllLines(lastDirectoriesFilePath);
                foreach (string line in lines)
                {
                    comboBoxSaveDir.Items.Add(line);
                }
            }
        }

        private void OnIndexChangedOrg(object sender, EventArgs e)
        {
            if (listBoxOrg.SelectedIndex == -1 || listBoxOrg.Items.Count < 1)
            {
                return;
            }

            int i = int.Parse(listBoxOrg.Items[listBoxOrg.SelectedIndex].ToString());
            if (listBoxSec.Items.Count > 0)
            {
                int pos = listBoxSec.Items.IndexOf(i);
                if (pos >= 0)
                {
                    listBoxSec.SelectedIndex = pos;
                }
            }

            pictureBoxOrg.BackgroundImage = Art.IsValidStatic(i)
                ? Art.GetStatic(i)
                : null;

            listBoxOrg.Invalidate();
        }

        private void DrawItemOrg(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            Brush fontBrush = Brushes.Gray;

            int i = int.Parse(listBoxOrg.Items[e.Index].ToString());
            if (listBoxOrg.SelectedIndex == e.Index)
            {
                e.Graphics.FillRectangle(Brushes.LightSteelBlue, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }

            if (!Art.IsValidStatic(i))
            {
                fontBrush = Brushes.Red;
            }
            else if (listBoxSec.Items.Count > 0)
            {
                if (!Compare(i))
                {
                    fontBrush = Brushes.Blue;
                }
            }

            e.Graphics.DrawString($"0x{i:X}", Font, fontBrush,
                new PointF(5,
                e.Bounds.Y + ((e.Bounds.Height / 2) -
                (e.Graphics.MeasureString($"0x{i:X}", Font).Height / 2))));
        }


        private void MeasureOrg(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 13;
        }

        /*private void OnClickLoadSecond(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSecondDir.Text))
            {
                return;
            }

            string path = textBoxSecondDir.Text;
            string file = Path.Combine(path, "art.mul");
            string file2 = Path.Combine(path, "artidx.mul");
            if (File.Exists(file) && File.Exists(file2))
            {
                SecondArt.SetFileIndex(file2, file);
                LoadSecond();
            }
        }*/

        private void OnClickLoadSecond(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSecondDir.Text))
            {
                return;
            }

            string path = textBoxSecondDir.Text;
            string mulFile = Path.Combine(path, "art.mul");
            string idxFile = Path.Combine(path, "artidx.mul");
            //string uopFile = Path.Combine(path, "artLegacyMUL.uop");
            if (File.Exists(mulFile) && File.Exists(idxFile))
            {
                SecondArt.SetFileIndex(idxFile, mulFile); //Load .mul file
                LoadSecond();
            }
            /*else if (File.Exists(uopFile)) //Load .uop file
            {
                SecondArt.SetFileIndex(idxFile, uopFile); 
                LoadSecond();
            }*/
        }

        private void LoadSecond()
        {
            _mCompare.Clear();
            listBoxSec.BeginUpdate();
            listBoxSec.Items.Clear();
            List<object> cache = new List<object>();
            int staticLength = SecondArt.GetMaxItemId() + 1;
            for (int i = 0; i < staticLength; i++)
            {
                cache.Add(i);
            }
            listBoxSec.Items.AddRange(cache.ToArray());
            listBoxSec.EndUpdate();
        }

        //Colors 
        private void DrawItemSec(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            Brush fontBrush = Brushes.Gray;
            Brush selectionBrush = Brushes.LightSteelBlue; // Color for first choice
            Brush secondSelectionBrush = Brushes.Yellow; // Color for second choice

            int i = int.Parse(listBoxSec.Items[e.Index].ToString());

            if (listBoxSec.SelectedIndices.Contains(e.Index))
            {
                if (ModifierKeys.HasFlag(Keys.Control)) // When CTRL key is pressed
                {
                    e.Graphics.FillRectangle(secondSelectionBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }
                else
                {
                    e.Graphics.FillRectangle(selectionBrush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
                }
            }

            if (!SecondArt.IsValidStatic(i))
            {
                fontBrush = Brushes.Red;
            }
            else if (!Compare(i))
            {
                fontBrush = Brushes.Blue;
            }

            e.Graphics.DrawString($"0x{i:X}", Font, fontBrush,
                new PointF(5,
                e.Bounds.Y + ((e.Bounds.Height / 2) -
                (e.Graphics.MeasureString($"0x{i:X}", Font).Height / 2))));
        }


        private void listBoxSec_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index == -1)
            {
                return;
            }

            Brush fontBrush = Brushes.Gray;
            Brush backBrush = Brushes.White;

            int i = int.Parse(listBoxSec.Items[e.Index].ToString());

            if (e.State.HasFlag(DrawItemState.Selected))
            {
                backBrush = Brushes.LightSteelBlue;
            }

            if (Control.ModifierKeys == Keys.Control && listBoxSec.SelectedIndices.Contains(e.Index))
            {
                backBrush = Brushes.LightGreen;
            }

            if (!SecondArt.IsValidStatic(i))
            {
                fontBrush = Brushes.Red;
            }
            else if (!Compare(i))
            {
                fontBrush = Brushes.Blue;
            }

            e.Graphics.FillRectangle(backBrush, e.Bounds);
            e.Graphics.DrawString($"0x{i:X}", Font, fontBrush,
                new PointF(5,
                e.Bounds.Y + ((e.Bounds.Height / 2) -
                (e.Graphics.MeasureString($"0x{i:X}", Font).Height / 2))));
        }


        private void MeasureSec(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 13;
        }

        private void OnIndexChangedSec(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndex == -1 || listBoxSec.Items.Count < 1)
            {
                return;
            }

            int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndex].ToString());
            int pos = listBoxOrg.Items.IndexOf(i);
            if (pos >= 0)
            {
                listBoxOrg.SelectedIndex = pos;
            }

            pictureBoxSec.BackgroundImage = SecondArt.IsValidStatic(i)
                ? SecondArt.GetStatic(i)
                : null;

            listBoxSec.Invalidate();
        }

        private bool Compare(int index)
        {
            if (_mCompare.ContainsKey(index))
            {
                return _mCompare[index];
            }

            Bitmap bitorg = Art.GetStatic(index);
            Bitmap bitsec = SecondArt.GetStatic(index);
            if (bitorg == null && bitsec == null)
            {
                _mCompare[index] = true;
                return true;
            }
            if (bitorg == null || bitsec == null
                               || bitorg.Size != bitsec.Size)
            {
                _mCompare[index] = false;
                return false;
            }

            byte[] btImage1 = new byte[1];
            btImage1 = (byte[])_ic.ConvertTo(bitorg, btImage1.GetType());
            byte[] btImage2 = new byte[1];
            btImage2 = (byte[])_ic.ConvertTo(bitsec, btImage2.GetType());

            byte[] checksum1 = _sha256.ComputeHash(btImage1);
            byte[] checksum2 = _sha256.ComputeHash(btImage2);
            bool res = true;
            for (int j = 0; j < checksum1.Length; ++j)
            {
                if (checksum1[j] != checksum2[j])
                {
                    res = false;
                    break;
                }
            }
            _mCompare[index] = res;
            return res;
        }

        private void OnChangeShowDiff(object sender, EventArgs e)
        {
            if (_mCompare.Count < 1)
            {
                if (checkBox1.Checked)
                {
                    MessageBox.Show("Second Item file is not loaded!");
                    checkBox1.Checked = false;
                }
                return;
            }

            listBoxOrg.BeginUpdate();
            listBoxSec.BeginUpdate();
            listBoxOrg.Items.Clear();
            listBoxSec.Items.Clear();
            List<object> cache = new List<object>();
            int staticLength = Math.Max(Art.GetMaxItemId(), SecondArt.GetMaxItemId());
            if (checkBox1.Checked)
            {
                for (int i = 0; i < staticLength; i++)
                {
                    if (!Compare(i))
                    {
                        cache.Add(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < staticLength; i++)
                {
                    cache.Add(i);
                }
            }
            listBoxOrg.Items.AddRange(cache.ToArray());
            listBoxSec.Items.AddRange(cache.ToArray());
            listBoxOrg.EndUpdate();
            listBoxSec.EndUpdate();
        }

        #region ExportAsBmp + ExportAsTiff listBoxSec
        private void ExportAsBmp(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndex == -1)
            {
                return;
            }

            int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndex].ToString());
            if (!SecondArt.IsValidStatic(i))
            {
                return;
            }

            string path = Options.OutputPath;
            string fileName = Path.Combine(path, $"Item(Sec) 0x{i:X}.bmp");
            SecondArt.GetStatic(i).Save(fileName, ImageFormat.Bmp);
            MessageBox.Show(
                $"Item saved to {fileName}",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }

        private void ExportAsTiff(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndex == -1)
            {
                return;
            }

            int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndex].ToString());
            if (!SecondArt.IsValidStatic(i))
            {
                return;
            }

            string path = Options.OutputPath;
            string fileName = Path.Combine(path, $"Item(Sec) 0x{i:X}.tiff");
            SecondArt.GetStatic(i).Save(fileName, ImageFormat.Tiff);
            MessageBox.Show(
                $"Item saved to {fileName}",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
        }
        #endregion

        #region Export image from to
        private void ExportAsBmp2(object sender, EventArgs e)
        {
            // Check if at least 2 items are selected
            if (listBoxSec.SelectedIndices.Count < 2)
            {
                MessageBox.Show("Please select at least 2 items.");
                return;
            }

            // Determine start and end address
            int startAddress = int.MaxValue;
            int endAddress = int.MinValue;
            foreach (int index in listBoxSec.SelectedIndices)
            {
                int address = int.Parse(listBoxSec.Items[index].ToString());
                if (address < startAddress) startAddress = address;
                if (address > endAddress) endAddress = address;
            }

            // Save the BMP files in the specified area
            for (int i = startAddress; i <= endAddress; i++)
            {
                if (!SecondArt.IsValidStatic(i)) continue;
                string path = Options.OutputPath;
                string fileName = Path.Combine(path, $"Item(Sec) 0x{i:X}.bmp");
                SecondArt.GetStatic(i).Save(fileName, ImageFormat.Bmp);
            }

            MessageBox.Show($"Images saved to {Options.OutputPath}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ExportAsTiff2(object sender, EventArgs e)
        {
            // Check if at least 2 items are selected
            if (listBoxSec.SelectedIndices.Count < 2)
            {
                MessageBox.Show("Please select at least 2 items.");
                return;
            }

            // Determine start and end address
            int startAddress = int.MaxValue;
            int endAddress = int.MinValue;
            foreach (int index in listBoxSec.SelectedIndices)
            {
                int address = int.Parse(listBoxSec.Items[index].ToString());
                if (address < startAddress) startAddress = address;
                if (address > endAddress) endAddress = address;
            }

            // Speichern der TIFF-Dateien im angegebenen Bereich
            for (int i = startAddress; i <= endAddress; i++)
            {
                if (!SecondArt.IsValidStatic(i)) continue;
                string path = Options.OutputPath;
                string fileName = Path.Combine(path, $"Item(Sec) 0x{i:X}.tiff");
                SecondArt.GetStatic(i).Save(fileName, ImageFormat.Tiff);
            }

            MessageBox.Show($"Images saved to {Options.OutputPath}", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region OnClickCopy
        private void OnClickCopy(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndex == -1)
            {
                return;
            }

            int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndex].ToString());
            if (!SecondArt.IsValidStatic(i))
            {
                return;
            }

            int staticLength = Art.GetMaxItemId() + 1;
            if (i >= staticLength)
            {
                return;
            }

            Bitmap copy = new Bitmap(SecondArt.GetStatic(i));
            Art.ReplaceStatic(i, copy);
            Options.ChangedUltimaClass["Art"] = true;
            ControlEvents.FireItemChangeEvent(this, i);
            _mCompare[i] = true;
            listBoxOrg.BeginUpdate();
            bool done = false;

            for (int id = 0; id < staticLength; id++)
            {
                if (id > i)
                {
                    listBoxOrg.Items.Insert(id, i);
                    done = true;
                    break;
                }

                if (id == i)
                {
                    done = true;
                    break;
                }
            }

            if (!done)
            {
                listBoxOrg.Items.Add(i);
            }

            listBoxOrg.EndUpdate();
            listBoxOrg.Invalidate();
            listBoxSec.Invalidate();
            OnIndexChangedOrg(this, null);
        }
        #endregion

        #region Replace graphic        

        private void OnClickReplace(object sender, EventArgs e)
        {
            // Open a dialog box that allows the user to select the areas to replace
            using (var form = new Form())
            {
                form.Text = "Select the areas to be replaced.";
                var label = new Label { Text = "Bereiche:", Left = 10, Top = 10 };
                var textBox = new TextBox { Left = label.Right + 10, Top = label.Top };
                var button = new Button { Text = "OK", Left = textBox.Right + 10, Top = textBox.Top };
                button.Click += (s, e) =>
                {
                    // Verify that the ranges entered by the user are valid
                    string[] areas = textBox.Text.Split(',');
                    bool validAreas = true;
                    foreach (string area in areas)
                    {
                        if (!int.TryParse(area.Trim(), out int position) || position < 0 || position >= listBoxOrg.Items.Count)
                        {
                            validAreas = false;
                            break;
                        }
                    }

                    if (validAreas)
                    {
                        // Replace the user-selected areas with the selection in listBoxSec
                        foreach (string area in areas)
                        {
                            int position = int.Parse(area.Trim());
                            listBoxOrg.Items[position] = listBoxSec.SelectedItem;
                        }
                        form.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid areas. Please enter valid areas.");
                    }
                };
                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(button);
                form.ShowDialog();
            }
        }

        private void OnClickShowSelection(object sender, EventArgs e)
        {
            UpdateContextMenu();
        }

        private void UpdateContextMenu()
        {
            // Delete all existing items from contextMenuStrip2
            contextMenuStrip2.Items.Clear();

            // Add each selected item in listBoxSec to contextMenuStrip2
            foreach (int index in listBoxSec.SelectedIndices)
            {
                int i = int.Parse(listBoxSec.Items[index].ToString());
                Bitmap image = SecondArt.GetStatic(i);
                string text = $"0x{i:X}";
                ToolStripMenuItem item = new ToolStripMenuItem(text);
                item.ImageScaling = ToolStripItemImageScaling.None; // Disable image scaling
                item.Image = new Bitmap(image, new Size(image.Width * 2, image.Height * 2)); // Enlarge the image
                item.Tag = i;
                item.Click += Item_Click;
                contextMenuStrip2.Items.Add(item);
            }

            // Add an "OK" button
            ToolStripButton okButton = new ToolStripButton("OK");
            okButton.Click += OnClickOkButton;
            contextMenuStrip2.Items.Add(okButton);
        }

        private void Item_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is int i)
            {
                int selectedIndex = listBoxOrg.SelectedIndex;
                if (selectedIndex != -1)
                {
                    Bitmap image = SecondArt.GetStatic(i);
                    Art.ReplaceStatic(selectedIndex, image);
                    Options.ChangedUltimaClass["Art"] = true;
                    ControlEvents.FireItemChangeEvent(this, selectedIndex);

                    // Update pictureBoxOrg with the selected item
                    pictureBoxOrg.BackgroundImage = Art.GetStatic(selectedIndex);

                    // Uncheck the selected item in listBoxSec
                    listBoxSec.SelectedIndices.Remove(listBoxSec.Items.IndexOf(i));
                }
            }
        }

        private void OnClickOkButton(object sender, EventArgs e)
        {
            // Replace the selected item in listBoxOrg with the first selected item in listBoxSec
            int selectedIndex = listBoxOrg.SelectedIndex;
            if (selectedIndex != -1 && listBoxSec.SelectedIndices.Count > 0)
            {
                int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndices[0]].ToString());
                Bitmap image = SecondArt.GetStatic(i);
                Art.ReplaceStatic(selectedIndex, image);
                Options.ChangedUltimaClass["Art"] = true;
                ControlEvents.FireItemChangeEvent(this, selectedIndex);

                // Update pictureBoxOrg with the selected item
                pictureBoxOrg.BackgroundImage = Art.GetStatic(selectedIndex);
            }
        }

        private void OnSelectedIndexChangedSec(object sender, EventArgs e)
        {
            UpdateContextMenu();
        }
        #endregion

        #region Search Textbox Hex
        private void OnClickSearch_Click(object sender, EventArgs e)
        {
            string addressText = searchTextBox.Text;
            int address;
            if (addressText.StartsWith("0x") || System.Text.RegularExpressions.Regex.IsMatch(addressText, @"\A\b[0-9a-fA-F]+\b\Z"))
            {
                string hexText = addressText.StartsWith("0x") ? addressText.Substring(2) : addressText;
                if (int.TryParse(hexText, System.Globalization.NumberStyles.HexNumber, null, out address))
                {
                    int index = FindIndexByHexValue(listBoxOrg, hexText);
                    if (index != -1)
                    {
                        listBoxOrg.SelectedIndex = index;
                    }
                    else
                    {
                        MessageBox.Show("Address not found.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid address. Please enter a valid hex address.");
                }
            }
            else
            {
                MessageBox.Show("Invalid address. Please enter a valid hex address.");
            }
        }

        private int FindIndexByHexValue(ListBox listBox, string hexValue)
        {
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (listBox.Items[i] is int intValue && intValue.ToString("X").Equals(hexValue, StringComparison.OrdinalIgnoreCase))
                {
                    return i;
                }
            }
            return -1;
        }

        #endregion

        #region OnClickBrowse

        private string lastSelectedPath;
        private string settingsDirectory = "DirectoryisSettings"; //Creates DirectoryisSettings
        private string settingsFileName = "CompareiItemsDirectoryisSettings.txt"; //Creates Text file
        private string settingsFilePath;

        private void OnClickBrowse(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select directory containing the art files";
                dialog.ShowNewFolderButton = false;
                if (!string.IsNullOrEmpty(lastSelectedPath))
                {
                    dialog.SelectedPath = lastSelectedPath;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxSecondDir.Text = dialog.SelectedPath;
                    lastSelectedPath = dialog.SelectedPath;
                    File.WriteAllText(settingsFilePath, lastSelectedPath);
                    SaveLastDirectory(lastSelectedPath);
                }
            }
        }
        #endregion        

        #region comboBoxSaveDir
        private void comboBoxSaveDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSaveDir.SelectedIndex != -1)
            {
                textBoxSecondDir.Text = comboBoxSaveDir.SelectedItem.ToString();
            }
        }

        private void SaveLastDirectory(string directory)
        {
            string settingsDirectory = "DirectoryisSettings"; //Directory DirectoryisSettings
            string lastDirectoriesFileName = "CompareiItemsLastDirectories.txt";
            string lastDirectoriesFilePath = Path.Combine(settingsDirectory, lastDirectoriesFileName);
            List<string> lastDirectories = new List<string>();
            if (File.Exists(lastDirectoriesFilePath))
            {
                lastDirectories.AddRange(File.ReadAllLines(lastDirectoriesFilePath));
            }
            lastDirectories.Remove(directory);
            lastDirectories.Insert(0, directory);
            if (lastDirectories.Count > 10) //10 lines limited 
            {
                lastDirectories = lastDirectories.Take(10).ToList();
            }
            File.WriteAllLines(lastDirectoriesFilePath, lastDirectories);
        }
        #endregion

        #region Buttons
        private void btLeftMoveItem_Click(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndex == -1)
            {
                return;
            }
            int i = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndex].ToString());
            if (!SecondArt.IsValidStatic(i))
            {
                return;
            }
            int staticLength = Art.GetMaxItemId() + 1;
            if (i >= staticLength)
            {
                return;
            }
            Bitmap copy = new Bitmap(SecondArt.GetStatic(i));
            Art.ReplaceStatic(i, copy);
            Options.ChangedUltimaClass["Art"] = true;
            ControlEvents.FireItemChangeEvent(this, i);
            _mCompare[i] = true;
            listBoxOrg.BeginUpdate();
            bool done = false;
            for (int id = 0; id < staticLength; id++)
            {
                if (id > i)
                {
                    listBoxOrg.Items.Insert(id, i);
                    done = true;
                    break;
                }
                if (id == i)
                {
                    done = true;
                    break;
                }
            }
            if (!done)
            {
                listBoxOrg.Items.Add(i);
            }
            listBoxOrg.EndUpdate();
            listBoxOrg.Invalidate();
            listBoxSec.Invalidate();

            // Update pictureBoxOrg with the selected item
            pictureBoxOrg.BackgroundImage = Art.GetStatic(i);
        }

        private void btLeftMoveItemMore_Click(object sender, EventArgs e)
        {
            if (listBoxSec.SelectedIndices.Count == 0)
            {
                return;
            }

            int staticLength = Art.GetMaxItemId() + 1;
            listBoxOrg.BeginUpdate();

            foreach (int selectedIndex in listBoxSec.SelectedIndices)
            {
                int i = int.Parse(listBoxSec.Items[selectedIndex].ToString());
                if (!SecondArt.IsValidStatic(i))
                {
                    continue;
                }
                if (i >= staticLength)
                {
                    continue;
                }
                Bitmap copy = new Bitmap(SecondArt.GetStatic(i));
                Art.ReplaceStatic(i, copy);
                Options.ChangedUltimaClass["Art"] = true;
                ControlEvents.FireItemChangeEvent(this, i);
                _mCompare[i] = true;

                bool done = false;
                for (int id = 0; id < staticLength; id++)
                {
                    if (id > i)
                    {
                        listBoxOrg.Items.Insert(id, i);
                        done = true;
                        break;
                    }
                    if (id == i)
                    {
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    listBoxOrg.Items.Add(i);
                }
            }

            listBoxOrg.EndUpdate();
            listBoxOrg.Invalidate();
            listBoxSec.Invalidate();

            // Update pictureBoxOrg with the first item selected
            int firstSelectedIndex = int.Parse(listBoxSec.Items[listBoxSec.SelectedIndices[0]].ToString());
            pictureBoxOrg.BackgroundImage = Art.GetStatic(firstSelectedIndex);
        }
        #endregion
    }
}
