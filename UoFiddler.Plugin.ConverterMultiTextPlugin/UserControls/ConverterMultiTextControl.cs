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
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ultima;
using UoFiddler.Controls.Forms;
using UoFiddler.Plugin.ConverterMultiTextPlugin.Forms;

namespace UoFiddler.Plugin.ConverterMultiTextPlugin.UserControls
{
    public partial class ConverterMultiTextControl : UserControl
    {
        private string originalFileName;

        //One Form
        private bool isFormOpen = false;

        public ConverterMultiTextControl()
        {
            InitializeComponent();

            label1.Text = "";
            label2.Text = "";
        }

        private void BtnMultiOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Save the path and filename of the selected file.
                string filePath = openFileDialog.FileName;
                originalFileName = Path.GetFileNameWithoutExtension(filePath);

                // Read the text file and write it into a TextBox.
                string fileContent = File.ReadAllText(filePath);
                string[] lines = fileContent.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                StringBuilder sb = new StringBuilder();
                bool startAppending = false;
                foreach (string line in lines)
                {
                    if (line.Contains("num components"))
                    {
                        startAppending = true;
                        continue;
                    }

                    if (startAppending)
                    {
                        sb.AppendLine(line);
                    }
                }

                textBox1.Clear();
                textBox2.Clear();
                if (sb.Length > 0)
                {
                    textBox1.Text = sb.ToString();
                }
                else
                {
                    textBox1.Text = fileContent;
                }

                label1.Text = "The text has been inserted.";
            }
        }

        private void btnSpeichernTxt_Click(object sender, EventArgs e)
        {
            // Check if TextBox2 has any content.
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                label2.Text = "There is no text that can be saved.";
                return;
            }

            // Verzeichnis erstellen
            string directoryPath = Path.Combine(Path.GetDirectoryName(openFileDialog.FileName), "OLDScript");
            Directory.CreateDirectory(directoryPath);

            // Take the filename from the original file name.
            string fileName = originalFileName + ".txt";
            string filePath = Path.Combine(directoryPath, fileName);

            // Write the contents of TextBox1 to a text file.
            File.WriteAllText(filePath, textBox1.Text);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            saveFileDialog.InitialDirectory = Path.Combine(Path.GetDirectoryName(openFileDialog.FileName), "Export");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Write the contents of TextBox2 to a text file.
                File.WriteAllText(saveFileDialog.FileName, textBox2.Text);

                label2.Text = "The text was successfully exported to the file.";
            }
        }

        private void btnUmwandeln_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text.Trim(); // Retrieve the text from TextBox1 and remove leading/trailing whitespace.
            if (string.IsNullOrEmpty(inputText)) // Check if textBox1 is empty.
            {
                // Handle the case where textBox1 is empty.
                // For example, display an error message to the user.
                MessageBox.Show("Please enter text into the field.");
                return; // Exit the method.
            }

            string[] inputLines = inputText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None); // Split the text into a string array.

            StringBuilder outputText = new StringBuilder(); // Create a StringBuilder object to concatenate the converted lines.

            foreach (string inputLine in inputLines)
            {
                string[] inputValues = inputLine.Split(' '); // Split the values in each line by whitespace.
                int sum = 0; // Initialize the sum of the first few decimal numbers in the line.

                for (int i = 0; i < inputValues.Length; i++)
                {
                    if (i == 0) // Select and convert the first decimal number in the line.
                    {
                        sum = Convert.ToInt32(inputValues[i]);
                        outputText.Append("0x" + sum.ToString("X") + " "); // Add the first converted hexadecimal number to the StringBuilder.
                    }
                    else // Simply add the remaining values to a StringBuilder.
                    {
                        outputText.Append(inputValues[i] + " ");
                    }
                }
                outputText.Append(Environment.NewLine); // Add a line break at the end of each line.
            }

            textBox2.Text = outputText.ToString(); // Set the result in TextBox2
        }

        private void btnCopyTBox2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox2.Text);
        }

        private void buttonGraficCutterForm_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            GraphicCutterForm form = new GraphicCutterForm();
            form.FormClosed += GraphicCutterForm_FormClosed; // Subscribe to the FormClosed event.
            form.Show();
            isFormOpen = true;

            buttonGraficCutterForm.Enabled = false; // Disable the button.
        }
        private void GraphicCutterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
            buttonGraficCutterForm.Enabled = true; // Enable the button again.
        }

        private void TextureCutter_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            TextureCutter form = new TextureCutter();
            form.FormClosed += TextureCutter_FormClosed;
            form.Show();
            isFormOpen = true;

            TextureCutter.Enabled = false;
        }

        private void TextureCutter_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
            TextureCutter.Enabled = true; // Enable the button again.
        }

        private void btDecriptClient_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            DecriptClientForm form = new DecriptClientForm();
            form.FormClosed += DecriptClientForm_FormClosed;
            form.Show();
            isFormOpen = true;

            form.Enabled = true;
        }

        private void DecriptClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
            btDecriptClient.Enabled = true; // Enable the button again.
        }

        private void btMapMaker_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            MapMaker form = new MapMaker();
            form.FormClosed += MapMaker_FormClosed;
            form.Show();
            isFormOpen = true;

            btMapMaker.Enabled = false;
        }
        private void MapMaker_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
            btMapMaker.Enabled = true; // Enable the button again.
        }

        private void btAnimationVDForm_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            AnimationVDForm form = new AnimationVDForm();
            form.FormClosed += AnimationVDForm_FormClosed;
            form.Show();
            isFormOpen = true;

            btAnimationVDForm.Enabled = false;
        }

        private void AnimationVDForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isFormOpen)
            {
                isFormOpen = false;
                btAnimationVDForm.Enabled = true; // Enable the button again.
            }
        }

        private void btAnimationEditFormButton_Click(object sender, EventArgs e)
        {
            if (isFormOpen)
            {
                return; // Exit the method if the form is already open.
            }

            AnimationEditFormButton form = new AnimationEditFormButton();
            form.FormClosed += AnimationEditFormButton_FormClosed;
            form.Show();
            isFormOpen = true;

            btAnimationEditFormButton.Enabled = false;
        }

        private void AnimationEditFormButton_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (isFormOpen)
            {
                isFormOpen = false;
                btAnimationEditFormButton.Enabled = true; // Enable the button again.
            }
        }

        #region Button binary code
        private void btBinaryCode_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxASCII.Checked)
                {
                    string binary = textBox2.Text;
                    binary = binary.Replace("\n", "").Replace("\r", "").Replace("\t", "");
                    List<Byte> byteList = new List<Byte>();

                    foreach (var bin in binary.Split(' '))
                    {
                        byteList.Add(Convert.ToByte(bin, 2));
                    }

                    textBox1.Text = Encoding.UTF8.GetString(byteList.ToArray());
                }
                else
                {
                    string text = textBox1.Text;
                    byte[] textBytes = Encoding.UTF8.GetBytes(text);
                    string binary = String.Join(" ", textBytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
                    textBox2.Text = binary;
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Fehler beim Umwandeln der Zeichenkette in eine Zahl: " + ex.Message);
            }
        }
        #endregion

        #region MorseCode
        private void btMorseCode_Click(object sender, EventArgs e)
        {
            Dictionary<char, string> morseCodeDictionary = new Dictionary<char, string>()
            {
                {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."}, {'F', "..-."},
                {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"}, {'K', "-.-"}, {'L', ".-.."},
                {'M', "--"}, {'N', "-."}, {'O', "---"}, {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."},
                {'S', "..."}, {'T', "-"}, {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"},
                {'Y', "-.--"}, {'Z', "--.."}, {'0', "-----"}, {'1', ".----"}, {'2', "..---"},
                {'3', "...--"}, {'4', "....-"}, {'5', "....."}, {'6', "-...."}, {'7', "--..."},
                {'8', "---.."}, {'9', "----."}, {' ', "/"}, {'Ä', ".-.-"}, {'Ö', "---."}, {'Ü', "..--"}
            };

            if (checkBoxASCII.Checked)
            {
                string morseCode = textBox2.Text;
                string text = "";

                foreach (var word in morseCode.Split(new string[] { " / " }, StringSplitOptions.None))
                {
                    foreach (var letter in word.Split(' '))
                    {
                        text += morseCodeDictionary.FirstOrDefault(x => x.Value == letter).Key;
                    }
                    text += " ";
                }

                textBox1.Text = text.Trim();
            }
            else
            {
                string text = textBox1.Text.ToUpper();
                string morseCode = String.Join(" ", text.Select(c => morseCodeDictionary.ContainsKey(c) ? morseCodeDictionary[c] : ""));
                textBox2.Text = morseCode;
            }
        }
        #endregion

        #region Clear
        private void btclear_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }
        #endregion

        #region Clipboard Text
        private void importClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                textBox1.Text = Clipboard.GetText();
            }
            else
            {
                MessageBox.Show("The clipboard contains no text.");
            }
        }
        #endregion
    }
}
