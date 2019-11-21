using NPOI.SS.UserModel;
using System.IO;
using System.Net;

namespace cadnvert
{
    public static class TemplateParser
    {
        public static string GetCsvHeaders(string templatePath)
        {
            IWorkbook wb;


            using (var webClient = new WebClient())
            {
                using var stream = webClient.OpenRead(templatePath);
                using var sr = new StreamReader(stream);
                wb = WorkbookFactory.Create(sr.BaseStream);
            }

            var sheet = wb.GetSheetAt(0);// get the first / default sheet 
            var headers = "";

            for (int row = 1; row <= sheet.LastRowNum; row++)
            {
                var prefix = ",";
                if (row == 1)
                    prefix = "";
                var csvRow = sheet.GetRow(row);
                if (csvRow == null) //null is when the row only contains empty cells 
                {
                    break;
                }
                var cellValue = csvRow.GetCell(4).StringCellValue;
                if (cellValue.ToUpper() == "SPACES" || cellValue.ToUpper() == "FILLER")
                {
                    continue;
                }
                if (string.IsNullOrWhiteSpace(cellValue.Trim()))
                {
                    break;
                }
                headers += prefix + cellValue;
            }
            return headers;
        }
    }
}
