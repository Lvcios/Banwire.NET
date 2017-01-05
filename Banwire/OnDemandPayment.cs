using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banwire
{
    public class OnDemandPayment
    {
        public string method { get; set; }
        public string user { get; set; }
        public string reference { get; set; }
        public string token { get; set; }
        public decimal amount { get; set; }
    }
}
