using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMS.Model;
using EMS.ViewModel;
using Microsoft.EntityFrameworkCore;
using EMS.Models;

namespace EMS.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet("{Empid}")]
        public async Task<IActionResult> EmployeeDetails(int Empid)
        {
           
            var EmpDeatils = await(from emp in _context.Employee
                                   join pro in _context.Project on emp.ProjectId equals pro.ProjectId
                                   where emp.EmployeeId==Empid
                                   select new
                                   {
                                       emp.EmployeeId,
                                       emp.EmployeeName,
                                       emp.Designation,
                                       pro.ProjectName,
                                       emp.Skills,
                                       pro.ProjectId,
                                       pro.StartDate,
                                       pro.EndDate

                                   }
                          ).FirstAsync();


            return Json(EmpDeatils);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            List<Employee_Project> ilIst = new List<Employee_Project>();
            var listData = await (from emp in _context.Employee
                                  join pro in _context.Project on emp.ProjectId equals pro.ProjectId
                                  select new
                                  {
                                      emp.EmployeeId,
                                      emp.EmployeeName,
                                      emp.Designation,
                                      pro.ProjectName

                                  }
                          ).ToListAsync();
            listData.ForEach(x =>
            {
                Employee_Project Obj = new Employee_Project();
                Obj.EmployeeId = x.EmployeeId;
                Obj.Designation = x.Designation;
                Obj.EmployeeName = x.EmployeeName;
                Obj.Project = x.ProjectName;
                ilIst.Add(Obj);
            });

            return Json(ilIst);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody]Employee empObj)
        {
            _context.Employee.Add(empObj);
            _context.SaveChanges();
            return Json("OK");


        }

        [HttpDelete]
        public IActionResult RemoveEmployeeDetails([FromBody]int empId)
        {
            Employee Emp;
            Emp = _context.Employee.Where(x => x.EmployeeId == empId).First();
            _context.Employee.Remove(Emp);
            _context.SaveChanges();
            return Json("OK");
        }

        [HttpPut]
        public IActionResult EditEmployee([FromBody]Employee empData)
        {
            _context.Entry(empData).State = EntityState.Modified;
            _context.SaveChanges();
            return Json("ok");
        }


    }
}