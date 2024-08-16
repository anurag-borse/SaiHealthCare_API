using System.Data;

namespace SaiHealthCare.Controllers
{
    internal class Output2
    {
        public string ResponseCode { get; internal set; }
        public string ResponseMessage { get; internal set; }
        public DataTable DATA { get; internal set; }
        public DataTable DATA1 { get; internal set; }
    }
}