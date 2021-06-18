using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCRUD.Data;
using WebApiCRUD.Models;

namespace WebApiCRUD.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<EmployeeModel> EmployeesTable { get; set; }
    }
}
