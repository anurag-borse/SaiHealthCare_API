using SaiHealthCare.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Helpers;
using SaiHealthCare.Models.ServiceReport;

namespace SaiHealthCare.Controllers.ServiceReport
{
    public class AED_ServiceReportController : ApiController
    {
        SqlConnection con = new SqlConnection(Properties.Settings.Default.dbconnection);
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;
        //Add Service report Method 
        public HttpResponseMessage Post([FromBody] ADD_ServiceReport obj)
        {
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.ServiceCallID = obj.ServiceCallID == "" ? null : obj.ServiceCallID.Trim();
                obj.CompanyType = obj.CompanyType == "" ? null : obj.CompanyType.Trim();
                obj.CustomerDetails = obj.CustomerDetails == "" ? null : obj.CustomerDetails.Trim();
                obj.SerialNumber = obj.SerialNumber == "" ? null : obj.SerialNumber.Trim();
                obj.Date = obj.Date == "" ? null : obj.Date.Trim();
                obj.ModelNumber = obj.ModelNumber == "" ? null : obj.ModelNumber.Trim();
                obj.Make = obj.Make == "" ? null : obj.Make.Trim();
                obj.SWVersion = obj.SWVersion == "" ? null : obj.SWVersion.Trim();
                obj.NatureOfProblem = obj.NatureOfProblem == "" ? null : obj.NatureOfProblem.Trim();
                obj.WorkDoneSolution = obj.WorkDoneSolution == "" ? null : obj.WorkDoneSolution.Trim();
                obj.ServiceType = obj.ServiceType == "" ? null : obj.ServiceType.Trim();
                obj.ServiceCharges = obj.ServiceCharges == "" ? null : obj.ServiceCharges.Trim();
                obj.Total = obj.Total == "" ? null : obj.Total.Trim();
                obj.AmountInWord = obj.AmountInWord == "" ? null : obj.AmountInWord.Trim();
                obj.EngineerRemark = obj.EngineerRemark == "" ? null : obj.EngineerRemark.Trim();
                obj.PaymentsDetails = obj.PaymentsDetails == "" ? null : obj.PaymentsDetails.Trim();
                obj.PaidAmount = obj.PaidAmount == "" ? null : obj.PaidAmount.Trim();
                obj.BalanceAmount = obj.BalanceAmount == "" ? null : obj.BalanceAmount.Trim();
                obj.SelectWork = obj.SelectWork == "" ? null : obj.SelectWork.Trim();
                obj.SelectCategory = obj.SelectCategory == "" ? null : obj.SelectCategory.Trim();
                obj.HospitalDiagnosticCenter = obj.HospitalDiagnosticCenter == "" ? null : obj.HospitalDiagnosticCenter.Trim();
                obj.Address = obj.Address == "" ? null : obj.Address.Trim();
                obj.Department = obj.Department == "" ? null : obj.Department.Trim();
                obj.ContactPerson = obj.ContactPerson == "" ? null : obj.ContactPerson.Trim();
                obj.Telephone = obj.Telephone == "" ? null : obj.Telephone.Trim();
                obj.MobileNumber = obj.MobileNumber == "" ? null : obj.MobileNumber.Trim();
                obj.ZipPostalCode = obj.ZipPostalCode == "" ? null : obj.ZipPostalCode.Trim();
                obj.Title = obj.Title == "" ? null : obj.Title.Trim();
                obj.Email = obj.Email == "" ? null : obj.Email.Trim();
                obj.ModelName = obj.ModelName == "" ? null : obj.ModelName.Trim();
                obj.Accessories = obj.Accessories == "" ? null : obj.Accessories.Trim();
                obj.Warranty = obj.Warranty == "" ? null : obj.Warranty.Trim();
                obj.WarrantyStartDate = obj.WarrantyStartDate == "" ? null : obj.WarrantyStartDate.Trim();
                obj.WarrantyEndDate = obj.WarrantyEndDate == "" ? null : obj.WarrantyEndDate.Trim();
                obj.ServiceInformation = obj.ServiceInformation == "" ? null : obj.ServiceInformation.Trim();
                obj.MalfunctionDescription = obj.MalfunctionDescription == "" ? null : obj.MalfunctionDescription.Trim();
                obj.ServiceProcess = obj.ServiceProcess == "" ? null : obj.ServiceProcess.Trim();
                obj.CS_SpecificSuggestion = obj.CS_SpecificSuggestion == "" ? null : obj.CS_SpecificSuggestion.Trim();
                obj.FunctionTest = obj.FunctionTest == "" ? null : obj.FunctionTest.Trim();
                obj.SafetyInspection = obj.SafetyInspection == "" ? null : obj.SafetyInspection.Trim();
                obj.SoftwareUpgrade = obj.SoftwareUpgrade == "" ? null : obj.SoftwareUpgrade.Trim();
                obj.NewSoftwareVersion = obj.NewSoftwareVersion == "" ? null : obj.NewSoftwareVersion.Trim();
                obj.SatisfactionFeedback = obj.SatisfactionFeedback == "" ? null : obj.SatisfactionFeedback.Trim();
                obj.Comment = obj.Comment == "" ? null : obj.Comment.Trim();
                obj.CustomerName = obj.CustomerName == "" ? null : obj.CustomerName.Trim();
                obj.EngineerName = obj.EngineerName == "" ? null : obj.EngineerName.Trim();
                obj.BankName = obj.BankName == "" ? null : obj.BankName.Trim();
                obj.IFSCCode = obj.IFSCCode == "" ? null : obj.IFSCCode.Trim();
                obj.Task = obj.Task == "" ? null : obj.Task.Trim();

                cmd = new SqlCommand("AED_ServiceReportAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@ServiceCallID", obj.ServiceCallID);
                cmd.Parameters.AddWithValue("@CompanyType", obj.CompanyType);
                cmd.Parameters.AddWithValue("@CustomerDetails", obj.CustomerDetails);
                cmd.Parameters.AddWithValue("@SerialNumber", obj.SerialNumber);
                cmd.Parameters.AddWithValue("@Date", obj.Date);
                cmd.Parameters.AddWithValue("@ModelNumber", obj.ModelNumber);
                cmd.Parameters.AddWithValue("@Make", obj.Make);
                cmd.Parameters.AddWithValue("@SWVersion", obj.SWVersion);
                cmd.Parameters.AddWithValue("@NatureOfProblem", obj.NatureOfProblem);
                cmd.Parameters.AddWithValue("@WorkDoneSolution", obj.WorkDoneSolution);
                cmd.Parameters.AddWithValue("@ServiceType", obj.ServiceType);
                cmd.Parameters.AddWithValue("@ServiceCharges", obj.ServiceCharges);
                cmd.Parameters.AddWithValue("@Total", obj.Total);
                cmd.Parameters.AddWithValue("@AmountInWord", obj.AmountInWord);
                cmd.Parameters.AddWithValue("@EngineerRemark", obj.EngineerRemark);
                cmd.Parameters.AddWithValue("@PaymentsDetails", obj.PaymentsDetails);
                cmd.Parameters.AddWithValue("@PaidAmount", obj.PaidAmount);
                cmd.Parameters.AddWithValue("@BalanceAmount", obj.BalanceAmount);
                cmd.Parameters.AddWithValue("@SelectWork", obj.SelectWork);
                cmd.Parameters.AddWithValue("@SelectCategory", obj.SelectCategory);
                cmd.Parameters.AddWithValue("@HospitalDiagnosticCenter", obj.HospitalDiagnosticCenter);
                cmd.Parameters.AddWithValue("@Address", obj.Address);
                cmd.Parameters.AddWithValue("@Department", obj.Department);
                cmd.Parameters.AddWithValue("@ContactPerson", obj.ContactPerson);
                cmd.Parameters.AddWithValue("@Telephone", obj.Telephone);
                cmd.Parameters.AddWithValue("@MobileNumber", obj.MobileNumber);
                cmd.Parameters.AddWithValue("@ZipPostalCode", obj.ZipPostalCode);
                cmd.Parameters.AddWithValue("@Title", obj.Title);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@ModelName", obj.ModelName);
                cmd.Parameters.AddWithValue("@Accessories", obj.Accessories);
                cmd.Parameters.AddWithValue("@Warranty", obj.Warranty);
                cmd.Parameters.AddWithValue("@WarrantyStartDate", obj.WarrantyStartDate);
                cmd.Parameters.AddWithValue("@WarrantyEndDate", obj.WarrantyEndDate);
                cmd.Parameters.AddWithValue("@ServiceInformation", obj.ServiceInformation);
                cmd.Parameters.AddWithValue("@MalfunctionDescription", obj.MalfunctionDescription);
                cmd.Parameters.AddWithValue("@ServiceProcess", obj.ServiceProcess);
                cmd.Parameters.AddWithValue("@CS_SpecificSuggestion", obj.CS_SpecificSuggestion);
                cmd.Parameters.AddWithValue("@FunctionTest", obj.FunctionTest);
                cmd.Parameters.AddWithValue("@SafetyInspection", obj.SafetyInspection);
                cmd.Parameters.AddWithValue("@SoftwareUpgrade", obj.SoftwareUpgrade);
                cmd.Parameters.AddWithValue("@NewSoftwareVersion", obj.NewSoftwareVersion);
                cmd.Parameters.AddWithValue("@SatisfactionFeedback", obj.SatisfactionFeedback);
                cmd.Parameters.AddWithValue("@Comment", obj.Comment);
                cmd.Parameters.AddWithValue("@CustomerName", obj.CustomerName);
                cmd.Parameters.AddWithValue("@EngineerName", obj.EngineerName);
                cmd.Parameters.AddWithValue("@BankName", obj.BankName);
                cmd.Parameters.AddWithValue("@IFSCCode", obj.IFSCCode);
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
        //Add Service report Method 
        public HttpResponseMessage Post([FromBody] GET_ServiceReport obj, long id)
        {
            output2 = new Output2();
            try
            {
                obj.EmployeeID = obj.EmployeeID == "" ? null : obj.EmployeeID.Trim();
                obj.ServiceCallID = obj.ServiceCallID == "" ? null : obj.ServiceCallID.Trim();
                obj.CompanyType = obj.CompanyType == "" ? null : obj.CompanyType.Trim();

                cmd = new SqlCommand("GET_ServiceReportAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@EmployeeID", obj.EmployeeID);
                cmd.Parameters.AddWithValue("@ServiceCallID", obj.ServiceCallID);
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
