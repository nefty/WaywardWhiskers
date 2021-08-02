using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class Agency
    {
        public int Id { get; }
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string Description { get; private set; }
    }
}
