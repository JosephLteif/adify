using System;
using System.Collections.Generic;
using System.Text;

namespace AdifyContracts.Ads.Response
{
    public class AdResponse
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string imageUrl { get; set; }
        public string adUrl { get; set; }
        public bool didPass { get; set; }
        public CategoryResponse category { get; set; }
        public AnalyticsResponse analytics { get; set; }
    }
}
