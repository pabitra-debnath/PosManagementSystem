using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class ItemCategoryGetway
    {
        PosDbContext _itemCategoryDb = new PosDbContext();

        public bool Add(ItemCategory category)
        {
            _itemCategoryDb.ItemCategories.Add(category);
            return _itemCategoryDb.SaveChanges() > 0;
        }

        public bool Update(ItemCategory category)
        {
            PosDbContext db = new PosDbContext();
            db.ItemCategories.Attach(category);
            db.Entry(category).State = EntityState.Modified;
            bool isUpdate = db.SaveChanges() > 0;
            return isUpdate;
        }

        public bool Delete(int categoryId)
        {
            var category = _itemCategoryDb.ItemCategories.FirstOrDefault(c => c.Id == categoryId);
            if (category != null)
            {
                _itemCategoryDb.ItemCategories.Remove(category);
            }
            return _itemCategoryDb.SaveChanges() > 0;
        }

        public List<ItemCategory> GetById(int id)
        {
            var category = _itemCategoryDb.ItemCategories.Where(c => c.Id == id).ToList();
            return category;
        }
        public List<ItemCategory> GetByName(string name)
        {
            var categoryList = _itemCategoryDb.ItemCategories.Where(c => c.Name == name).ToList();
            return categoryList;
        }
        public List<ItemCategory> GetByCode(string code)
        {
            var categoryList = _itemCategoryDb.ItemCategories.Where(c => c.Code == code).ToList();
            return categoryList;
        }

        public List<ItemCategory> GetAll()
        {
            var categoryList = _itemCategoryDb.ItemCategories.OrderByDescending(c=>c.Id).ToList();
            return categoryList;
        }
        
    }
}
