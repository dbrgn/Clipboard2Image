/**********************************************
 * Clipboard2Image saves an image from the clipboard to the Desktop
 * or to a specified folder.
 * Copyright (C) 2010 Danilo Bargen
 * 
 * This file is part of Clipboard2Image.
 * 
 * Clipboard2Image is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * Clipboard2Image is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with Clipboard2Image. If not, see http://www.gnu.org/licenses/.
***********************************************/

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace Clipboard2Image
{
	public partial class MainForm : Form
	{
		// Clipboard data object
		public IDataObject clipboardData;
		// Clipboard image data
		public Image image;
		
		public MainForm()
		{
			InitializeComponent();
		}

        // Main form load event
		private void MainForm_Load(object sender, EventArgs e)
		{
            // Set default value for combobox
            cbxFileFormat.SelectedIndex = 0;

            LoadClipboardData();
		}

        // Catch KeyDown events
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F5)
            {
                LoadClipboardData();
            }
            else if (e.KeyCode == System.Windows.Forms.Keys.Escape)
            {
                Close();
            }
        }

        private void LoadClipboardData()
        {
            // If clipboard isn't empty
            if (Clipboard.GetDataObject() != null)
            {
                // Get clipboard data
                clipboardData = Clipboard.GetDataObject();

                // If clipboard data is in bitmap format
                if (clipboardData != null && clipboardData.GetDataPresent(DataFormats.Bitmap))
                {
                    // Get image data
                    image = (Image)clipboardData.GetData(DataFormats.Bitmap, true);

                    // Enable buttons
                    btnSaveFile.Enabled = true;
                    btnQuicksaveFile.Enabled = true;

                    // Update preview
                    pbxFilePreview.Image = image;
                }
                else
                {
                    MessageBox.Show("Sorry, I couldn't find any image in the clipboard", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Disable buttons
                    btnSaveFile.Enabled = false;
                    btnQuicksaveFile.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Sory, the clipboard is empty", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Disable buttons
                btnSaveFile.Enabled = false;
                btnQuicksaveFile.Enabled = false;
            }
        }

		// On dropdown-index-change, update the saveFileDialog filetype filter
		private void cbxFileFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Set filter for file type
			saveFileDialog1.Filter = cbxFileFormat.Text + " Image (*." + cbxFileFormat.Text + ")|*." + cbxFileFormat.Text;
		}

        // Display saveFile dialog
        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            // Display dialog
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult dialogResult = saveFileDialog1.ShowDialog();

            // If everything's ok, save file
            if (dialogResult == DialogResult.OK)
            {
                saveFile(saveFileDialog1.FileName);
            }
        }

		// Quicksave image to Desktop
		private void btnQuicksaveImage_Click(object sender, EventArgs e)
		{
			if (image != null)
			{
				// Get unused filepath string
				string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\image." + cbxFileFormat.Text;
				int i = 1;
				while (System.IO.File.Exists(filePath))
				{
					i++;
					filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\image" + i + "." + cbxFileFormat.Text;
				}
				
				// Save file
				saveFile(filePath);
			}
		}

        // Saves the file to the directory specified in the filePath argument.
        private void saveFile(string filePath)
        {
            // Define file format
            ImageFormat fileFormat;
            switch (cbxFileFormat.Text)
            {
                case "png":
                    fileFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
                case "jpg":
                    fileFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                    break;
                case "gif":
                    fileFormat = System.Drawing.Imaging.ImageFormat.Gif;
                    break;
                case "bmp":
                    fileFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                    break;
                default:
                    fileFormat = System.Drawing.Imaging.ImageFormat.Png;
                    break;
            }

            // Save image to desktop
            image.Save(filePath, fileFormat);

            // Close form
            if (conditionalClose("Successfully saved image.") == false)
            {
                pbxFilePreview.Image = null;
                btnQuicksaveFile.Enabled = false;
                btnSaveFile.Enabled = false;
            }
        }

        // Close form if checkbox hasn't been checked. Else, return false.
        // Optionally, provide text to show in a message box before closing.
        private bool conditionalClose(String msgBoxText = "", MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            MessageBox.Show(msgBoxText, "", MessageBoxButtons.OK, icon);
            if (cbxNoAutoclose.Checked)
            {
                return false;
            }
            else
            {
                Close();
                return true; // Ha-ha...
            }
        }
	}
}
