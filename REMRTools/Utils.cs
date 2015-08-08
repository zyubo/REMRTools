using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace REMRTools
{
    public class Utils
    {
        public static DataTable LoadCSV(string filePath)
        {
            var parser = new Microsoft.VisualBasic.FileIO.TextFieldParser(filePath);
            parser.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited;
            parser.SetDelimiters(new string[] { ";" });
            Regex regex = new Regex("\"(.*?)\"");

            DataTable table = new DataTable();
            bool isFirstRow = true;

            while (!parser.EndOfData)
            {
                string[] row = parser.ReadFields();
                if (row.Length == 0 || row[0].Length == 0) continue;
                string line = row[0];
                string sub = regex.Match(line).Value;
                if (!string.IsNullOrEmpty(sub))
                {
                    line = line.Replace(sub, sub.Replace(", ", ",").Replace(",", "@"));
                }
                if(isFirstRow)
                {
                    foreach (var c in line.Split(','))
                    {
                        table.Columns.Add(c, typeof(string));
                    }
                    isFirstRow = false;
                }
                else
                {
                    table.Rows.Add(line.Split(','));
                }
            }

            return table;
        }
    }
}
