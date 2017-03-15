using ITUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class DataConvertor
    {
        public static List<sap_document> sap_document(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<sap_document> returnList = new List<sap_document>();

            foreach (DataRow dr in dt.Rows)
            {
                sap_document returnElement = sap_document(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static sap_document sap_document(DataRow dr)
        {
            sap_document s = new sap_document();
            s.sap_shipment = Utility.GetDBStringValue(dr, "sap_shipment");//dr["sap_shipment"].ToString();
            s.storerkey = Utility.GetDBStringValue(dr, "storerkey");
            s.sap_do = Utility.GetDBStringValue(dr, "sap_do");
            s.type_do = Utility.GetDBStringValue(dr, "type_do");
            s.externalloadid = Utility.GetDBStringValue(dr, "externalloadid");
            s.qty = Utility.GetDBStringValue(dr, "qty");
            s.c_shopto = Utility.GetDBStringValue(dr, "c_shopto");
            s.c_billto = Utility.GetDBStringValue(dr, "c_billto");
            s.ordergroup = Utility.GetDBStringValue(dr, "ordergroup");
            s.b_state = Utility.GetDBStringValue(dr, "b_state");
            s.b_zip = Utility.GetDBStringValue(dr, "b_zip");
            s.containerqty = Utility.GetDBStringValue(dr, "containerqty");
            s.delivertplace = Utility.GetDBStringValue(dr, "delivertplace");
            s.dischareplace = Utility.GetDBStringValue(dr, "dischareplace");
            s.notes = Utility.GetDBStringValue(dr, "notes");
            s.notes2 = Utility.GetDBStringValue(dr, "notes2");
            s.appointmenttime = Utility.GetDBDateTimeValue(dr, "appointmenttime");
            s.appointmenttime_ = Utility.GetDBStringValue(dr, "appointmenttime");

            s.Carriercode = Utility.GetDBStringValue(dr, "Carriercode");

            s.Susr1 = Utility.GetDBStringValue(dr, "Susr1");
            s.Susr2 = Utility.GetDBStringValue(dr, "Susr2");
            s.Susr3 = Utility.GetDBStringValue(dr, "Susr3");
            s.Susr4 = Utility.GetDBStringValue(dr, "Susr4");
            s.Susr5 = Utility.GetDBStringValue(dr, "Susr5");

            s.Transportationservice = Utility.GetDBStringValue(dr, "Transportationservice");
            s.Door = Utility.GetDBStringValue(dr, "Door");
            s.Transportationmode = Utility.GetDBDateTimeValue(dr, "Transportationmode");
            s.Itemlineno = Utility.GetDBDateTimeValue(dr, "Itemlineno");
            s.Orderdate = Utility.GetDBDateTimeValue(dr, "Orderdate");
            s.LoadingDate = Utility.GetDBDateTimeValue(dr, "LoadingDate");
            s.ArrivalDate = Utility.GetDBDateTimeValue(dr, "ArrivalDate");

            s.Drivername = Utility.GetDBStringValue(dr, "Drivername");
            s.Trailernumber = Utility.GetDBStringValue(dr, "Trailernumber");
            s.Packnotes = Utility.GetDBStringValue(dr, "Packnotes");
            s.DO_Grade = Utility.GetDBStringValue(dr, "DO_Grade");
            s.DO_ItemNote = Utility.GetDBStringValue(dr, "DO_ItemNote");
            s.DO_PackingR = Utility.GetDBStringValue(dr, "DO_PackingR");
            s.sap_shipment = Utility.GetDBStringValue(dr, "sap_shipment");
            return s;
        }

        public static List<RFID_tmp> RFID_tmp(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<RFID_tmp> returnList = new List<RFID_tmp>();

            foreach (DataRow dr in dt.Rows)
            {
                RFID_tmp returnElement = RFID_tmp(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static RFID_tmp RFID_tmp(DataRow dr)
        {
            RFID_tmp s = new RFID_tmp();
            s.sap_shipment = Utility.GetDBStringValue(dr, "sap_shipment");
            s.rfid_id = Utility.GetDBStringValue(dr, "rfid_id");
            s.status = Utility.GetDBStringValue(dr, "status");
            return s;
        }

        public static List<Truck> Truck(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<Truck> returnList = new List<Truck>();

            foreach (DataRow dr in dt.Rows)
            {
                Truck returnElement = Truck(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static Truck Truck(DataRow dr)
        {
            Truck t = new Truck();
            t.vehicle = Utility.GetDBStringValue(dr, "vehicle");
            t.veh_text = Utility.GetDBStringValue(dr, "veh_text");
            t.veh_type = Utility.GetDBStringValue(dr, "veh_type");
            t.veh_status = Utility.GetDBStringValue(dr, "veh_status");
            t.carrier = Utility.GetDBStringValue(dr, "carrier");
            t.veh_nrtus = Utility.GetDBStringValue(dr, "veh_nrtus");
            t.vol_uom = Utility.GetDBStringValue(dr, "vol_uom");
            t.wgt_uom = Utility.GetDBStringValue(dr, "wgt_uom");
            t.class_grp = Utility.GetDBStringValue(dr, "class_grp");
            t.rfid = Utility.GetDBStringValue(dr, "rfid");
            t.cre_name = Utility.GetDBStringValue(dr, "cre_name");
            t.cha_name = Utility.GetDBStringValue(dr, "cha_name");

            t.cre_date = Utility.GetDBDateTimeValue(dr, "cre_date");
            t.cha_date = Utility.GetDBDateTimeValue(dr, "cha_date");

            return t;
        }

        public static List<Driver> Driver(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<Driver> returnList = new List<Driver>();

            foreach (DataRow dr in dt.Rows)
            {
                Driver returnElement = Driver(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static Driver Driver(DataRow dr)
        {
            Driver d = new Driver();
            d.driver_code = Utility.GetDBStringValue(dr, "driver_code");
            d.pers_code = Utility.GetDBStringValue(dr, "pers_code");
            d.first_name = Utility.GetDBStringValue(dr, "first_name");
            d.last_name = Utility.GetDBStringValue(dr, "last_name");
            d.carrier = Utility.GetDBStringValue(dr, "carrier");
            d.drv_status = Utility.GetDBStringValue(dr, "drv_status");
            d.license_type = Utility.GetDBStringValue(dr, "license_type");
            d.valid_from = Utility.GetDBStringValue(dr, "valid_from");
            d.valid_to = Utility.GetDBStringValue(dr, "valid_to");
            d.rfid = Utility.GetDBStringValue(dr, "rfid");
            //d.status = Utility.GetDBStringValue(dr, "status");
            d.rfid = Utility.GetDBStringValue(dr, "rfid");
            return d;
        }

        public static List<Employee> Employee(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<Employee> returnList = new List<Employee>();

            foreach (DataRow dr in dt.Rows)
            {
                Employee returnElement = Employee(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static Employee Employee(DataRow dr)
        {
            Employee u = new Employee();
            u.userid = Utility.GetDBStringValue(dr, "userid");
            u.password = Utility.GetDBStringValue(dr, "password");
            u.first_name = Utility.GetDBStringValue(dr, "first_name");
            u.last_name = Utility.GetDBStringValue(dr, "last_name");
            u.carrier = Utility.GetDBStringValue(dr, "carrier");
            u.authorized = Utility.GetDBStringValue(dr, "authorized");
            return u;
        }

        public static List<Carriers> Carriers(DataTable dt)
        {
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<Carriers> returnList = new List<Carriers>();

            foreach (DataRow dr in dt.Rows)
            {
                Carriers returnElement = Carriers(dr);
                returnList.Add(returnElement);
            }
            return returnList;
        }

        private static Carriers Carriers(DataRow dr)
        {
            Carriers c = new Carriers();
            c.carrier = Utility.GetDBStringValue(dr, "carrier");
            c.name = Utility.GetDBStringValue(dr, "name");
            return c;
        }
    }
}