using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPagePersonal.Model;
using System.Configuration;
using System.Data.OleDb;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Web.Configuration;
using System.Reflection;
using System.Web.UI.WebControls;
using System.Web.Services.Discovery;

namespace WebPagePersonal.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home

        public ActionResult Index()
        {
            return View();
        }
      
        public JsonResult GetCompanyMasterdata()
        {
            string constr = ConfigurationManager.ConnectionStrings["CONNHERULES"].ConnectionString;
            List<Dropdown> rows = new List<Dropdown>();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SP_Dropdowngetdata", con))
                {

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        da.Fill(ds);

                        DataTable dt = ds.Tables[0];

                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                rows.Add(new Dropdown
                                {
                                    Drodowndata = dr["StateName"].ToString(),
                                });
                            }
                        }
                    }
                }
            }
            return Json(rows, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Cofeepage()
        {
            return View();
        }
        public ActionResult Loginpage()
        {
      
            return View();
        }
        public ActionResult Finance()
        {

            return View();
        }
        // [HttpPost]
        public ActionResult Customalert()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Businesspartnerr() {
        
            return View();
        }
        public ActionResult Businesspartnerrdata()
        {

            return View();
        }
        public JsonResult FinancialLiteracy(Postdata FnlTest)
        {

            try
            {
                string msg = Postdata.FinancialLiteracyTest(FnlTest);
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Forgetpasswords()
        {

            return View();
        }
        [HttpGet]
        public JsonResult NOTIFICATION()
        {
            

            return Json(HttpStatusCode.OK);
        }
        [HttpPost]
        public JsonResult Forgetpasseord(Signupmodel FnlTest)
        {



            try {
                SqlConnection conn = null;
                using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNHERULES"].ToString()))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_forgetpassword", conn))
                    {
                        cmd.Parameters.AddWithValue("@gmailid", FnlTest.Gmail_id);
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter sds = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            sds.Fill(ds);
                            DataTable dt = ds.Tables[0];
                            FnlTest.Gmail_id = dt.Rows[0]["Email"].ToString();
                            FnlTest.id = dt.Rows[0]["id"].ToString();
                        }
                    }
                }
                return Json(FnlTest, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);              
            }  
        }
        public ActionResult Createnewpassword()
        {
            return View();
        }
 
       
    }



    //[HttpPost]
    //public async Task<ActionResult> ImportFile(HttpPostedFileBase importFile)
    //{
    //    if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

    //    try
    //    {
    //        var fileData = GetDataFromCSVFile(importFile.InputStream);

    //        var dtEmployee = fileData.ToDataTable();
    //        var tblEmployeeParameter = new SqlParameter("tblEmployeeTableType", SqlDbType.Structured)
    //        {
    //            TypeName = "dbo.tblTypeEmployee",
    //           Value = dtEmployee
    //        };
    //       await _dbContext.Database.ExecuteSqlCommandAsync("EXEC spBulkImportEmployee @tblEmployeeTableType", tblEmployeeParameter);
    //        return Json(new { Status = 1, Message = "File Imported Successfully " });
    //    }
    //    catch (Exception ex)
    //    {
    //        return Json(new { Status = 0, Message = ex.Message });
    //    }
    //}

    //public static class Extensions
    //{
    //    public static DataTable ToDataTable<T>(this List<T> items)
    //    {
    //        DataTable dataTable = new DataTable(typeof(T).Name);

    //        //Get all the properties  
    //        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    //        foreach (PropertyInfo prop in Props)
    //        {
    //            //Defining type of data column gives proper data table   
    //            var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
    //            //Setting column names as Property names  
    //            dataTable.Columns.Add(prop.Name, type);
    //        }
    //        foreach (T item in items)
    //        {
    //            var values = new object[Props.Length];
    //            for (int i = 0; i < Props.Length; i++)
    //            {
    //                //inserting property values to datatable rows  
    //                values[i] = Props[i].GetValue(item, null);
    //            }
    //            dataTable.Rows.Add(values);
    //        }
    //        return dataTable;
    //    }
    //}


    



}


