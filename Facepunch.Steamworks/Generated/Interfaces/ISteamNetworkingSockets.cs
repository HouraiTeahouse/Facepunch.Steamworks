using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Steamworks.Data;


namespace Steamworks
{
	internal class ISteamNetworkingSockets : SteamInterface
	{
		public override string InterfaceName => "SteamNetworkingSockets002";
		
		public override void InitInternals()
		{
			_CreateListenSocketIP = Marshal.GetDelegateForFunctionPointer<FCreateListenSocketIP>( Marshal.ReadIntPtr( VTable, 0) );
			_ConnectByIPAddress = Marshal.GetDelegateForFunctionPointer<FConnectByIPAddress>( Marshal.ReadIntPtr( VTable, 8) );
			_CreateListenSocketP2P = Marshal.GetDelegateForFunctionPointer<FCreateListenSocketP2P>( Marshal.ReadIntPtr( VTable, 16) );
			_ConnectP2P = Marshal.GetDelegateForFunctionPointer<FConnectP2P>( Marshal.ReadIntPtr( VTable, 24) );
			_AcceptConnection = Marshal.GetDelegateForFunctionPointer<FAcceptConnection>( Marshal.ReadIntPtr( VTable, 32) );
			_CloseConnection = Marshal.GetDelegateForFunctionPointer<FCloseConnection>( Marshal.ReadIntPtr( VTable, 40) );
			_CloseListenSocket = Marshal.GetDelegateForFunctionPointer<FCloseListenSocket>( Marshal.ReadIntPtr( VTable, 48) );
			_SetConnectionUserData = Marshal.GetDelegateForFunctionPointer<FSetConnectionUserData>( Marshal.ReadIntPtr( VTable, 56) );
			_GetConnectionUserData = Marshal.GetDelegateForFunctionPointer<FGetConnectionUserData>( Marshal.ReadIntPtr( VTable, 64) );
			_SetConnectionName = Marshal.GetDelegateForFunctionPointer<FSetConnectionName>( Marshal.ReadIntPtr( VTable, 72) );
			_GetConnectionName = Marshal.GetDelegateForFunctionPointer<FGetConnectionName>( Marshal.ReadIntPtr( VTable, 80) );
			_SendMessageToConnection = Marshal.GetDelegateForFunctionPointer<FSendMessageToConnection>( Marshal.ReadIntPtr( VTable, 88) );
			_FlushMessagesOnConnection = Marshal.GetDelegateForFunctionPointer<FFlushMessagesOnConnection>( Marshal.ReadIntPtr( VTable, 96) );
			_ReceiveMessagesOnConnection = Marshal.GetDelegateForFunctionPointer<FReceiveMessagesOnConnection>( Marshal.ReadIntPtr( VTable, 104) );
			_ReceiveMessagesOnListenSocket = Marshal.GetDelegateForFunctionPointer<FReceiveMessagesOnListenSocket>( Marshal.ReadIntPtr( VTable, 112) );
			_GetConnectionInfo = Marshal.GetDelegateForFunctionPointer<FGetConnectionInfo>( Marshal.ReadIntPtr( VTable, 120) );
			_GetQuickConnectionStatus = Marshal.GetDelegateForFunctionPointer<FGetQuickConnectionStatus>( Marshal.ReadIntPtr( VTable, 128) );
			_GetDetailedConnectionStatus = Marshal.GetDelegateForFunctionPointer<FGetDetailedConnectionStatus>( Marshal.ReadIntPtr( VTable, 136) );
			_GetListenSocketAddress = Marshal.GetDelegateForFunctionPointer<FGetListenSocketAddress>( Marshal.ReadIntPtr( VTable, 144) );
			_CreateSocketPair = Marshal.GetDelegateForFunctionPointer<FCreateSocketPair>( Marshal.ReadIntPtr( VTable, 152) );
			_GetIdentity = Marshal.GetDelegateForFunctionPointer<FGetIdentity>( Marshal.ReadIntPtr( VTable, 160) );
			_ReceivedRelayAuthTicket = Marshal.GetDelegateForFunctionPointer<FReceivedRelayAuthTicket>( Marshal.ReadIntPtr( VTable, 168) );
			_FindRelayAuthTicketForServer = Marshal.GetDelegateForFunctionPointer<FFindRelayAuthTicketForServer>( Marshal.ReadIntPtr( VTable, 176) );
			_ConnectToHostedDedicatedServer = Marshal.GetDelegateForFunctionPointer<FConnectToHostedDedicatedServer>( Marshal.ReadIntPtr( VTable, 184) );
			_GetHostedDedicatedServerPort = Marshal.GetDelegateForFunctionPointer<FGetHostedDedicatedServerPort>( Marshal.ReadIntPtr( VTable, 192) );
			_GetHostedDedicatedServerPOPID = Marshal.GetDelegateForFunctionPointer<FGetHostedDedicatedServerPOPID>( Marshal.ReadIntPtr( VTable, 200) );
			_GetHostedDedicatedServerAddress = Marshal.GetDelegateForFunctionPointer<FGetHostedDedicatedServerAddress>( Marshal.ReadIntPtr( VTable, 208) );
			_CreateHostedDedicatedServerListenSocket = Marshal.GetDelegateForFunctionPointer<FCreateHostedDedicatedServerListenSocket>( Marshal.ReadIntPtr( VTable, 216) );
			_RunCallbacks = Marshal.GetDelegateForFunctionPointer<FRunCallbacks>( Marshal.ReadIntPtr( VTable, 224) );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamListenSocket FCreateListenSocketIP( IntPtr self, ref SteamNetworkingIPAddr localAddress );
		private FCreateListenSocketIP _CreateListenSocketIP;
		
		#endregion
		internal HSteamListenSocket CreateListenSocketIP( ref SteamNetworkingIPAddr localAddress )
		{
			return _CreateListenSocketIP( Self, ref localAddress );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamNetConnection FConnectByIPAddress( IntPtr self, ref SteamNetworkingIPAddr address );
		private FConnectByIPAddress _ConnectByIPAddress;
		
		#endregion
		internal HSteamNetConnection ConnectByIPAddress( ref SteamNetworkingIPAddr address )
		{
			return _ConnectByIPAddress( Self, ref address );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamListenSocket FCreateListenSocketP2P( IntPtr self, int nVirtualPort );
		private FCreateListenSocketP2P _CreateListenSocketP2P;
		
		#endregion
		internal HSteamListenSocket CreateListenSocketP2P( int nVirtualPort )
		{
			return _CreateListenSocketP2P( Self, nVirtualPort );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamNetConnection FConnectP2P( IntPtr self, ref SteamNetworkingIdentity identityRemote, int nVirtualPort );
		private FConnectP2P _ConnectP2P;
		
		#endregion
		internal HSteamNetConnection ConnectP2P( ref SteamNetworkingIdentity identityRemote, int nVirtualPort )
		{
			return _ConnectP2P( Self, ref identityRemote, nVirtualPort );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate Result FAcceptConnection( IntPtr self, HSteamNetConnection hConn );
		private FAcceptConnection _AcceptConnection;
		
		#endregion
		internal Result AcceptConnection( HSteamNetConnection hConn )
		{
			return _AcceptConnection( Self, hConn );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FCloseConnection( IntPtr self, HSteamNetConnection hPeer, int nReason, string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger );
		private FCloseConnection _CloseConnection;
		
		#endregion
		internal bool CloseConnection( HSteamNetConnection hPeer, int nReason, string pszDebug, [MarshalAs( UnmanagedType.U1 )] bool bEnableLinger )
		{
			return _CloseConnection( Self, hPeer, nReason, pszDebug, bEnableLinger );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FCloseListenSocket( IntPtr self, HSteamListenSocket hSocket );
		private FCloseListenSocket _CloseListenSocket;
		
		#endregion
		internal bool CloseListenSocket( HSteamListenSocket hSocket )
		{
			return _CloseListenSocket( Self, hSocket );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FSetConnectionUserData( IntPtr self, HSteamNetConnection hPeer, long nUserData );
		private FSetConnectionUserData _SetConnectionUserData;
		
		#endregion
		internal bool SetConnectionUserData( HSteamNetConnection hPeer, long nUserData )
		{
			return _SetConnectionUserData( Self, hPeer, nUserData );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate long FGetConnectionUserData( IntPtr self, HSteamNetConnection hPeer );
		private FGetConnectionUserData _GetConnectionUserData;
		
		#endregion
		internal long GetConnectionUserData( HSteamNetConnection hPeer )
		{
			return _GetConnectionUserData( Self, hPeer );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FSetConnectionName( IntPtr self, HSteamNetConnection hPeer, string pszName );
		private FSetConnectionName _SetConnectionName;
		
		#endregion
		internal void SetConnectionName( HSteamNetConnection hPeer, string pszName )
		{
			_SetConnectionName( Self, hPeer, pszName );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetConnectionName( IntPtr self, HSteamNetConnection hPeer, StringBuilder pszName, int nMaxLen );
		private FGetConnectionName _GetConnectionName;
		
		#endregion
		internal bool GetConnectionName( HSteamNetConnection hPeer, StringBuilder pszName, int nMaxLen )
		{
			return _GetConnectionName( Self, hPeer, pszName, nMaxLen );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate Result FSendMessageToConnection( IntPtr self, HSteamNetConnection hConn, IntPtr pData, uint cbData, int nSendFlags );
		private FSendMessageToConnection _SendMessageToConnection;
		
		#endregion
		internal Result SendMessageToConnection( HSteamNetConnection hConn, IntPtr pData, uint cbData, int nSendFlags )
		{
			return _SendMessageToConnection( Self, hConn, pData, cbData, nSendFlags );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate Result FFlushMessagesOnConnection( IntPtr self, HSteamNetConnection hConn );
		private FFlushMessagesOnConnection _FlushMessagesOnConnection;
		
		#endregion
		internal Result FlushMessagesOnConnection( HSteamNetConnection hConn )
		{
			return _FlushMessagesOnConnection( Self, hConn );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate int FReceiveMessagesOnConnection( IntPtr self, HSteamNetConnection hConn, [In,Out] ref SteamNetworkingMessage_t[]  ppOutMessages, int nMaxMessages );
		private FReceiveMessagesOnConnection _ReceiveMessagesOnConnection;
		
		#endregion
		internal int ReceiveMessagesOnConnection( HSteamNetConnection hConn, [In,Out] ref SteamNetworkingMessage_t[]  ppOutMessages, int nMaxMessages )
		{
			return _ReceiveMessagesOnConnection( Self, hConn, ref ppOutMessages, nMaxMessages );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate int FReceiveMessagesOnListenSocket( IntPtr self, HSteamListenSocket hSocket, [In,Out] ref SteamNetworkingMessage_t[]  ppOutMessages, int nMaxMessages );
		private FReceiveMessagesOnListenSocket _ReceiveMessagesOnListenSocket;
		
		#endregion
		internal int ReceiveMessagesOnListenSocket( HSteamListenSocket hSocket, [In,Out] ref SteamNetworkingMessage_t[]  ppOutMessages, int nMaxMessages )
		{
			return _ReceiveMessagesOnListenSocket( Self, hSocket, ref ppOutMessages, nMaxMessages );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetConnectionInfo( IntPtr self, HSteamNetConnection hConn, ref SteamNetConnectionInfo_t pInfo );
		private FGetConnectionInfo _GetConnectionInfo;
		
		#endregion
		internal bool GetConnectionInfo( HSteamNetConnection hConn, ref SteamNetConnectionInfo_t pInfo )
		{
			return _GetConnectionInfo( Self, hConn, ref pInfo );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetQuickConnectionStatus( IntPtr self, HSteamNetConnection hConn, ref SteamNetworkingQuickConnectionStatus pStats );
		private FGetQuickConnectionStatus _GetQuickConnectionStatus;
		
		#endregion
		internal bool GetQuickConnectionStatus( HSteamNetConnection hConn, ref SteamNetworkingQuickConnectionStatus pStats )
		{
			return _GetQuickConnectionStatus( Self, hConn, ref pStats );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate int FGetDetailedConnectionStatus( IntPtr self, HSteamNetConnection hConn, StringBuilder pszBuf, int cbBuf );
		private FGetDetailedConnectionStatus _GetDetailedConnectionStatus;
		
		#endregion
		internal int GetDetailedConnectionStatus( HSteamNetConnection hConn, StringBuilder pszBuf, int cbBuf )
		{
			return _GetDetailedConnectionStatus( Self, hConn, pszBuf, cbBuf );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetListenSocketAddress( IntPtr self, HSteamListenSocket hSocket, ref SteamNetworkingIPAddr address );
		private FGetListenSocketAddress _GetListenSocketAddress;
		
		#endregion
		internal bool GetListenSocketAddress( HSteamListenSocket hSocket, ref SteamNetworkingIPAddr address )
		{
			return _GetListenSocketAddress( Self, hSocket, ref address );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FCreateSocketPair( IntPtr self, [In,Out] HSteamNetConnection[]  pOutConnection1, [In,Out] HSteamNetConnection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref SteamNetworkingIdentity pIdentity1, ref SteamNetworkingIdentity pIdentity2 );
		private FCreateSocketPair _CreateSocketPair;
		
		#endregion
		internal bool CreateSocketPair( [In,Out] HSteamNetConnection[]  pOutConnection1, [In,Out] HSteamNetConnection[]  pOutConnection2, [MarshalAs( UnmanagedType.U1 )] bool bUseNetworkLoopback, ref SteamNetworkingIdentity pIdentity1, ref SteamNetworkingIdentity pIdentity2 )
		{
			return _CreateSocketPair( Self, pOutConnection1, pOutConnection2, bUseNetworkLoopback, ref pIdentity1, ref pIdentity2 );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetIdentity( IntPtr self, ref SteamNetworkingIdentity pIdentity );
		private FGetIdentity _GetIdentity;
		
		#endregion
		internal bool GetIdentity( ref SteamNetworkingIdentity pIdentity )
		{
			return _GetIdentity( Self, ref pIdentity );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FReceivedRelayAuthTicket( IntPtr self, IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		private FReceivedRelayAuthTicket _ReceivedRelayAuthTicket;
		
		#endregion
		internal bool ReceivedRelayAuthTicket( IntPtr pvTicket, int cbTicket, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			return _ReceivedRelayAuthTicket( Self, pvTicket, cbTicket, pOutParsedTicket );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate int FFindRelayAuthTicketForServer( IntPtr self, ref SteamNetworkingIdentity identityGameServer, int nVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket );
		private FFindRelayAuthTicketForServer _FindRelayAuthTicketForServer;
		
		#endregion
		internal int FindRelayAuthTicketForServer( ref SteamNetworkingIdentity identityGameServer, int nVirtualPort, [In,Out] SteamDatagramRelayAuthTicket[]  pOutParsedTicket )
		{
			return _FindRelayAuthTicketForServer( Self, ref identityGameServer, nVirtualPort, pOutParsedTicket );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamNetConnection FConnectToHostedDedicatedServer( IntPtr self, ref SteamNetworkingIdentity identityTarget, int nVirtualPort );
		private FConnectToHostedDedicatedServer _ConnectToHostedDedicatedServer;
		
		#endregion
		internal HSteamNetConnection ConnectToHostedDedicatedServer( ref SteamNetworkingIdentity identityTarget, int nVirtualPort )
		{
			return _ConnectToHostedDedicatedServer( Self, ref identityTarget, nVirtualPort );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate ushort FGetHostedDedicatedServerPort( IntPtr self );
		private FGetHostedDedicatedServerPort _GetHostedDedicatedServerPort;
		
		#endregion
		internal ushort GetHostedDedicatedServerPort()
		{
			return _GetHostedDedicatedServerPort( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate SteamNetworkingPOPID FGetHostedDedicatedServerPOPID( IntPtr self );
		private FGetHostedDedicatedServerPOPID _GetHostedDedicatedServerPOPID;
		
		#endregion
		internal SteamNetworkingPOPID GetHostedDedicatedServerPOPID()
		{
			return _GetHostedDedicatedServerPOPID( Self );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		[return: MarshalAs( UnmanagedType.I1 )]
		private delegate bool FGetHostedDedicatedServerAddress( IntPtr self, ref SteamDatagramHostedAddress pRouting );
		private FGetHostedDedicatedServerAddress _GetHostedDedicatedServerAddress;
		
		#endregion
		internal bool GetHostedDedicatedServerAddress( ref SteamDatagramHostedAddress pRouting )
		{
			return _GetHostedDedicatedServerAddress( Self, ref pRouting );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate HSteamListenSocket FCreateHostedDedicatedServerListenSocket( IntPtr self, int nVirtualPort );
		private FCreateHostedDedicatedServerListenSocket _CreateHostedDedicatedServerListenSocket;
		
		#endregion
		internal HSteamListenSocket CreateHostedDedicatedServerListenSocket( int nVirtualPort )
		{
			return _CreateHostedDedicatedServerListenSocket( Self, nVirtualPort );
		}
		
		#region FunctionMeta
		[UnmanagedFunctionPointer( CallingConvention.ThisCall )]
		private delegate void FRunCallbacks( IntPtr self, IntPtr pCallbacks );
		private FRunCallbacks _RunCallbacks;
		
		#endregion
		internal void RunCallbacks( IntPtr pCallbacks )
		{
			_RunCallbacks( Self, pCallbacks );
		}
		
	}
}
