using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCRUD.Models
{
    public class EmployeeModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
