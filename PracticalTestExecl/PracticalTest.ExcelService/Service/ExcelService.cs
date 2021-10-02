using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using PracticalTest.ExcelService.Models;
using PracticalTest.ExcelService.Service.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalTest.ExcelService.Service
{
    public class ExcelService : IExcelService
    {
        private string filePath = "";
        public ExcelService()
        {
            filePath = @"C:\Users\Athula\Documents\testdata.xlsx";
        }

        public List<BookData> ReadExcelFile()
        {
            var excelData = new List<BookData> { };
            string strDoc = filePath;
            //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(strDoc, false))
            {
                //create the object for workbook part  
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                StringBuilder excelResult = new StringBuilder();

                //using for each loop to get the sheet from the sheetcollection  
                int sheetCount = 0;
                var rowListData = new List<List<string>> { };
                foreach (Sheet thesheet in thesheetcollection)
                {
                    sheetCount++;
                    Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;
                    SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                    foreach (Row thecurrentrow in thesheetdata)
                    {
                        List<string> rowData = new List<string> { };
                        foreach (Cell thecurrentcell in thecurrentrow)
                        {
                            string currentcellvalue = string.Empty;
                            if (thecurrentcell.DataType != null)
                            {
                                if (thecurrentcell.DataType == CellValues.SharedString)
                                {
                                    int id;
                                    if (Int32.TryParse(thecurrentcell.InnerText, out id))
                                    {
                                        SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                                        if (item.Text != null)
                                        {
                                            //code to take the string value  
                                            excelResult.Append(item.Text.Text + " ");
                                            rowData.Add(item.Text.Text);
                                        }
                                        else if (item.InnerText != null)
                                        {
                                            currentcellvalue = item.InnerText;
                                            rowData.Add(currentcellvalue);
                                        }
                                        else if (item.InnerXml != null)
                                        {
                                            currentcellvalue = item.InnerXml;
                                            rowData.Add(currentcellvalue);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //excelResult.Append(Convert.ToInt16(thecurrentcell.InnerText) + " ");
                                rowData.Add(thecurrentcell.InnerText);
                            }
                        }

                        excelResult.AppendLine();
                        rowListData.Add(rowData);
                    }

                    var resf = excelResult;
                    var res = excelResult.ToString();

                    var sheetData = new BookData
                    {
                        Data = rowListData,
                        SheetNo = sheetCount,
                    };

                    excelData.Add(sheetData);
                }
            }

            return excelData;
        }
        public void InsertRow(List<string> rowData)
        {
            int sheetNo = 1;
            string strDoc = filePath;
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(strDoc, true))
            {
                int currSheet = 0;
                WorkbookPart workbookPart = doc.WorkbookPart;
                Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();
                foreach (Sheet thesheet in thesheetcollection)
                {
                    currSheet++;
                    if (sheetNo == currSheet)
                    {
                        Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;
                        SheetData thesheetdata = (SheetData)theWorksheet.GetFirstChild<SheetData>();
                        Row lastRow = thesheetdata.Elements<Row>().LastOrDefault();

                        var census = rowData;
                        //var census = new List<string> { "aaaa", "bbbb" };
                        Row row = new Row() { RowIndex = (lastRow.RowIndex + 1) };
                        foreach (var item in census)
                        {
                            Cell cell = new Cell()
                            {
                                DataType = CellValues.String,
                                CellValue = new CellValue(item)
                            };
                            row.Append(cell);
                        }


                        if (lastRow != null)
                        {
                            thesheetdata.InsertAfter(row, lastRow);
                        }
                        else
                        {
                            thesheetdata.InsertAt(new Row() { RowIndex = 0 }, 0);
                        }
                    }
                }
            }
        }
        public void UpdateCell(string text, uint rowIndex, string columnName)
        {
            int sheetNo = 1;
            string strDoc = filePath;
            using (SpreadsheetDocument doc = SpreadsheetDocument.Open(strDoc, true))
            {
                WorksheetPart worksheetPart = GetWorksheetPartByName(doc, 1);
                if (worksheetPart != null)
                {
                    Cell cell = GetCell(worksheetPart.Worksheet, columnName, rowIndex);
                    cell.CellValue = new CellValue(text);
                    cell.DataType = new EnumValue<CellValues>(CellValues.Number);
                    // Save the worksheet.
                    worksheetPart.Worksheet.Save();
                }
            }
        }
        public void WriteExcelFile(List<UserDetails> persons)
        {
            // Lets converts our object data to Datatable for a simplified logic.
            // Datatable is most easy way to deal with complex datatypes for easy reading and formatting. 
            DataTable table = (DataTable)JsonConvert.DeserializeObject(JsonConvert.SerializeObject(persons), (typeof(DataTable)));

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                var sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Sheet1" };

                sheets.Append(sheet);

                Row headerRow = new Row();

                List<String> columns = new List<string>();
                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);

                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(column.ColumnName);
                    headerRow.AppendChild(cell);
                }

                sheetData.AppendChild(headerRow);

                foreach (DataRow dsrow in table.Rows)
                {
                    Row newRow = new Row();
                    foreach (String col in columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(dsrow[col].ToString());
                        newRow.AppendChild(cell);
                    }

                    sheetData.AppendChild(newRow);
                }

                workbookPart.Workbook.Save();
            }
        }

        private static Cell GetCell(Worksheet worksheet, string columnName, uint rowIndex)
        {
            Row row = GetRow(worksheet, rowIndex);

            if (row == null)
                return null;

            return row.Elements<Cell>().Where(c => string.Compare
                   (c.CellReference.Value, columnName +
                   rowIndex, true) == 0).First();
        }
        private static Row GetRow(Worksheet worksheet, uint rowIndex)
        {
            return worksheet.GetFirstChild<SheetData>().
              Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
        }
        private static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, int sheetId)
        {
            IEnumerable<Sheet> sheets =
               document.WorkbookPart.Workbook.GetFirstChild<Sheets>().
               Elements<Sheet>().Where(s => s.SheetId == sheetId);

            if (sheets.Count() == 0)
            {
                // The specified worksheet does not exist.

                return null;
            }

            string relationshipId = sheets.First().Id.Value;
            WorksheetPart worksheetPart = (WorksheetPart)
                 document.WorkbookPart.GetPartById(relationshipId);
            return worksheetPart;

        }
    }
}
