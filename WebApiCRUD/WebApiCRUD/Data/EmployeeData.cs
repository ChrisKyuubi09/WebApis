using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD.Context;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    public class EmployeeData : IEmployeeData
    {
        private DataContext _employeeContext;
        public EmployeeData(DataContext employeeContext)
        {
            _employeeContext = employeeContext;
        }
        public EmployeeModel AddEmployee(EmployeeModel employee)
        {
            _employeeContext.Add(employee);
            _employeeContext.SaveChanges();
            return employee;
        }

        public void DeleteEmployee(Guid id)
        {
            var deletedEmployee = GetEmployee(id);

            _employeeContext.EmployeesTable.Remove(deletedEmployee);
            _employeeContext.SaveChanges();
        }

        public EmployeeModel GetEmployee(Guid id)
        {
            var employeeReturned = _employeeContext.EmployeesTable.Where(x => x.Id == id).FirstOrDefault();

            return employeeReturned;
        }

        public List<EmployeeModel> GetEmployees()
        {
            return _employeeContext.EmployeesTable.ToList();
        }

        public EmployeeModel UpdatedEmployee(Guid id, EmployeeModel employee)
        {
            var currentEmployee = _employeeContext.EmployeesTable.Find(id);
            currentEmployee.Name = employee.Name;
            _employeeContext.EmployeesTable.Update(currentEmployee);
            _employeeContext.SaveChanges();
            return currentEmployee;
        }
    }
}
