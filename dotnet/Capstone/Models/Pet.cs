using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Pet
    {
        public int Id { get; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
