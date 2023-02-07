using DataRoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataRoom
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()

            {
                new Employee() {Id=1, Name="Sothun Thay", Email="sothun.thay@icloud.com", Department = Departments.IT },
                new Employee() {Id=2, Name="Sreyneth Khorn", Email="skhorn@icloud.com", Department = Departments.FINANCE },
                new Employee() {Id=3, Name="Nisa Thay", Email="nisa.thay@icloud.com", Department = Departments.HR },
                new Employee() {Id=4, Name="Bosba Thay", Email="bosba.thay@icloud.com", Department = Departments.HR }
            };

        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Detail(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }

        public Employee Add(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.Id == employeeChanges.Id);
            if (employee != null)
            {
                employee.Name = employeeChanges.Name;
                employee.Email = employeeChanges.Email;
                employee.Department = employeeChanges.Department;
           }
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee =_employeeList.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }
    }
}
