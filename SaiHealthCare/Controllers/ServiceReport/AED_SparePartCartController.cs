using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.InteropServices;

namespace SaiHealthCare.Controllers.ServiceReport
{
    public class AED_SparePartCartController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;
        //Add Spare Part Method 
        public HttpResponseMessage Post([FromBody] ADD_SparePartCart obj)
        {
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.SparePartCartID = obj.SparePartCartID == "" ? null : obj.SparePartCartID.Trim();
                obj.ServiceCallID = obj.ServiceCallID == "" ? null : obj.ServiceCallID.Trim();
                obj.SparePartName = obj.SparePartName == "" ? null : obj.SparePartName.Trim();
                obj.Charges = obj.Charges == "" ? null : obj.Charges.Trim();
                obj.PN = obj.PN == "" ? null : obj.PN.Trim();
                obj.OldSN = obj.OldSN == "" ? null : obj.OldSN.Trim();
                obj.NewSN = obj.NewSN == "" ? null : obj.NewSN.Trim();
                obj.Quantity = obj.Quantity == "" ? null : obj.Quantity.Trim();
                obj.Task = obj.Task == "" ? null : obj.Task.Trim();
               
                cmd = new SqlCommand("AED_SparePartCartAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@SparePartCartID", obj.SparePartCartID);
                cmd.Parameters.AddWithValue("@ServiceCallID", obj.ServiceCallID);
                cmd.Parameters.AddWithValue("@SparePartName", obj.SparePartName);
                cmd.Parameters.AddWithValue("@Charges", obj.Charges);
                cmd.Parameters.AddWithValue("@PN", obj.PN);
                cmd.Parameters.AddWithValue("@OldSN", obj.OldSN);
                cmd.Parameters.AddWithValue("@NewSN", obj.NewSN);
                cmd.Parameters.AddWithValue("@Quantity", obj.Quantity);
                cmd.Parameters.AddWithValue("@Task", obj.Task);

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
        //Get Spare Part Method 
        public HttpResponseMessage Post([FromBody] GET_SparePartCart obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.ServiceCallID = obj.ServiceCallID == "" ? null : obj.ServiceCallID.Trim();
                obj.Task = obj.Task == "" ? null : obj.Task.Trim();

                cmd = new SqlCommand("GET_SparePartCartAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@ServiceCallID", obj.ServiceCallID);
                cmd.Parameters.AddWithValue("@Task", obj.Task);

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
