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
    public class PurchaseManager
    {
        PurchaseGetway _purchase = new PurchaseGetway();
        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            return _purchase.GetItemSelectList();
        }

        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _purchase.GetBranchSelectList();
        }

        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            return _purchase.GetEmployeeSelectList();
        }

        public IEnumerable<SelectListItem> GetSupplierSelectList()
        {
            return _purchase.GetSupplierSelectList();
        }

        public List<Employee> GetEmployeeList(long branchId)
        {
            return _purchase.GetEmployeeList(branchId);
        }

        public bool IsPurchaseOperationSuccess(PurchaseOperationInfo poi)
        {
            return _purchase.IsPurchaseOperationSuccess(poi);
        }

        public bool IsStockUpdated(List<PurchaseOperation> items, long branchId)
        {
            return _purchase.IsStockUpdated(items, branchId);
        }

        public Item GetItem(long id)
        {
            return _purchase.GetItem(id);
        }

        public string GetPurchaseNo()
        {
            return _purchase.GetPurchaseNo();
        }

        public PurchaseOperationInfo GetPurchaseOpInfo(string purchaseNo)
        {
            return _purchase.GetPurchaseOpInfo(purchaseNo);
        }

        public PurchaseOperationInfo GetPurchaseOpInfo(long id)
        {
            return _purchase.GetPurchaseOpInfo(id);
        }

        public IEnumerable<PurchaseOperationInfo> GetPurchaseOpInfoList()
        {
            return _purchase.GetPurchaseOpInfoList();
        }

        public IEnumerable<PurchaseOperationInfo> GetPurchaseOpInfoList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _purchase.GetPurchaseOpInfoList(branchId, fromDate, toDate);
        }
    }
}
