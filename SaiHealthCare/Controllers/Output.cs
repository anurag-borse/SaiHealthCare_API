using System.Data;

namespace SaiHealthCare.Controllers
{
    internal class Output
    {

        public string ResponseCode { get; internal set; }
        public string ResponseMessage { get; internal set; }
        public object DATA { get; internal set; }
        public DataTable DATA1 { get; internal set; }
        public string ID { get; internal set; }
        public string Token { get; set; } 

    }
}