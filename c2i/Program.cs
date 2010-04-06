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
 *   OpenGrades is free software: you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or
 *   (at your option) any later version.
 *   
 *   OpenGrades is distributed in the hope that it will be useful,
 *   but WITHOUT ANY WARRANTY; without even the implied warranty of
 *   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
 *   GNU General Public License for more details.
 *   
 *   You should have received a copy of the GNU General Public License
 *   along with Clipboard2Image. If not, see http://www.gnu.org/licenses/.
 * 
 * Version: 1.1 (06.04.2010)
 * 
 * Required to run:
 *	- Microsoft .NET Framework 2.0 or higher
***********************************************/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace c2i
{
	// Todo: Document
	class Program
	{
		// Clipboard data object
		public static IDataObject clipboardData;
		// Clipboard image data
		public static Image image;

		[STAThread]
		static void Main(string[] args)
		{
			// Todo: Read arguments
			if (Clipboard.GetDataObject() != null)
			{
				// Get clipboard data
				clipboardData = Clipboard.GetDataObject();

				// If clipboard data is in bitmap format
				if (clipboardData != null && clipboardData.GetDataPresent(DataFormats.Bitmap))
				{
					// Get image data
					image = (Image)clipboardData.GetData(DataFormats.Bitmap, true);

					// Todo: Save Image
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
	}
}
