using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADDEmployeeTask
    {
        public string EmployeeID { get; set; }
        public string EmployeeType { get; set; }
        public string Date { get; set; }
        public string Location { get; set; }
        public string TodaysWork { get; set; }
        public string Remark { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
        public string EXTRA4 { get; set; }
    }

    public class Get_EmployeeTaskList
    {
        public string EmployeeID { get; set; }
        public string EmployeeType { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string WORD { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
       
    }
}