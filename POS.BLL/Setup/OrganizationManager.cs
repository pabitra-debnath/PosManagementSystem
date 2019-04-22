using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using POS.DAL.Setup;
using POS.Models.Setup;

namespace POS.BLL.Setup
{
    public class OrganizationManager
    {
        OrganizationGetway _organizationGetway = new OrganizationGetway();
        public bool Add(Organization organization)
        {
            if (organization == null)
            {
                throw new Exception("Insert Organization information");
            }
            if (organization.Name == null || organization.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter");
            }
            if (_organizationGetway.GetByName(organization).Count > 0)
            {
                throw new Exception("Name should be unique");
            }
            if (organization.Code == null || organization.Code.Length != 7)
            {
                throw new Exception("Code length should be 7 charecter");
            }
            if (_organizationGetway.GetByCode(organization).Count > 0)
            {
                throw new Exception("Code should be unique");
            }
            if (organization.ContactNo == null || organization.ContactNo.Length != 11)
            {
                throw new Exception("Contact no should be 11 digit");
            }
            if (_organizationGetway.GetByContactNo(organization).Count > 0)
            {
                throw new Exception("Contact no should be unique");
            }
            return _organizationGetway.Add(organization);
        }

        public bool Update(Organization organization, string prevName, string prevCode, string prevContactNo)
        {
            if (organization == null)
            {
                throw new Exception("Insert Organization information");
            }
            if (organization.Name == null || organization.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter");
            }
            if (organization.Name != prevName)
            {
                if (_organizationGetway.GetByName(organization).Count > 0)
                {
                    throw new Exception("Name should be unique");
                }
            }
            if (organization.Code == null || organization.Code.Length != 7)
            {
                throw new Exception("Code length should be 7 charecter");
            }
            if (organization.Code != prevCode)
            {
                if (_organizationGetway.GetByCode(organization).Count > 0)
                {
                    throw new Exception("Code should be unique");
                }
            }
            if (organization.ContactNo == null || organization.ContactNo.Length != 11)
            {
                throw new Exception("Contact no should be 11 digit");
            }
            if (organization.ContactNo != prevContactNo)
            {
                if (_organizationGetway.GetByContactNo(organization).Count > 0)
                {
                    throw new Exception("Contact no should be unique");
                }
            }
            return _organizationGetway.Update(organization);
        }

        public bool Delete(int organizationId)
        {
            return _organizationGetway.Delete(organizationId);
        }

        public Organization GetById(int categoryId)
        {
            return _organizationGetway.GetById(categoryId);
        }
        public List<Organization> GetAll()
        {
            return _organizationGetway.GetAll();
        }

        public string GenerateCode(string name)
        {
            string part1 = name.Substring(0, 3).ToUpper();
            string part2 = (_organizationGetway.GetAll().Count + 1).ToString("D3");
            return part1 + "#" + part2;
        }
    }
}
