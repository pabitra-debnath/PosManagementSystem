using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Operation;
using POS.Models.Setup;

namespace POS.Models.ViewModel
{
    public class ExpenseOperationVM
    {
        public long Id { get; set; }

        [Required]
        public long ItemId { get; set; }
        public virtual ExpenseItem Item { get; set; }
        [Required]
        public long Quantity { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public double LineTotal { get; set; }
        public string Reason { get; set; }
        public DateTime? Date { get; set; }
        [Required]
        public long ExpenseInformationId { get; set; }
        public virtual ExpenseOperationInfo ExpenseInformation { get; set; }
    }
}
