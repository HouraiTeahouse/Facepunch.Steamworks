﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Steamworks
{
	/// <summary>
	/// Exposes a wide range of information and actions for applications and Downloadable Content (DLC).
	/// </summary>
	public static class Apps
	{
		static Internal.ISteamApps _steamapps;
		internal static Internal.ISteamApps steamapps
		{
			get
			{
				if ( _steamapps == null )
					_steamapps = new Internal.ISteamApps();

				return _steamapps;
			}
		}

		/// <summary>
		/// Checks if the active user is subscribed to the current App ID
		/// </summary>
		public static bool IsSubscribed => steamapps.BIsSubscribed();

		/// <summary>
		/// Checks if the license owned by the user provides low violence depots.
		/// Low violence depots are useful for copies sold in countries that have content restrictions
		/// </summary>
		public static bool IsLowVoilence => steamapps.BIsLowViolence();

		/// <summary>
		/// Checks whether the current App ID license is for Cyber Cafes.
		/// </summary>
		public static bool IsCybercafe => steamapps.BIsCybercafe();

		/// <summary>
		/// CChecks if the user has a VAC ban on their account
		/// </summary>
		public static bool IsVACBanned => steamapps.BIsVACBanned();

		/// <summary>
		/// Gets the current language that the user has set.
		/// This falls back to the Steam UI language if the user hasn't explicitly picked a language for the title.
		/// </summary>
		public static string GameLangauge => steamapps.GetCurrentGameLanguage();

		/// <summary>
		/// Gets a list of the languages the current app supports.
		/// </summary>
		public static string[] AvailablLanguages => steamapps.GetAvailableGameLanguages().Split( new[] { ',' }, StringSplitOptions.RemoveEmptyEntries );

		/// <summary>
		/// Checks if the active user is subscribed to a specified AppId.
		/// Only use this if you need to check ownership of another game related to yours, a demo for example.
		/// </summary>
		public static bool IsSubscribedToApp( AppId appid ) => steamapps.BIsSubscribedApp( appid.Value );

		/// <summary>
		/// Checks if the user owns a specific DLC and if the DLC is installed
		/// </summary>
		public static bool IsDlcInstalled( AppId appid ) => steamapps.BIsDlcInstalled( appid.Value );

		/// <summary>
		/// Returns the time of the purchase of the app
		/// </summary>
		public static DateTime PurchaseTime( AppId appid ) => Facepunch.Steamworks.Utility.Epoch.ToDateTime( steamapps.GetEarliestPurchaseUnixTime( appid.Value ) );

		/// <summary>
		/// Checks if the user is subscribed to the current app through a free weekend
		/// This function will return false for users who have a retail or other type of license
		/// Before using, please ask your Valve technical contact how to package and secure your free weekened
		/// </summary>
		public static bool IsSubscribedFromFreeWeekend => steamapps.BIsSubscribedFromFreeWeekend();

		/// <summary>
		/// Returns metadata for all available DLC
		/// </summary>
		public static IEnumerable<DlcInformation> DlcInformation()
		{
			var appid = default( SteamNative.AppId_t );
			var sb = new StringBuilder( 512 );
			var available = false;

			for ( int i = 0; i < steamapps.GetDLCCount(); i++ )
			{
				if ( !steamapps.BGetDLCDataByIndex( i, ref appid, ref available, sb, sb.Capacity ) )
					continue;

				yield return new DlcInformation
				{
					AppId = appid.Value,
					Name = sb.ToString(),
					Available = available
				};
			}
		}

		/// <summary>
		/// Install/Uninstall control for optional DLC
		/// </summary>
		public static void InstallDlc( AppId appid ) => steamapps.InstallDLC( appid.Value );

		/// <summary>
		/// Install/Uninstall control for optional DLC
		/// </summary>
		public static void UninstallDlc( AppId appid ) => steamapps.UninstallDLC( appid.Value );

	}
}