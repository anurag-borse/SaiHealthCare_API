using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_EmployeeTaskData
    {
        public string EmployeeID { get; set; }
        public string EmployeeTaskID { get; set; }
        public string EmployeeType { get; set; }
        public string AllocatedWork { get; set; }
        public string WorkResult { get; set; }
        public string Remark { get; set; }
        public string NewLearning { get; set; }
        public string Location { get; set; }
        public string HospitalName { get; set; }
        public string CustomerDetails { get; set; }
        public string ServiceEngReason { get; set; }
        public string DoctorName { get; set; }
        public string ContactNumber { get; set; }
        public string ExistingModel { get; set; }
        public string ProposedModel { get; set; }
        public string SalesTeamStatus { get; set; }
        public string Purpose { get; set; }
        public string WarehouseType { get; set; }
        public string CleaningOff { get; set; }
        public string Type { get; set; }
        public string EquipmentsPartDetails { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string PersonFrom { get; set; }
        public string PersonName { get; set; }
        public string WhoAskForIt { get; set; }
        public string DCNumber { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }

    public class Get_EmployeeTaskDataList
    {
        public string EmployeeID { get; set; }
        public string EmployeeTaskID { get; set; }
        public string EmployeeType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string WORD { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}