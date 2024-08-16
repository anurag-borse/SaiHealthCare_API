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
    public class CustomerLoginAPIController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] CustomerLogin obj)
        {
            output = new Output();
            string rv = Master.RandomString(5);
            try
            {
                obj.CONTACT_NO = obj.CONTACT_NO == "" ? null : obj.CONTACT_NO.Trim();
                obj.COMPANY_ID = obj.COMPANY_ID == "" ? null : obj.COMPANY_ID.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("CustomerLoginAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CONTACT_NO", obj.CONTACT_NO);
                cmd.Parameters.AddWithValue("@COMPANY_ID", obj.COMPANY_ID);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds.Tables.Count > 1)
                {
                    output = new Output()
                    {
                        ResponseCode = ds.Tables[1].Rows[0]["ResponseCode"].ToString(),
                        ResponseMessage = ds.Tables[1].Rows[0]["ResponseMessage"].ToString(),
                        DATA = ds.Tables[0],
                        //DATA1 = ds.Tables[1]
                    };
                }
                else
                {
                    output = new Output()
                    {
                        ResponseCode = ds.Tables[0].Rows[0]["ResponseCode"].ToString(),
                        ResponseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString(),
                    };
                }
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
