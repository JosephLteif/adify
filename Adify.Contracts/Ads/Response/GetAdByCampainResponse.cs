using System;
using System.Collections.Generic;
using System.Text;

namespace AdifyContracts.Ads.Response
{
    public class GetAdByCampainResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public string durationInDays { get; set; }
        public int budget { get; set; }
        public ICollection<AdResponse> Ads { get; set; }
    }
}
