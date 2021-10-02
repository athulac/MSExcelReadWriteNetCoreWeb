using Microsoft.AspNetCore.Mvc;
using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTestExecl.Controllers
{
    [Route("[controller]/[action]")]
    public class StatusController : Controller
    {
        private readonly IStatusService statusService;

        public StatusController(IStatusService statusService)
        {
            this.statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await statusService.GetAll();
            return new JsonResult(res);
        }
    }
}
