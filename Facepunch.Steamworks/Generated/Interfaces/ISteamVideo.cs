using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	internal class ISteamVideo : SteamInterface
	{
		public ISteamVideo( bool server = false ) : base( server )
		{
		}
		
		public override string InterfaceName => "STEAMVIDEO_INTERFACE_V002";
		
		public override void InitInternals()
		{
			_GetVideoURL = Marshal.GetDelegateForFunctionPointer<FGetVideoURL>( Marshal.ReadIntPtr( VTable, 0) );
			_IsBroadcasting = Marshal.GetDelegateForFunctionPointer<FIsBroadcasting>( Marshal.ReadIntPtr( VTable, 8) );
			_GetOPFSettings = Marshal.GetDelegateForFunctionPointer<FGetOPFSettings>( Marshal.ReadIntPtr( VTable, 16) );
			_GetOPFStringForApp = Marshal.GetDelegateForFunctionPointer<FGetOPFStringForApp>( Marshal.ReadIntPtr( VTable, 24) );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FGetVideoURL( IntPtr self, AppId_t unVideoAppID );
		private FGetVideoURL _GetVideoURL;
		
		#endregion
		internal void GetVideoURL( AppId_t unVideoAppID )
		{
			_GetVideoURL( Self, unVideoAppID );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FIsBroadcasting( IntPtr self, ref int pnNumViewers );
		private FIsBroadcasting _IsBroadcasting;
		
		#endregion
		internal bool IsBroadcasting( ref int pnNumViewers )
		{
			return _IsBroadcasting( Self, ref pnNumViewers );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FGetOPFSettings( IntPtr self, AppId_t unVideoAppID );
		private FGetOPFSettings _GetOPFSettings;
		
		#endregion
		internal void GetOPFSettings( AppId_t unVideoAppID )
		{
			_GetOPFSettings( Self, unVideoAppID );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetOPFStringForApp( IntPtr self, AppId_t unVideoAppID, StringBuilder pchBuffer, ref int pnBufferSize );
		private FGetOPFStringForApp _GetOPFStringForApp;
		
		#endregion
		internal bool GetOPFStringForApp( AppId_t unVideoAppID, StringBuilder pchBuffer, ref int pnBufferSize )
		{
			return _GetOPFStringForApp( Self, unVideoAppID, pchBuffer, ref pnBufferSize );
		}
		
	}
}
