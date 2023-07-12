
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using ResourceHunter.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;


namespace ResourceHunter
{
    public class ImportFiles : IImportFiles
    {
        List<string> translateColumn = new List<string>();
        List<string> firstColumn = new List<string>();
        int langCount;
        string _fileName;
        public ImportFiles(string fileName)

        { _fileName = fileName; }

        public (List<string>, List<string>, int) ReadExcell(int selectLang)
        {
                FileInfo existingFile = new FileInfo(_fileName);
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    int colCountExcel = worksheet.Dimension.End.Column;  
                    int rowCountExcel = worksheet.Dimension.End.Row;     

                    firstColumn = null;
                    translateColumn = null;
                    langCount = 0;

                    langCount = colCountExcel;
                    worksheet.Cells[1, 1].Value = "key";
                    int rowCount = 0;

                    for (int i = 1; i <= rowCountExcel; i++)
                    {
                        if (!(worksheet.Cells[i, 1].Value?.ToString() == ""))
                        {
                            rowCount++;
                        }
                    }

                    Dictionary<int, List<string>> dictLanguage = new Dictionary<int, List<string>>();
                    for (int i = 1; i <= langCount; i++)
                    {
                        dictLanguage.Add(i, new List<string>());

                        for (int g = 1; g <= rowCount; g++)
                        {
                            dictLanguage[i].Add(worksheet.Cells[g, i].Value?.ToString());
                        }
                    }
                    firstColumn = dictLanguage[1];
                    translateColumn = dictLanguage[selectLang]; 
                }
            return (firstColumn, translateColumn, langCount);
        }
    }
}
