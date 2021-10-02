using Microsoft.AspNetCore.Mvc;
using PracticalTest.Domain.Entity;
using PracticalTest.ExcelService.Service.Interface;
using PracticalTest.Service.Interfaces;
using PracticalTestExecl.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PracticalTestExecl.Controllers
{

    [Route("[controller]/[action]")]
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IExcelService excelService;

        public StudentController(IStudentService studentService, 
            IExcelService excelService)
        {
            this.studentService = studentService;
            this.excelService = excelService;
        }

        [HttpGet]
        [Route("/")]
        public IActionResult Index()
        {         
            return View();
        }

        [HttpGet]
        public IActionResult AddStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] StudentCreateViewModel model)
        {
            var obj = new Student
            {
                Acadamic = model.Acadamic,
                Act = model.Act,
                Sat = model.Sat,

                City = model.City,
                State = model.State,
                Zip = model.Zip,
                Gpa = model.Gpa,

                FirstName = model.FirstName,
                LastName = model.LastName,
                Dob = model.Dob,
                Gender = model.Gender == 1 ? true : false,
                StatusId = model.StatusId,
                Exclusion = model.Exclusion,
                Email = model.Email,
                EthnicityId = model.EthnicityId, 
            };

            var res = await studentService.Save(obj);
            if (res == null)
            {
                return new JsonResult("");
            }

            var student = await studentService.GetByEmail(model.Email);
            List<string> lst = new List<string>
            {
               student.Id.ToString(),
               student.FirstName,
               student.LastName,
               student.Dob.ToString(),
               student.Ethnicity.Name,
               student.Gender==true?"Male":"Female",
               student.Status?.Name,
               student.Acadamic?.Period,
               student.Exclusion,
               student.Act?.Composite.ToString(),
               student.Act?.Math.ToString(),
               student.Act?.English.ToString(),
               student.Act?.Reading.ToString(),
               student.Sat?.Combined.ToString(),
               student.Sat?.Math.ToString(),
               student.Sat?.Verbal.ToString(),
               student.Sat?.Reading.ToString(),
               student.Gpa.ToString(),
               student.City,
               student.State,
               student.Zip.ToString(),
               student.Email,
               student.Acadamic?.EntryAge.ToString(),
               student.Acadamic?.Ged.ToString(),
               student.Acadamic?.EnglishSecondLang.ToString(),
               student.Acadamic?.FirsGeneration.ToString(),                
            };
            excelService.InsertRow(lst);

            return new JsonResult("");
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await studentService.GetAll();
            if (res == null)
            {
                return new JsonResult("");
            }

            return new JsonResult(res);
        }


        [HttpGet]
        public IActionResult ListStudentExcel()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllExcel()
        {      

            var res = excelService.ReadExcelFile();
            if (res == null)
            {
                return new JsonResult("");
            }

            return new JsonResult(res);
        }

        
    }

}
