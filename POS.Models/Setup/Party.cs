﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Setup
{
    public class Party
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PreCode { get; set; }
        [Required]
        public string Code { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[] Image { get; set; }
        public DateTime Date { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsSupplier { get; set; }
    }
}
