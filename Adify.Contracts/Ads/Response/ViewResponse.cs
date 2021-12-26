using System;

namespace AdifyContracts.Ads.Response
{
    public class ViewResponse
    {
        public int id { get; set; }
        public DateTime viewedTime { get; set; }
        public string ip { get; set; }
    }
}