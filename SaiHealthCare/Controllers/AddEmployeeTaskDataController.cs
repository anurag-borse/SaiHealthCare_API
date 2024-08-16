using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace SaiHealthCare.Controllers
{
    public class AddEmployeeTaskDataController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public HttpResponseMessage Post([FromBody] ADD_EmployeeTaskData obj)
        {
            output = new Output();
            try
            {

                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.EmployeeTaskID = obj.EmployeeTaskID == "" ? null : obj.EmployeeTaskID.Trim();
                obj.EmployeeType = obj.EmployeeType == "" ? null : obj.EmployeeType.Trim();
                obj.AllocatedWork = obj.AllocatedWork == "" ? null : obj.AllocatedWork.Trim();
                obj.WorkResult = obj.WorkResult == "" ? null : obj.WorkResult.Trim();
                obj.Remark = obj.Remark == "" ? null : obj.Remark.Trim();
                obj.NewLearning = obj.NewLearning == "" ? null : obj.NewLearning.Trim();
                obj.Location = obj.Location == "" ? null : obj.Location.Trim();
                obj.HospitalName = obj.HospitalName == "" ? null : obj.HospitalName.Trim();
                obj.CustomerDetails = obj.CustomerDetails == "" ? null : obj.CustomerDetails.Trim();
                obj.ServiceEngReason = obj.ServiceEngReason == "" ? null : obj.ServiceEngReason.Trim();
                obj.DoctorName = obj.DoctorName == "" ? null : obj.DoctorName.Trim();
                obj.ContactNumber = obj.ContactNumber == "" ? null : obj.ContactNumber.Trim();
                obj.ExistingModel = obj.ExistingModel == "" ? null : obj.ExistingModel.Trim();
                obj.ProposedModel = obj.ProposedModel == "" ? null : obj.ProposedModel.Trim();
                obj.SalesTeamStatus = obj.SalesTeamStatus == "" ? null : obj.SalesTeamStatus.Trim();
                obj.Purpose = obj.Purpose == "" ? null : obj.Purpose.Trim();
                obj.WarehouseType = obj.WarehouseType == "" ? null : obj.WarehouseType.Trim();
                obj.CleaningOff = obj.CleaningOff == "" ? null : obj.CleaningOff.Trim();
                obj.Type = obj.Type == "" ? null : obj.Type.Trim();
                obj.EquipmentsPartDetails = obj.EquipmentsPartDetails == "" ? null : obj.EquipmentsPartDetails.Trim();
                obj.InTime = obj.InTime == "" ? null : obj.InTime.Trim();
                obj.OutTime = obj.OutTime == "" ? null : obj.OutTime.Trim();
                obj.PersonFrom = obj.PersonFrom == "" ? null : obj.PersonFrom.Trim();
                obj.PersonName = obj.PersonName == "" ? null : obj.PersonName.Trim();
                obj.WhoAskForIt = obj.WhoAskForIt == "" ? null : obj.WhoAskForIt.Trim();
                obj.DCNumber = obj.DCNumber == "" ? null : obj.DCNumber.Trim();
                obj.Latitude = obj.Latitude == "" ? null : obj.Latitude.Trim();
                obj.Longitude = obj.Longitude == "" ? null : obj.Longitude.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("AED_EmployeeTaskData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeTaskID", obj.EmployeeTaskID);
                cmd.Parameters.AddWithValue("@EmployeeType", obj.EmployeeType);
                cmd.Parameters.AddWithValue("@AllocatedWork", obj.AllocatedWork);
                cmd.Parameters.AddWithValue("@WorkResult", obj.WorkResult);
                cmd.Parameters.AddWithValue("@Remark", obj.Remark);
                cmd.Parameters.AddWithValue("@NewLearning", obj.NewLearning);
                cmd.Parameters.AddWithValue("@Location", obj.Location);
                cmd.Parameters.AddWithValue("@HospitalName", obj.HospitalName);
                cmd.Parameters.AddWithValue("@CustomerDetails", obj.CustomerDetails);
                cmd.Parameters.AddWithValue("@ServiceEngReason", obj.ServiceEngReason);
                cmd.Parameters.AddWithValue("@DoctorName", obj.DoctorName);
                cmd.Parameters.AddWithValue("@ContactNumber", obj.ContactNumber);
                cmd.Parameters.AddWithValue("@ExistingModel", obj.ExistingModel);
                cmd.Parameters.AddWithValue("@ProposedModel", obj.ProposedModel);
                cmd.Parameters.AddWithValue("@SalesTeamStatus", obj.SalesTeamStatus);
                cmd.Parameters.AddWithValue("@Purpose", obj.Purpose);
                cmd.Parameters.AddWithValue("@WarehouseType", obj.WarehouseType);
                cmd.Parameters.AddWithValue("@CleaningOff", obj.CleaningOff);
                cmd.Parameters.AddWithValue("@Type", obj.Type);
                cmd.Parameters.AddWithValue("@EquipmentsPartDetails", obj.EquipmentsPartDetails);
                cmd.Parameters.AddWithValue("@InTime", obj.InTime);
                cmd.Parameters.AddWithValue("@OutTime", obj.OutTime);
                cmd.Parameters.AddWithValue("@PersonFrom", obj.PersonFrom);
                cmd.Parameters.AddWithValue("@PersonName", obj.PersonName);
                cmd.Parameters.AddWithValue("@WhoAskForIt", obj.WhoAskForIt);
                cmd.Parameters.AddWithValue("@DCNumber", obj.DCNumber);
                cmd.Parameters.AddWithValue("@Latitude", obj.Latitude);
                cmd.Parameters.AddWithValue("@Longitude", obj.Longitude);
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

        public HttpResponseMessage Post([FromBody] Get_EmployeeTaskDataList obj, long id)
        {
            output2 = new Output2();

            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.EmployeeTaskID = obj.EmployeeTaskID == "" ? null : obj.EmployeeTaskID.Trim();
                obj.EmployeeType = obj.EmployeeType == "" ? null : obj.EmployeeType.Trim();
                obj.StartDate = obj.StartDate == "" ? null : obj.StartDate.Trim();
                obj.EndDate = obj.EndDate == "" ? null : obj.EndDate.Trim();
                obj.WORD = obj.WORD == "" ? null : obj.WORD.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                cmd = new SqlCommand("Get_EmployeeTaskData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@EmployeeTaskID", obj.EmployeeTaskID);
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
