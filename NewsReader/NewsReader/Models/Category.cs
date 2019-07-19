using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NewsReader.Models.Base;

namespace NewsReader.Models
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Category()
            :base()
        {
        }
    }
}