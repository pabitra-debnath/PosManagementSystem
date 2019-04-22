using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Operation;

namespace POS.Models.ViewModel
{
    public class StockReportVM
    {
        public IEnumerable<SelectListItem> SelectListBranch { get; set; }
        public IEnumerable<Stock> StockList { get; set; }
    }
}
