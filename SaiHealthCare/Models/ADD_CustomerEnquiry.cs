using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_CustomerEnquiry
    {
        public string Customer_ID { get; set; }
        public string P_ID { get; set; }
        public string CUSTOMER_REMARK { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }

    public class Get_CustomerEnquiry
    {
        public string Customer_ID { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}