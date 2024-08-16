using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaiHealthCare.Models.ServiceReport;

namespace SaiHealthCare.Controllers.ServiceReport
{
    public class GetServiceReportFormController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output2 output2;
        DataSet ds;
        DataTable dtData;

        public HttpResponseMessage Post([FromBody] GetServiceReportForm obj)
        {
            output2 = new Output2();
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.M_ID = obj.M_ID == "" ? null : obj.M_ID.Trim();
                obj.CAT_ID = obj.CAT_ID == "" ? null : obj.CAT_ID.Trim();
                obj.CUSTOMER_TYPE_ID = obj.CUSTOMER_TYPE_ID == "" ? null : obj.CUSTOMER_TYPE_ID.Trim();
                obj.CompanyType = obj.CompanyType == "" ? null : obj.CompanyType.Trim();

                cmd = new SqlCommand("Api_GenerateServiceReport", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@M_ID", obj.M_ID);
                cmd.Parameters.AddWithValue("@CAT_ID", obj.CAT_ID);
                cmd.Parameters.AddWithValue("@CUSTOMER_TYPE_ID", obj.CUSTOMER_TYPE_ID);
                cmd.Parameters.AddWithValue("@CompanyType", obj.CompanyType);

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
