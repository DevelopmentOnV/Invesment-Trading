using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Net;
using WebPagePersonal.Model;
using System.Web.Services.Description;

namespace WebPagePersonal.Controllers
{
    public class InsertinpdfController : Controller
  {
      
                public ActionResult Index()
        {
            return View();
        }
        //public FileResult BSEPDFApproved(string Email_Id, string AadharNo, string BaCode, string Inwardno)
        //{
        //    //var Inwardno = "MA00001";
        //    var data1 = new SignUP();
        //    int pdfpgcount = 0;
        //    // string pdfClientSign = ConfigurationManager.AppSettings["PdfClientSign"];
        //    try
        //    {
        //        var pathDownloadDP = ConfigurationManager.AppSettings["MADocumentFolder"];
        //        string folderPath1 = pathDownloadDP;
        //        if (!Directory.Exists(folderPath1 + "\"" + Inwardno + "\"" + Inwardno + ""))

        //            //  Directory.CreateDirectory(folderPath1 + "\"" + Inwardno + "\"" + Inwardno + "");
        //            Directory.CreateDirectory(folderPath1 + "" + Inwardno + "");



        //        // string path1 = ConfigurationManager.AppSettings["FolderPath"];

        //        //   string constrtpd = ConfigurationManager.ConnectionStrings["SqlHerculesAcmiilMaster"].ConnectionString;
        //        string constr = ConfigurationManager.ConnectionStrings["SqlHerculesAcmiilMaster"].ConnectionString;
        //        string pathDownloadCheck = pathDownloadDP + Inwardno + @" /" + Inwardno + ".pdf";


        //        if (System.IO.File.Exists(pathDownloadCheck))
        //        {
        //            // If file found, delete it    
        //            System.IO.File.Delete(pathDownloadCheck);
        //        }
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand("USP_InsertMARegistrationDetail", con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                cmd.Parameters.AddWithValue("@AgentSrno", Inwardno);
        //                cmd.Parameters.AddWithValue("@option", 8);
        //                cmd.Connection = con;
        //                cmd.CommandTimeout = 6000;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
        //                {
        //                    try
        //                    {

        //                        DataSet ds = new DataSet();
        //                        sda.Fill(ds);
        //                        DataTable dt = ds.Tables[0];
        //                        foreach (DataRow recomm in dt.Rows)
        //                        {
        //                            data1.SrNo = recomm["SrNo"].ToString();
        //                            data1.Products = recomm["Products"].ToString();
        //                            data1.AgentType = recomm["AgentType"].ToString();
        //                            data1.AgentSrno = recomm["AgentSrno"].ToString();
        //                            data1.AcmEmpName = recomm["AcmEmpName"].ToString();
        //                        }
        //                        var dto = new SignUP();
        //                        dto = data1;
        //                        byte[] data;
        //                        string FileToSetDataPDF = "";
        //                        FileToSetDataPDF = pathDownloadDP + "MA form1.pdf";
        //                        string fileNameNew = Inwardno + ".pdf";
        //                        PdfReader pdfReader = null;
        //                        Document document = null;
        //                        string newFilePDFMFESignProf = pathDownloadDP + Inwardno + @"/" + Inwardno + ".pdf";
        //                        //string strAttachment = ConfigurationManager.AppSettings["FolderPathDownloads"] + Inwardno + @"\" + fileNameNew;
        //                        using (document = new Document(PageSize.A4, 10, 10, 10, 10))
        //                        using (MemoryStream stream101 = new MemoryStream())
        //                        using (var existingFileStream = new FileStream(FileToSetDataPDF, FileMode.Open))
        //                        using (var FileStreamPDF = new FileStream(newFilePDFMFESignProf, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Read))
        //                        {
        //                            pdfReader = new PdfReader(existingFileStream);
        //                            document.Open();
        //                            var stamper = new PdfStamper(pdfReader, FileStreamPDF);
        //                            stamper.FreeTextFlattening = true;
        //                            var form = stamper.AcroFields;
        //                            var fieldKeys = form.Fields.Keys;
        //                            if (dto != null)
        //                            {
        //                                var pdfContentByteImage22 = stamper.GetOverContent(2);
        //                                BaseFont bfFontI2Page = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                pdfContentByteImage22.SetFontAndSize(bfFontI2Page, 7);

        //                                if (dto.AgentPhoto != "" && dto.AgentPhoto != null)
        //                                {
        //                                    var pdfContentByteImage = stamper.GetOverContent(1);
        //                                    var sigimageImage = Image.GetInstance(dto.AgentPhoto);
        //                                    sigimageImage.SetAbsolutePosition(490, 700);
        //                                    sigimageImage.ScaleAbsolute(63, 78);
        //                                    pdfContentByteImage.Rectangle(5, 5, 5, 5);
        //                                    pdfContentByteImage.AddImage(sigimageImage);
        //                                }
        //                                IDictionary<String, AcroFields.Item> fields = form.Fields;
        //                                foreach (String name in fields.Keys)
        //                                {
        //                                    form.SetFieldProperty(name, "textcolor", BaseColor.BLUE, null);
        //                                    form.SetFieldProperty(name, "textfont", Font.BOLD, null);
        //                                }
        //                                string Strname = dto.MA_Name.ToString();
        //                                int strnameCount = Strname.Length;
        //                                string Str1 = "";
        //                                string Str2 = "";
        //                                string Str3 = "";
        //                                string Str4 = "";
        //                                if (strnameCount <= 30)
        //                                {
        //                                    Str1 = Strname;
        //                                }
        //                                else if (strnameCount <= 120)
        //                                {
        //                                    Str1 = Strname.Substring(0, 29);
        //                                    if (strnameCount >= 30)
        //                                    {
        //                                        Str2 = Strname.Substring(30, strnameCount > 59 ? 29 : strnameCount - 30);

        //                                    }
        //                                    if (strnameCount >= 60)
        //                                    {
        //                                        Str3 = Strname.Substring(60, strnameCount > 89 ? 29 : strnameCount - 60);
        //                                    }
        //                                    if (strnameCount >= 90)
        //                                    {
        //                                        Str4 = Strname.Substring(90, strnameCount == 119 ? 20 : strnameCount - 90);
        //                                        //StrbankAddress3 = StrbankAddress.Substring(31, 60);
        //                                    }
        //                                }
        //                                ////////////////////////////////////////////
        //                                string StrRAddress = dto.Address1.ToString();
        //                                int strRAddressCount = StrRAddress.Length;
        //                                string StrRAddress1 = "";
        //                                string StrRAddress2 = "";
        //                                string StrRAddress3 = "";
        //                                string StrRAddress4 = "";
        //                                if (strRAddressCount <= 30)
        //                                {
        //                                    StrRAddress1 = StrRAddress;
        //                                }
        //                                else if (strRAddressCount <= 120)
        //                                {
        //                                    StrRAddress1 = StrRAddress.Substring(0, 29);
        //                                    if (strRAddressCount >= 30)
        //                                    {
        //                                        StrRAddress2 = StrRAddress.Substring(29, strRAddressCount > 59 ? 29 : strRAddressCount - 29);

        //                                    }
        //                                    if (strRAddressCount >= 60)
        //                                    {
        //                                        StrRAddress3 = StrRAddress.Substring(59, strRAddressCount > 89 ? 29 : strRAddressCount - 59);
        //                                    }
        //                                    if (strRAddressCount >= 90)
        //                                    {
        //                                        StrRAddress4 = StrRAddress.Substring(89, strRAddressCount == 119 ? 29 : strRAddressCount - 89);
        //                                        //StrbankAddress3 = StrbankAddress.Substring(31, 60);
        //                                    }
        //                                }
        //                                //////////////////////////////////////////////
        //                                string StrbankAddress = dto.BranchAddress.ToString();
        //                                int strAddressCount = StrbankAddress.Length;
        //                                string StrbankAddress1 = "";
        //                                string StrbankAddress2 = "";
        //                                string StrbankAddress3 = "";
        //                                string StrbankAddress4 = "";
        //                                if (strAddressCount <= 30)
        //                                {
        //                                    StrbankAddress1 = StrbankAddress;
        //                                }
        //                                else if (strAddressCount <= 120)
        //                                {
        //                                    StrbankAddress1 = StrbankAddress.Substring(0, 29);
        //                                    if (strAddressCount >= 30)
        //                                    {
        //                                        StrbankAddress2 = StrbankAddress.Substring(29, strAddressCount > 59 ? 29 : strAddressCount - 29);

        //                                    }
        //                                    if (strAddressCount >= 60)
        //                                    {
        //                                        StrbankAddress3 = StrbankAddress.Substring(59, strAddressCount > 89 ? 29 : strAddressCount - 59);
        //                                    }
        //                                    if (strAddressCount >= 90)
        //                                    {
        //                                        StrbankAddress4 = StrbankAddress.Substring(89, strAddressCount == 119 ? 29 : strAddressCount - 89);
        //                                        //StrbankAddress3 = StrbankAddress.Substring(31, 60);
        //                                    }
        //                                }

        //                                //////////////////////////////////////////////
        //                                string StrbankName = dto.AgentBankName.ToString();
        //                                int strbankNameCount = StrbankName.Length;
        //                                string StrbankName1 = "";
        //                                string StrbankName2 = "";
        //                                string StrbankName3 = "";
        //                                string StrbankName4 = "";
        //                                if (strbankNameCount <= 30)
        //                                {
        //                                    StrbankName1 = StrbankName;
        //                                }
        //                                else if (strAddressCount <= 120)
        //                                {
        //                                    StrbankName1 = StrbankName.Substring(0, 29);
        //                                    if (strbankNameCount >= 30)
        //                                    {
        //                                        StrbankName2 = StrbankName.Substring(29, strbankNameCount > 59 ? 29 : strbankNameCount - 29);

        //                                    }
        //                                    if (strbankNameCount >= 60)
        //                                    {
        //                                        StrbankName3 = StrbankName.Substring(59, strbankNameCount > 89 ? 29 : strbankNameCount - 59);
        //                                    }
        //                                    if (strbankNameCount >= 90)
        //                                    {
        //                                        StrbankName4 = StrbankName.Substring(89, strbankNameCount == 119 ? 29 : strbankNameCount - 89);
        //                                        ///StrbankAddress3 = StrbankAddress.Substring(31, 60);
        //                                    }
        //                                }
        //                                string strEmpName = dto.AcmEmpName.ToString();
        //                                int strEmpNameCount = strEmpName.Length;
        //                                string StrEmpName1 = "";
        //                                string StrEmpName2 = "";
        //                                string StrEmpName3 = "";
        //                                string StrEmpName4 = "";
        //                                if (strEmpNameCount <= 30)
        //                                {
        //                                    StrEmpName1 = strEmpName;
        //                                }
        //                                else if (strAddressCount <= 120)
        //                                {
        //                                    StrEmpName1 = strEmpName.Substring(0, 29);
        //                                    if (strEmpNameCount >= 30)
        //                                    {
        //                                        StrEmpName2 = strEmpName.Substring(29, strEmpNameCount > 59 ? 29 : strEmpNameCount - 29);

        //                                    }
        //                                    if (strbankNameCount >= 60)
        //                                    {
        //                                        StrEmpName3 = strEmpName.Substring(59, strEmpNameCount > 89 ? 29 : strEmpNameCount - 59);
        //                                    }
        //                                    if (strbankNameCount >= 90)
        //                                    {
        //                                        StrEmpName4 = strEmpName.Substring(89, strEmpNameCount == 119 ? 29 : strEmpNameCount - 89);
        //                                        //StrbankAddress3 = StrbankAddress.Substring(31, 60);
        //                                    }
        //                                }
        //                                form.SetField("Name", Str1.ToString());
        //                                form.SetField("Name1", Str2.ToString());
        //                                form.SetField("Name2", Str3.ToString());
        //                                form.SetField("Address", StrRAddress1);
        //                                form.SetField("Address1", StrRAddress2);
        //                                form.SetField("Address3", StrRAddress3);
        //                                form.SetField("Address4", StrRAddress4);
        //                                form.SetField("Mobile", dto.MobileNo);
        //                                form.SetField("Email", dto.EmailID);
        //                                form.SetField("DOB", dto.DateOfBirth);
        //                                form.SetField("Name as per Bank", StrbankName1);
        //                                form.SetField("Name as per Bank1", StrbankName2);
        //                                form.SetField("Name as per Bank2", StrbankName3);
        //                                form.SetField("Bank name", dto.BankName);
        //                                form.SetField("bank address", StrbankAddress1);
        //                                form.SetField("bankaddress1", StrbankAddress2);
        //                                form.SetField("bankaddress2", StrbankAddress3);
        //                                form.SetField("bankaddress3", StrbankAddress4);
        //                                form.SetField("Account Number", dto.BankAccNo);
        //                                form.SetField("MICR", dto.MICR);
        //                                form.SetField("IFSC", dto.IFSCcode);
        //                                form.SetField("PAN", dto.Pancard);
        //                                form.SetField("aadhar", dto.AadharCard);
        //                                form.SetField("ARN", dto.ARNNumber);
        //                                form.SetField("EUIN", dto.EUINNumber);
        //                                if (dto.OutsideName != string.Empty)
        //                                {
        //                                    form.SetField("Introducer name", dto.OutsideName);
        //                                }
        //                                if (dto.AcmEmpName != string.Empty)
        //                                {
        //                                    form.SetField("Introducer name", StrEmpName1);
        //                                    form.SetField("Introducer name1", StrEmpName2);

        //                                }

        //                                form.SetField("ACM code", dto.AcmRCcode ?? "");



        //                                if (dto.AgentType == "super")
        //                                {

        //                                    // form.SetField("C2", "YES", true);
        //                                    form.SetField("C2", "super", "true", true);
        //                                }
        //                                if (dto.AgentType == "mini")
        //                                {
        //                                    form.SetField("C1", "mini", "true", true);


        //                                }
        //                                if (dto.CollegeName != string.Empty)
        //                                {
        //                                    //   form.SetField("E1", "Yes", true);
        //                                    form.SetField("E1", "12th", "true", true);
        //                                }
        //                                if (dto.CollegeName1 != string.Empty)
        //                                {
        //                                    //  form.SetField("E2", "Yes", true);
        //                                    form.SetField("E2", "Graduate", "true", true);
        //                                }
        //                                if (dto.CollegeName2 != string.Empty)
        //                                {
        //                                    // form.SetField("E3", "Yes", true);
        //                                    form.SetField("E3", "Others", "true", true);
        //                                }

        //                                var s = dto.Products;
        //                                string[] values = s.Split(',');
        //                                for (int i = 0; i < values.Length; i++)
        //                                {
        //                                    values[i] = values[i].Trim();
        //                                    if (values[i] == "1")
        //                                    {
        //                                        form.SetField("P1", "Equities", "true", true);
        //                                    }
        //                                    if (values[i] == "4")
        //                                    {
        //                                        form.SetField("Products", "IPO", "true", true);

        //                                    }
        //                                    if (values[i] == "2")
        //                                    {
        //                                        form.SetField("P3", "NPS", "true", true);

        //                                    }
        //                                    if (values[i] == "5")
        //                                    {
        //                                        form.SetField("P4", "IB", "true", true);

        //                                    }
        //                                    if (values[i] == "3")
        //                                    {
        //                                        form.SetField("P5", "Alternate", "true", true);

        //                                    }
        //                                }

        //                                if (dto.AgentPhoto != string.Empty)
        //                                {
        //                                    form.SetField("M1", "photo", "true", true);
        //                                }
        //                                if (dto.AadharPhotoFront != string.Empty)
        //                                {
        //                                    form.SetField("M2", "Aadhar", "true", true);
        //                                }
        //                                if (dto.PancardPhoto != string.Empty)
        //                                {
        //                                    form.SetField("M3", "PAN", "true", true);
        //                                }
        //                                if (dto.AddressPhoto != string.Empty)
        //                                {
        //                                    form.SetField("M4", "Address", "true", true);
        //                                }
        //                                if (dto.CancelledCheque != string.Empty)
        //                                {
        //                                    form.SetField("M5", "Can cheque", "true", true);
        //                                }
        //                                if (dto.ARNCardPhoto != string.Empty)
        //                                {
        //                                    form.SetField("M6", "ARN", "true", true);
        //                                }
        //                                if (dto.ExamCertificate != string.Empty)
        //                                {
        //                                    form.SetField("M7", "Exam", "true", true);
        //                                }
        //                                if (dto.PancardPhoto != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 3; i <= 3; ++i) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte5 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage5 = Image.GetInstance(dto.PancardPhoto);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte5.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte5.SetFontAndSize(bf, 12);
        //                                    pdfContentByte5.BeginText();
        //                                    string text = "Pan Card Proof";
        //                                    pdfContentByte5.ShowTextAligned(1, text, 80, 820, 0);
        //                                    sigimage5.SetAbsolutePosition(40, 300);
        //                                    sigimage5.ScaleAbsoluteHeight(300);
        //                                    sigimage5.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte5.AddImage(sigimage5);

        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    // pdfpgcount = pdfpgcount;
        //                                }
        //                                if (dto.AadharPhotoFront != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 4; i <= 4; i++) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.AadharPhotoFront);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "Aadhar Proof Front";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);




        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }
        //                                if (dto.AadharPhotoBack != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 5; i <= 5; i++) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.AadharPhotoBack);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "Aadhar Proof Back";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);




        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }



        //                                if (dto.AddressPhoto != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 6; i <= 6; ++i) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.AddressPhoto);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "Address Proof";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);




        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }
        //                                if (dto.CancelledCheque != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 7; i <= 7; i++) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.CancelledCheque);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "Cancelled Cheque Proof";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);




        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }
        //                                if (dto.EuinPhotoName != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 8; i <= 8; i++) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.ARNCardPhoto);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "ARN Proof Back";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);
        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }
        //                                if (dto.EuinPhoto != string.Empty)
        //                                {
        //                                    var numberofPages = pdfReader.NumberOfPages;
        //                                    var rectangle = pdfReader.GetPageSize(1);
        //                                    var i = 0;
        //                                    for (i = 9; i <= 9; i++) stamper.InsertPage((i), rectangle);
        //                                    var pagecount = pdfReader.NumberOfPages;
        //                                    var pagenumber = i - 1;
        //                                    var pdfContentByte2 = stamper.GetOverContent(pagenumber);

        //                                    Image sigimage2 = Image.GetInstance(dto.EuinPhoto);
        //                                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //                                    pdfContentByte2.SetColorFill(BaseColor.BLACK);
        //                                    pdfContentByte2.SetFontAndSize(bf, 12);
        //                                    pdfContentByte2.BeginText();
        //                                    string text = "EUIN Proof";
        //                                    pdfContentByte2.ShowTextAligned(1, text, 80, 820, 0);

        //                                    // sigimage2.SetAbsolutePosition(38, 720);
        //                                    sigimage2.SetAbsolutePosition(40, 300);
        //                                    //RESH
        //                                    sigimage2.ScaleAbsoluteHeight(300);
        //                                    sigimage2.ScaleAbsoluteWidth(500);
        //                                    pdfContentByte2.AddImage(sigimage2);
        //                                    PdfContentByte canvas = stamper.GetOverContent(pagenumber);
        //                                    ColumnText.ShowTextAligned(canvas, Element.ALIGN_JUSTIFIED, new Phrase(DateTime.Now.ToString()), 175, 45, 0);

        //                                    //  pdfpgcount = pdfpgcount + 1;

        //                                }

        //                                stamper.FormFlattening = true;
        //                                stamper.PartialFormFlattening("field1");
        //                                stamper.Close();
        //                                pdfReader.Close();
        //                                data = stream101.ToArray();
        //                                document.Close();
        //                                string pathDownloads = pathDownloadDP + Inwardno + @"/" + Inwardno + ".pdf";

        //                                FileStream fs = new FileStream(pathDownloads, FileMode.Open, FileAccess.Read);


        //                                return File(fs, "application/pdf", fileNameNew);

        //                                //Saveinsertdata(Email_Id);
        //                            }
        //                            else
        //                            {
        //                                throw new Exception("no record found");
        //                            }

        //                        }

        //                    }

        //                    catch (Exception ex)
        //                    {
        //                        throw ex;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception exOuter)
        //    {
        //        throw exOuter;

        //    }
        //}

        public ActionResult signupnew()
        {
            return View();
        }

        public ActionResult EncodeDecode()
          
        {

            return View();
        }
        [HttpPost]
        public JsonResult Signuppage(Signupmodel FnlTest)
        {

            try
            {


                string msg = Signupmodel.Signuppage(FnlTest);
               
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult loginpage(Signupmodel FnlTest)
        {
            var valuedata = "";
            int n = 45698745;
            int reverse = 0;
            int  rem;
            try
            {
              //  int n, reverse = 0, rem;
               // Console.Write("Enter a number: ");
               // n = int.Parse(Console.ReadLine());
                while (n != 0)
                {
                    rem = n % 10;
                    reverse = reverse * 10 + rem;
                    n /= 10;
                }
               // Console.Write("Reversed Number: " + reverse);
                valuedata =("Reversed Number: " + reverse);


                string msg = Signupmodel.loginpage(FnlTest );
                // ViewBag.Message = "Hello from ViewBag!";
                // ViewBag.Message = "Hello from ViewBag!";

                var bigCities = new List<string>()
                    {
                        "New York",
                        "London",
                        "Mumbai",
                        "Chicago"
                    };

                foreach (var b in bigCities)
                {

                    if (b == "New York")
                    {
                        var df = b;
                    }
                    Console.WriteLine("the number is " + b);
                }


                string[] splitvalues = msg.Split(',', ',', ',');
                
                var xyz = splitvalues[0];
                return Json(splitvalues, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(HttpStatusCode.BadRequest, JsonRequestBehavior.AllowGet);
            }
        }

     
    }
}



