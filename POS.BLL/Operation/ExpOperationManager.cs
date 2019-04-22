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
    public class ExpOperationManager
    {
        ExpOperationGetway _expenseDal = new ExpOperationGetway();
        public IEnumerable<SelectListItem> GetExpenseItemSelectList()
        {
            return _expenseDal.GetExpenseItemSelectList();
        }

        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _expenseDal.GetBranchSelectList();
        }

        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            return _expenseDal.GetEmployeeSelectList();
        }

        public List<Employee> GetEmployeeList(long branchId)
        {
            return _expenseDal.GetEmployeeList(branchId);
        }

        public string GetExpenseNo()
        {
            return _expenseDal.GetExpenseNo();
        }

        public bool IsExpenseOperationSuccess(ExpenseOperationInfo exoi)
        {
            return _expenseDal.IsExpenseOperationSuccess(exoi);
        }

        public ExpenseOperationInfo GetExpenseOpInfo(string expenseNo)
        {
            return _expenseDal.GetExpenseOpInfo(expenseNo);
        }

        public ExpenseOperationInfo GetExpenseOpInfo(long id)
        {
            return _expenseDal.GetExpenseOpInfo(id);
        }

        public IEnumerable<ExpenseOperationInfo> GetExpenseOpInfoList()
        {
            return _expenseDal.GetExpenseOpInfoList();
        }

        public IEnumerable<ExpenseOperationInfo> GetExpenseOpInfoList(long branchId, DateTime fromDate,
            DateTime toDate)
        {
            return _expenseDal.GetExpenseOpInfoList(branchId, fromDate, toDate);
        }
    }
}
