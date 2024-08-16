using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_LEAVE
    {
        public string EMP_ID { get; set; }
        public string LEAVE_CATEGORY { get; set; }
        public string LEAVE_REASON { get; set; }
        public string LEAVE_TYPE { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
       
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
    public class GET_LEAVE
    {
        public string EMP_ID { get; set; }
        public string FROM_DATE { get; set; }
        public string TO_DATE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}