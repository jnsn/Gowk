//
//  UpdateMeterService.cs
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
using System.Net;
using Anculus.Core;
using Gowk.Security;

namespace Gowk.Services
{
	public delegate void UpdateMeterErrorDelegate(string message);

	public delegate void UpdateMeterStatusDelegate(StageType stageType);

	public class UpdateMeterService
	{
		private const double DEFAULT_REFRESH_INTERVAL = 60.0;
		private ulong m_loopID = 0uL;

		public event UpdateMeterErrorDelegate UpdateMeterErrorEvent;

		public event UpdateMeterStatusDelegate UpdateMeterStatusEvent;

		public UpdateMeterService()
		{
			m_loopID = ThreadDispatch.DispatchAtInterval((int)(GetInterval() * 60 * 1000), UpdateUsage);
		}

		public void UpdateMeterSettings()
		{
			ThreadDispatch.ChangeInterval(m_loopID, (int)(GetInterval() * 60 * 1000));
			ForceMeterUpdate();
		}

		public void ForceMeterUpdate()
		{
			UpdateUsage();
		}

		public double GetInterval()
		{
			try
			{
				object interval = SettingsService.Get(SettingsService.RefreshIntervalKey);
				if ((interval != null) && (interval is double))
				{
					return (double)interval;
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "An error occurred retrieving the refresh interval.");
			}
			
			return DEFAULT_REFRESH_INTERVAL;
		}

		public string GetUserID()
		{
			try
			{
				object userID = SettingsService.Get(SettingsService.UserIDKey);
				if ((userID != null) && (userID is string))
				{
					return userID as string;
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "An error occurred retrieving the user ID.");
			}
			
			return string.Empty;
		}

		public string GetPassword()
		{
			try
			{
				object password = SettingsService.Get(SettingsService.PasswordKey);
				if ((password != null) && (password is string))
				{
					return Crypter.Decrypt((password as string));
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "An error occurred retrieving the password.");
			}
			
			return string.Empty;
		}

		private void UpdateUsage()
		{
			Log.Info("Updating meter usage.");

			if (string.IsNullOrEmpty(GetUserID()) || string.IsNullOrEmpty(GetPassword()))
			{
				return;
			}
			
			try
			{
				#pragma warning disable 618
				ServicePointManager.CertificatePolicy = new CertificateValidation();
				#pragma warning restore 618
				
				TelemeterService service = new TelemeterService();
				RetrieveUsageRequestType request = new RetrieveUsageRequestType { UserId = GetUserID(), Password = GetPassword() };
				service.retrieveUsageCompleted += HandleServiceretrieveUsageCompleted;
				service.retrieveUsageAsync(request);
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error retrieving meter usage.");
				
				if (UpdateMeterErrorEvent != null)
				{
					UpdateMeterErrorEvent(ex.Message);
				}
			}
		}

		private void HandleServiceretrieveUsageCompleted(object sender, retrieveUsageCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				Log.Error(e.Error.Message, "Error retrieving meter usage.");
				
				if (UpdateMeterErrorEvent != null)
				{
					UpdateMeterErrorEvent(e.Error.Message);
				}
				
				return;
			}
			
			try
			{
				StageType stageType = e.Result.Item as StageType;
				if ((stageType != null) && (UpdateMeterStatusEvent != null))
				{
					UpdateMeterStatusEvent(stageType);
				}
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error retrieving meter usage.");
				
				if (UpdateMeterErrorEvent != null)
				{
					UpdateMeterErrorEvent(ex.Message);
				}
			}
		}
	}
}

