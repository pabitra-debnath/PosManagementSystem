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
    public class BranchGetway
    {
        PosDbContext dbContext = new PosDbContext();
        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            var list = dbContext.Organizations.ToList();

            var selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "---Select---", Value = "", Selected = true }
            };

            selectList.AddRange(list.Select(li => new SelectListItem { Text = li.Name, Value = li.Id.ToString() }));

            return selectList;
        }
        public List<Branch> GetBranchList()
        {
            var list = dbContext.Branches.OrderByDescending(c=>c.Id).ToList();
            return list;
        }
        public string GetBranchCode()
        {
            long code;

            if (dbContext.Branches.ToList().Count > 0)
            {
                code = Convert.ToInt64(dbContext.Branches.Select(x => x.Code).Max());

                if (code >= 999)
                {
                    var allNumbers = Enumerable.Range(1, 999).Select(y => (long)y);
                    var currentList = ((IEnumerable<string>)dbContext.Branches.Select(x => x.Code))
                        .Select(x => Convert.ToInt64(x));
                    var missingNumbersFirst = allNumbers.Except(currentList).First();
                    code = missingNumbersFirst - 1;
                }
            }
            else
            {
                code = 0;
            }

            return string.Format("{0:000}", (code + 1));
        }
        public bool IsBranchSaved(Branch branch)
        {


            dbContext.Branches.Add(branch);
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



        public Branch FindBranch(long? id)
        {
            var branch = dbContext.Branches.Find(id);
            var itemOrganization = dbContext.Organizations.Find(branch.OrganizationId);
            Branch branchh = null;

            if (branch != null)
            {
                branchh = branch;
            }

            return branchh;
        }

        public bool IsBranchUpdated(Branch branch)
        {

            dbContext.Entry(branch).State = EntityState.Modified;
            var isUpdated = dbContext.SaveChanges() > 0;

            return isUpdated;
        }

        public bool IsBranchDeleted(long id)
        {

            Branch branch = dbContext.Branches.Find(id);
            if (branch != null)
            {
                dbContext.Branches.Remove(branch);
                var isDeleted = dbContext.SaveChanges() > 0;
                return isDeleted;
            }

            return false;

        }

        public bool IsUniqueCode(string code)
        {
            return !dbContext.Branches.Any(x => x.Code == code);
        }

        public List<Branch> GetByOrgId(int orgId)
        {
            var branchs = dbContext.Branches.Where(c => c.OrganizationId == orgId).ToList();
            return branchs;
        }
    }
}
