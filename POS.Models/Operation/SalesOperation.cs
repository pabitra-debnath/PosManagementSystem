using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.Models.Operation
{
    public class SalesOperation
    {
        public long Id { get; set; }

        [Required]
        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        [Required]
        public double LineTotal { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public long SalesOperationInformationId { get; set; }
        public virtual SalesOperationInfo SalesOperationInformation { get; set; }
    }
}
