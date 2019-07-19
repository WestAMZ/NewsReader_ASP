using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsReader.Models.Base
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime DateCreated { get; set; }
        public Entity()
        {
            this.DateCreated = DateTime.Now;
        }
    }
}