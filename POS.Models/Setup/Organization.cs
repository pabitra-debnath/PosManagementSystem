using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Setup
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
    }
}
