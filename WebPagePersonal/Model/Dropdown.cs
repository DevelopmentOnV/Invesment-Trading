using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace WebPagePersonal.Model
{
    public class Dropdown
    {

       public string Drodowndata { get; set; }
    }

    public class Postdata
    {
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Gmail_id { get; set; }
        public string Mobilenumber { get; set; }
        public string Country { get; set; }


        public static string FinancialLiteracyTest(Postdata FnlTest)
        {
            string msg = "";
            try
            {
                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["DBWHDB1IPOMaster"].ToString()))
                {
                    sqlCon.Open();
                    using (SqlCommand sql_cmnd = new SqlCommand("SP_Insertformdata", sqlCon))
                    {
                        sql_cmnd.Parameters.AddWithValue("@First_name", FnlTest.First_name);
                        sql_cmnd.Parameters.AddWithValue("@Last_name", FnlTest.Last_name);
                        sql_cmnd.Parameters.AddWithValue("@Gmail", FnlTest.Gmail_id);
                        sql_cmnd.Parameters.AddWithValue("@Country", FnlTest.Country);
                        sql_cmnd.Parameters.AddWithValue("@Mobilenumber", FnlTest.Mobilenumber);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;
                 
                        using (SqlDataAdapter sda = new SqlDataAdapter(sql_cmnd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            try
                            {
                                msg = "ok";
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message); ;
                            }
                            sqlCon.Close();
                        }
                    }
                }
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
