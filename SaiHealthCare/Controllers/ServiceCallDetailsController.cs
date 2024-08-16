using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Policy;
using System.Web.Hosting;
using System.Web;

namespace SaiHealthCare.Controllers
{
    public class ServiceCallDetailsController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] AED_SERVICE_CALL obj)
        {
            output = new Output();
            string url1 = "";
            string rv = Master.RandomString(5);
            try
            {

                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.SERVICE_CALL_ID = obj.SERVICE_CALL_ID == "" ? null : obj.SERVICE_CALL_ID.Trim();
                obj.SP_ID = obj.SP_ID == "" ? null : obj.SP_ID.Trim();
                obj.QUANTITY = obj.QUANTITY == "" ? null : obj.QUANTITY.Trim();
                obj.AMOUNT = obj.AMOUNT == "" ? null : obj.AMOUNT.Trim();
                obj.LATITUDE = obj.LATITUDE == "" ? null : obj.LATITUDE.Trim();
                obj.LONGITUDE = obj.LONGITUDE == "" ? null : obj.LONGITUDE.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();
                obj.EXTRA4 = obj.EXTRA4 == "" ? null : obj.EXTRA4.Trim();

                try
                {

                    if (obj.PHOTO.Length > 0)
                    {
                        Byte[] data1; // = new Byte()[1];
                        data1 = (Byte[])(obj.PHOTO);
                        MemoryStream mem = new MemoryStream(data1);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(mem);
                        img.Save(HostingEnvironment.MapPath("~/ImagesUploaded/" + "ServiceReport" + rv.Trim() + ".jpg"), ImageFormat.Jpeg);
                        url1 = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + "ServiceReport" + rv.Trim() + ".jpg";
                    }
                }
                catch (Exception ex)
                {
                }

                cmd = new SqlCommand("AED_SPAREPART", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@SERVICE_CALL_ID", obj.SERVICE_CALL_ID);
                cmd.Parameters.AddWithValue("@SP_ID", obj.SP_ID);
                cmd.Parameters.AddWithValue("@QUANTITY", obj.QUANTITY);
                cmd.Parameters.AddWithValue("@AMOUNT", obj.AMOUNT);
                cmd.Parameters.AddWithValue("@LATITUDE", obj.LATITUDE);
                cmd.Parameters.AddWithValue("@LONGITUDE", obj.LONGITUDE);
                cmd.Parameters.AddWithValue("@TYPE", obj.TYPE);
                cmd.Parameters.AddWithValue("@PHOTO", url1);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);
                cmd.Parameters.AddWithValue("@EXTRA4", obj.EXTRA4);

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

        public HttpResponseMessage Post([FromBody] GET_SPARE_PART obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.SERVICE_CALL_ID = obj.SERVICE_CALL_ID == "" ? null : obj.SERVICE_CALL_ID.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("GET_SERVICE_CALL_DEATAILS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@SERVICE_CALL_ID", obj.SERVICE_CALL_ID);
                cmd.Parameters.AddWithValue("@TYPE", obj.TYPE);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);
                output2.ResponseCode = "0";
                output2.ResponseMessage = " List";
                output2.DATA = ds.Tables[0];
                output2.DATA1 = ds.Tables[1];
            }
            catch (Exception exp)
            {
                output2.ResponseCode = "1";
                output2.ResponseMessage = exp.Message;
                output2.DATA = null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, output2, "application/json");

        }
    }
}
