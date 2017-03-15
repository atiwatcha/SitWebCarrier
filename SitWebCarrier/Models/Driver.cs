using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class Driver
    {
        public string driver_code { get; set; }
        public string driver_code_ { get; set; }
        public string pers_code { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string carrier { get; set; }
        public string drv_status { get; set; }
        public string license_type { get; set; }
        public string valid_from { get; set; }
        public string valid_to { get; set; }
        public string status { get; set; }
        public string rfid { get; set; }
    }
}

