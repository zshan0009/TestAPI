using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestAPI.Helpers
{
    public class WebHelper
    {
        
        private static string userAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)";
        public static async Task<string> GetWebResponse(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers["User-Agent"] = userAgent;
                // Download data.
                var response = await client.DownloadStringTaskAsync(url);
                // Write values.
                return response;
            }

            //if (response.StatusCode == HttpStatusCode.OK)
            //{
            //    // No error , if response is OK
            //}
            //else
            //{
            //    throw new Exception(response.Content.ReadAsStringAsync().Result);
            //}
        }
    }
}
