using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.Models.Operation
{
    public class SalesOperationInfo
    {
        public long Id { get; set; }
        [Required]
        public string SalesNo { get; set; }
        [Required]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public string CustomerName { get; set; }
        public string CustomerContact { get; set; }

        [Required]
        public double TotalAmount { get; set; }
        public double? VAT { get; set; }
        public double? DiscountAmount { get; set; }
        [Required]
        public double PayableAmount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime SalesDate { get; set; }
        public DateTime Date { get; set; }

        public List<SalesOperation> SalesItems { get; set; }
    }
}
