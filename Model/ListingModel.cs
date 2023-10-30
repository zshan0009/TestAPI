using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Helpers;
using Newtonsoft.Json;

namespace TestAPI.Model
{
    public class ListingModel
    {
        #region public properties
        public string from { set; get; }
        public string to { set; get; }
        public List<Listings> listings { set; get; }
        #endregion

        public async Task<List<Listings>> GetListings(int passengerCount)
        {
            var url = string.Format("https://jayridechallengeapi.azurewebsites.net/api/QuoteRequest");
            var quoteList = JsonConvert.DeserializeObject<ListingModel>(await WebHelper.GetWebResponse(url));

            var listings = quoteList.listings.Where(x => x.vehicleType.maxPassengers >= passengerCount);
            return listings.Select(x =>
            {
                x.totalPrice = x.pricePerPassenger * x.vehicleType?.maxPassengers;
                return x;

            }).OrderBy(x => x.totalPrice).ToList();

            //return listings.ToList();
        }
    }

    public class Listings
    {
        public string name { set; get; }
        public decimal pricePerPassenger { set; get; }
        public decimal? totalPrice { set; get; }
        public VehicleType vehicleType { set; get; }
    }
    public class VehicleType
    {
        public string name { set; get; }
        public int maxPassengers { set; get; }
    }
}
