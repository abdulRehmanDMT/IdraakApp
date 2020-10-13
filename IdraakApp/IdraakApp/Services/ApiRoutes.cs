using System;
using System.Collections.Generic;
using System.Text;

namespace IdraakApp.Services
{
    public static class ApiRoutes
    {
        public static class Base
        {
            /// <summary>
            /// Local
            /// </summary>
            public static readonly string BaseUrl = "https://idraak.kayyen.com/";

            /// <summary>
            /// Live
            /// </summary>
            //public static readonly string BaseUrl = "";
        }

        public static class IdraakCountries
        {
            public static readonly string GetCountryDetailByCountryCode = "api/Countries/";
        }

        public static class MicUrls
        {
            public static readonly string IpInfoUrl = "http://ipinfo.io/?token=b883411df4c0d8";
        }
    }
}
