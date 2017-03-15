using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class Truck
    {
        public string vehicle { get; set; }
        public string vehicle_ { get; set; }
        public string veh_text { get; set; }
        public string veh_type { get; set; }
        public string veh_status { get; set; }
        public string truck_status { get; set; }
        public string carrier { get; set; }
        public string veh_nrtus { get; set; }
        public string vol_uom { get; set; }
        public string wgt_uom { get; set; }
        public string class_grp { get; set; }
        public string rfid { get; set; }
        public DateTime? cre_date { get; set; }
        public string cre_name { get; set; }
        public DateTime?  cha_date { get; set; }
        public string cha_name { get; set; }
    }

    public class Truck_type
    {
        public string veh_type { get; set; }
        public string text { get; set; }
    }

    public class Truck_status
    {
        public string veh_status { get; set; }
        public string text { get; set; }
    }
}
