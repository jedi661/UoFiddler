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
using System.IO;
using System.Text;
using System.Windows.Forms;
using Ultima;
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
            if (inputText.StartsWith("0x")) // Check if the text has already been converted.
            {
                textBox2.Text = inputText; // Copy the text from TextBox1 to TextBox2.
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
                return; // Beendet die Methode, wenn die Form bereits geöffnet ist
            }

            GraphicCutterForm form = new GraphicCutterForm();
            form.FormClosed += GraphicCutterForm_FormClosed; // Abonniere das FormClosed-Ereignis
            form.Show();
            isFormOpen = true;

            buttonGraficCutterForm.Enabled = false; // Deaktiviert den Button
        }
        private void GraphicCutterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            isFormOpen = false;
            buttonGraficCutterForm.Enabled = true; // Aktiviert den Button wieder
        }

    }
}
