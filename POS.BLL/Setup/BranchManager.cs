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
    public class BranchManager
    {
        BranchGetway _branchDal = new BranchGetway();

        public bool IsBranchSaved(Branch branch)
        {
            return _branchDal.IsBranchSaved(branch);
        }

        public IEnumerable<SelectListItem> GetBranchSelectList()
        {
            return _branchDal.GetBranchSelectList();
        }

        public List<Branch> GetBranchList()
        {
            return _branchDal.GetBranchList();
        }

        public List<Branch> GetByOrgId(int orgId)
        {
            return _branchDal.GetByOrgId(orgId);
        }
        public string GetBranchCode()
        {
            return _branchDal.GetBranchCode();
        }



        public Branch FindBranch(long? id)
        {
            return _branchDal.FindBranch(id);
        }

        public bool IsBranchUpdated(Branch branch)
        {
            return _branchDal.IsBranchUpdated(branch);
        }

        public bool IsBranchDeleted(long id)
        {

            return _branchDal.IsBranchDeleted(id);

        }

        public bool IsUniqueCode(string code, string initialCode)
        {
            if (initialCode == code)
            {
                return true;
            }
            return _branchDal.IsUniqueCode(code);
        }
    }
}
