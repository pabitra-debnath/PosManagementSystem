using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Operation;
using POS.Models.Setup;

namespace POS.DAL.Operation
{
    public class ExpOperationGetway
    {
        PosDbContext dbContext = new PosDbContext();
        public IEnumerable<SelectListItem> GetExpenseItemSelectList()
        {
            var list = dbContext.ExpenseItems.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Code + " - " + li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            var list = dbContext.Branches.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Address, Value = li.Id.ToString() }));

            return selectList;
        }
        public IEnumerable<SelectListItem> GetEmployeeSelectList()
        {
            var list = dbContext.Employees.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Employee> GetEmployeeList(long branchId)
        {
            var employeeList = dbContext.Employees.Where(x => x.BranchId == branchId).ToList();
            return employeeList;
        }

        public string GetExpenseNo()
        {
            long expenseNo;

            if (dbContext.ExpenseOperationInformations.ToList().Count > 0)
            {
                expenseNo = Convert.ToInt64(dbContext.ExpenseOperationInformations.Select(x => x.ExpenseNo).Max());
            }
            else
            {
                expenseNo = 0;
            }

            return string.Format("{0:0000000}", (expenseNo + 1));
        }

        public bool IsExpenseOperationSuccess(ExpenseOperationInfo exoi)
        {


            dbContext.ExpenseOperationInformations.Add(exoi);
            var isSuccess = dbContext.SaveChanges() > 0;

            return isSuccess;
        }

        public ExpenseOperationInfo GetExpenseOpInfo(string expenseNo)
        {
            ExpenseOperationInfo item = dbContext.ExpenseOperationInformations.Where(x => x.ExpenseNo == expenseNo).Include(x => x.ExpenseItems).FirstOrDefault();
            return item;
        }

        public ExpenseOperationInfo GetExpenseOpInfo(long id)
        {
            ExpenseOperationInfo item = dbContext.ExpenseOperationInformations.Where(x => x.Id == id).Include(x => x.ExpenseItems).FirstOrDefault();

            return item;
        }

        public IEnumerable<ExpenseOperationInfo> GetExpenseOpInfoList()
        {
            var items = dbContext.ExpenseOperationInformations.Include(x => x.ExpenseItems);
            return items;
        }
        public IEnumerable<ExpenseOperationInfo> GetExpenseOpInfoList(long branchId, DateTime fromDate, DateTime toDate)
        {
            var items = dbContext.ExpenseOperationInformations
                .Where(x => x.BranchId == branchId && x.ExpenseDate >= fromDate && x.ExpenseDate <= toDate)
                .Include(x => x.ExpenseItems);
            return items;
        }
    }
}
