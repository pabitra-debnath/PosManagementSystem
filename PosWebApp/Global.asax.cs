using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using POS.Models.Operation;
using POS.Models.Setup;
using POS.Models.ViewModel;

namespace PosWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ItemCategory, ItemCategoryVM>();
                cfg.CreateMap<ItemCategoryVM, ItemCategory>();

                cfg.CreateMap<ExpenseCategory, ExpenseCategoryVM>();
                cfg.CreateMap<ExpenseCategoryVM, ExpenseCategory>();

                cfg.CreateMap<Item, ItemVM>();
                cfg.CreateMap<ItemVM, Item>();

                cfg.CreateMap<ExpenseItem, ExpenseItemVM>();
                cfg.CreateMap<ExpenseItemVM, ExpenseItem>();

                cfg.CreateMap<Organization, OrganizationVM>();
                cfg.CreateMap<OrganizationVM, Organization>();

                cfg.CreateMap<Branch, BranchVM>();
                cfg.CreateMap<BranchVM, Branch>();

                cfg.CreateMap<Party, PartyVM>();
                cfg.CreateMap<PartyVM, Party>();

                cfg.CreateMap<Employee, EmployeeVM>();
                cfg.CreateMap<EmployeeVM, Employee>();

                cfg.CreateMap<PurchaseOperation, PurchaseOperationVM>();
                cfg.CreateMap<PurchaseOperationVM, PurchaseOperation>();

                cfg.CreateMap<PurchaseOperationInfo, PurchaseOperationInfoVM>();
                cfg.CreateMap<PurchaseOperationInfoVM, PurchaseOperationInfo>();


                cfg.CreateMap<ExpenseOperationInfo, ExpenseOperationInfoVM>();
                cfg.CreateMap<ExpenseOperationInfoVM, ExpenseOperationInfo>();

                cfg.CreateMap<ExpenseOperation, ExpenseOperationVM>();
                cfg.CreateMap<ExpenseOperationVM, ExpenseOperation>();

                cfg.CreateMap<SalesOperation, SalesOperationVM>();
                cfg.CreateMap<SalesOperationVM, SalesOperation>();

                cfg.CreateMap<SalesOperationInfo, SalesOperationInfoVM>();
                cfg.CreateMap<SalesOperationInfoVM, SalesOperationInfo>();
            });
        }
    }
}
