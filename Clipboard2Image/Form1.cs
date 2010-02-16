using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Clipboard2Image
{
	public partial class Form1 : Form
	{
		// Clipboard data object
		public IDataObject data;
		// Clipboard image data
		public Image image;
		
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			// Set default value for combobox
			cbxFileFormat.SelectedIndex = 0;

			if (Clipboard.GetDataObject() != null)
			{
				data = Clipboard.GetDataObject();

				if (data != null && data.GetDataPresent(DataFormats.Bitmap))
				{
					// Get image data
					image = (Image)data.GetData(DataFormats.Bitmap, true);

					// Enable buttons
					btnSaveFile.Enabled = true;
					btnQuicksaveFile.Enabled = true;

					// Update preview
					pbxFilePreview.Image = image;
				}
				else
				{
					// Show error message
					MessageBox.Show("Data in clipboard is not an image format");
					Close();
				}
			}
			else
			{
				// Show error message
				MessageBox.Show("No data in clipboard");
				Close();
			}
		}

		private void cbxFileFormat_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Set filter for file type
			saveFileDialog1.Filter = cbxFileFormat.Text + " Image (*." + cbxFileFormat.Text + ")|*." + cbxFileFormat.Text;
		}

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
			Close();
		}

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

		private void btnClose_Click(object sender, EventArgs e)
		{
			// Close program
			Close();
		}
	}
}
