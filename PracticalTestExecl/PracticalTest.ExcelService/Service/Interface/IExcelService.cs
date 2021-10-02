using PracticalTest.ExcelService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.ExcelService.Service.Interface
{
    public interface IExcelService
    {
        List<BookData> ReadExcelFile();
        void InsertRow(List<string> rowData);
        void UpdateCell(string text, uint rowIndex, string columnName);
        void WriteExcelFile(List<UserDetails> persons);
    }
}
