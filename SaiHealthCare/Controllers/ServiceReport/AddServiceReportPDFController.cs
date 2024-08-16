using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web;
using System.Web.Http;

namespace SaiHealthCare.Controllers.ServiceReport
{
    public class AddServiceReportPDFController : ApiController
    {
        Output output;
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dtData;
        public HttpResponseMessage Post()
        {
            try
            {
                HttpResponseMessage result = null;
                var httpRequest = HttpContext.Current.Request;
                if (httpRequest.Files.Count > 0)
                {
                    var docfiles = new List<string>();
                    var filePath = "";
                    var filePath1 = "";
                    var extension1 = "";
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];

                        filePath1 = postedFile.FileName;
                        extension1 = Path.GetExtension(postedFile.FileName);
                        filePath = HttpContext.Current.Server.MapPath("~/ImagesUploaded/" + postedFile.FileName);
                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);
                    }
                    string s = httpRequest.Params["EXTRA"] + "_" + httpRequest.Params["EXTRA1"] + "_" + httpRequest.Params["EXTRA2"] + "_" + DateTime.Now.ToString("MM_dd_yyyy_hh_mm_ss_tt") + "_" + Master.RandomString(5);//Master.RandomString(7);

                    byte[] imageByteData = System.IO.File.ReadAllBytes(filePath);
                    System.IO.File.WriteAllBytes(HostingEnvironment.MapPath("~/ImagesUploaded/" + s + extension1), imageByteData);
                    string url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + s + extension1;


                    cmd = new SqlCommand("Upload_Document_PDF", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PhotosPDFID", httpRequest.Params["PhotosPDFID"]);
                    cmd.Parameters.AddWithValue("@TYPE", httpRequest.Params["TYPE"]);
                    cmd.Parameters.AddWithValue("@EXTRA", httpRequest.Params["EXTRA"]);
                    cmd.Parameters.AddWithValue("@EXTRA1", httpRequest.Params["EXTRA1"]);
                    cmd.Parameters.AddWithValue("@EXTRA2", httpRequest.Params["EXTRA2"]);
                    cmd.Parameters.AddWithValue("@FILE_NAME", httpRequest.Params["FILE_NAME"]);
                    cmd.Parameters.AddWithValue("@FILE_URL", url);

                    if (con.State == System.Data.ConnectionState.Open) { con.Close(); }
                    con.Open();
                    object i = cmd.ExecuteScalar();
                    con.Close();
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                output = new Output() { ResponseCode = "0", ResponseMessage = "Failed." };

            }
            output = new Output() { ResponseCode = "0", ResponseMessage = "document added successfully." };
            return Request.CreateResponse(HttpStatusCode.OK, output, "application/json");
        }
    }
}
