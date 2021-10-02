using PracticalTest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Student> Save(Student student);
        Task<List<Student>> GetAll();
        Task<Student> GetByEmail(string email);
    }
}
