using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Setup;

namespace POS.Models.ViewModel
{
    public class ExpenseCategoryVM
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        [Required(ErrorMessage = "Name field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Code field is required")]
        [StringLength(7, ErrorMessage = "Code length should 7 charecter")]
        public string Code { get; set; }
        public string PrevName { get; set; }
        public string PrevCode { get; set; }
        public string Description { get; set; }
        public List<ExpenseCategory> All { get; set; }
        public List<SelectListItem> DropDown { get; set; }
    }
}
