using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class EmployeeLeaveCancel
    {
        public string EMP_ID { get; set; }
        public string LEAVE_ID { get; set; }
        public string LEAVE_CANCEL_REMARK { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}