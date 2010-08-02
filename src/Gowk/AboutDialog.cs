//
//  AboutDialog.cs
//  
//  Author:
//       Jensen Somers <jensen.somers@gmail.com>
// 
//  Copyright (c) 2010 Jensen Somers
// 
//  This program is free software; you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation; either version 2 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
//  
//  You should have received a copy of the GNU General Public License
//  along with this program; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Anculus.Core;

namespace Gowk
{
	public class AboutDialog : Gtk.AboutDialog
	{
		public AboutDialog() : base()
		{
			ProgramName = "Gowk";
			Logo = new Gdk.Pixbuf(@"Data/icon.png");
			Version = (new Version(Assembly.GetEntryAssembly().GetName().Version.ToString())).ToString(3);
			Comments = "FUP Telemeter status indicator";
			Copyright = "Copyright \u00a9 2010 Jensen Somers";
			Authors = GetAuthors().ToArray();
			Artists = GetArtists().ToArray();
			License = GetLicenseInfo();
			WrapLicense = true;

			Response += HandleResponse;
		}

		private void HandleResponse(object o, Gtk.ResponseArgs args)
		{
			Destroy();
		}

		private List<string> GetAuthors()
		{
			return new List<string> { "Jensen Somers" };
		}

		private List<string> GetArtists()
		{
			return new List<string> { "Patrick Ceuppens" };
		}

		private string GetLicenseInfo()
		{
			string license = string.Empty;
			
			try
			{
				using (StreamReader reader = new StreamReader(@"Data/COPYING"))
				{
					license = reader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error opening license file.");
			}
			
			return license;
		}
	}
}
