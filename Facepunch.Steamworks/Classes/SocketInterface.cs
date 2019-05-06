﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Steamworks.Data;

namespace Steamworks
{
	public class SocketInterface
	{
		public List<NetConnection> Connecting = new List<NetConnection>();
		public List<NetConnection> Connected = new List<NetConnection>();
		public Socket Socket { get; internal set; }

		public bool Close() => Socket.Close();

		public override string ToString() => Socket.ToString();

		public virtual void OnConnectionChanged( NetConnection connection, ConnectionInfo data )
		{
			switch ( data.State )
			{
				case ConnectionState.Connecting:
					OnConnecting( connection, data );
					break;
				case ConnectionState.Connected:
					OnConnected( connection, data );
					break;
				case ConnectionState.ClosedByPeer:
				case ConnectionState.ProblemDetectedLocally:
				case ConnectionState.None:
					OnDisconnected( connection, data );
					break;
			}
		}

		/// <summary>
		/// Default behaviour is to accept every connection
		/// </summary>
		public virtual void OnConnecting( NetConnection connection, ConnectionInfo data )
		{
			connection.Accept();
			Connecting.Add( connection );
		}

		/// <summary>
		/// Client is connected. They move from connecting to Connections
		/// </summary>
		public virtual void OnConnected( NetConnection connection, ConnectionInfo data )
		{
			Connecting.Remove( connection );
			Connected.Add( connection );
		}

		/// <summary>
		/// The connection has been closed remotely or disconnected locally. Check data.State for details.
		/// </summary>
		public virtual void OnDisconnected( NetConnection connection, ConnectionInfo data )
		{
			connection.Close();

			Connecting.Remove( connection );
			Connected.Remove( connection );
		}

		public void Receive( int bufferSize = 32 )
		{
			// #32bit
			int processed = 0;
			IntPtr messageBuffer = Marshal.AllocHGlobal( 8 * bufferSize );

			try
			{
				processed = SteamNetworkingSockets.Internal.ReceiveMessagesOnListenSocket( Socket, messageBuffer, bufferSize );

				for ( int i = 0; i < processed; i++ )
				{
					// #32bit
					ReceiveMessage( Marshal.ReadIntPtr( messageBuffer, i * 8 ) );
				}
			}
			finally
			{
				Marshal.FreeHGlobal( messageBuffer );
			}

			//
			// Overwhelmed our buffer, keep going
			//
			if ( processed == bufferSize )
				Receive( bufferSize );
		}

		internal unsafe void ReceiveMessage( IntPtr msgPtr )
		{
			var msg = Marshal.PtrToStructure<NetMsg>( msgPtr );
			try
			{
				OnMessage( msg.Connection, msg.Identity, msg.DataPtr, msg.DataSize, msg.RecvTime, msg.MessageNumber, msg.Channel );
			}
			finally
			{
				//
				// Releases the message
				//
				msg.Release( msgPtr );
			}
		}

		public virtual void OnMessage( NetConnection connection, NetworkIdentity identity, IntPtr data, int size, long messageNum, long recvTime, int channel )
		{

		}
	}
}