using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class Carrier
    {
        public string Shipment { get; set; }

        public string Appointment { get; set; }

        public string Do { get; set; }

        public DateTime? TimeIn { get; set; }

        public DateTime? TimeIOut { get; set; }

        public DateTime? TimeImport { get; set; }

        public string IDUserImport { get; set; }

        public string Invoice { get; set; }

        public string IDVender { get; set; }

        public string IDCar { get; set; }

        public string IDDriver { get; set; }

        public string IDUserConfirm { get; set; }
        public DateTime? TimeConfirm { get; set; }
    }
}