﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SteamNative;

namespace Steamworks
{
	/// <summary>
	/// Not for reuse by newbs
	/// </summary>
	public class ServerListFavourites : BaseServerList
	{
		internal override void LaunchQuery()
		{
			var filters = GetFilters();
			request = Internal.RequestFavoritesServerList( AppId.Value, filters, (uint)filters.Length, IntPtr.Zero );
		}
	}
}