/**********************************************
 * Clipboard2Image Tool - Command line version
 * 
 * This tool saves an image from the clipboard to the Desktop or to a specified folder.
 * Supported filetypes: png, jpg, gif, bmp
 * 
 * Author: Danilo Bargen <gezuru@gmail.com>
 * 
 * License:
 *   Clipboard2Image saves an image from the clipboard to the Desktop
 *   or to a specified folder.
 *   Copyright (C) 2010 Danilo Bargen
 *   
 *   This file is part of Clipboard2Image.
 *   
 *   Clipboard2Image is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *   
 *   Clipboard2Image is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *   GNU General Public License for more details.
 *   
 *   You should have received a copy of the GNU General Public License
 *   along with Clipboard2Image. If not, see http://www.gnu.org/licenses/.
 * 
 * Version: 1.1 (21.04.2010)
 * 
 * Required to run:
 *	- Microsoft .NET Framework 2.0 or higher
***********************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace c2i
{
	class Program
	{
		// Clipboard data object
		public static IDataObject clipboardData;
		// Clipboard image data
		public static Image image;

		/// <summary>
		/// Main program
		/// </summary>
		[STAThread]
		static void Main()
		{
			try
			{
				// Fill arguments into list
				IList<string> arguments = new List<string>();
				foreach (string arg in Environment.GetCommandLineArgs())
				{
					arguments.Add(arg);
				}

				// If no arguments were supplied, throw an exception
				if (arguments.Count < 2)
				{
					throw new ArgumentException("Arguments missing");
				}

				// Get filepath and filetype
				string filePath = Path.GetFullPath(arguments[1]);
				string fileType = Path.GetExtension(filePath).Substring(1, 3);

				if (Clipboard.GetDataObject() != null)
				{
					// Get clipboard data
					clipboardData = Clipboard.GetDataObject();

					// If clipboard data is in bitmap format
					if (clipboardData != null && clipboardData.GetDataPresent(DataFormats.Bitmap))
					{
						// Get image data
						image = (Image)clipboardData.GetData(DataFormats.Bitmap, true);

						// Save Image
						saveFile(filePath, fileType);
					}
					else
					{
						// Show error message
						Console.WriteLine("Data in clipboard is not an image format");
					}
				}
				else
				{
					// Show error message
					Console.WriteLine("No data in clipboard");
					clipboardData = Clipboard.GetDataObject();
				}
			}
			catch (ArgumentException)
			{
				// Show usage information
				usage();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			
		}

		/// <summary>
		/// Displays the usage for this tool
		/// </summary>
		private static void usage()
		{
			Console.WriteLine("Usage: c2i filename.ext");
			Console.WriteLine("Examples:");
			Console.WriteLine("\tc2i image.png");
			Console.WriteLine("\tc2i c:\\image.jpg");
			Console.WriteLine("\tc2i \"d:\\file path\\image.gif\"");
		}

		/// <summary>
		/// Saves the file to the directory specified in the filePath argument.
		/// </summary>
		/// <param name="filePath">The file path.</param>
		/// <param name="fileType">The file extension.</param>
		private static void saveFile(string filePath, string fileType)
		{
			// Define file format
			ImageFormat fileFormat;
			switch (fileType)
			{
				case "png":
					fileFormat = ImageFormat.Png;
					break;
				case "jpg":
					fileFormat = ImageFormat.Jpeg;
					break;
				case "gif":
					fileFormat = ImageFormat.Gif;
					break;
				case "bmp":
					fileFormat = ImageFormat.Bmp;
					break;
				default:
					fileFormat = ImageFormat.Png;
					break;
			}

			try
			{
				// Save image
				image.Save(filePath, fileFormat);
			}
			catch (System.Runtime.InteropServices.ExternalException e)
			{
				Console.WriteLine(e.Message);
				Console.WriteLine("You probably tried to save to a directory that doesn't exist.");
			}
		}
	}
}
