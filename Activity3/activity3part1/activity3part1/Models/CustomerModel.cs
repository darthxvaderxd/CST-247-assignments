using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace activity3part1.Models
{
    public class CustomerModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public CustomerModel(int ID, string Name, int Age)
        {
            this.ID = ID;
            this.Name = Name;
            this.Age = Age;
        }
    }
}