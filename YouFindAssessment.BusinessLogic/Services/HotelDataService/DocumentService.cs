
using OfficeOpenXml;

using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Text;

namespace YouFindAssessment.BusinessLogic.Services.HotelService
{
    public class DocumentService
    {
        private string _name { get; set; }
        private ExcelPackage _package;
        private ExcelWorksheet _sheet;

        public DocumentService(string name)
        {
            _name = name;
          
           // ExcelPackage.LicenseContext = System.ComponentModel;

            _package = new ExcelPackage(new FileInfo($"{_name}_{DateTime.Now.ToString("ddMMyy-HHmm")}.xlsx"));
            _sheet = _package.Workbook.Worksheets.Add("Report");
        }

        public void LoadFromDataTable(DataTable dt)
        {
            _sheet.Cells["A1"].LoadFromDataTable(dt, true, TableStyles.Medium9);
            _sheet.Cells[2, 3, dt.Rows.Count + 1, 3].Style.Numberformat.Format = "#,##0.00";
            _sheet.Cells[_sheet.Dimension.Address].AutoFitColumns();
            _package.Save();
        }

        public void Dispose()
        {
            _package.Dispose();
        }
    }
}
