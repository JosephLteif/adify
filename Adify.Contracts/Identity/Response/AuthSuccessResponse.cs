using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdifyContracts.Response
{
    public class AuthSuccessResponse
    {
        public string user { get; set; }
        public string token { get; set; }
        public string userid { get; set; }
        public string expiration { get; set; }
        public string status { get; set; }

    }
}
