using System;
using System.Linq;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace MyOxygen.Libraries
{
    public static class Network
    {
        /// <summary>
        /// Check if there is a connection by WiFi or Mobile Data.
        /// </summary>
        /// <returns>True for either WiFi or Mobile Data, otherwise false.</returns>
        public static bool IsConnectionWifiOrCellular()
        {
            return IsConnectionWifi() || IsConnectionCellular();
        }


        /// <summary>
        /// Checks if there is a connection by WiFi.
        /// </summary>
        /// <returns>True for yes, otherwise false.</returns>
        public static bool IsConnectionWifi()
        {
            var profiles = CrossConnectivity.Current.ConnectionTypes;
            return profiles.Contains(ConnectionType.WiFi);
        }


        /// <summary>
        /// Checks if there is a connection by Mobile Data.
        /// </summary>
        /// <returns>True for yes, otherwise false.</returns>
        public static bool IsConnectionCellular()
        {
            var profiles = CrossConnectivity.Current.ConnectionTypes;
            return profiles.Contains(ConnectionType.Cellular);
        }


        /// <summary>
        /// Makes sure all special characters are escaped.
        /// </summary>
        /// <param name="urlEntry">Entry to encode for the URL.</param>
        /// <returns>Encoded URL entry.</returns>
        public static string EncodeForUrl(string urlEntry)
        {
            // https://stackoverflow.com/a/34189188/3872145
            return Uri.EscapeDataString(urlEntry);
        }


        /// <summary>
        /// Sets the connection changed event.
        /// </summary>
        /// <param name="connectivityChangedEventHandler">Connectivity changed event handler.</param>
        public static void SetOnConnectionChangedEvent(ConnectivityChangedEventHandler connectivityChangedEventHandler)
        {
            CrossConnectivity.Current.ConnectivityChanged -= connectivityChangedEventHandler;
            CrossConnectivity.Current.ConnectivityChanged += connectivityChangedEventHandler;
        }


        /// <summary>
        /// Sets the connection type changed event.
        /// </summary>
        /// <param name="connectivityTypeChangedEventHandler">Connectivity changed event handler.</param>
        public static void SetOnConnectionTypeChangedEvent(ConnectivityTypeChangedEventHandler connectivityTypeChangedEventHandler)
        {
            CrossConnectivity.Current.ConnectivityTypeChanged -= connectivityTypeChangedEventHandler;
            CrossConnectivity.Current.ConnectivityTypeChanged += connectivityTypeChangedEventHandler;
        }
    }
}
