using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    public interface IEmployeeData
    {
        List<EmployeeModel> GetEmployees();
        EmployeeModel GetEmployee(Guid id);

        EmployeeModel AddEmployee(EmployeeModel employee);

        void DeleteEmployee(Guid id);

        EmployeeModel UpdatedEmployee(Guid id, EmployeeModel employee);
    }
}
