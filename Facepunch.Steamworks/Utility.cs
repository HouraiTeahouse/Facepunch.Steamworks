﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Facepunch.Steamworks
{
    internal static class Utility
    {
        static internal uint SwapBytes( uint x )
        {
            return ( ( x & 0x000000ff ) << 24 ) +
                   ( ( x & 0x0000ff00 ) << 8 ) +
                   ( ( x & 0x00ff0000 ) >> 8 ) +
                   ( ( x & 0xff000000 ) >> 24 );
        }


        static internal uint IpToInt32( this IPAddress ipAddress )
        {
            return BitConverter.ToUInt32( ipAddress.GetAddressBytes().Reverse().ToArray(), 0 );
        }

        static internal IPAddress Int32ToIp( uint ipAddress )
        {
            return new IPAddress( BitConverter.GetBytes( ipAddress ).Reverse().ToArray() );
        }

        static internal class Epoch
        {
            private static readonly DateTime epoch = new DateTime( 1970, 1, 1, 0, 0, 0, DateTimeKind.Utc );

            /// <summary>
            /// Returns the current Unix Epoch
            /// </summary>
            public static int Current
            {
                get
                {
                    return (int)( DateTime.UtcNow.Subtract( epoch ).TotalSeconds );
                }
            }

            /// <summary>
            /// Convert an epoch to a datetime
            /// </summary>
            public static DateTime ToDateTime( decimal unixTime )
            {
                return epoch.AddSeconds( (long)unixTime );
            }

            /// <summary>
            /// Convert a DateTime to a unix time
            /// </summary>
            public static uint FromDateTime( DateTime dt )
            {
                return (uint)( dt.Subtract( epoch ).TotalSeconds );
            }

        }

        internal static string FormatPrice(string currency, ulong price)
        {
            var decimaled = (price / 100.0).ToString("0.00");

            switch (currency )
            {
                case "GBP": return $"£{decimaled}";
                case "USD": return $"${decimaled}";
                case "CAD": return $"${decimaled} CAD";
                case "EUR": return $"€{decimaled}";
                case "RUB": return $"₽{decimaled}";
                case "NZD": return $"${decimaled} NZD";

                // TODO - all of them

                default: return $"{decimaled}{currency}";
            }

            
        }
    }
}
