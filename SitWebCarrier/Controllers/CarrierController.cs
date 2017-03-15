using SitWebCarrier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITUtility;

namespace SitWebCarrier.Controllers
{
    public class CarrierController : Controller
    {
        //
        // GET: /Carrier/
        public string connetionString = System.Configuration.ConfigurationManager.ConnectionStrings["MSSqlConnection"].ConnectionString;

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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUser()
        {
            try
            {
                List<Employee> List_Employee = new List<Employee>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getUsers(out List_Employee, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                return View(List_Employee);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult editUser(Employee emp)
        {
            try
            {
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (emp.userid != null)
                {
                    pr = acc.editUsers(emp, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                else
                {
                    emp.userid = emp.userid_;
                    pr = acc.addUsers(emp, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }


                return RedirectToAction("getUser", "Carrier");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getUserEdit(Employee emp)
        {
            try
            {
                List<Employee> List_Employee = new List<Employee>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (emp.userid != null)
                {
                    Employee t = new Employee();
                    t.userid = emp.userid.Trim();
                    pr = acc.getUsers(out List_Employee, t, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }

                return View(List_Employee.FirstOrDefault());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getTruck()
        {
            try
            {
                List<Truck> List_Truck = new List<Truck>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getTruck(out List_Truck, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                return View(List_Truck);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getTruckEdit(Truck tru)
        {
            try
            {
                List<Truck> List_Truck = new List<Truck>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (tru.vehicle != null)
                {
                    Truck t = new Truck();
                    t.vehicle = tru.vehicle.Trim();
                    pr = acc.getTruck(out List_Truck, t, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                
                return View(List_Truck.FirstOrDefault());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult editTruck(Truck tru)
        {
            try
            {
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (tru.vehicle != null)
                {
                    pr = acc.editTruck(tru, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                else
                {
                    tru.vehicle = tru.vehicle_;
                    pr = acc.addTruck(tru, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }

                
                return RedirectToAction("getTruck", "Carrier");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getDriver()
        {
            try
            {
                List<Driver> List_Driver = new List<Driver>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();
                pr = acc.getDriver(out List_Driver, null, connetionString);
                //pr = acc.getUsers(out List_Users, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                return View(List_Driver);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getDriverEdit(Driver dri)
        {
            try
            {
                List<Driver> List_Driver = new List<Driver>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (dri.driver_code != null)
                {
                    Driver t = new Driver();
                    t.driver_code = dri.driver_code.Trim();
                    pr = acc.getDriver(out List_Driver, t, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }

                return View(List_Driver.FirstOrDefault());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult editDriver(Driver dri)
        {
            try
            {
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (dri.driver_code != null)
                {
                    pr = acc.editDriver(dri, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                else
                {
                    dri.driver_code = dri.driver_code_;
                    pr = acc.addDriver(dri, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }


                return RedirectToAction("getDriver", "Carrier");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult getUsers()
        {
            try
            {
                List<Employee> List_Users = new List<Employee>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getUsers(out List_Users, null, connetionString);
                //pr = acc.getUsers(out List_Users, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                return View(List_Users);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        public ActionResult editUsers(Employee emp)
        {
            try
            {
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                if (emp.userid != null)
                {
                    pr = acc.editUsers(emp, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                else
                {
                    emp.userid = emp.userid_;
                    pr = acc.addUsers(emp, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }


                return RedirectToAction("getUsers", "Carrier");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }


        public ActionResult getsap_document_assig()
        {
            
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                string USER_IDs = CheckUSER_ID();
                if (USER_IDs == null)
                {
                    throw new Exception("ไม่พบ User ID!");
                }

                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document_assig(out List_sap_document, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }

                List<Carriers> List_Carriers = new List<Carriers>();
                pr = acc.getCarrier(out List_Carriers, null, connetionString);
                ViewBag.List_Carriers = List_Carriers;
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                if (List_sap_document != null && List_sap_document.Any())
                {
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }
                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult getSap_documentAssigCarrier(string[] sap_shipments, string carrier)
        {
            try
            {
                if(sap_shipments == null || carrier == null){
                    throw new Exception("เลือกข้อมูลไม่ครบ");
                }
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();
                List<sap_document> List_sap_document;
                foreach(string ship in sap_shipments){
                    List_sap_document = new List<sap_document>();
                    sap_document s = new sap_document();
                    s.sap_shipment = ship;
                    pr = acc.getsap_document(out List_sap_document,s,connetionString);
                    if (pr.Successed && List_sap_document.Any())
                    {
                        sap_document s1 = new sap_document();
                        s1 = List_sap_document.First();
                        s1.Carriercode = carrier;
                        s1.ArrivalDate = DateTime.Now;
                        pr = acc.editsap_document(s1, connetionString);
                        if (!pr.Successed)
                        {
                            throw new Exception(pr.ErrorMessage);
                        }
                    }
                    

                    //send_carrier s = new send_carrier();
                    //s.Sap_shipment = ship;
                    //s.Carriercode = carrier;
                    //s.ArrivalDate = DateTime.Now;

                    //pr = acc.addsend_carrier(s,connetionString);
                    //if (!pr.Successed)
                    //{
                    //    throw new Exception(pr.ErrorMessage);
                    //}
                }

                return Json(new { Sucesss = "1"});
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = " " + ex.Message;
                return Json(new { Sucesss = "0", ErrorMessage = "" + ex.Message });
            }
        }

        public ActionResult getsend_carrier_assig()
        {
            //หน้าคู่ค้าเลือกงานให้คนขับ รถ
           
            try
            {
                string USER_IDs = CheckUSER_ID();
                if (USER_IDs == null)
                {
                    throw new Exception("ไม่พบ User ID!");
                }


                sap_document s = new sap_document();
                s.Carriercode = Session["carrier"].ToString();
                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsend_carrier_assig(out List_sap_document, s, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }

                if (List_sap_document != null && List_sap_document.Any())
                {
                    List<Driver> List_Driver = new List<Driver>();
                    pr = acc.getDriver(out List_Driver, null, connetionString);
                    ViewBag.List_Driver = List_Driver;
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }

                    List<Truck> List_Truck = new List<Truck>();
                    pr = acc.getTruck(out List_Truck, null, connetionString);
                    ViewBag.List_Truck = List_Truck;
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult getSap_documentAssigDriverTrailer(sap_document sap_document)
        {
            try
            {
                if (sap_document == null)
                {
                    throw new Exception("เลือกข้อมูลไม่ครบ");
                }
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                List<sap_document> List_sap_document = new List<sap_document>();
                pr = acc.getsap_document(out List_sap_document,sap_document, connetionString);
                if (pr.Successed && List_sap_document.Any())
                {
                    sap_document s = new sap_document();
                    s = List_sap_document.First(); //รอตรวจแฟล็ก ว่ายกเลิกไหม
                    s.sap_shipment = sap_document.sap_shipment;
                    s.Drivername = sap_document.Drivername;
                    s.Trailernumber = sap_document.Trailernumber;
                    pr = acc.editsap_document(s, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                }
                else
                {
                    throw new Exception("ไม่สำเร็จ "+pr.ErrorMessage);
                }

                
                return Json(new { Sucesss = "1" });
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = " " + ex.Message;
                return Json(new { Sucesss = "0", ErrorMessage = " " + ex.Message });
            }
        }

        public ActionResult getsap_document_confirm()
        {
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                string USER_IDs = CheckUSER_ID();
                if (USER_IDs == null)
                {
                    throw new Exception("ไม่พบ User ID!");
                }

                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document_confirm(out List_sap_document, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }

                if (List_sap_document != null && List_sap_document.Any())
                {
                    return View(List_sap_document);
                }else{
                    throw new Exception("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

        
        [HttpPost]
        public ActionResult getSap_documentConfirm(string[] sap_shipments)
        {
            try
            {
                if(sap_shipments == null){
                    throw new Exception("เลือกข้อมูลไม่ครบ");
                }
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();
                List<sap_document> List_sap_document;
                foreach(string ship in sap_shipments){
                    List_sap_document = new List<sap_document>();
                    sap_document d = new sap_document();
                    d.sap_shipment = ship;
                    pr = acc.getsap_document(out List_sap_document, d, connetionString);
                    if (pr.Successed && List_sap_document.Any())
                    {
                        sap_document s = new sap_document();
                        s = List_sap_document.First();
                        s.sap_shipment = ship;
                        s.Susr1 = "1";
                        s.Orderdate = DateTime.Now;

                        pr = acc.editsap_document(s, connetionString);
                        if (!pr.Successed)
                        {
                            throw new Exception(pr.ErrorMessage);
                        }
                    }
                    else
                    {
                        throw new Exception(pr.ErrorMessage);
                    }

                    
                }

                return Json(new { Sucesss = "1"});
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = " " + ex.Message;
                return Json(new { Sucesss = "0", ErrorMessage = " " + ex.Message });
            }
        }

        // user มารับของ โดยติด rfid 
        public ActionResult getsap_document_additem()
        {
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                string USER_IDs = CheckUSER_ID();
                if (USER_IDs == null)
                {
                    throw new Exception("ไม่พบ User ID!");
                }

                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document_additem(out List_sap_document, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                if (List_sap_document != null && List_sap_document.Any())
                {
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }

                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "" + ex.Message;
                return View();
            }
        }

        public ActionResult getRFID_tmpLoop()
        {
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                List<RFID_tmp> List_RFID_tmp = new List<RFID_tmp>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getRFID(out List_RFID_tmp, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                if (List_RFID_tmp != null && List_RFID_tmp.Any())
                {
                    return Json(new { Sucesss = "1", Count = List_RFID_tmp.Select(s=>s.sap_shipment).Distinct().Count().ToString() });
                }
                else
                {
                    throw new Exception("");
                }
            }
            catch (Exception ex)
            {
                return Json(new { Sucesss = "0", ErrorMessage = " " + ex.Message });
            }
        }

        public ActionResult getsap_document_confirmRFID()
        {
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                string USER_IDs = CheckUSER_ID();
                if (USER_IDs == null)
                {
                    throw new Exception("ไม่พบ User ID!");
                }

                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document_confirmRFID(out List_sap_document, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                if (List_sap_document != null && List_sap_document.Any())
                {
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }


                
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "" + ex.Message;
                return View();
            }
        }

        public ActionResult getsap_document_broad()
        {
            //หน้าเลือกงานให้คู่ค้า
            try
            {
                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document(out List_sap_document, null, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }
                if (List_sap_document != null && List_sap_document.Any())
                {
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }



            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "" + ex.Message;
                return View();
            }
        }

        [HttpPost]
        public ActionResult saveSap_documentRFID(string sap_shipment)
        {
            try
            {
                if (sap_shipment == null)
                {
                    throw new Exception("เลือกข้อมูลไม่ครบ");
                }
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                List<sap_document> List_sap_document = new List<sap_document>();
                sap_document d = new sap_document();
                d.sap_shipment = sap_shipment;
                pr = acc.getsap_document(out List_sap_document, d, connetionString);
                if (pr.Successed && List_sap_document.Any())
                {
                    sap_document s = new sap_document();
                    s = List_sap_document.First();
                    s.sap_shipment = sap_shipment;
                    s.Susr2 = "1";
                    s.LoadingDate = DateTime.Now;

                    pr = acc.editsap_document(s, connetionString);
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                    else
                    {
                        RFID_tmp RFID = new RFID_tmp();
                        RFID.sap_shipment = sap_shipment;
                        pr = acc.deleteRFID(RFID, connetionString);
                    }
                }
                else
                {
                    throw new Exception(pr.ErrorMessage);
                }

                return Json(new { Sucesss = "1" });
            }
            catch (Exception ex)
            {
                //ViewBag.ErrorMessage = " " + ex.Message;
                return Json(new { Sucesss = "0", ErrorMessage = " " + ex.Message });
            }
        }

        public ActionResult geteditsend_carrier_assig(string sap_shipment)
        {
            //หน้าคู่ค้าเลือกงานให้คนขับ รถ
            try
            {
                sap_document s = new sap_document();
                s.sap_shipment = sap_shipment;
                List<sap_document> List_sap_document = new List<sap_document>();
                dataAccess acc = new dataAccess();
                ProcessResult pr = new ProcessResult();

                pr = acc.getsap_document(out List_sap_document, s, connetionString);
                if (!pr.Successed)
                {
                    throw new Exception(pr.ErrorMessage);
                }

                if (List_sap_document != null && List_sap_document.Any())
                {
                    List<Driver> List_Driver = new List<Driver>();
                    pr = acc.getDriver(out List_Driver, null, connetionString);
                    ViewBag.List_Driver = List_Driver;
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }

                    List<Truck> List_Truck = new List<Truck>();
                    pr = acc.getTruck(out List_Truck, null, connetionString);
                    ViewBag.List_Truck = List_Truck;
                    if (!pr.Successed)
                    {
                        throw new Exception(pr.ErrorMessage);
                    }
                    return View(List_sap_document);
                }
                else
                {
                    throw new Exception("ไม่พบข้อมูล");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = " " + ex.Message;
                return View();
            }
        }

       

    }

}
