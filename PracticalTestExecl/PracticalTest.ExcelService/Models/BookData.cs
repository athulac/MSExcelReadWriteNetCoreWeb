using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.ExcelService.Models
{
    public class BookData
    {
        public int SheetNo { get; set; }
        public List<List<string>> Data { get; set; }
    }
}
