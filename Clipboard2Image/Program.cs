/**********************************************
 * Clipboard2Image Tool
 * 
 * This tool saves an image from the clipboard to the Desktop or to a specified folder.
 * Supported filetypes: png, jpg, gif, bmp
 * 
 * Author: Danilo Bargen <gezuru@gmail.com>
 * License: CC by-nc-sa 3.0 (http://creativecommons.org/licenses/by-nc-sa/3.0/)
 * 
 * Version: 1.0 (16.02.2010)
 * 
 * Required to run:
 *	- Microsoft .NET Framework 2.0 or higher
***********************************************/

using System;
using System.Windows.Forms;

namespace Clipboard2Image
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
	}
}
