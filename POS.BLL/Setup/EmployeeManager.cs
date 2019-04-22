using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.DAL.Setup;
using POS.Models.Setup;

namespace POS.BLL.Setup
{
    public class EmployeeManager
    {
        EmployeeGetway _employeeGetway = new EmployeeGetway();

        //Add new employee
        public bool Add(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.Name) || employee.Name.Length < 3)
            {
                throw new Exception("Name should be at least 3 charecter");
            }
            
            if (string.IsNullOrEmpty(employee.Code))
            {
                throw new Exception("Code shoud be 7 charecter");
            }
            if (_employeeGetway.GetByCode(employee.Code) != null)
            {
                throw new Exception("Code should be unique");
            }
            //if (employee.BranchId < 1)
            //{
            //    throw new Exception("Branch is required");
            //}
            if (string.IsNullOrEmpty(employee.ContactNo) || employee.ContactNo.Length != 11)
            {
                throw new Exception("Contact no should be 11 digit");
            }
            if (_employeeGetway.GetByContactNo(employee.ContactNo) != null)
            {
                throw new Exception("Contact No should be unique");
            }
            if (_employeeGetway.GetByEmail(employee.Email) != null)
            {
                throw new Exception("Email should be unique");
            }
            if (string.IsNullOrEmpty(employee.NID) || (employee.NID.Length != 13 && employee.NID.Length != 17))
            {
                throw new Exception("NID should be 13 or 17 digit");
            }
            if (_employeeGetway.GetByNID(employee.NID) != null)
            {
                throw new Exception("NID should be unique");
            }

            return _employeeGetway.Add(employee);
        }
        //---------------------------------------------------------------

        //Generate employee code
        public string GetCode(string name)
        {
            string part1 = name.Substring(0, 3).ToUpper();
            string part2 = DateTime.Now.ToString("yyyyMMdd");
            return "EMP-" + part1 + "-" + part2;
        }
        //----------------------------------------------------------------

        //Get all employee
        public List<Employee> GetAll()
        {
            return _employeeGetway.GetAll();
        }
        //--------------------------------------------------------

        //Get A employee by id
        public Employee GetById(int employeeId)
        {
            return _employeeGetway.GetById(employeeId);
        }

        public bool Delete(int employeeId)
        {
            return _employeeGetway.Delete(employeeId);
        }

        public bool Update(Employee employee)
        {
            if (employee.Code != employee.PrevCode)
            {
                if (_employeeGetway.GetByCode(employee.Code) != null)
                {
                    throw new Exception("Code should be unique");
                }
            }
            if (employee.ContactNo != employee.PrevContact)
            {
                if (_employeeGetway.GetByContactNo(employee.ContactNo) != null)
                {
                    throw new Exception("Contact No should be unique");
                }
            }
            if (employee.Email != employee.PrevEmail)
            {
                if (_employeeGetway.GetByEmail(employee.Email) != null)
                {
                    throw new Exception("Email should be unique");
                }
            }
            if (employee.NID != employee.PrevNID)
            {
                if (_employeeGetway.GetByNID(employee.NID) != null)
                {
                    throw new Exception("NID should be unique");
                }
            }
            return _employeeGetway.Update(employee);
        }
    }
}
