using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Model
{
    public class EmployeeContext:DbContext   
     {  
        public EmployeeContext(DbContextOptions<EmployeeContext> options):base(options)  
        {  
  
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Project> Project { get; set; }  
    }  
}
