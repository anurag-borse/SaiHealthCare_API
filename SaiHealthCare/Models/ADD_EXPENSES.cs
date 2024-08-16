using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_EXPENSES
    {
        public string EMP_ID { get; set; }
        public string EXPENSE_TYPE { get; set; }
        public string AMOUNT { get; set; }
        public string REMARK { get; set; }
        public string PHOTO { get; set; } // change from byte[] to string from anurag 16/08/2024

        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
    public class GET_EXPENSES
    {
        public string EMP_ID { get; set; }
        
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }


    public class EmployeeTask
    {
        public string EmployeeId { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string TaskId { get; set; }
        public string Type { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
    }
}