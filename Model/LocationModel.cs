using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Helpers;

namespace TestAPI.Model
{
    public class LocationModel
    {
        #region Constants

        private const string ACCESSKEY = "4e53ea4ac558847b0cb0111f6fedc134";

        #endregion

        #region Public Properties
        public string IP { get; set; }
        #endregion

        public LocationModel()
        {

        }
        public async Task<string> GetLocationByIP(string ipAddress)
        {
            var fields = "city";
            var url = string.Format("http://api.ipstack.com/{0}?access_key={1}&fields={2}", ipAddress, ACCESSKEY, fields);
            return await WebHelper.GetWebResponse(url);
        }
    }
}
