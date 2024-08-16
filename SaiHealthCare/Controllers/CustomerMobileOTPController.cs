using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace SaiHealthCare.Controllers
{
    public class CustomerMobileOTPController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        Output output;
        string mob;
        string msg, otp;

        private static Random random = new Random((int)DateTime.Now.Ticks);

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            int ch;

            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65));
                builder.Append(ch);
            }
            return builder.ToString();
        }
        public HttpResponseMessage Post([FromBody] Mobile_OTP value)
        {
            otp = RandomString(2);
           msg = "Dear User, Your OTP is " + otp + ". OTP is valid for 15 minutes. Do not share this OTP with anyone. Thanks from Sai Health Care.";
            cmd = new SqlCommand("Customer_Mobile_OTP", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CONTACT_NO", value.CONTACT_NO.Trim());
            cmd.Parameters.AddWithValue("@OTP", otp.Trim());

            mob = value.CONTACT_NO.Trim();

            if (con.State == System.Data.ConnectionState.Open) { con.Close(); }
            con.Open();
            object i = cmd.ExecuteScalar();
            con.Close();

            if (Convert.ToInt32(i.ToString()) > 0)
            {
                output = new Output() { ResponseCode = "0", ResponseMessage = "Success.! Please check your  MessageBox.", ID = otp.Trim(), DATA = "2468" };

                try
                {
                    Master.send(msg, mob);
                }
                catch (Exception ex)
                {
                }

            }
            else if (Convert.ToInt32(i.ToString()) == -1)
            {
                output = new Output() { ResponseCode = "1", ResponseMessage = "Account not exists with this mobile number, please contact to admin.", ID = "0", DATA = "2468" };

            }
            else
            {
                output = new Output() { ResponseCode = "2", ResponseMessage = "Error.", ID = "0", DATA = "2468" };

            }

            return Request.CreateResponse(HttpStatusCode.OK, output, "application/json");
        }
    }
}
