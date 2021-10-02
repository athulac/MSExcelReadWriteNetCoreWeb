using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTest.Domain.Entity
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        public Ethnicity Ethnicity { get; set; }
        [ForeignKey("Ethnicity")]
        public int EthnicityId { get; set; }

        public Status Status { get; set; }
        [ForeignKey("Status")]
        public int StatusId { get; set; }

        public Acadamic Acadamic { get; set; }
        [ForeignKey("Acadamic")]
        public int AcadamicId { get; set; }
             

        public Act Act { get; set; }
        [ForeignKey("Act")]
        public int? ActId { get; set; }


        public Sat Sat { get; set; }
        [ForeignKey("Sat")]
        public int? SatId { get; set; }



        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Exclusion { get; set; }


        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public decimal Gpa { get; set; }
    }
}
