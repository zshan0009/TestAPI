using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Helpers;
using TestAPI.Model;

namespace TestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> Candidate(string name, string phone)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(phone))
                return new JsonResult("Invalid input");

            var model = new CandidateModel
            {
                Name = name,
                Phone = phone
            };

            var result = await model.process();
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> Location(string ip)
        {
            if (string.IsNullOrEmpty(ip) || !InputHelper.IsIPValid(ip))
                return new JsonResult("Invalid input");

            var model = new LocationModel();
            var result = await model.GetLocationByIP(ip);
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> Listings(int passengerCount)
        {
            if (passengerCount <= 0 || !InputHelper.IsNumberValid(passengerCount))
                return new JsonResult("Invalid input");

            var model = new ListingModel();
            var result = await model.GetListings(passengerCount);
            return new JsonResult(result);
        }
    }
}
