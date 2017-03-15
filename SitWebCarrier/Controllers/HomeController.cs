using SitWebCarrier.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITUtility;
using System.Data;

namespace SitWebCarrier.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private void GetShipmentSap()
        {
            Carrier c = new Carrier();
            c.Shipment = "";
            c.Appointment = "";
            c.Appointment = "";
            
        }

        public ActionResult Carrier()
        {
            string USER_IDs = CheckUSER_ID();
            if (USER_IDs == null)
            {
                ViewBag.ErrorMessage = "ไม่พบ User ID!";
                return View();
            }
            else
            {
                ProcessResult pr = new ProcessResult();

                // InsertMicrosoftSql();
                //UpdateMicrosoftSql();
                List<Carrier> List_Carrier = new List<Carrier>();
                pr = QueryCarrierConfirm(out List_Carrier,"");
                if (pr.Successed)
                {
                    return View(List_Carrier);
                }
                else
                {
                    ViewBag.ErrorMessage = "เกิดข้อผิดพลาดจากระบบ " + pr.ErrorMessage;
                    return View();
                }
            }

            
            
        }

        public ActionResult CarrierConfirm()
        {
            string USER_IDs = CheckUSER_ID();
            if (USER_IDs == null)
            {
                ViewBag.ErrorMessage = "ไม่พบ User ID!";
                return View();
            }
            else
            {
                ProcessResult pr = new ProcessResult();

                // InsertMicrosoftSql();
                //UpdateMicrosoftSql();
                List<Carrier> List_Carrier = new List<Carrier>();
                pr = QueryCarrierConfirm(out List_Carrier,"N");
                if (pr.Successed)
                {
                    return View(List_Carrier);
                }
                else
                {
                    ViewBag.ErrorMessage = "เกิดข้อผิดพลาดจากระบบ " + pr.ErrorMessage;
                    return View();
                }
            }



        }

        
        [HttpGet]
        public ActionResult CarrierShipment(string appointmant)
        {
            ProcessResult pr = new ProcessResult();

            // InsertMicrosoftSql();
            //UpdateMicrosoftSql();
            List<Carrier> List_Carrier = new List<Carrier>();
            pr = QueryCarrier(out List_Carrier, appointmant);
            if (pr.Successed)
            {
                Carrier c = new Models.Carrier();
                c = List_Carrier.FirstOrDefault();
                return View(c);
            }
            else
            {
                ViewBag.ErrorMessage = "เกิดข้อผิดพลาดจากระบบ " + pr.ErrorMessage;
                return View();
            }

        }

        [HttpPost]
        public ActionResult SaveAppointment(string Appointment,string Shipment,string IDVender,string IDCar,string IDDriver)
        {
            string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
            SqlConnection cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand command = new SqlCommand("Update Carrier.dbo.Carrier set IDVender= @0,IDCar=@1,IDDriver=@3,TimeIn=@4,StatusConfirm='N' where Appointment=@5 and Shipment=@6", cnn);
            command.Parameters.Add(new SqlParameter("0", IDVender));
            command.Parameters.Add(new SqlParameter("1", IDCar));
            command.Parameters.Add(new SqlParameter("3", IDDriver));

            command.Parameters.Add(new SqlParameter("4", DateTime.Now));

            command.Parameters.Add(new SqlParameter("5", Appointment));
            command.Parameters.Add(new SqlParameter("6", Shipment));
            //command.ExecuteReader();
            int numberOfRecords = command.ExecuteNonQuery();

            command.Dispose();
            cnn.Close();
            return null;
        }

        private string CheckUSER_ID()
        {
            if (Session["name"] != null)
            {
                string name = (string)Session["name"];
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
                else
                {
                    return (string)null;
                }
            }
            else
            {
                return (string)null;
            }
        }

        public string ContactJSON()
        {
            ViewBag.Message = "Your contact page.";
            ProcessResult pr = new ProcessResult();
            DataTable dt;
            string json = null;
            pr = QueryMicrosoftSql1(out  dt);
            if(pr.Successed){
                json = DatatableToJSON(dt);
            }
            return json;
        }

        public static string DatatableToJSON(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }

        public static ProcessResult QueryMicrosoftSql(out List<Carrier> List_Carrier)
        {
            ProcessResult pr = new ProcessResult();
            pr.Successed = true;
            List_Carrier = new List<Carrier>();
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = null;
                string sqlStr = @"SELECT Shipment
                              ,Appointment
                                ,TimeIn
                          FROM Carrier.dbo.Carrier" + condition;
                SqlCommand command = new SqlCommand(sqlStr, cnn);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Carrier b = new Carrier();
                    b.Shipment = dataReader.GetValue(0).ToString();
                    b.Appointment = dataReader.GetValue(1).ToString();
                    b.IDVender = dataReader.GetValue(2).ToString();
                    List_Carrier.Add(b);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();

                
            }
            catch (Exception ex)
            {
                pr.Successed = false;
                pr.ErrorMessage = ex.Message;
            }
            return pr;
        }

        public static ProcessResult QueryCarrierConfirm(out List<Carrier> List_Carrier, string StatusConfirm)
        {
            ProcessResult pr = new ProcessResult();
            pr.Successed = true;
            List_Carrier = new List<Carrier>();
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = null;
                if (StatusConfirm != null)
                {
                    if (StatusConfirm == "")
                    {
                        condition += " and StatusConfirm is null";
                    }else{
                        condition += " and StatusConfirm=" + Utility.SQLValueString(StatusConfirm);
                    }
                    
                }
                string sqlStr = @"SELECT Shipment
                              ,Appointment
                                ,TimeIn
                          FROM Carrier.dbo.Carrier where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sqlStr, cnn);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Carrier b = new Carrier();
                    b.Shipment = dataReader.GetValue(0).ToString();
                    b.Appointment = dataReader.GetValue(1).ToString();
                    b.IDVender = dataReader.GetValue(2).ToString();
                    List_Carrier.Add(b);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
                pr.Successed = false;
                pr.ErrorMessage = ex.Message;
            }
            return pr;
        }

        public static ProcessResult QueryCarrier(out List<Carrier> List_Carrier,string appointment)
        {
            ProcessResult pr = new ProcessResult();
            pr.Successed = true;
            List_Carrier = new List<Carrier>();
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = null;
                if (appointment != null)
                {
                    condition += " and Appointment = " + Utility.SQLValueString(appointment);
                }
                string sqlStr = @"SELECT Shipment
                              ,Appointment
                                ,TimeIn
                          FROM Carrier.dbo.Carrier where 1=1 " + condition;
                SqlCommand command = new SqlCommand(sqlStr, cnn);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Carrier b = new Carrier();
                    b.Shipment = dataReader.GetValue(0).ToString();
                    b.Appointment = dataReader.GetValue(1).ToString();
                    b.IDVender = dataReader.GetValue(2).ToString();
                    List_Carrier.Add(b);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
                pr.Successed = false;
                pr.ErrorMessage = ex.Message;
            }
            return pr;
        }

        public static ProcessResult QueryMicrosoftSql1(out DataTable dt)
        {
            ProcessResult pr = new ProcessResult();
            pr.Successed = true;
            dt = null;
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();
                string condition = null;
                string sqlStr = @"SELECT Shipment
                              ,Appointment
                                ,TimeIn
                          FROM Carrier.dbo.Carrier" + condition;
                SqlCommand command = new SqlCommand(sqlStr, cnn);
                //SqlDataReader dataReader = command.ExecuteReader();
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
               
                //dataReader.Close();
                command.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
                pr.Successed = false;
                pr.ErrorMessage = ex.Message;
            }
            return pr;
        }

        public static void InsertMicrosoftSql(){
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Carrier.dbo.Carrier (Shipment,Appointment,TimeIn) VALUES(@0,@1,@2)", cnn);
                command.Parameters.Add(new SqlParameter("0","test"));
                command.Parameters.Add(new SqlParameter("1", "testdfsdf"));
                command.Parameters.Add(new SqlParameter("2", DateTime.Now));
                command.ExecuteReader();

                command.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
            }
        }

        public static void UpdateMicrosoftSql()
        {
            try
            {
                string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;
                SqlConnection cnn = new SqlConnection(connetionString);
                cnn.Open();

                SqlCommand command = new SqlCommand("Update Carrier.dbo.Carrier set Shipment= @0,TimeIn=@1 where Appointment='testdfsdf'", cnn);
                command.Parameters.Add(new SqlParameter("0", "Atiwat"));
                command.Parameters.Add(new SqlParameter("1", DateTime.Now));
                command.ExecuteReader();

                command.Dispose();
                cnn.Close();


            }
            catch (Exception ex)
            {
            }
        }
    }
}
