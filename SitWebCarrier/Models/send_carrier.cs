using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class send_carrier
    {
        public int id { get; set; }
        public string Carriercode { get; set; }
        public string Sap_shipment { get; set; }
        public string Susr1 { get; set; }
        public string Susr2 { get; set; }
        public string Susr3 { get; set; }
        public string Susr4 { get; set; }
        public string Susr5 { get; set; }
        public DateTime? Transportationmode { get; set; }
        public string Transportationservice { get; set; }
        public string Door { get; set; }
        public DateTime? Itemlineno { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? LoadingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string Drivername { get; set; }
        public string Trailernumber { get; set; }
        public string Packnotes { get; set; }
        public string DO_Grade { get; set; }
        public string DO_ItemNote { get; set; }
        public string DO_PackingR { get; set; }
        public string DO_FumigationR { get; set; }

    }
}