using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class AED_SERVICE_CALL
    {
        public string EMP_ID { get; set; }
        public string SERVICE_CALL_ID { get; set; }
        public string SP_ID { get; set; }
        public string QUANTITY { get; set; }
        public string AMOUNT { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
        public string EXTRA4 { get; set; }
        public byte[] PHOTO { get; set; }
    }
    public class GET_SPARE_PART
    {
        public string EMP_ID { get; set; }
        public string SERVICE_CALL_ID { get; set; }
        public string SP_ID { get; set; }
        public string QUANTITY { get; set; }
        public string AMOUNT { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}