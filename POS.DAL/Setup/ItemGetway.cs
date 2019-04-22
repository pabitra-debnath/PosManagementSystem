using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class ItemGetway
    {
        PosDbContext dbContext = new PosDbContext();
        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            var list = dbContext.ItemCategories.Select(x => x).Distinct().ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Item> GetItemList()
        {
            var list = dbContext.Items.OrderByDescending(c=>c.Id).ToList();
            return list;
        }

        public bool IsItemSaved(Item item)
        {
            dbContext.Items.Add(item);
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

        internal string GetItemCategoryCode()
        {
            throw new NotImplementedException();
        }

        public string GetItemCategoryCode(long id)
        {
            var code = dbContext.ItemCategories.Where(x => x.Id == id).Select(x => x.Code).FirstOrDefault();
            return code;
        }

        public string GetItemCode(long id)
        {
            long code;
            string preCode = GetItemCategoryCode(id);

            if (dbContext.Items.Where(x => x.PreCode == preCode).ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Items.Where(x => x.PreCode == preCode).Select(x => x.Code).Max());

                if (code >= 999999)
                {
                    var allNumbers = Enumerable.Range(1, 999999).Select(y => (long)y);
                    var currentList = ((IEnumerable<string>)dbContext.Items.Where(x => x.PreCode == preCode).Select(x => x.Code))
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

        public Item FindItem(long? id)
        {
            var item = dbContext.Items.Find(id);
            var itemCategory = dbContext.ItemCategories.Find(item.CategoryId);
            Item itemm = null;

            if (item != null)
            {
                itemm = item;
            }

            return itemm;
        }
        public bool IsUniqueName(string name)
        {
            return !dbContext.Items.Any(x => x.Name == name);
        }

        public bool IsUniqueCode(string preCode, string code)
        {
            return !dbContext.Items.Any(x => x.Code == code && x.PreCode == preCode);
        }
        public bool IsItemUpdated(Item item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            var isUpdated = dbContext.SaveChanges() > 0;

            return isUpdated;
        }

        public bool IsItemDeleted(long id)
        {
            Item item = dbContext.Items.Find(id);
            if (item != null)
            {
                dbContext.Items.Remove(item);
            }
            var isDeleted = dbContext.SaveChanges() > 0;
            return isDeleted;
            
        }
    }
}
