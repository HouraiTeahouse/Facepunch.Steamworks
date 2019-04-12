﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Steamworks
{
	public static class Steam
	{
		internal static int HUser;

		public static void Init( uint appid )
		{
			System.Environment.SetEnvironmentVariable( "SteamAppId", appid.ToString() );
			System.Environment.SetEnvironmentVariable( "SteamGameId", appid.ToString() );

			if ( !SteamApi.Init() )
			{
				throw new System.Exception( "SteamApi_Init returned false. Steam isn't running, couldn't find Steam, AppId is ureleased, Don't own AppId." );
			}

			HUser = SteamApi.GetHSteamUser();
			if ( HUser == 0 )
			{
				throw new System.Exception( "GetHSteamUser returned 0" );
			}
		}
	}
}