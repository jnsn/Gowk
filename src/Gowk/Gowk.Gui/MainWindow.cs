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
using Anculus.Core;
using Gowk.Security;
using Gowk.Services;
using Gtk;
using Notifications;

namespace Gowk.Gui
{
	public partial class MainWindow : Gtk.Window
	{
		private readonly StatusIcon m_statusIcon = new StatusIcon();
		private readonly UpdateMeterService m_updateMeterService = new UpdateMeterService();

		public MainWindow() : base(Gtk.WindowType.Toplevel)
		{
			Build();
			InitStatusIcon();
			
			m_updateMeterService.UpdateMeterErrorEvent += UpdateMeterErrorEventHandler;
			m_updateMeterService.UpdateMeterStatusEvent += UpdateMeterStatusEventHandler;
			m_updateMeterService.ForceMeterUpdate();
		}

		private void UpdateMeterStatusEventHandler(StageType stageType)
		{
			Log.Info("Showing status notification.");
			
			int stageNumber = Convert.ToInt32(stageType.StageNumber);
			m_statusIcon.Pixbuf = GetIcon(stageNumber);
			m_statusIcon.Tooltip = stageType.Description;
			
			Notification notification = new Notification { Icon = GetIcon(stageNumber), Summary = string.Format("{0}/9", stageNumber), Body = stageType.Description, Urgency = Urgency.Normal };
			
			notification.Show();
		}

		private void UpdateMeterErrorEventHandler(string message)
		{
			Log.Info("Showing error notification: {0}", message);
			
			m_statusIcon.Pixbuf = GetIcon(9);
			m_statusIcon.Tooltip = message;
			
			Notification notification = new Notification { IconName = Stock.DialogError, Summary = "Er is een fout opgetreden bij het updaten van de Telemeter status.", Body = message, Urgency = Urgency.Critical };
			
			notification.Show();
		}

		private static Gdk.Pixbuf GetIcon(int stage)
		{
			if ((stage >= 1) && (stage <= 9))
			{
				return Gdk.Pixbuf.LoadFromResource(string.Format("stage-{0}.png", stage));
			}
			
			return Gdk.Pixbuf.LoadFromResource("stage-9.png");
		}

		private void InitStatusIcon()
		{
			m_statusIcon.PopupMenu += (sender, args) =>
			{
				Menu menu = new Menu();
				
				ImageMenuItem preferences = new ImageMenuItem(Stock.Preferences, null);
				preferences.Activated += (preferencesSender, preferencesArgs) => { ShowWindow(); };
				
				ImageMenuItem refresh = new ImageMenuItem(Stock.Refresh, null);
				refresh.Activated += (refreshSender, refreshArgs) => { m_updateMeterService.ForceMeterUpdate(); };
				
				ImageMenuItem quit = new ImageMenuItem(Stock.Quit, null);
				quit.Activated += (quitSender, quitArgs) => { RealQuit(); };
				
				menu.Add(preferences);
				menu.Add(refresh);
				menu.Add(new SeparatorMenuItem());
				menu.Add(quit);
				
				menu.ShowAll();
				menu.Popup();
			};
			
			m_statusIcon.Pixbuf = GetIcon(1);
			m_statusIcon.Tooltip = "Nog geen geldige Telemeter status opgehaald.";
		}

		private void ShowWindow()
		{
			UserIDEntry.Text = m_updateMeterService.GetUserID();
			PasswordEntry.Text = m_updateMeterService.GetPassword();
			IntervalScale.Value = m_updateMeterService.GetInterval();
			
			Show();
		}

		private void RealQuit()
		{
			ThreadDispatch.Shutdown();
			Application.Quit();
		}

		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
		{
			Hide();
			a.RetVal = true;
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
				
				m_updateMeterService.UpdateMeterSettings();
				Hide();
			}
		}
	}
}
