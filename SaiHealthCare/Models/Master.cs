using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Web;

namespace SaiHealthCare.Models
{
    public class Master
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        static SqlCommand cmd;
        static SqlDataAdapter sda;
        static DataTable dt;
        String varUserName = "";
        String varPWD = "";
        String varSenderID = "";
        private static Random random = new Random((int)DateTime.Now.Ticks);
        public static string RandomString(int size)
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
        public static int excutescalerqryint(String qry)
        {
            cmd = new SqlCommand(qry, con);
            // cmd.CommandTimeout = 160;
            con.Open();
            object i = cmd.ExecuteScalar();
            con.Close();
            if (Convert.ToInt32(i) > 0)
                return Convert.ToInt32(i);
            else
                return 0;
        }

        public static void sendmail(string mail1, string message, string title)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("", 587);
                mail.From = new MailAddress("");
                mail.To.Add(mail1.Trim());
                mail.Subject = title;
                mail.Body = message;
                SmtpServer.Credentials = new System.Net.NetworkCredential("", "");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {

            }
        }
        public static void send(string varMSG, string varPhNo)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create("  " + varPhNo + "&text=" + varMSG + "  ");
          HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }

        public static void sendTaskSMS(string varMSG, string varPhNo, string templateId)
        {
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(" " + varPhNo + "&text=" + varMSG + " " + templateId + "");
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();
            System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());
            string responseString = respStreamReader.ReadToEnd();
            respStreamReader.Close();
            myResp.Close();
        }

        public static string excutescalerqryString(String qry)
        {
            cmd = new SqlCommand(qry, con);
            //  cmd.CommandTimeout = 60;
            con.Open();
            Object i = cmd.ExecuteScalar();
            con.Close();
            if (i != null)
                return Convert.ToString(i);
            else
                return null;
        }
        public static DataTable fillData(String qry)
        {
            dt = new DataTable();
            cmd = new SqlCommand(qry, con);
            sda = new SqlDataAdapter(cmd);
            // cmd.CommandTimeout = 60;
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
                return dt;
            else
                return null;
        }

        public static void sendnotificationAll(string token)
        {
            string data = "";
            string Token = token;
            //string Message = message;
            WebRequest WebRequest = WebRequest.Create("https://onesignal.com/api/v1/notifications");
            WebRequest.Method = "post";
            WebRequest.ContentType = "application/json";
            WebRequest.Headers.Add("Authorization", "Basic N2UyNDA1MWMtMmFhOC00YmRmLWI3YjAtNjFjNDk3ODJkYTY0");
            data = "{\"app_id\":\"APPID\",\"included_segments\": [\"All\"],\"headings\":{\"en\":\"SAI\"},\"contents\": {\"en\": \"" + "" + "\"},  \"big_picture\":\"" + token + "\"}";//"big_picture":""
            Byte[] byteArray = Encoding.UTF8.GetBytes(data);
            WebRequest.ContentLength = byteArray.Length;
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (Stream dataStream = WebRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse WebResponse = WebRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = WebResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            string str = sResponseFromServer;
                        }
                    }
                }
            }
        }

        public static void sendnotificationJrToSrSalesTeam(string token, string message)
        {
            string data = "";
            string Token = token;
            //string Message = message;
            WebRequest WebRequest = WebRequest.Create("https://onesignal.com/api/v1/notifications");
            WebRequest.Method = "post";
            WebRequest.ContentType = "application/json";
            WebRequest.Headers.Add("Authorization", "Basic N2UyNDA1MWMtMmFhOC00YmRmLWI3YjAtNjFjNDk3ODJkYTY0");
            data = "{\"app_id\":\"APPID\",\"included_segments\": [\"All\"],\"headings\":{\"en\":\"SAI\"},\"contents\": {\"en\": \"" + "" + "\"},  \"big_picture\":\"" + token + "\"}";//"big_picture":""
            Byte[] byteArray = Encoding.UTF8.GetBytes(data);
            WebRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = WebRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse WebResponse = WebRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = WebResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            string str = sResponseFromServer;
                        }
                    }
                }
            }
        }
    }
}