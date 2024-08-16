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
    public class LEADController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADD_LEAD obj)
        {
            output = new Output();
            string url1 = "";
            string rv = Master.RandomString(5);
            try
            {

                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.COMPANY_ID = obj.COMPANY_ID == "" ? null : obj.COMPANY_ID.Trim();
                obj.DSR_DATE = obj.DSR_DATE == "" ? null : obj.DSR_DATE.Trim();
                obj.CUSTOMER_NAME = obj.CUSTOMER_NAME == "" ? null : obj.CUSTOMER_NAME.Trim();
                obj.FIRM_NAME = obj.FIRM_NAME == "" ? null : obj.FIRM_NAME.Trim();
                obj.FIRM_ADDRESS = obj.FIRM_ADDRESS == "" ? null : obj.FIRM_ADDRESS .Trim();
                obj.CITY_NAME = obj.CITY_NAME == "" ? null : obj.CITY_NAME.Trim();
                obj.MOBILE_NO = obj.MOBILE_NO == "" ? null : obj.MOBILE_NO.Trim();
                obj.MODALITY = obj.MODALITY == "" ? null : obj.MODALITY.Trim();
                obj.EMAIL_ID = obj.EMAIL_ID == "" ? null : obj.EMAIL_ID.Trim();
                obj.PROJECHTED_MODEL = obj.PROJECHTED_MODEL == "" ? null : obj.PROJECHTED_MODEL.Trim();
                obj.CUSTOMER_REQUIREMENT = obj.CUSTOMER_REQUIREMENT == "" ? null : obj.CUSTOMER_REQUIREMENT.Trim();
                obj.SALES_PERSON_COMMITMENTS = obj.SALES_PERSON_COMMITMENTS == "" ? null : obj.SALES_PERSON_COMMITMENTS.Trim();
                obj.FORCASTED_MONTH = obj.FORCASTED_MONTH == "" ? null : obj.FORCASTED_MONTH.Trim();
                obj.PRICE = obj.PRICE == "" ? null : obj.PRICE.Trim();
                obj.BUY_PERCENT = obj.BUY_PERCENT == "" ? null : obj.BUY_PERCENT.Trim();
                obj.ENQUIRY_TYPE = obj.ENQUIRY_TYPE == "" ? null : obj.ENQUIRY_TYPE.Trim();
               
                try
                {

                    if (obj.UPLOAD_VISITING_CARD.Length > 0)
                    {
                        Byte[] data1; // = new Byte()[1];
                        data1 = (Byte[])(obj.UPLOAD_VISITING_CARD);
                        MemoryStream mem = new MemoryStream(data1);
                        System.Drawing.Image img = System.Drawing.Image.FromStream(mem);
                        img.Save(HostingEnvironment.MapPath("~/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg"), ImageFormat.Jpeg);
                        url1 = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + "PHOTO" + rv.Trim() + ".jpg";
                    }
                }
                catch (Exception ex)
                {
                }

                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("AED_LEADS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@COMPANY_ID", obj.COMPANY_ID);
                cmd.Parameters.AddWithValue("@DSR_DATE", obj.DSR_DATE);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", obj.CUSTOMER_NAME);
                cmd.Parameters.AddWithValue("@FIRM_NAME", obj.FIRM_NAME);
                cmd.Parameters.AddWithValue("@FIRM_ADDRESS", obj.FIRM_ADDRESS);
                cmd.Parameters.AddWithValue("@CITY_NAME", obj.CITY_NAME);
                cmd.Parameters.AddWithValue("@MOBILE_NO", obj.MOBILE_NO);
                cmd.Parameters.AddWithValue("@MODALITY", obj.MODALITY);
                cmd.Parameters.AddWithValue("@EMAIL_ID", obj.EMAIL_ID);
                cmd.Parameters.AddWithValue("@PROJECHTED_MODEL", obj.PROJECHTED_MODEL);
                cmd.Parameters.AddWithValue("@CUSTOMER_REQUIREMENT", obj.CUSTOMER_REQUIREMENT);
                cmd.Parameters.AddWithValue("@SALES_PERSON_COMMITMENTS", obj.SALES_PERSON_COMMITMENTS);
                cmd.Parameters.AddWithValue("@FORCASTED_MONTH", obj.FORCASTED_MONTH);
                cmd.Parameters.AddWithValue("@PRICE", obj.PRICE);
                cmd.Parameters.AddWithValue("@BUY_PERCENT", obj.BUY_PERCENT);
                cmd.Parameters.AddWithValue("@ENQUIRY_TYPE", obj.ENQUIRY_TYPE);
                cmd.Parameters.AddWithValue("@UPLOAD_VISITING_CARD", url1);
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
        public HttpResponseMessage Post([FromBody] GET_LEAD obj, long id)
        {
            output2 = new Output2();
            try
            {

                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("GET_LEADS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
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
