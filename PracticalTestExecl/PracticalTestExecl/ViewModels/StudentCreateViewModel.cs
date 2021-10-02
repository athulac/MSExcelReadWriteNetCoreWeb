using PracticalTest.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticalTestExecl.ViewModels
{
    public class StudentCreateViewModel
    {
      
        //public Acadamic Acadamic { get; set; }     
             
        //public Act Act { get; set; }       
       

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public string Exclusion { get; set; }
        public int EthnicityId { get; set; }


        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public decimal Gpa { get; set; }


        public Sat Sat { get; set; }
        public Act Act { get; set; }
        public Acadamic Acadamic { get; set; }
    }
}
