using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Setup;
using System.Web;

namespace POS.Models.ViewModel
{
    public class ItemCategoryVM
    {
        public int? Id { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set;}

        [Required(ErrorMessage = "Category Name Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Code is required")]
        [StringLength(7, ErrorMessage = "Code length should 7 charecter")]
        public string Code { get; set; }
        public string PrevName { get; set; }
        public string PrevCode { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public List<ItemCategory> CategoryList { get; set; }
        public List<SelectListItem> CategoryDropDown { get; set; }
    }
}
