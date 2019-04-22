using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Models.Setup
{
    public class Employee
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int OrganizationId { get; set; }
        public virtual  Organization Organizations { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branchs { get; set; }
        public DateTime JoiningDate { get; set; }
        public string ImagePath { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int? ReferenceId { get; set; }
        public string EmergencyContact { get; set; }
        public string NID { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        [NotMapped]
        public List<Employee> Employees { get; set; }
        [NotMapped]
        public List<Branch> BranchList { get; set; }
        [NotMapped]
        public string PrevCode { get; set; }
        [NotMapped]
        public string PrevContact { get; set; }
        [NotMapped]
        public string PrevEmail { get; set; }
        [NotMapped]
        public string PrevNID { get; set; }
        [NotMapped]
        public string PrevImg { get; set; }
    }
}
