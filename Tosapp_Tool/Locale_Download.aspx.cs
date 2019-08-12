using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tosapp_Tool
{
    public partial class Locale_Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string q = Request.QueryString["getFilePath"];
            string ex = Request.QueryString["ext"];
            fileName = q;
            extention = ex;
            flushxlsxfile();
            //轉換完成後將自己頁面關閉
            Response.Write("<script language='javascript'>window.close();</script>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //string tmpFilePName = Path.GetTempFileName();
            //string path = tmpFilePName;

            //// This text is added only once to the file.
            
            //    // Create a file to write to.
            //    //string createText = "Hello and Welcome" + Environment.NewLine;
            //    //File.WriteAllText(path, createText, Encoding.UTF8);
            //    //File.WriteAllText(path, "1234456dfghdfgsdf\n245asdsdf", Encoding.UTF8);

            //using (FileStream fs2 = new FileStream(path, System.IO.FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    StreamWriter sw = new StreamWriter(fs2);
            //    //輸出html字串
            //    sw.Write("1234456dfghdfgsdf\n245asdsdf");
            //    sw.Close();
            //    fs2.Close();
            //}
            //Response.Write(tmpFilePName);

            //var fileName = "test.xlsx";

            ////取得檔案在 Server 上的實體路徑
            //var filePath = "D:\\pre_plugin_webtech_tosys_skills.xlsx";

            ////緩衝區大小，每次讀取100KB
            //var bufferSize = 102400;
            //var buffer = new byte[bufferSize];
            //var fs = new FileStream(filePath,
            //    FileMode.Open, FileAccess.Read);
            ////輸出檔案的位元組總長度
            //var outputLength = fs.Length;
            ////每次讀取的位元組長度
            //var readLength = 0;

            //Context.Response.Clear();
            //Context.Response.AddHeader(
            //    "Content-Length", outputLength.ToString());
            //Context.Response.ContentType = "application/vnd.ms-excel";
            //Context.Response.AddHeader(
            //    "content-disposition",
            //    "attachment; filename=" + fileName);

            ////剩餘位元組長度大於零，且與瀏覽器連接著，就繼續執行
            //while (outputLength > 0 && Context.Response.IsClientConnected)
            //{
            //    readLength = fs.Read(buffer, 0, bufferSize);
            //    Context.Response.OutputStream.Write(buffer, 0, readLength);
            //    Context.Response.Flush();
            //    outputLength = outputLength - readLength;
            //}

            //fs.Close();
            //Context.Response.End();

        }

        private string fileName = null; //文檔名
        private string extention = null;
        private IWorkbook workbook = null;

        /// <summary>
        /// 將DataTable數據導入到excel中
        /// </summary>
        /// <param name="data">要導入的數據</param>
        /// <param name="isColumnWritten">DataTable的列名是否要導入</param>
        /// <param name="sheetName">要導入的excel的sheet的名稱</param>
        /// <returns>導入數據行數(包含列名那一行)</returns>
        public int DataTableToExcel(DataTable data, string sheetName, bool isColumnWritten)
        {
            //fileName = @"E:\11.xlsx";
            fileName = Path.GetTempFileName();
            int i = 0;
            int j = 0;
            int count = 0;
            ISheet sheet = null;

            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            //if (fileName.IndexOf(".xlsx") > 0) // 2007版本
            workbook = new XSSFWorkbook();
            //else if (fileName.IndexOf(".xls") > 0) // 2003版本
            //    workbook = new HSSFWorkbook();

            try
            {
                if (workbook != null)
                {
                    sheet = workbook.CreateSheet(sheetName);
                }
                else
                {
                    return -1;
                }

                if (isColumnWritten == true) //寫入DataTable的列名
                {
                    IRow row = sheet.CreateRow(0);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Columns[j].ColumnName);
                    }
                    count = 1;
                }
                else
                {
                    count = 0;
                }

                for (i = 0; i < data.Rows.Count; ++i)
                {
                    IRow row = sheet.CreateRow(count);
                    for (j = 0; j < data.Columns.Count; ++j)
                    {
                        row.CreateCell(j).SetCellValue(data.Rows[i][j].ToString());
                    }
                    ++count;
                }
                workbook.Write(fs); //寫入到excel
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return -1;
            }
        }

        protected void flushxlsxfile()
        {
            var bufferSize = 102400;
            var buffer = new byte[bufferSize];
            var fs = new FileStream(fileName,
                FileMode.Open, FileAccess.Read);
            //輸出檔案的位元組總長度
            var outputLength = fs.Length;
            //每次讀取的位元組長度
            var readLength = 0;

            Context.Response.Clear();
            Context.Response.AddHeader(
                "Content-Length", outputLength.ToString());
            Context.Response.ContentType = "application/vnd.ms-excel";
            Context.Response.AddHeader(
                "content-disposition",
                "attachment; filename=" + Path.GetFileNameWithoutExtension(fileName) +"."+ extention);

            //剩餘位元組長度大於零，且與瀏覽器連接著，就繼續執行
            while (outputLength > 0 && Context.Response.IsClientConnected)
            {
                readLength = fs.Read(buffer, 0, bufferSize);
                Context.Response.OutputStream.Write(buffer, 0, readLength);
                Context.Response.Flush();
                outputLength = outputLength - readLength;
            }

            fs.Close();
            Context.Response.End();
        }
    }
}