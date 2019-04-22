using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Models.Setup;

namespace POS.DAL.Setup
{
    public class EmployeeGetway
    {
        PosDbContext _employeeDb = new PosDbContext();
        public bool Add(Employee employee)
        {
            _employeeDb.Employees.Add(employee);
            return _employeeDb.SaveChanges() > 0;
        }

        public bool Delete(int employeeId)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee != null)
            {
                _employeeDb.Employees.Remove(employee);
            }
            return _employeeDb.SaveChanges() > 0;
        }

        public bool Update(Employee employee)
        {
            PosDbContext db = new PosDbContext();
            db.Employees.Attach(employee);
            db.Entry(employee).State=EntityState.Modified;
            return db.SaveChanges() > 0;
        }

        public Employee GetById(int employeeId)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.Id == employeeId);
            return employee;
        }
        public Employee GetByName(string name)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.Name == name);
            return employee;
        }

        public Employee GetByCode(string code)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.Code == code);
            return employee;
        }

        public Employee GetByContactNo(string contactNo)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.ContactNo == contactNo);
            return employee;
        }

        public Employee GetByEmail(string email)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.Email == email);
            return employee;
        }
        public Employee GetByNID(string nid)
        {
            var employee = _employeeDb.Employees.FirstOrDefault(e => e.NID == nid);
            return employee;
        }

        public List<Employee> GetAll()
        {
            var employee = _employeeDb.Employees.OrderByDescending(c=>c.Id).ToList();
            return employee;
        }
    }
}
