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
    public class AddEmployeeTaskController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADDEmployeeTask obj)
        {
            output = new Output();
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.EmployeeType = obj.EmployeeType == "" ? null : obj.EmployeeType.Trim();
                obj.Date = obj.Date == "" ? null : obj.Date.Trim();
                obj.Location = obj.Location == "" ? null : obj.Location.Trim();
                obj.TodaysWork = obj.TodaysWork == "" ? null : obj.TodaysWork.Trim();
                obj.Remark = obj.Remark == "" ? null : obj.Remark.Trim();
                obj.Latitude = obj.Latitude == "" ? null : obj.Latitude.Trim();
                obj.Longitude = obj.Longitude == "" ? null : obj.Longitude.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();
                obj.EXTRA4 = obj.EXTRA4 == "" ? null : obj.EXTRA4.Trim();

                cmd = new SqlCommand("AED_EmployeeTask", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
                cmd.Parameters.AddWithValue("@Date", obj.Date);
                cmd.Parameters.AddWithValue("@Location", obj.Location);
                cmd.Parameters.AddWithValue("@TodaysWork", obj.TodaysWork);
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                cmd.Parameters.AddWithValue("@Latitude", obj.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", obj.Longitude);
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

        public HttpResponseMessage Post([FromBody] Get_EmployeeTaskList obj, long id)
        {
            output2 = new Output2();

            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.EmployeeType = obj.EmployeeType == "" ? null : obj.EmployeeType.Trim();
                obj.StartDate = obj.StartDate == "" ? null : obj.StartDate.Trim();
                obj.EndDate = obj.EndDate == "" ? null : obj.EndDate.Trim();
                obj.WORD = obj.WORD == "" ? null : obj.WORD.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("GET_EmpDailyReportTask", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
                cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                cmd.Parameters.AddWithValue("@WORD", obj.WORD);
                cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                sda = new SqlDataAdapter(cmd);
                ds = new DataSet();
                sda.Fill(ds);

                output2.ResponseCode = "0";
                output2.ResponseMessage = " List";
                output2.DATA = ds.Tables[0];
                //output2.DATA1 = ds.Tables[1];
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
