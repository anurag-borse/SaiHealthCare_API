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
    public class CustomerEnquiryController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADD_CustomerEnquiry obj)
        {
            output = new Output();
            try
            {
                obj.Customer_ID = obj.Customer_ID == "" ? null : obj.Customer_ID.Trim();
                obj.P_ID = obj.P_ID == "" ? null : obj.P_ID.Trim();
                obj.CUSTOMER_REMARK = obj.CUSTOMER_REMARK == "" ? null : obj.CUSTOMER_REMARK.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("AED_CustomerEnquiry", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Customer_ID", obj.Customer_ID);
                cmd.Parameters.AddWithValue("@P_ID", obj.P_ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_REMARK", obj.CUSTOMER_REMARK);
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

        public HttpResponseMessage Post([FromBody] Get_CustomerEnquiry obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.Customer_ID = obj.Customer_ID == "" ? null : obj.Customer_ID.Trim();
                obj.TYPE = obj.TYPE == "" ? null : obj.TYPE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("Get_CustomerEnquiry", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Customer_ID", obj.Customer_ID);
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
