using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class OrganizationGetway
    {
        PosDbContext _organizationDb = new PosDbContext();
        public bool Add(Organization organization)
        {
            _organizationDb.Organizations.Add(organization);
            return _organizationDb.SaveChanges() > 0;
        }

        public bool Update(Organization organization)
        {
            PosDbContext db = new PosDbContext();
            db.Organizations.Attach(organization);
            db.Entry(organization).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var organization = _organizationDb.Organizations.FirstOrDefault(c => c.Id == id);
            if (organization!=null)
            {
                _organizationDb.Organizations.Remove(organization);
            }
            return _organizationDb.SaveChanges() > 0;
        }

        public Organization GetById(int categoryId)
        {
            return  _organizationDb.Organizations.FirstOrDefault(c => c.Id == categoryId);
        }
        public List<Organization> GetByName(Organization organization)
        {
            return _organizationDb.Organizations.Where(c => c.Name == organization.Name).ToList();
        }

        public List<Organization> GetByCode(Organization organization)
        {
            return _organizationDb.Organizations.Where(c => c.Code == organization.Code).ToList();
        }

        public List<Organization> GetByContactNo(Organization organization)
        {
            return _organizationDb.Organizations.Where(c => c.ContactNo == organization.ContactNo).ToList();
        }

        public List<Organization> GetAll()
        {
            return _organizationDb.Organizations.OrderByDescending(c=>c.Id).ToList();
        }

    }
}
