using System.Collections.Generic;

namespace AdifyContracts.Ads.Response
{
    public class AnalyticsResponse
    {
        public int id { get; set; }
        public object clicks { get; set; }
        public List<ViewResponse> views { get; set; }
    }
}