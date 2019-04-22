using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class ExpenseCategoryGetway
    {
        PosDbContext _expenseCategoryDb = new PosDbContext();

        public bool Add(ExpenseCategory category)
        {
            _expenseCategoryDb.ExpenseCategories.Add(category);
            if (_expenseCategoryDb.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool Update(ExpenseCategory category)
        {
            PosDbContext db = new PosDbContext();
            db.ExpenseCategories.Attach(category);
            db.Entry(category).State = EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Delete(int categoryId)
        {
            var category = _expenseCategoryDb.ExpenseCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _expenseCategoryDb.ExpenseCategories.Remove(category);
            }
            return _expenseCategoryDb.SaveChanges() > 0;
        }

        public ExpenseCategory GetById(int id)
        {
            var category = _expenseCategoryDb.ExpenseCategories.FirstOrDefault(c => c.Id == id);
            return category;
        }
        public List<ExpenseCategory> GetByName(string name)
        {
            var categoryList = _expenseCategoryDb.ExpenseCategories.Where(c => c.Name == name).ToList();
            return categoryList;
        }
        public List<ExpenseCategory> GetByCode(string code)
        {
            var categoryList = _expenseCategoryDb.ExpenseCategories.Where(c => c.Code == code).ToList();
            return categoryList;
        }

        public List<ExpenseCategory> GetAll()
        {
            var categoryList = _expenseCategoryDb.ExpenseCategories.OrderByDescending(c=>c.Id).ToList();
            return categoryList;
        }
    }
}
