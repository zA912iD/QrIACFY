// 代码生成时间: 2025-08-03 15:26:04
using System;
using System.Windows;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExcelGeneratorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GenerateExcel(string filePath, int numberOfSheets, int rows, int columns)
        {
            try
            {
                using (SpreadsheetDocument document = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    // Add a WorkbookPart to the document.
                    WorkbookPart workbookPart = document.AddWorkbookPart();

                    // Add a Workbook to the WorkbookPart.
                    workbookPart.AddChild(new Workbook());

                    // Add a worksheet to the Workbook.
                    for (int i = 1; i <= numberOfSheets; i++)
                    {
                        SheetData sheetData = new SheetData();
                        Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                        Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()), SheetId = i, Name = "Sheet" + i };
                        sheets.Append(sheet);

                        for (int row = 1; row <= rows; row++)
                        {
                            Row r = new Row();
                            for (int col = 1; col <= columns; col++)
                            {
                                // Add cells with sample data.
                                Cell cell = new Cell() { CellValue = new CellValue("What is your quest?"), DataType = CellValues.String };
                                r.Append(cell);
                            }
                            sheetData.Append(r);
                        }
                        workbookPart.WorksheetParts.ElementAt(i - 1).AddChild(sheetData);
                    }

                    // Add the Workbook to the document.
                    document.WorkbookPart.Workbook.AppendChild(new Workbook());
                }
                MessageBox.Show("Excel file generated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            // Call the GenerateExcel method with the selected file path and number of sheets, rows and columns.
            GenerateExcel("GeneratedExcel.xlsx", 1, 10, 5);
        }
    }
}