using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DAL.Setup;
using POS.Models.Setup;

namespace POS.BLL.Setup
{
    public class ExpenseCategoryManager
    {
        ExpenseCategoryGetway _expenseCatagoryGetway = new ExpenseCategoryGetway();
        public bool Add(ExpenseCategory category)
        {

            if (category == null)
            {
                throw new Exception("Insert Category Information");
            }
            if (category.Name == null || category.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter!");
            }
            if (_expenseCatagoryGetway.GetByName(category.Name).Count > 0)
            {
                throw new Exception("Name should be Unique!");
            }
            if (string.IsNullOrEmpty(category.Code) || category.Code.Length != 7)
            {
                throw new Exception("Category code should be 7 charecter!");
            }
            if (_expenseCatagoryGetway.GetByCode(category.Code).Count > 0)
            {
                throw new Exception("Code should be Unique!");
            }

            return _expenseCatagoryGetway.Add(category);
        }
        public bool Update(ExpenseCategory category, string prevName, string prevCode)
        //save previous name and code in a temporary variable to check unique!
        {
            if (category == null)
            {
                throw new Exception("Insert Category Information");
            }
            if (category.Name == null || category.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter!");
            }
            if (string.IsNullOrEmpty(category.Code) || category.Code.Length != 7)
            {
                throw new Exception("Category code should be 7 charecter!");
            }
            if (category.Name != prevName)
            {
                if (_expenseCatagoryGetway.GetByName(category.Name).Count > 0)
                {
                    throw new Exception("Name should be Unique!");
                }
            }
            if (category.Code != prevCode)
            {
                if (_expenseCatagoryGetway.GetByCode(category.Code).Count > 0)
                {
                    throw new Exception("Code should be Unique!");
                }
            }
            return _expenseCatagoryGetway.Update(category);
        }

        public bool Delete(int categoryId)
        {
            return _expenseCatagoryGetway.Delete(categoryId);
        }
        public List<ExpenseCategory> GetAll()
        {
            return _expenseCatagoryGetway.GetAll();
        }

        public ExpenseCategory GetById(int id)
        {
            return _expenseCatagoryGetway.GetById(id);
        }

        //Auto generate category code!
        public string GenerateCode(string name)
        {
            string part1 = name.Substring(0, 3).ToUpper();
            string part2 = (_expenseCatagoryGetway.GetAll().Count + 1).ToString("D3");
            return part1 + "#" + part2;
        }
    }
}
