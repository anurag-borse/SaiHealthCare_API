using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaiHealthCare.Controllers
{
    public class AddCustomerDataController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADD_CustomerData obj)
        {
            output = new Output();
            try
            {
                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.CUSTOMER_NAME = obj.CUSTOMER_NAME == "" ? null : obj.CUSTOMER_NAME.Trim();
                obj.MOBILE_NO = obj.MOBILE_NO == "" ? null : obj.MOBILE_NO.Trim();
                obj.EXISTING_REQUIRMENT = obj.EXISTING_REQUIRMENT == "" ? null : obj.EXISTING_REQUIRMENT.Trim();
                obj.NEW_REQUIRMENT = obj.NEW_REQUIRMENT == "" ? null : obj.NEW_REQUIRMENT.Trim();
                obj.ENQUIRY_TYPE = obj.ENQUIRY_TYPE == "" ? null : obj.ENQUIRY_TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("AED_CustomerRowData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_NAME", obj.CUSTOMER_NAME);
                cmd.Parameters.AddWithValue("@MOBILE_NO", obj.MOBILE_NO);
                cmd.Parameters.AddWithValue("@EXISTING_REQUIRMENT", obj.EXISTING_REQUIRMENT);
                cmd.Parameters.AddWithValue("@NEW_REQUIRMENT", obj.NEW_REQUIRMENT);
                cmd.Parameters.AddWithValue("@ENQUIRY_TYPE", obj.ENQUIRY_TYPE);
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

        public HttpResponseMessage Post([FromBody] Get_CustomerData obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("GET_CustomerRowData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
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
