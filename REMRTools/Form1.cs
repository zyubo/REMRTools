using ClosedXML.Excel;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace REMRTools
{
    public partial class Form1 : Form
    {
        DataTable cityTable = null;
        Thread thIndeed = null;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(thIndeed != null)
            {
                thIndeed.Abort();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cityTable = Utils.LoadCSV("AdWords API Cities-DMA Regions 2014-12-29.csv");
        }

        private DataTable InitDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Location", typeof(string));
            table.Columns.Add("Jobs", typeof(int));
            table.Columns.Add("Url", typeof(string));
            table.Columns.Add("Weight", typeof(string));
            dgv.DataSource = table;
            dgv.DataBindingComplete += dgv_DataBindingComplete;
            dgv.CellContentClick += dgv_CellContentClick;
            return table;
        }

        void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string cellValue = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            if (cellValue.StartsWith("http://") || cellValue.StartsWith("https://"))
            {
                Process.Start(cellValue);
            }
        }

        void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells[2].Value != null && System.Uri.IsWellFormedUriString(r.Cells[2].Value.ToString(), UriKind.Absolute))
                {
                    r.Cells[2] = new DataGridViewLinkCell();
                    // Note that if I want a different link colour for example it must go here
                    DataGridViewLinkCell c = r.Cells[2] as DataGridViewLinkCell;
                    c.LinkColor = Color.Blue;
                }
            }
        }

        private void TaskStartIndeed()
        {
            DataTable table = InitDataTable();
            XLWorkbook wb = new XLWorkbook();
            thIndeed = new Thread(delegate()
            {
                //int index = 0;
                foreach (DataRow row in cityTable.Rows)
                {
                    string value = row[2].ToString();
                    //string[] arr = value.Split('@');
                    //string state = arr.Last().Replace("\"", "");
                    if (value == "Connecticut")
                    {
                        GetIndeed(table, row[0].ToString(), "CT");
                        Thread.Sleep(3000);
                    }
                }
                string resultFileName = "JobsByCity_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".xlsx";
                try
                {
                    wb.Worksheets.Add(table, "CT");
                    wb.SaveAs(resultFileName);
                    //Process.Start(resultFileName);
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(resultFileName + " generated.");
                    });
                }
                catch (Exception ex)
                {
                    File.WriteAllText("err_log.txt", ex.Message);
                }
            });
            thIndeed.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="city">Milford</param>
        /// <param name="state">CT</param>
        private void GetIndeed(DataTable table, string city, string state)
        {
            HtmlWeb web = new HtmlWeb();
            string url = "http://www.indeed.com/jobs?q=&l=" + city + "%2C+" + state + "&radius=0";
            //string url = "http://www.indeed.com/jobs?q=&l=" + "Stamford" + "%2C+" + "CT" + "&radius=0";
            HtmlAgilityPack.HtmlDocument indeed = web.Load(url);
            HtmlNode searchCount = indeed.GetElementbyId("searchCount");
            HtmlNode highSalary = indeed.GetElementbyId("SALARY_rbo");
            HtmlNode originalRadius = indeed.GetElementbyId("original_radius_result");

            if(searchCount != null)
            {
                try
                {
                    int jobsCount = int.Parse(searchCount.InnerText.Split(' ').Last().Replace(",",""));
                    string location = city + ", " + state;
                    string weight = "";
                    if (originalRadius != null && originalRadius.InnerText.Contains("No jobs found"))
                    {
                        location += "~";
                        jobsCount *= -1;
                    }
                    if (highSalary != null)
                    {
                        foreach(HtmlNode ul in highSalary.ChildNodes)
                        {
                            if(ul.Name == "ul")
                            {
                                foreach(HtmlNode li in ul.ChildNodes)
                                {
                                    if (li.Name == "li" && (li.InnerText.Contains("$70,000+") || li.InnerText.Contains("$80,000+") || li.InnerText.Contains("$90,000+")))
                                    {
                                        weight = li.InnerText.Trim();
                                    }
                                }
                            }
                        }
                    }
                    this.Invoke((MethodInvoker)delegate
                    {
                        table.Rows.Add(location, jobsCount, url, weight);
                    });
                }
                catch { }
            }

            highSalary = null;
            searchCount = null;
            indeed = null;
            web = null;

            GC.Collect();
            GC.WaitForFullGCComplete();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskStartIndeed();
        }

        private void agilityPackDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Demos.AgilityPack();
        }

        private void openXMLDemoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Demos.OpenXML();
        }

        private void loadCitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgv.DataSource = cityTable;
        }
    }
}
