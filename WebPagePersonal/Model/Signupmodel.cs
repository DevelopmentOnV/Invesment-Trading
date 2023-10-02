using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace WebPagePersonal.Model
{
    public class Signupmodel
    {
        public string fullname { get; set; }
        public string Gmail_id { get; set; }
        public string mobile { get; set; }
        public string state { get; set; }
        public string passwordfirst { get; set; }
        public string id { get; set; }
        public string passwordconfirm { get; set; }

        public static string Signuppage(Signupmodel FnlTest)
        {
            string msg = "";
            try
            {
                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNHERULES"].ToString()))
                {
                    sqlCon.Open();
                    using (SqlCommand sql_cmnd = new SqlCommand("sp_Signup_webpersonal", sqlCon))
                    {
                     
                        sql_cmnd.Parameters.AddWithValue("@FullName", FnlTest.fullname);
                        sql_cmnd.Parameters.AddWithValue("@Email", FnlTest.Gmail_id);
                        sql_cmnd.Parameters.AddWithValue("@Mobile", FnlTest.mobile);
                        sql_cmnd.Parameters.AddWithValue("@State", FnlTest.state);
                        sql_cmnd.Parameters.AddWithValue("@Password", FnlTest.passwordconfirm);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(sql_cmnd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            try
                            {
                                msg = "200";
                                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587)

                                {

                                    Port = 587,
                                    Credentials = new NetworkCredential("vikas.acmiil@gmail.com", "Acmiil@1234"),
                                    EnableSsl = true,
                                };

                                MailMessage mailMessage = new MailMessage
                                {
                                    From = new MailAddress("Vikas.acmiil@gmail.com"),
                                    Subject = "Subject of your email",
                                    Body = "Body of your email",
                                    IsBodyHtml = true,
                                };

                                mailMessage.To.Add("yadavvicku555@gmail.com");

                                try
                                {
                                   // client.UseDefaultCredentials = true;
                                    smtpClient.Send(mailMessage);
                                    //ViewBag.Message = "Email sent successfully!";

                                }
                                catch (Exception ex)
                                {
                                    //ViewBag.Message = $"Error sending email: {ex.Message}";
                                }
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
        //public static void SuccessMailForReferalBaLogin(Signupmodel FnlTest)
        //{
        //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential("your_email@gmail.com", "your_password"),
        //        EnableSsl = true,
        //    };

        //    MailMessage mailMessage = new MailMessage
        //    {
        //        From = new MailAddress("your_email@gmail.com"),
        //        Subject = "Subject of your email",
        //        Body = "Body of your email",
        //        IsBodyHtml = true,
        //    };

        //    mailMessage.To.Add("recipient@example.com");

        //    try
        //    {
        //        smtpClient.Send(mailMessage);
        //        //ViewBag.Message = "Email sent successfully!";

        //    }
        //    catch (Exception ex)
        //    {
        //        //ViewBag.Message = $"Error sending email: {ex.Message}";
        //    }

        //}

     






        public static string loginpage(Signupmodel FnlTest )
        {
            string Gmail_id = "";
            string password = "";
            string fullname = "";
            string Mobile = "";
            string State = "";
            string formdatavalue = "";
            try
            {


                SqlConnection sqlCon = null;
                using (sqlCon = new SqlConnection(ConfigurationManager.ConnectionStrings["CONNHERULES"].ToString()))
                {
                    sqlCon.Open();
                    using (SqlCommand sql_cmnd = new SqlCommand("sp_Login_webpersonal", sqlCon))
                    {
                        sql_cmnd.Parameters.AddWithValue("@Gmail_id", FnlTest.Gmail_id);
                        sql_cmnd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter sda = new SqlDataAdapter(sql_cmnd))
                        {
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            DataTable dt = ds.Tables[0];
                            try
                            {
                                
                             
                                Gmail_id = dt.Rows[0]["Email"].ToString();
                                password = dt.Rows[0]["Password"].ToString();
                                fullname = dt.Rows[0]["FullName"].ToString();
                                Mobile = dt.Rows[0]["Mobile"].ToString();
                                State = dt.Rows[0]["State"].ToString();
                                formdatavalue = (Gmail_id + "," + password+","+ fullname + "," + Mobile);
                                
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message); ;
                            }
                            sqlCon.Close();
                        }
                    }

                }
                return formdatavalue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}