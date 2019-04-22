using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class ExpenseItemGetway
    {
            PosDbContext dbContext = new PosDbContext();
            public IEnumerable<SelectListItem> GetExpenseItemSelectList()
            {
                var list = dbContext.ExpenseCategories.Select(x => x).Distinct().ToList();

                var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

                selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

                return selectList;
            }
            public List<ExpenseItem> GetExpenseItemList()
            {
                var list = dbContext.ExpenseItems.OrderByDescending(c=>c.Id).ToList();
                return list;
            }
            public bool IsExpenseItemSaved(ExpenseItem expenseItem)
            {


                dbContext.ExpenseItems.Add(expenseItem);
                var isAdded = dbContext.SaveChanges();

                if (isAdded > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
        
            public string GetExpenseCategoryCode(long id)
            {
                var code = dbContext.ExpenseCategories.Where(x => x.Id == id).Select(x => x.Code).FirstOrDefault();
                return code;
            }

            public string GetExpenseItemCode(long id)
            {
                long code;
                string preCode = GetExpenseCategoryCode(id);

                if (dbContext.ExpenseItems.Where(x => x.PreCode == preCode).ToList().Count > 0)
                {
                    code = Convert.ToInt64(dbContext.ExpenseItems.Where(x => x.PreCode == preCode).Select(x => x.Code).Max());

                    if (code >= 999999)
                    {
                        var allNumbers = Enumerable.Range(1, 999999).Select(y => (long)y);
                        var currentList = ((IEnumerable<string>)dbContext.ExpenseItems.Where(x => x.PreCode == preCode).Select(x => x.Code))
                            .Select(x => Convert.ToInt64(x));
                        var missingNumbersFirst = allNumbers.Except(currentList).First();
                        code = missingNumbersFirst - 1;
                    }
                }
                else
                {
                    code = 0;
                }

                return string.Format("{0:000000}", (code + 1));
            }

            public ExpenseItem FindExpenseItem(long? id)
            {
                var expenseItem = dbContext.ExpenseItems.Find(id);
                var itemCategory = dbContext.ExpenseCategories.Find(expenseItem.CategoryId);
                ExpenseItem expenseItemm = null;

                if (expenseItem != null)
                {
                    expenseItemm = expenseItem;
                }

                return expenseItemm;
            }

            public bool IsExpenseItemUpdated(ExpenseItem expenseItem)
            {

                dbContext.Entry(expenseItem).State = EntityState.Modified;
                var isUpdated = dbContext.SaveChanges() > 0;

                return isUpdated;
            }

            public bool IsExpenseItemDeleted(long id)
            {
                ExpenseItem item = dbContext.ExpenseItems.Find(id);
                if (item != null)
                {
                    dbContext.ExpenseItems.Remove(item);
                    var isDeleted = dbContext.SaveChanges() > 0;
                    return isDeleted;
                }

                return false;
            }

            public bool IsUniqueName(string name)
            {
                return !dbContext.ExpenseItems.Any(x => x.Name == name);
            }

            public bool IsUniqueCode(string preCode, string code)
            {
                return !dbContext.ExpenseItems.Any(x => x.Code == code && x.PreCode == preCode);
            }
    }
}
