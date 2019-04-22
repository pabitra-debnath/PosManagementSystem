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
    public class OrganizationVM
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code field is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Contact no is required")]
        public string ContactNo  { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public List<Organization> Organizations { get; set; }
        public string PrevName { get; set; }
        public string PrevCode { get; set; }
        public string PrevContactNo { get; set; }
    }
}
