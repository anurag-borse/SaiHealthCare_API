using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class ADD_LEAD
    {
        public string EMP_ID { get; set; }
        public string COMPANY_ID { get; set; }
        public string DSR_DATE { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string FIRM_NAME { get; set; }
        public string FIRM_ADDRESS { get; set; }
        public string CITY_NAME { get; set; }
        public string MOBILE_NO { get; set; }
        public string MODALITY { get; set; }
        public string EMAIL_ID { get; set; }
        public string PROJECHTED_MODEL { get; set; }
        public string CUSTOMER_REQUIREMENT { get; set; }
        public string SALES_PERSON_COMMITMENTS { get; set; }
        public string FORCASTED_MONTH { get; set; }
        public string PRICE { get; set; }
        public string BUY_PERCENT { get; set; }
        public string ENQUIRY_TYPE { get; set; }
        public byte[] UPLOAD_VISITING_CARD { get; set; }

        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
    public class GET_LEAD
    {
        public string EMP_ID { get; set; }

        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}