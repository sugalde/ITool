using System.Web;
using System.Web.Mvc;
using Excel;
using System.IO;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using InventoryTool.Models;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace InventoryTool.Controllers
{
    public class ReadExcelController : Controller
    {

        public ActionResult Import()
        {
            return View();
        }


        public ActionResult Importexcel()
        {


            if (Request.Files["FileUpload1"].ContentLength > 0)
            {
                string extension = System.IO.Path.GetExtension(Request.Files["FileUpload1"].FileName);
                //C:\Proyectos\GitHub\FeeCodes\InventoryToolApp\InventoryTool\InventoryTool\UploadedFiles
                string path1 = string.Format("{0}/{1}", Server.MapPath("~/UploadedFiles"), Request.Files["FileUpload1"].FileName);
                if (System.IO.File.Exists(path1))
                    System.IO.File.Delete(path1);

                Request.Files["FileUpload1"].SaveAs(path1);
                string sqlConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["InventoryToolContext"].ConnectionString;

                string cadenacon = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source=C:\\Proyectos\\GitHub\\FeeCodes\\InventoryToolApp\\InventoryTool\\InventoryTool\\UploadedFiles\\Amort.xlsx";
                OleDbConnection conexionExcel = new OleDbConnection(cadenacon);
  
                conexionExcel.Open();
                System.DateTime fecha = System.DateTime.Now;
                string strcommand = "Select [Fleet],[Unit],[LogNo],[CapCost],[BookValue],[Term],[Lpis],[OnRdDat],[OfRdDat],[Scontr],[InsPremiumResidualAmt],";
                strcommand += "[Fee],[Desc],[MMYY],[Start],[Stop],[Amt],[Method],[Rate],[BL,],[AC],'Admin','" + fecha.ToString() + "' from [Sheet1$]";

                //Create OleDbCommand to fetch data from Excel
                OleDbCommand cmd = new OleDbCommand(strcommand, conexionExcel);
                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();

                SqlBulkCopy sqlBulk = new SqlBulkCopy(sqlConnectionString);
                //Give your Destination table name
                sqlBulk.DestinationTableName = "FeeCodes";
                sqlBulk.WriteToServer(dReader);
                conexionExcel.Close();

                // SQL Server Connection String


            }

            return RedirectToAction("Import");
        }

    }
}