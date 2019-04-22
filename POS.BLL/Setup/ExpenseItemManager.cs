using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.DAL.Setup;
using POS.Models.Setup;

namespace POS.BLL.Setup
{
    public class ExpenseItemManager
    {
        ExpenseItemGetway _expenseItemDal = new ExpenseItemGetway();

        public IEnumerable<SelectListItem> GetExpenseItemSelectList()
        {
            return _expenseItemDal.GetExpenseItemSelectList();
        }

        public List<ExpenseItem> GetExpenseItemList()
        {
            return _expenseItemDal.GetExpenseItemList();
        }

        public bool IsExpenseItemSaved(ExpenseItem expenseItem)
        {
            return _expenseItemDal.IsExpenseItemSaved(expenseItem);
        }

        public string GetExpenseCategoryCode(long id)
        {
            return _expenseItemDal.GetExpenseCategoryCode(id);
        }

        public string GetExpenseItemCode(long id)
        {
            return _expenseItemDal.GetExpenseItemCode(id);
        }

        public ExpenseItem FindExpenseItem(long? id)
        {
            return _expenseItemDal.FindExpenseItem(id);
        }

        public bool IsExpenseItemUpdated(ExpenseItem expenseItem)
        {
            return _expenseItemDal.IsExpenseItemUpdated(expenseItem);
        }

        public bool IsExpenseItemDeleted(long id)
        {
            return _expenseItemDal.IsExpenseItemDeleted(id);
        }
        public bool IsUniqueName(string name, string initialName)
        {
            if (initialName == name)
            {
                return true;
            }
            return _expenseItemDal.IsUniqueName(name);
        }

        public bool IsUniqueCode(string preCode, string code, string initialPreCode, string initialCode)
        {
            if ((initialPreCode + initialCode) == (preCode + code))
            {
                return true;
            }
            return _expenseItemDal.IsUniqueCode(preCode, code);
        }
    }
}
