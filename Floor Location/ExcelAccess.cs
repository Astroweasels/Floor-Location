using Floor_Location.Models;
using OfficeOpenXml;
using System.IO;

namespace Floor_Location
{
    public class ExcelAccess
    {
        private string filePath;
        private string NewFilePath;
        private FileInfo file;
        public ExcelAccess()
        {
            //filePath = @"C:\Projects\Floor-Location\FLOOR_LOCATIONExcelTest.xlsx";
            filePath = Directory.GetCurrentDirectory() + "\\FLOOR_LOCATION.xlsx";
            file = new FileInfo(filePath);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public List<ExcelMapDM> ExcelList()
        {
            
            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                
                ExcelWorksheet worksheet = package.Workbook.Worksheets["WMS Location Floor Location"];

                int rows = worksheet.Dimension.Rows;
                int columns = worksheet.Dimension.Columns;
                List<ExcelMapDM> cellValues = new List<ExcelMapDM>();

                for (int row =2; row <= rows; row++)
                {

                        ExcelMapDM cellvalue = new ExcelMapDM();
                        cellvalue.LOCATION_NAME = worksheet.Cells[row, 1].Value.ToString();
                        cellvalue.LOCATION_ID = worksheet.Cells[row, 2].Value.ToString();
                        cellvalue.IS_CLEARANCE = worksheet.Cells[row, 3].Value.ToString();
                        cellValues.Add(cellvalue);    
                }
          
                return cellValues;
            }
            
        }

        #region Add

        public void AddExcelValue(string Location_name, string Location_ID, string Is_clearance)
        {
            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["WMS Location Floor Location"];

                int targetRow = worksheet.Dimension.End.Row + 1;

                worksheet.Cells[targetRow, 1].Value = Location_name;
                worksheet.Cells[targetRow, 2].Value = Location_ID;
                worksheet.Cells[targetRow, 3].Value = Is_clearance;
                package.Save();
                worksheet.Dispose();

            }
        }

        #endregion

        #region Update
        public void UpdateExcelValue(int rowIndex, string Location_name, string Location_ID, string Is_clearance)
        {
            using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["WMS Location Floor Location"];

                worksheet.Cells[rowIndex, 1].Value = Location_name;
                worksheet.Cells[rowIndex, 2].Value = Location_ID;
                worksheet.Cells[rowIndex, 3].Value = Is_clearance;
                package.Save();

            }
        }

        #endregion

        #region Delete
        public void DeleteExcelRow(int rowIndex)
        {
                using (ExcelPackage package = new ExcelPackage(filePath))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["WMS Location Floor Location"];

                worksheet.DeleteRow(rowIndex);
                package.Save();
                

            }
        }
        #endregion
    }
}
