using ClosedXML.Excel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REMRTools
{
    public class Demos
    {

        public static void DataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Dosage", typeof(int));
            table.Columns.Add("Drug", typeof(string));
            table.Columns.Add("Patient", typeof(string));
            table.Columns.Add("Date", typeof(DateTime));

            // Here we add five DataRows.
            table.Rows.Add(25, "Indocin", "David", DateTime.Now);
            table.Rows.Add(50, "Enebrel", "Sam", DateTime.Now);
            table.Rows.Add(10, "Hydralazine", "Christoff", DateTime.Now);
            table.Rows.Add(21, "Combivent", "Janet", DateTime.Now);
            table.Rows.Add(100, "Dilantin", "Melanie", DateTime.Now);
        }

        public static void AgilityPack()
        {
            //HtmlDocument doc = new HtmlDocument();
            //doc.Load("file.htm");
            //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href"))
            //{
            //    HtmlAttribute att = link.Attributes["href"];
            //    //att.Value = FixLink(att);
            //}
            //doc.Save("file.htm");

            HtmlWeb web = new HtmlWeb();
            HtmlDocument google = web.Load("http://www.google.com");
            HtmlDocument w3 = web.Load("http://www.w3.org/");

            HtmlNodeCollection nodes = w3.DocumentNode.SelectNodes("/html[1]/body[1]/div[1]/div[2]/div[3]/div[2]/div[1]/div[1]/div[1]/div");
            foreach (HtmlNode node in nodes)
            {
                Console.WriteLine(node.InnerText.Trim());
            }

            //HtmlNode title = indeed.GetElementbyId("title");
            //string titleValue = title.Attributes["title"].Value;
        }

        public static void OpenXML()
        {
            //XLWorkbook wb = new XLWorkbook();
            //DataTable dt = GetDataTableOrWhatever();
            //wb.Worksheets.Add(dt, "WorksheetName");

            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Contacts");
            //Title
            ws.Cell("B2").Value = "Contacts";

            //First Names
            ws.Cell("B3").Value = "FName";
            ws.Cell("B4").Value = "John";
            ws.Cell("B5").Value = "Hank";
            ws.Cell("B6").SetValue("Dagny"); // Another way to set the value

            //Last Names
            ws.Cell("C3").Value = "LName";
            ws.Cell("C4").Value = "Galt";
            ws.Cell("C5").Value = "Rearden";
            ws.Cell("C6").SetValue("Taggart"); // Another way to set the value
            // Boolean
            ws.Cell("D3").Value = "Outcast";
            ws.Cell("D4").Value = true;
            ws.Cell("D5").Value = false;
            ws.Cell("D6").SetValue(false); // Another way to set the value

            //DateTime
            ws.Cell("E3").Value = "DOB";
            ws.Cell("E4").Value = new DateTime(1919, 1, 21);
            ws.Cell("E5").Value = new DateTime(1907, 3, 4);
            ws.Cell("E6").SetValue(new DateTime(1921, 12, 15)); // Another way to set the value

            //Numeric
            ws.Cell("F3").Value = "Income";
            ws.Cell("F4").Value = 2000;
            ws.Cell("F5").Value = 40000;
            ws.Cell("F6").SetValue(10000); // Another way to set the value

            //From worksheet
            var rngTable = ws.Range("B2:F6");

            //From another range
            var rngDates = rngTable.Range("D3:D5"); // The address is relative to rngTable (NOT the worksheet)
            var rngNumbers = rngTable.Range("E3:E5"); // The address is relative to rngTable (NOT the worksheet)

            //Using a OpenXML's predefined formats
            rngDates.Style.NumberFormat.NumberFormatId = 15;

            //Using a custom format
            rngNumbers.Style.NumberFormat.Format = "$ #,##0";

            rngTable.FirstCell().Style
                .Font.SetBold()
                .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

            rngTable.FirstRow().Merge(); // We could've also used: rngTable.Range("A1:E1").Merge() or rngTable.Row(1).Merge()

            var rngHeaders = rngTable.Range("A2:E2"); // The address is relative to rngTable (NOT the worksheet)
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            var rngData = ws.Range("B3:F6");
            var excelTable = rngData.CreateTable();

            // Add the totals row
            excelTable.ShowTotalsRow = true;
            // Put the average on the field "Income"
            // Notice how we're calling the cell by the column name
            excelTable.Field("Income").TotalsRowFunction = XLTotalsRowFunction.Average;
            // Put a label on the totals cell of the field "DOB"
            excelTable.Field("DOB").TotalsRowLabel = "Average:";

            //Add thick borders to the contents of our spreadsheet
            ws.RangeUsed().Style.Border.OutsideBorder = XLBorderStyleValues.Thick;

            // You can also specify the border for each side:
            // contents.FirstColumn().Style.Border.LeftBorder = XLBorderStyleValues.Thick;
            // contents.LastColumn().Style.Border.RightBorder = XLBorderStyleValues.Thick;
            // contents.FirstRow().Style.Border.TopBorder = XLBorderStyleValues.Thick;
            // contents.LastRow().Style.Border.BottomBorder = XLBorderStyleValues.Thick;

            ws.Columns().AdjustToContents(); // You can also specify the range of columns to adjust, e.g.
            // ws.Columns(2, 6).AdjustToContents(); or ws.Columns("2-6").AdjustToContents();

            wb.SaveAs("Showcase.xlsx");
        }
    }
}
