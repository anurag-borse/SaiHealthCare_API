using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaiHealthCare.Models.ServiceReport
{
    public class GetServiceReportForm
    {
        public string EmployeeID { get; set; }
        public string M_ID { get; set; }
        public string CAT_ID { get; set; }
        public string CUSTOMER_TYPE_ID { get; set; }
        public string CompanyType { get; set; }
    }
}