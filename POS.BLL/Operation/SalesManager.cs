using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.DAL.Operation;
using POS.Models.Operation;
using POS.Models.Setup;

namespace POS.BLL.Operation
{
    public class SalesManager
    {
        SalesGetway _salesDal = new SalesGetway();
        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            return _salesDal.GetItemSelectList();
        }

        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _salesDal.GetBranchSelectList();
        }

        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            return _salesDal.GetEmployeeSelectList();
        }

        public List<Employee> GetEmployeeList(long branchId)
        {
            return _salesDal.GetEmployeeList(branchId);
        }

        public List<Item> GetStockItemList(long branchId)
        {
            return _salesDal.GetStockItemList(branchId);
        }

        public string GetSalesNo()
        {
            return _salesDal.GetSalesNo();
        }

        public bool IsSalesOperationSuccess(SalesOperationInfo soi)
        {
            return _salesDal.IsSalesOperationSuccess(soi);
        }

        public bool IsStockUpdated(List<SalesOperation> items, long branchId)
        {
            return _salesDal.IsStockUpdated(items, branchId);
        }

        public object GetItemStatus(long branchId, long itemId)
        {
            return _salesDal.GetItemStatus(branchId, itemId);
        }

        public SalesOperationInfo GetSalesOpInfo(string salesNo)
        {
            return _salesDal.GetSalesOpInfo(salesNo);
        }

        public SalesOperationInfo GetSalesOpInfo(long id)
        {
            return _salesDal.GetSalesOpInfo(id);
        }

        public IEnumerable<SalesOperationInfo> GetSalesOpInfoList()
        {
            return _salesDal.GetSalesOpInfoList();
        }

        public IEnumerable<SalesOperationInfo> GetSalesOpInfoList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _salesDal.GetSalesOpInfoList(branchId, fromDate, toDate);
        }
    }
}
