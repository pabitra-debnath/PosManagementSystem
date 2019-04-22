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
    public class ItemManager
    {
        ItemGetway _itemGetway = new ItemGetway();

        public bool IsItemSaved(Item item)
        {
            return _itemGetway.IsItemSaved(item);
        }

        public IEnumerable<SelectListItem> GetItemSelectList()
        {
            return _itemGetway.GetItemSelectList();
        }
        public List<Item> GetItemList()
        {
            return _itemGetway.GetItemList();
        }

        public Item FindItem(long? id)
        {
            return _itemGetway.FindItem(id);
        }

        public string GetItemCategoryCode(long id)
        {
            return _itemGetway.GetItemCategoryCode(id);
        }

        public string GetItemCode(long id)
        {
            return _itemGetway.GetItemCode(id);
        }

        public bool IsItemUpdated(Item item)
        {
            return _itemGetway.IsItemUpdated(item);
        }

        public bool IsItemDeleted(long id)
        {
            if (id >0)
            {
                return _itemGetway.IsItemDeleted(id);
            }

            return false;
        }

        public bool IsUniqueName(string name, string initialName)
        {
            if (initialName == name)
            {
                return true;
            }
            return _itemGetway.IsUniqueName(name);
        }

        public bool IsUniqueCode(string preCode, string code, string initialPreCode, string initialCode)
        {
            if ((initialPreCode + initialCode) == (preCode + code))
            {
                return true;
            }
            return _itemGetway.IsUniqueCode(preCode, code);
        }
    }
}
