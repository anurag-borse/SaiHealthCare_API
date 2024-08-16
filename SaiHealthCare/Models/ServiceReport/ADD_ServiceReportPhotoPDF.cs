using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models.ServiceReport
{
    public class ADD_ServiceReportPhotoPDF
    {
        public string ServiceReportID { get; set; }
        public byte[] ServiceReportPhoto { get; set; }
        public string ServiceReportPDF { get; set; }
        public string EXTRA1 { get; set; }
    }
}