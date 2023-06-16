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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UoFiddler.Forms
{
    public partial class ChangeLogForm : Form
    {
        public ChangeLogForm()
        {
            InitializeComponent();

            // Add an event handler for the KeyDown event of the ToolStripTextBox
            toolStripTextBox1.KeyDown += (s, args) =>
            {
                // Check if the Enter key was pressed
                if (args.KeyCode == Keys.Enter)
                {
                    // Get the text from the RichTextBox
                    string richText = richTextBox1.Text;
                    // Get the search term from the ToolStripTextBox
                    string searchTerm = toolStripTextBox1.Text;

                    // Check if the search term is present in the text
                    if (richText.Contains(searchTerm))
                    {
                        // Search the text for all occurrences of the search term
                        int index = 0;
                        while ((index = richText.IndexOf(searchTerm, index)) != -1)
                        {
                            // Highlight the current occurrence of the search term
                            richTextBox1.Select(index, searchTerm.Length);
                            richTextBox1.SelectionBackColor = Color.Yellow;

                            // Continue the search
                            index += searchTerm.Length;
                        }
                    }
                }
            };
        }

        private void ChangeLogForm_Load(object sender, EventArgs e)
        {
            // Read the contents of the "Changelog.txt" file into a string
            string changelogText = File.ReadAllText("Changelog.txt");
            // Split the text into an array of lines
            string[] lines = changelogText.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            // Loop through each line
            for (int i = 0; i < lines.Length; i++)
            {
                // Check if the line starts with a "-"
                if (lines[i].StartsWith("-"))
                {
                    // Replace the "-" with a "•"
                    lines[i] = "•" + lines[i].Substring(1);
                }
            }
            // Join the lines back into a single string
            changelogText = string.Join(Environment.NewLine, lines);
            // Replace some specific strings with other strings
            changelogText = changelogText.Replace("#XG1", "Nikodemus");
            changelogText = changelogText.Replace("#XG2", "AsYlum");
            changelogText = changelogText.Replace("#XG3", "Alathair");
            // Convert the text to RTF format
            string changelogRtf = ConvertToRtf(changelogText);
            // Set the RTF property of the richTextBox1 to the RTF text
            richTextBox1.Rtf = changelogRtf;
        }

        private string ConvertToRtf(string text)
        {
            // Create a new StringBuilder to build the RTF text
            var rtf = new StringBuilder();
            // Append the RTF header
            rtf.Append(@"{\rtf1\ansi ");
            // Split the input text into an array of lines
            string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            // Loop through each line
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                // Check if the line starts with "Version :"
                if (line.StartsWith("Version :"))
                {
                    // Append the RTF code to make the text bold
                    rtf.Append(@"\b ");
                    // Append the line
                    rtf.Append(line);
                    // Append the RTF code to end the bold text
                    rtf.Append(@"\b0 ");
                }
                else
                {
                    // Append the line
                    rtf.Append(line);
                }
                // If this is not the last line
                if (i < lines.Length - 1)
                {
                    // Append the RTF code for a new line
                    rtf.Append(@"\line ");
                }
            }
            // Append the RTF footer
            rtf.Append("}");
            // Return the RTF text as a string
            return rtf.ToString();
        }
        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Set focus on the ToolStripTextBox.
            toolStripTextBox1.Focus();
        }

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the right mouse button was pressed.
            if (e.Button == MouseButtons.Right)
            {
                // Show the context menu at the current mouse position.
                contextMenuStrip1.Show(richTextBox1, e.Location);
            }
        }
    }
}
