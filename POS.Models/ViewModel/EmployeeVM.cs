using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using POS.Models.Setup;

namespace POS.Models.ViewModel
{
    public class EmployeeVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage="Name is required")]
        [MinLength(3, ErrorMessage = "Name should be at least 3 charecter")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code is required")]
        [MinLength(16, ErrorMessage = "Code sould be 16 digit")]
        [MaxLength(16, ErrorMessage = "Code should be 16 digit")]
        public string Code { get; set; }
        public int? OrganizationId { get; set; }
        public Organization Organizations { get; set; }
        [Required(ErrorMessage = "Branch is required")]
        public int BranchId { get; set; }
        public DateTime JoiningDate { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        [Required(ErrorMessage = "Contact No is required")]
        [MinLength(11, ErrorMessage = "Contact No should be 11 digit")]
        [MaxLength(11, ErrorMessage = "Contact No should be 11 digit")]
        public string ContactNo { get; set; }
        [EmailAddress(ErrorMessage = "Email address not valid")]
        public string Email { get; set; }
        public int? ReferenceId { get; set; }
        public string EmergencyContact { get; set; }
        [Required(ErrorMessage = "NID is required")]
        [MinLength(13, ErrorMessage = "NID should be 13 or 17 digit")]
        [MaxLength(17, ErrorMessage = "NID should be 13 or 17 digit")]
        public string NID { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Branch> BranchList { get; set; }
        public string PrevCode { get; set; }
        public string PrevContact { get; set; }
        public string PrevEmail { get; set; }
        public string PrevNID { get; set; }
        public string PrevImg { get; set; }

    }
}
