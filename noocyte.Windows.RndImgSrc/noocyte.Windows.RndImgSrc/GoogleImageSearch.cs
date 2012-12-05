using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Networking;
using Windows.Networking.;

namespace noocyte.Windows.RndImgSrc
{
    class GoogleImageSearch
    {
        public static string CurrentIPAddress()
        {
            var icp = NetworkInformation.GetInternetConnectionProfile();

            if (icp != null && icp.NetworkAdapter != null)
            {
                var hostname = NetworkInformation.GetHostNames().FirstOrDefault();

                if (hostname != null)
                {
                    // the ip address
                    return hostname.CanonicalName;
                }
            }

            return string.Empty;
        }

        public ItemCollection GetImages(string searchQuery)
        {


            return null;
        }
    }
}
