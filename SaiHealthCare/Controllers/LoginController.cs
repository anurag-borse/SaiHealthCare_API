using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaiHealthCare.Models;
using SaiHealthCare.Data;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SaiHealthCare.Controllers
{
    public class LoginController : ApiController
    {
        private readonly SaiHealthCareRepository _repository;

        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public LoginController()
        {
            _repository = new SaiHealthCareRepository();
        }

        public HttpResponseMessage Post([FromBody] LOGIN_API obj)
        {
            output = new Output();
            string rv = Master.RandomString(5);
            try
            {
                obj.CONTACT_NO = string.IsNullOrEmpty(obj.CONTACT_NO) ? null : obj.CONTACT_NO.Trim();
                obj.PASSWORD = string.IsNullOrEmpty(obj.PASSWORD) ? null : obj.PASSWORD.Trim();
                obj.COMPANY_ID = string.IsNullOrEmpty(obj.COMPANY_ID) ? null : obj.COMPANY_ID.Trim();
                obj.EXTRA1 = string.IsNullOrEmpty(obj.EXTRA1) ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = string.IsNullOrEmpty(obj.EXTRA2) ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = string.IsNullOrEmpty(obj.EXTRA3) ? null : obj.EXTRA3.Trim();

                using (SqlConnection con = _repository.GetConnection())
                {
                    cmd = new SqlCommand("ApiLogin_SAIHC", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CONTACT_NO", obj.CONTACT_NO);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@COMPANY_ID", obj.COMPANY_ID);
                    cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                    cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                    cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                    sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables[1].Rows[0]["ResponseCode"].ToString() == "0")
                    {
                        output = new Output()
                        {
                            ResponseCode = ds.Tables[1].Rows[0]["ResponseCode"].ToString(),
                            ResponseMessage = ds.Tables[1].Rows[0]["ResponseMessage"].ToString(),
                            DATA = ds.Tables[0]
                        };
                    }
                    else
                    {
                        output = new Output()
                        {
                            ResponseCode = ds.Tables[1].Rows[0]["ResponseCode"].ToString(),
                            ResponseMessage = ds.Tables[1].Rows[0]["ResponseMessage"].ToString(),
                            DATA = ds.Tables[0]
                        };
                    }
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
