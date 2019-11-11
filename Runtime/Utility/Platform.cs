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
#if UNITY_STANDALONE_WIN
		public const int StructPlatformPackSize = 8;
		public const string LibraryName = "steam_api64";
		public const CallingConvention MemberConvention = CallingConvention.Cdecl;
#elif UNITY_STANDALONE_OSX || UNITY_STANDALONE_LINUX
		public const int StructPlatformPackSize = 4;
		public const string LibraryName = "libsteam_api";
		public const CallingConvention MemberConvention = CallingConvention.Cdecl;
#endif

		public const int StructPackSize = 4;



		public static int MemoryOffset( int memLocation )
		{
#if PLATFORM_64
			return memLocation;
#else
			return memLocation / 2;
#endif
		}
	}
}
