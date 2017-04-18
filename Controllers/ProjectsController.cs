using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EMS.Model;
using Microsoft.EntityFrameworkCore;

namespace EMS.Controllers
{
    [Produces("application/json")]
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private readonly EmployeeContext _context;

        public ProjectsController(EmployeeContext context)
        {
            _context = context;
        }
        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Project> project_ = new List<Project>();
            var Project = await (from data in _context.Project
                                 select new
                                 {
                                     ProjectId = data.ProjectId,
                                     ProjectName = data.ProjectName
                                 }).ToListAsync();
            Project.ForEach(x =>
            {
                Project pro = new Project();
                pro.ProjectId = x.ProjectId;
                pro.ProjectName = x.ProjectName;
                project_.Add(pro);
            });


            return Json(project_);
        }

       
       
    }
}
