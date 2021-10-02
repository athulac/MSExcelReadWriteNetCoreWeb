using PracticalTest.Domain.Entity;
using PracticalTest.Repositoy.Repositories.Interfaces;
using PracticalTest.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this.studentRepository = studentRepository;
        }
        
        public async Task<Student> Save(Student student)
        {
            if (student.Act.Composite == 0 && student.Act.English == 0 && student.Act.Math == 0 && student.Act.Reading == 0)
            {
                student.Act = null;
            }

            if (student.Sat.Combined == 0 && student.Sat.Math == 0 && student.Sat.Reading == 0 && student.Sat.Verbal == 0)
            {
                student.Sat = null;
            }
           
            var res = await studentRepository.AddAsync(student);
            if (res>0)
            {
                return student;
            }

            return new Student { };
        }

        public async Task<List<Student>> GetAll()
        { 
            var res = studentRepository.GetAllAsync(x => x.Ethnicity);
            if (!res.Any())
            {
                return new List<Student> { };
            }

            return res.ToList();
        }

        public async Task<Student> GetByEmail(string email)
        {
            var res = studentRepository.Find(x => x.Email == email,
                x => x.Ethnicity, x => x.Acadamic, x => x.Act, x => x.Sat);
            if (!res.Any())
            {
                return new Student { };
            }

            return res.First();
        }
    }
}
