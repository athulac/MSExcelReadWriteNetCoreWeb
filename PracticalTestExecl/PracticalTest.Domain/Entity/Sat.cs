using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Entity
{
    public class Sat
    {
        [Key]
        public int Id { get; set; }
        public int Combined { get; set; }
        public int Math { get; set; }
        public int Verbal { get; set; }
        public int Reading { get; set; }
    }
}
