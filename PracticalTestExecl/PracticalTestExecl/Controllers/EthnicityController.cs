using Microsoft.AspNetCore.Mvc;
using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTestExecl.Controllers
{
    [Route("[controller]/[action]")]
    public class EthnicityController : Controller
    {
        private readonly IEthnicityService ethnicityService;

        public EthnicityController(IEthnicityService ethnicityService)
        {
            this.ethnicityService = ethnicityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await ethnicityService.GetAll();
            return new JsonResult(res);
        }
    }
}
