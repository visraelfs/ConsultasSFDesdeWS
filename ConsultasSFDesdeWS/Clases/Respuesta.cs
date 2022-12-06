using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasSFDesdeWS.Clases
{

    public class Root
    {
        public Response consultaGenericaSalesforceResult { get; set; }
        public Response recuperarInformacionFaltanteSalesforceResult { get; set; }
    }
    public class Response
    {
        public bool estatus { get; set; }

        public string mensaje { get; set; }
    }
    public class Mensaje
    {
        public int? totalSize { get; set; }
        public bool? done { get; set; }
        public string nextRecordsUrl { get; set; }
        public Records[] Records { get; set; }
    }

    public class Records
    {

        public attributes attributes { get; set; }

        [JsonProperty("Name")]
        public string ExpedienteProyecto { get; set; }

        [JsonProperty("CloseDate")]
        public DateTime? FechaCierre { get; set; }
        public string id { get; set; }

        [JsonProperty("OpportunityLineItems")]
        public OpportunityLineItems ProductosDeOportunidad { get; set; }

    }

    public class attributes
    {
        public string Opportunity { get; set; }
        public string url { get; set; }

    }


    public class OpportunityLineItems
    {
        [JsonProperty("totalSize")]
        public int numeroProductos { get; set; }

        public class Records
        {
            [JsonProperty("Referencia_Elara__r")]
            public Referencia_Elara__r ReferenciaElara { get; set; }
         
            public Product2 Product2 { get; set; }


        }

        public Records[] records { get; set; }
    }

    public class Product2
    {
        [JsonProperty("Name")]
        public string nombreProducto { get; set; }
    }

    public class Referencia_Elara__r
    {
        [JsonProperty("Referencia__c")]
        public string referencia { get; set; }

        [JsonProperty("Status_COS__c")]
        public string EstatusCoS { get; set; }

        [JsonProperty("Fecha_Activo__c")]
        public DateTime? FechaActivo { get; set; }

        [JsonProperty("Fecha_Desinstalado__c")]
        public DateTime? FechaDesinstalado { get; set; }

        [JsonProperty("Fecha_Desactivado__c")]
        public DateTime? FechaDesactivado { get; set; }

        [JsonProperty("Fecha_Reemplazo__c")]
        public DateTime? FechaReemplazo { get; set; }

        [JsonProperty("Fecha_Cancelado__c")]
        public DateTime? FechaCancelado { get; set; }

        [JsonProperty("Fecha_Entregado__c")]
        public DateTime? FechaEntregado { get; set; }

        [JsonProperty("Fecha_Concluido__c")]
        public DateTime? FechaConcluido { get; set; }

        [JsonProperty("Fecha_Actualizacion__c")]
        public DateTime? FechaActualizacion { get; set; }

        [JsonProperty("Fecha_por_Instalar__c")]
        public DateTime? FechaPorInstalar { get; set; }

        [JsonProperty("Fecha_instalado__c")]
        public DateTime? FechaInstalado { get; set; }
    }
}
