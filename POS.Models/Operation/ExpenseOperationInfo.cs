﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.Models.Operation
{
    public class ExpenseOperationInfo
    {
        public long Id { get; set; }
        [Required]
        public string ExpenseNo { get; set; }
        [Required]
        public long BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        [Required]
        public long EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        [Required]
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public double DueAmount { get; set; }
        public DateTime ExpenseDate { get; set; }
        public DateTime Date { get; set; }

        public List<ExpenseOperation> ExpenseItems { get; set; }
    }
}
