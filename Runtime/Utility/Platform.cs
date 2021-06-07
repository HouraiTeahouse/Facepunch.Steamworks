using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;

namespace Steamworks
{
	internal static class Platform
    {
#if UNITY_STANDALONE_WIN && UNITY_64
		public const int StructPlatformPackSize = 8;
		public const string LibraryName = "steam_api64";
#elif UNITY_STANDALONE_WIN && !UNITY_64
		public const int StructPlatformPackSize = 8;
		public const string LibraryName = "steam_api";
#elif UNITY_STANDALONE_LINUX || UNITY_STANDALONE_OSX
		public const int StructPlatformPackSize = 4;
		public const string LibraryName = "libsteam_api";
#endif

		public const CallingConvention CC = CallingConvention.Cdecl;
		public const int StructPackSize = 4;
	}
}
