using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web.Hosting;
using System.Web;
using System.Web.Http;

namespace SaiHealthCare.Controllers
{
    public class EmployeeTaskController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;
        public HttpResponseMessage Post([FromBody] EmployeeTask obj)
        {
            output = new Output();

            try
            {

                obj.EmployeeId = obj.EmployeeId == "" ? null : obj.EmployeeId.Trim();
                obj.TaskTitle = obj.TaskTitle == "" ? null : obj.TaskTitle.Trim();
                obj.Description = obj.Description == "" ? null : obj.Description.Trim();
                obj.Category = obj.Category == "" ? null : obj.Category.Trim();
                obj.HospitalName = obj.HospitalName == "" ? null : obj.HospitalName.Trim();
                obj.Address = obj.Address == "" ? null : obj.Address.Trim();
                obj.City = obj.City == "" ? null : obj.City.Trim();
                obj.Type = obj.Type == "" ? null : obj.Type.Trim();
                obj.TaskId = obj.TaskId == "" ? null : obj.TaskId.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();

                

                cmd = new SqlCommand("InsertUpdate_EmployeeTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Type", obj.Type);
                cmd.Parameters.AddWithValue("@TaskId", obj.TaskId);
                cmd.Parameters.AddWithValue("@EmployeeId", obj.EmployeeId);
                cmd.Parameters.AddWithValue("@TaskTitle", obj.TaskTitle);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@Category", obj.Category);
                cmd.Parameters.AddWithValue("@HospitalName", obj.HospitalName);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@City", obj.City);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);

                sda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sda.Fill(ds);
                output = new Output()
                {
                    ResponseCode = ds.Tables[0].Rows[0]["ResponseCode"].ToString(),
                    ResponseMessage = ds.Tables[0].Rows[0]["ResponseMessage"].ToString(),
                    //DATA = ds.Tables[0],
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
