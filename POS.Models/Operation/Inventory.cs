﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Operation
{
    public class Inventory
    {
        public int Id { get; set; }
        public int BranchId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
