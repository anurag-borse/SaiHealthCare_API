using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace SaiHealthCare.Models
{
    //Add Spare Part Method Class
    public class ADD_SparePartCart
    {
        public string EmployeeID { get; set; }
        public string SparePartCartID { get; set; }
        public string ServiceCallID { get; set; }
        public string SparePartName { get; set; }
        public string Charges { get; set; }
        public string PN { get; set; }
        public string OldSN { get; set; }
        public string NewSN { get; set; }
        public string Quantity { get; set; }
        public string Task { get; set; }
    }

    //Get Spare Part Method Class
    public class GET_SparePartCart
    {
        public string EmployeeID { get; set; }
        public string ServiceCallID { get; set; }
        public string Task { get; set; }
    }
}