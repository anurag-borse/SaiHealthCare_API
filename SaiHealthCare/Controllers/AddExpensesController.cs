using SaiHealthCare.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SaiHealthCare.Data;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Web.Hosting;
using System.Web;

namespace SaiHealthCare.Controllers
{
    public class AddExpensesController : ApiController
    {
        private readonly SaiHealthCareRepository _repository;
        SqlCommand cmd;
        SqlDataAdapter sda;
        Output output;
        DataTable dtData;
        Output2 output2;
        DataSet ds;

        public AddExpensesController()
        {
            _repository = new SaiHealthCareRepository();
        }


        [HttpPost]
        public HttpResponseMessage Post([FromBody] ADD_EXPENSES obj)
        {
            var output = new Output();
            string url1 = "";
            string rv = Master.RandomString(5);

            try
            {
                obj.EMP_ID = obj.EMP_ID == "" ? null : obj.EMP_ID.Trim();
                obj.EXPENSE_TYPE = obj.EXPENSE_TYPE == "" ? null : obj.EXPENSE_TYPE.Trim();
                obj.AMOUNT = obj.AMOUNT == "" ? null : obj.AMOUNT.Trim();
                obj.REMARK = obj.REMARK == "" ? null : obj.REMARK.Trim();
                obj.EXTRA1 = obj.EXTRA1 == "" ? null : obj.EXTRA1.Trim();
                obj.EXTRA2 = obj.EXTRA2 == "" ? null : obj.EXTRA2.Trim();
                obj.EXTRA3 = obj.EXTRA3 == "" ? null : obj.EXTRA3.Trim();

                using (SqlConnection con = _repository.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("AED_EXPENSES", con))
                    {
                        if (obj.PHOTO != null && obj.PHOTO.Length > 0)
                        {
                            try
                            {
                                byte[] imageBytes = Convert.FromBase64String(obj.PHOTO);

                                using (MemoryStream mem = new MemoryStream(imageBytes))
                                {
                                    using (System.Drawing.Image img = System.Drawing.Image.FromStream(mem))
                                    {
                                        string folderPath = HostingEnvironment.MapPath("~/ImagesUploaded/");
                                        if (!Directory.Exists(folderPath))
                                        {
                                            Directory.CreateDirectory(folderPath);
                                        }

                                        string fileName = "PHOTO" + rv.Trim() + ".jpg";
                                        string filePath = Path.Combine(folderPath, fileName);
                                        img.Save(filePath, ImageFormat.Jpeg);

                                        url1 = HttpContext.Current.Request.Url.Scheme + "://" + HttpContext.Current.Request.Url.Authority + "/ImagesUploaded/" + fileName;
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                output.ResponseCode = "-1";
                                output.ResponseMessage = "Error processing image: " + ex.Message;
                                return Request.CreateResponse(HttpStatusCode.InternalServerError, output);
                            }
                        }

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                        cmd.Parameters.AddWithValue("@EXPENSE_TYPE", obj.EXPENSE_TYPE);
                        cmd.Parameters.AddWithValue("@AMOUNT", obj.AMOUNT);
                        cmd.Parameters.AddWithValue("@REMARK", obj.REMARK);
                        cmd.Parameters.AddWithValue("@PHOTO", url1);
                        cmd.Parameters.AddWithValue("@EXTRA1", obj.EXTRA1);
                        cmd.Parameters.AddWithValue("@EXTRA2", obj.EXTRA2);
                        cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                        // Execute the stored procedure
                        con.Open();
                        cmd.ExecuteNonQuery();

                        // Capture output parameters (if any) and set the response accordingly
                        output.ResponseCode = "0";  // Assuming success is 0
                        output.ResponseMessage = "Success";

                        return Request.CreateResponse(HttpStatusCode.OK, output);
                    }
                }
            }
            catch (Exception ex)
            {
                output.ResponseCode = "-1";
                output.ResponseMessage = ex.Message;
                return Request.CreateResponse(HttpStatusCode.InternalServerError, output);
            }
        }


        public HttpResponseMessage Post([FromBody] GET_EXPENSES obj, long id)
        {
            output2 = new Output2();
            try
            {
                using (SqlConnection con = _repository.GetConnection())
                {
                    obj.EMP_ID = string.IsNullOrEmpty(obj.EMP_ID) ? null : obj.EMP_ID.Trim();
                    obj.EXTRA1 = string.IsNullOrEmpty(obj.EXTRA1) ? null : obj.EXTRA1.Trim();
                    obj.EXTRA2 = string.IsNullOrEmpty(obj.EXTRA2) ? null : obj.EXTRA2.Trim();
                    obj.EXTRA3 = string.IsNullOrEmpty(obj.EXTRA3) ? null : obj.EXTRA3.Trim();

                    DateTime extra1Date, extra2Date;
                    DateTime? extra1 = DateTime.TryParse(obj.EXTRA1, out extra1Date) ? (DateTime?)extra1Date : null;
                    DateTime? extra2 = DateTime.TryParse(obj.EXTRA2, out extra2Date) ? (DateTime?)extra2Date : null;

                    using (SqlCommand cmd = new SqlCommand("GET_EXPENSES", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@EMP_ID", obj.EMP_ID);
                        cmd.Parameters.AddWithValue("@EXTRA1", (object)extra1 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@EXTRA2", (object)extra2 ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@EXTRA3", obj.EXTRA3);

                        sda = new SqlDataAdapter(cmd);
                        ds = new DataSet();
                        sda.Fill(ds);

                        output2.ResponseCode = "0";
                        output2.ResponseMessage = "List";
                        output2.DATA = ds.Tables[0];
                        output2.DATA1 = ds.Tables[1];
                    }
                }
            }
            catch (Exception exp)
            {
                output2.ResponseCode = "1";
                output2.ResponseMessage = exp.Message;
                output2.DATA = null;
                output2.DATA1 = null;
            }
            return Request.CreateResponse(HttpStatusCode.OK, output2, "application/json");
        }


    }
}