using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;
using POS.DAL.Setup;
namespace POS.BLL.Setup
{
    public class ItemCategoryManager
    {
        ItemCategoryGetway _itemCategoryGetway = new ItemCategoryGetway();

        //Add new Item category
        public bool Add(ItemCategory category)
        {

            if (category == null)
            {
                throw new Exception("Insert Category Information");
            }
            if (category.Name == null || category.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter!");
            }
            if (_itemCategoryGetway.GetByName(category.Name).Count > 0)
            {
                throw new Exception("Name should be Unique!");
            }
            if (string.IsNullOrEmpty(category.Code) || category.Code.Length != 7)
            {
                throw new Exception("Category code should be 7 charecter!");
            }
            if (_itemCategoryGetway.GetByCode(category.Code).Count > 0)
            {
                throw new Exception("Code should be Unique!");
            }

            return _itemCategoryGetway.Add(category);
        }//--------------------------------------------------------------------------------------

        public bool Update(ItemCategory category, string prevName, string prevCode)
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
                if (_itemCategoryGetway.GetByName(category.Name).Count > 0)
                {
                    throw new Exception("Name should be Unique!");
                }
            }
            if (category.Code != prevCode)
            {
                if (_itemCategoryGetway.GetByCode(category.Code).Count > 0)
                {
                    throw new Exception("Code should be Unique!");
                }
            }
            return _itemCategoryGetway.Update(category);
        } //-------------------------------------------------------------------------------------

        //Delete item category
        public bool Delete(int categoryId)
        {
            return _itemCategoryGetway.Delete(categoryId);
        }
        public List<ItemCategory> GetAll()
        {
            return _itemCategoryGetway.GetAll();
        }

        public List<ItemCategory> GetById(int id)
        {
            return _itemCategoryGetway.GetById(id).ToList();
        }

        //Auto generate category code
        public string GenerateCode(string name)
        {
            string part1 = name.Substring(0, 3).ToUpper();
            string part2 = (_itemCategoryGetway.GetAll().Count + 1).ToString("D3");
            return part1 + "#" + part2;
        } //-----------------------------------------------------------------------------------
        
    }
}
