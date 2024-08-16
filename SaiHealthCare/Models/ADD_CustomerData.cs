using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_CustomerData
    {
        public string EMP_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string EXISTING_REQUIRMENT { get; set; }
        public string NEW_REQUIRMENT { get; set; }
        public string ENQUIRY_TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }

    public class Get_CustomerData
    {
        public string EMP_ID { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}