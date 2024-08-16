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
    public class LeaveController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;


        public HttpResponseMessage Post([FromBody] ADD_LEAVE obj)
        {
            output = new Output();
            string rv = Master.RandomString(5);
            try
            {

                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.LEAVE_CATEGORY = obj.LEAVE_CATEGORY == "" ? null : obj.LEAVE_CATEGORY.Trim();
                obj.LEAVE_REASON = obj.LEAVE_REASON == "" ? null : obj.LEAVE_REASON.Trim();
                obj.LEAVE_TYPE = obj.LEAVE_TYPE == "" ? null : obj.LEAVE_TYPE.Trim();
                obj.FROM_DATE = obj.FROM_DATE == "" ? null : obj.FROM_DATE.Trim();
                obj.TO_DATE = obj.TO_DATE == "" ? null : obj.TO_DATE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("AED_LEAVE", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@LEAVE_CATEGORY", obj.LEAVE_CATEGORY);
                cmd.Parameters.AddWithValue("@LEAVE_REASON", obj.LEAVE_REASON);
                cmd.Parameters.AddWithValue("@LEAVE_TYPE", obj.LEAVE_TYPE);
                cmd.Parameters.AddWithValue("@FROM_DATE", obj.FROM_DATE);
                cmd.Parameters.AddWithValue("@TO_DATE", obj.TO_DATE);
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
        public HttpResponseMessage Post([FromBody] GET_LEAVE obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.FROM_DATE = obj.FROM_DATE == "" ? null : obj.FROM_DATE.Trim();
                obj.TO_DATE = obj.TO_DATE == "" ? null : obj.TO_DATE.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("GET_LEAVE", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                cmd.Parameters.AddWithValue("@FROM_DATE", obj.FROM_DATE);
                cmd.Parameters.AddWithValue("@TO_DATE", obj.TO_DATE);
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
