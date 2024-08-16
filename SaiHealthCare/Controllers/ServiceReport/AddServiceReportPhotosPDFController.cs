using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaiHealthCare.Models;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Policy;
using System.Web.Hosting;
using System.Web;
using SaiHealthCare.Models.ServiceReport;

namespace SaiHealthCare.Controllers.ServiceReport
{
    public class AddServiceReportPhotosPDFController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADD_ServiceReportPhotoPDF obj)
        {
            output = new Output();
            string url = "";
            string rv = Master.RandomString(5);
            try
            {
                obj.ServiceReportID = obj.ServiceReportID == "" ? null : obj.ServiceReportID.Trim();
                obj.ServiceReportPDF = obj.ServiceReportPDF == "" ? null : obj.ServiceReportPDF.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();

                try
                {

                    if (obj.ServiceReportPhoto.Length > 0)
                    {
                        Byte[] data1; // = new Byte()[1];
                        data1 = (Byte[])(obj.ServiceReportPhoto);
                        MemoryStream mem = new MemoryStream(data1);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(mem);
                        img.Save(HostingEnvironment.MapPath("~/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg"), ImageFormat.Jpeg);
                        url = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg";
                    }
                }
                catch (Exception ex)
                {
                }

                cmd = new SqlCommand("AED_ServiceReportPhotoPDF", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ServiceReportID", obj.ServiceReportID);
                cmd.Parameters.AddWithValue("@ServiceReportPDF", obj.ServiceReportPDF);
                cmd.Parameters.AddWithValue("@ServiceReportPhoto", url);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);

                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                output = new Output()
                {
                    ResponseCode = ds.Tables[0].Rows[0]["ResponseCode"].ToString(),
                    ResponseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString(),
                    DATA = ds.Tables[0],
                    //DATA1 = ds.Tables[1]
                };
            }
            catch (Exception exp)
            {
                output.ResponseCode = "1";
                output.ResponseMessage = exp.Message;
                output.DATA = null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, output, "application/json");

        }
    }
}
