using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SitWebCarrier.Models
{
    public class sap_document
    {
        public string sap_shipment { get; set; }
        public DateTime? appointmenttime { get; set; }
        //public string appointmenttime { get; set; }
        public string appointmenttime_ { get; set; }
        public string storerkey { get; set; }
        public string sap_do { get; set; }
        public string type_do { get; set; }
        public string externalloadid { get; set; }
        public string qty { get; set; }
        public string c_shopto { get; set; }
        public string c_billto { get; set; }
        public string ordergroup { get; set; }
        public string b_state { get; set; }
        public string b_zip { get; set; }
        public string containerqty { get; set; }
        public string delivertplace { get; set; }
        public string dischareplace { get; set; }
        public string notes { get; set; }
        public string notes2 { get; set; }

        public string Carriercode { get; set; }
        public string Susr1 { get; set; }
        public string Susr2 { get; set; }
        public string Susr3 { get; set; }
        public string Susr4 { get; set; }
        public string Susr5 { get; set; }
        
        public string Transportationservice { get; set; }
        public string Door { get; set; }

        public DateTime? Transportationmode { get; set; }
        public DateTime? Itemlineno { get; set; }
        public DateTime? Orderdate { get; set; }
        public DateTime? LoadingDate { get; set; }
        public DateTime? ArrivalDate { get; set; }
        //public string Transportationmode { get; set; }
        //public string Itemlineno { get; set; }
        //public string Orderdate { get; set; }
        //public string LoadingDate { get; set; }
        //public string ArrivalDate { get; set; }

        public string Drivername { get; set; }
        public string Trailernumber { get; set; }
        public string Packnotes { get; set; }
        public string DO_Grade { get; set; }
        public string DO_ItemNote { get; set; }
        public string DO_PackingR { get; set; }
        public string DO_FumigationR { get; set; }
    }
}