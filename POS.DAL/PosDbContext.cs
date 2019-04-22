using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Operation;
using POS.Models.Setup;

namespace POS.DAL
{
    public class PosDbContext:DbContext
    {
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ExpenseItem> ExpenseItems { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<PurchaseOperationInfo> PurchaseOperationInformations { get; set; }
        public DbSet<PurchaseOperation> PurchaseOperationItems { get; set; }

        public DbSet<ExpenseOperationInfo> ExpenseOperationInformations { get; set; }
        public DbSet<ExpenseOperation> ExpenseOperationItems { get; set; }

        public DbSet<SalesOperationInfo> SalesOperationInformations { get; set; }
        public DbSet<SalesOperation> SalesOperationItems { get; set; }

        public DbSet<Stock> Stocks { get; set; }
    }
}
