using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS.Controllers
{
    [Produces("application/json")]
    [Route("api/EmployeeInfo")]
    public class EmployeeInfoController : Controller
    {
        // GET: api/EmployeeInfo
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/EmployeeInfo/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/EmployeeInfo
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/EmployeeInfo/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
