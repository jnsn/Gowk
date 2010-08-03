//
//  MainWindow.cs
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
using Gowk.Services;
using Gtk;
using Notifications;

namespace Gowk
{
	public partial class MainWindow : Gtk.Window
	{
		private readonly StatusIcon m_statusIcon = new StatusIcon();
		private ulong m_loopID = 0uL;

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			Build();
			InitStatusIcon();
			
			m_loopID = ThreadDispatch.DispatchAtInterval((int)(GetInterval() * 60 * 1000), UpdateMeterUsage);
			UpdateMeterUsage();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Hide();
			a.RetVal = true;
		}

		private void InitStatusIcon()
		{
			m_statusIcon.PopupMenu += (sender, args) =>
			{
				Menu menu = new Menu();
				
				ImageMenuItem preferences = new ImageMenuItem(Stock.Preferences, null);
				preferences.Activated += (preferencesSender, preferencesArgs) => { ShowWindow(); };
				
				ImageMenuItem refresh = new ImageMenuItem(Stock.Refresh, null);
				refresh.Activated += (refreshSender, refreshArgs) => { UpdateMeterUsage(); };
				
				ImageMenuItem quit = new ImageMenuItem(Stock.Quit, null);
				quit.Activated += (quitSender, quitArgs) => { RealQuit(); };
				
				menu.Add(preferences);
				menu.Add(refresh);
				menu.Add(new SeparatorMenuItem());
				menu.Add(quit);
				
				menu.ShowAll();
				menu.Popup();
			};
			
			m_statusIcon.Pixbuf = new Gdk.Pixbuf(@"Data/64/stage-1.png");
			m_statusIcon.Tooltip = "Nog geen geldige status opgehaald.";
		}

		private void UpdateMeterUsage()
		{
			Log.Info("Retrieving telemeter usage.");
			
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
				RetrieveUsageRequestType request = new RetrieveUsageRequestType {
					UserId = GetUserID(),
					Password = GetPassword()
				};
				service.retrieveUsageCompleted += HandleServiceretrieveUsageCompleted;
				service.retrieveUsageAsync(request);
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error trying to retrieve usage.");
				ShowErrorNotification(ex.Message);
			}
		}

		void HandleServiceretrieveUsageCompleted(object sender, retrieveUsageCompletedEventArgs e)
		{
			if (e.Error != null)
			{
				Log.Error(e.Error.Message, "Error retrieving usage.");
				ShowErrorNotification(e.Error.Message);
				
				return;
			}
			
			try
			{
				StageType stage = e.Result.Item as StageType;
				
				if (stage != null)
				{
					int stageNumber = Convert.ToInt32(stage.StageNumber);
					
					m_statusIcon.Pixbuf = GetIcon(stageNumber);
					m_statusIcon.Tooltip = string.Format("{0}/9 - {1}", stageNumber, stage.Description);
					
					ShowStatusNotification(stageNumber, stage.Description);
				}
				
				Log.Info("Usage retrieved.");
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error retrieving usage.");
				ShowErrorNotification(ex.Message);
			}
		}

		private void ShowWindow()
		{
			UserIDEntry.Text = GetUserID();
			PasswordEntry.Text = GetPassword();
			IntervalScale.Value = GetInterval();
			
			Show();
		}

		private void RealQuit()
		{
			ThreadDispatch.Shutdown();
			Application.Quit();
		}

		private static string GetUserID()
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
				Log.Error(ex, "Error getting key.");
			}
			
			return string.Empty;
		}

		private static string GetPassword()
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
				Log.Error(ex, "Error getting key.");
			}
			
			return string.Empty;
		}

		private static double GetInterval()
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
				Log.Error(ex, "Error getting key.");
			}
			
			return 60.0;
		}

		private Gdk.Pixbuf GetIcon(int stage)
		{
			switch (stage)
			{
				case 1:
					return new Gdk.Pixbuf(@"Data/64/stage-1.png");
				case 2:
					return new Gdk.Pixbuf(@"Data/64/stage-2.png");
				case 3:
					return new Gdk.Pixbuf(@"Data/64/stage-3.png");
				case 4:
					return new Gdk.Pixbuf(@"Data/64/stage-4.png");
				case 5:
					return new Gdk.Pixbuf(@"Data/64/stage-5.png");
				case 6:
					return new Gdk.Pixbuf(@"Data/64/stage-6.png");
				case 7:
					return new Gdk.Pixbuf(@"Data/64/stage-7.png");
				case 8:
					return new Gdk.Pixbuf(@"Data/64/stage-8.png");
				case 9:
					return new Gdk.Pixbuf(@"Data/64/stage-8.png");
				default:
					return new Gdk.Pixbuf(@"Data/64/stage-1.png");
			}
		}

		private void ShowStatusNotification(int stage, string description)
		{
			Log.Info("Showing status notification.");
			
			Notification notification = new Notification {
				Icon = GetIcon(stage),
				Summary = string.Format("{0}/9", stage),
				Body = description,
				Urgency = Urgency.Normal
			};
			
			notification.Show();
		}

		private void ShowErrorNotification(string error)
		{
			Log.Info("Showing error notification");
			
			Notification notification = new Notification {
				IconName = Stock.DialogError,
				Summary = "Er is een fout opgetreden bij het ophalen van de telemeter status.",
				Body = error,
				Urgency = Urgency.Critical
			};
			
			notification.Show();
		}

		protected virtual void OnCloseEvent(object sender, System.EventArgs e)
		{
			Hide();
		}

		protected virtual void OnQuitEvent(object sender, System.EventArgs e)
		{
			RealQuit();
		}

		protected virtual void OnAboutEvent(object sender, System.EventArgs e)
		{
			(new AboutDialog()).Show();
		}

		protected virtual void OnSaveButtonClickedEvent(object sender, System.EventArgs e)
		{
			if (!string.IsNullOrEmpty(UserIDEntry.Text) && !string.IsNullOrEmpty(PasswordEntry.Text))
			{
				SettingsService.Set(SettingsService.UserIDKey, UserIDEntry.Text);
				SettingsService.Set(SettingsService.PasswordKey, Crypter.Encrypt(PasswordEntry.Text));
				SettingsService.Set(SettingsService.RefreshIntervalKey, IntervalScale.Value);
				
				ThreadDispatch.ChangeInterval(m_loopID, (int)(GetInterval() * 60 * 1000));
				UpdateMeterUsage();
				
				Hide();
			}
		}
		
		
		
	}
}
