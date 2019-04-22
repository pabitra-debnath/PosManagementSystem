using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.Models.Operation
{
    public class Stock
    {
        public long Id { get; set; }
        [Required]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public long StockQuantity { get; set; }
        [Required]
        public double AveragePrice { get; set; }
        public DateTime? Date { get; set; }
    }
}
