// 代码生成时间: 2025-09-21 04:23:11
using System;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGeneratorApp
{
    /// <summary>
    /// Excel表格自动生成器
    /// </summary>
    public class ExcelGenerator
    {
        /// <summary>
        /// 创建一个Excel文件
        /// </summary>
        /// <param name="data">要写入Excel的数据</param>
        /// <param name="filePath">文件保存路径</param>
        /// <returns>生成文件的路径，若失败则返回null</returns>
        public string CreateExcelFile(object[,] data, string filePath)
        {
            try
            {
                // 创建Excel文件
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // 添加一个WorkbookPart到文档中
                    WorkbookPart workbookPart = document.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    // 添加一个WorksheetPart到WorkbookPart中
                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                    worksheetPart.Worksheet = new Worksheet(new SheetData());

                    // 将WorksheetPart添加到Workbook中
                    Sheets sheets = workbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    };
                    sheets.Append(sheet);

                    // 填充数据到Excel中
                    SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                    for (int row = 0; row < data.GetLength(0); row++)
                    {
                        uint rId = 1 + row;
                        Row rowElement = new Row() { RowIndex = rId };
                        for (int col = 0; col < data.GetLength(1); col++)
                        {
                            Cell cell = new Cell() { CellReference = $"{(char)('A' + col)}{rId}", CellValue = new CellValue(data[row, col].ToString()), DataType = new EnumValue<CellValues>(CellValues.String) };
                            rowElement.Append(cell);
                        }
                        sheetData.Append(rowElement);
                    }

                    // 保存更改
                    workbookPart.Workbook.Save();
                }
                return filePath;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"Error creating Excel file: {ex.Message}");
                return null;
            }
        }
    }
}
