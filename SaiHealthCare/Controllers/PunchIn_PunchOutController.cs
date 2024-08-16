using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Hosting;
using System.Web;
using System.Web.Http;

namespace SaiHealthCare.Controllers
{
    public class PunchIn_PunchOutController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;


        public HttpResponseMessage Post([FromBody] PUNCHIN_PUNCHOUT obj)
        {
            output = new Output();
            string url1 = "";
            string url2 = "";
            string rv = Master.RandomString(5);
            try
            {

                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.CHECK_IN_TYPE = obj.CHECK_IN_TYPE == "" ? null : obj.CHECK_IN_TYPE.Trim();
                obj.VEHICAL_TYPE_ID = obj.VEHICAL_TYPE_ID == "" ? null : obj.VEHICAL_TYPE_ID.Trim();
                obj.LATITUDE = obj.LATITUDE == "" ? null : obj.LATITUDE.Trim();
                obj.LONGITUDE = obj.LONGITUDE == "" ? null : obj.LONGITUDE.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                try
                {

                    if (obj.ODOMETER_PHOTO_CHECK_IN.Length > 0)
                    {
                        Byte[] data1; // = new Byte()[1];
                        data1 = (Byte[])(obj.ODOMETER_PHOTO_CHECK_IN);
                        MemoryStream mem = new MemoryStream(data1);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(mem);
                        img.Save(HostingEnvironment.MapPath("~/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg"), ImageFormat.Jpeg);
                        url1 = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg";
                    }
                }
                catch (Exception ex)
                {
                }
                try
                {

                    if (obj.ODOMETER_PHOTO_CHECK_OUT.Length > 0)
                    {
                        Byte[] data1; // = new Byte()[1];
                        data1 = (Byte[])(obj.ODOMETER_PHOTO_CHECK_OUT);
                        MemoryStream mem = new MemoryStream(data1);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(mem);
                        img.Save(HostingEnvironment.MapPath("~/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg"), ImageFormat.Jpeg);
                        url2 = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg";
                    }
                }
                catch (Exception ex)
                {
                }

                cmd = new SqlCommand("CHECK_IN_CHECK_OUT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@CHECK_IN_TYPE", obj.CHECK_IN_TYPE);
                cmd.Parameters.AddWithValue("@VEHICAL_TYPE_ID", obj.VEHICAL_TYPE_ID);
                cmd.Parameters.AddWithValue("@LATITUDE", obj.LATITUDE);
                cmd.Parameters.AddWithValue("@LONGITUDE", obj.LONGITUDE);
                cmd.Parameters.AddWithValue("@ODOMETER_PHOTO_CHECK_IN", url1);
                cmd.Parameters.AddWithValue("@ODOMETER_PHOTO_CHECK_OUT", url2);
                cmd.Parameters.AddWithValue("@TYPE", obj.TYPE);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

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
