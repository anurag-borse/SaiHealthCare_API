using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models.ServiceReport
{
    //add service report class
    public class ADD_ServiceReport
    {
        public string EmployeeID { get; set; }
        public string ServiceCallID { get; set; }
        public string CompanyType { get; set; }
        public string CustomerDetails { get; set; }
        public string SerialNumber { get; set; }
        public string Date { get; set; }
        public string ModelNumber { get; set; }
        public string Make { get; set; }
        public string SWVersion { get; set; }
        public string NatureOfProblem { get; set; }
        public string WorkDoneSolution { get; set; }
        public string ServiceType { get; set; }
        public string ServiceCharges { get; set; }
        public string Total { get; set; }
        public string AmountInWord { get; set; }
        public string EngineerRemark { get; set; }
        public string PaymentsDetails { get; set; }
        public string PaidAmount { get; set; }
        public string BalanceAmount { get; set; }
        public string SelectWork { get; set; }
        public string SelectCategory { get; set; }
        public string HospitalDiagnosticCenter { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public string ContactPerson { get; set; }
        public string Telephone { get; set; }
        public string MobileNumber { get; set; }
        public string ZipPostalCode { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string ModelName { get; set; }
        public string Accessories { get; set; }
        public string Warranty { get; set; }
        public string WarrantyStartDate { get; set; }
        public string WarrantyEndDate { get; set; }
        public string ServiceInformation { get; set; }
        public string MalfunctionDescription { get; set; }
        public string ServiceProcess { get; set; }
        public string CS_SpecificSuggestion { get; set; }
        public string FunctionTest { get; set; }
        public string SafetyInspection { get; set; }
        public string SoftwareUpgrade { get; set; }
        public string NewSoftwareVersion { get; set; }
        public string SatisfactionFeedback { get; set; }
        public string Comment { get; set; }
        public string CustomerName { get; set; }
        public string EngineerName { get; set; }
        public string BankName { get; set; }
        public string IFSCCode { get; set; }
        public string Task { get; set; }

    }
    //add service report class
    public class GET_ServiceReport
    {
        public string EmployeeID { get; set; }
        public string ServiceCallID { get; set; }
        public string CompanyType { get; set; }
    }
}