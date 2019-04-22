using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.BLL.Setup;
using POS.Models.Setup;

namespace PosTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExpenseCategoryManager catMan = new ExpenseCategoryManager();
            ////save section
            //ExpenseCategory expenseCategory = new ExpenseCategory()
            //{
            //    Name = "Salary",
            //    Description = "this is expense category"
            //};
            //expenseCategory.Code = catMan.GenerateCode(expenseCategory);
            //if (catMan.Add(expenseCategory))
            //{
            //    Console.WriteLine("Save success!");
            //}
            //else
            //{
            //    Console.WriteLine("Failed!");
            //}

            ////update section
            //var expenseCategory = catMan.GetById(1);
            //string prevName = expenseCategory.Name;
            //string prevCode = expenseCategory.Code;
            //expenseCategory.Name = "updatedName";
            //expenseCategory.Description = "category updated!";
            //if (catMan.Update(expenseCategory, prevName, prevCode))
            //{
            //    Console.WriteLine("Update succes!");
            //}
            //else
            //{
            //    Console.WriteLine("Failed!");
            //}

            ////Delete section
            //if (catMan.Delete(1))
            //{
            //    Console.WriteLine("Delete success!");
            //}
            //else
            //{
            //    Console.WriteLine("Failed!");
            //}
            Console.ReadKey();
        }
    }
}
