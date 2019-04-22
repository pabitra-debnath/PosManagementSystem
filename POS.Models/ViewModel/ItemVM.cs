﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Setup;

namespace POS.Models.ViewModel
{
    public class ItemVM
    {
        public long Id { get; set; }
        [Required]
        [Remote("IsUniqueName", "Item", ErrorMessage = "The Name already exists", AdditionalFields = "initialName")]
        public string Name { get; set; }
        [Required]
        public string PreCode { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "The Code must be length of 6")]
        [Remote("IsUniqueCode", "Item", ErrorMessage = "The Code already exists", AdditionalFields = "PreCode,initialCode,initialPreCode")]
        public string Code { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        [Required]
        [DisplayName("Cost Price")]
        public double CostPrice { get; set; }
        [DisplayName("Sale Price")]
        public double SalePrice { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Category")]
        public long CategoryId { get; set; }
        public virtual ItemCategory Category { get; set; }

        public List<Item> Items { get; set; }
        public IEnumerable<SelectListItem> SelectList { get; set; }
    }
}
