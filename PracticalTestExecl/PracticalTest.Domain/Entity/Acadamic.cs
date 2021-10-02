using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.Domain.Entity
{
    public class Acadamic
    {
        [Key]
        public int Id { get; set; }
        public string Period { get; set; }
        public decimal EntryAge { get; set; }
        public int Ged { get; set; }
        public int EnglishSecondLang { get; set; }
        public int FirsGeneration { get; set; }
    }
}
