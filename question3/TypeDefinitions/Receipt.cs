using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace question3
{
    class Receipt
    {
        public bool added { get; set; }
        public string description { get; set; }
        public BoundingPoly boundingPoly { get; set; }
    }
}
