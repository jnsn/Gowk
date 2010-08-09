//
//  SettingsService.cs
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
using Anculus.Core;
using GConf;

namespace Gowk.Services
{
	static internal class SettingsService
	{
		private static readonly string m_applicationKey = "/apps/gowk/";
		private static readonly Client m_client = new Client();

		public static string UserIDKey
		{
			get { return "userid"; }
		}

		public static string PasswordKey
		{
			get { return "password"; }
		}

		public static string RefreshIntervalKey
		{
			get { return "interval"; }
		}

		public static object Get(string key)
		{
			CheckKey(key);
			
			return m_client.Get(m_applicationKey + key);
		}

		public static void Set(string key, object val)
		{
			m_client.Set(m_applicationKey + key, val);
		}

		private static void CheckKey(string key)
		{
			try
			{
				m_client.Get(m_applicationKey + key);
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Key {0} not found.", key);
				m_client.Set(m_applicationKey + key, null);
			}
		}
	}
}

