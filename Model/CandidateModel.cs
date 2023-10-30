using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.Helpers;

namespace TestAPI.Model
{
    public class CandidateModel
    { 
        public string Name { get; set; }
        public string Phone { get; set; }
        public async Task<CandidateModel> process()
        {
            return new CandidateModel
            {
                Name = InputHelper.Sanitise(Name),
                Phone = InputHelper.Sanitise(Phone)
            };
        }

    }
}
