using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsReader.Models.Base;

namespace NewsReader.Models
{
    public class Country:Entity
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public Country()
            :base()
        {
        }
    }
}