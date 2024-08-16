using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models
{
    public class PUNCHIN_PUNCHOUT
    {
        public string EMP_ID { get; set; }
        public string CHECK_IN_TYPE { get; set; }
        public string VEHICAL_TYPE_ID { get; set; }
        public string LATITUDE { get; set; }
        public string LONGITUDE { get; set; }
        public byte[] ODOMETER_PHOTO_CHECK_IN { get; set; }
        public byte[] ODOMETER_PHOTO_CHECK_OUT { get; set; }
        public string TYPE { get; set; }
        public string EXTRA1 { get; set; }
        public string EXTRA2 { get; set; }
        public string EXTRA3 { get; set; }
    }
}