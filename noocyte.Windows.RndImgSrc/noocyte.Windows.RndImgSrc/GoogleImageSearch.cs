using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;
using Windows.Networking;
using System.Net.Http;
using Windows.Data.Json;

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

        public async Task<ItemCollection> ExaminePhotos(string query)
        {
            string responseText = await GetImageJson(query);
            JsonObject root = JsonObject.Parse(responseText);
            var response = root.GetNamedObject("responseData");
            var images = response.GetNamedArray("results");
            for (uint i = 0; i < images.Count; i++)
            {
                Item item = new Item();
                item.Title = images.GetObjectAt(i).GetNamedString("title");
                item.SetImage(new Uri(images.GetObjectAt(i).GetNamedString("url")));
                item.Link = images.GetObjectAt(i).GetNamedString("originalContextUrl");
                Collection.Add(item);
            }
            return this.Collection;
        }

        private ItemCollection _Collection = new ItemCollection();
        public ItemCollection Collection
        {
            get { return this._Collection; }
        }

        private async Task<string> GetImageJson(string query)
        {
            var client = new HttpClient();
            string url = "https://ajax.googleapis.com/ajax/services/search/images?v=1.0&q=fuzzy%20monkey&rsz=8";
            return await client.GetStringAsync(url);
        }
    }
}
