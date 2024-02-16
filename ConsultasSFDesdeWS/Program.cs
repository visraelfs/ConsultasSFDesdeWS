using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultasSFDesdeWS.Clases;

namespace ConsultasSFDesdeWS
{
    class Program
    {
        static void Main(string[] args)
        {

            //Generamos la consulta
            string customQuery = "SELECT CloseDate,Name,(SELECT id,Product2.Name, Referencia_Elara__r.Referencia__c, Referencia_Elara__r.Status_COS__c, Referencia_Elara__r.Fecha_Activo__c,Referencia_Elara__r.Fecha_Desinstalado__c, Referencia_Elara__r.Fecha_Desactivado__c, Referencia_Elara__r.Fecha_Reemplazo__c,Referencia_Elara__r.Fecha_Cancelado__c, Referencia_Elara__r.Fecha_Entregado__c, Referencia_Elara__r.Fecha_Concluido__c FROM OpportunityLineItems) FROM Opportunity WHERE CloseDate >= 2022-11-01 and StageName = 'Cierre'";

            WCFSalesForceCoSCall call = new WCFSalesForceCoSCall();

            dynamic jsonBody = new System.Dynamic.ExpandoObject();

            jsonBody.customQuery = customQuery;


            //Realizamos el llamado al WS para obtener los resultados de la consulta
            string result = call.POST("http://172.31.248.4/wcfsalesforcecos/SalesforceCos.svc/consultaGenericaSalesforce", jsonBody);

            //Desearealizamos la respuesta
            Root consultaGenericaSalesforceResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(result);
            Mensaje objetoMensaje = Newtonsoft.Json.JsonConvert.DeserializeObject<Mensaje>(consultaGenericaSalesforceResult.consultaGenericaSalesforceResult.mensaje);


            jsonBody = new System.Dynamic.ExpandoObject();
            jsonBody.link = objetoMensaje.nextRecordsUrl;

            List<Records[]> records = new List<Records[]>();

            records.Add(objetoMensaje.Records);

            //Si la respuesta está por partes, iteramos hasta el final de los registros
            while (objetoMensaje.nextRecordsUrl != null)
            {
                jsonBody = new System.Dynamic.ExpandoObject();
                jsonBody.link = objetoMensaje.nextRecordsUrl;
                string result2 = call.POST("http://172.31.248.4/wcfsalesforcecos/SalesforceCos.svc/recuperarInformacionFaltanteSalesforce", jsonBody);               
                consultaGenericaSalesforceResult = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(result2);
                objetoMensaje = Newtonsoft.Json.JsonConvert.DeserializeObject<Mensaje>(consultaGenericaSalesforceResult.recuperarInformacionFaltanteSalesforceResult.mensaje);
                records.Add(objetoMensaje.Records);
            }


            //Juntamos en un solo objeto, todos los resultados
            Records[] finalresult = (from r in records
                                     from r2 in r
                                     select r2).Distinct().ToArray();


            //Debido a que al momento de obtener los registros desde salesforce, los valores estan en objetos internos, generaremos la respuesta en un solo objeto

            List<InformeUnificado> informeUnificado = new List<InformeUnificado>();

            foreach(Records expedienteProyecto in finalresult)
            {              

                foreach(OpportunityLineItems.Records oli in expedienteProyecto.ProductosDeOportunidad.records)
                {
                    InformeUnificado item = new InformeUnificado();

                    item.ExpedienteProyecto = expedienteProyecto.ExpedienteProyecto;
                    item.FechaDeCierre = expedienteProyecto.FechaCierre;
                    item.Producto = oli.Product2.nombreProducto;
                    item.Referencia = oli.ReferenciaElara.referencia;
                    item.EstatusCoS = oli.ReferenciaElara.EstatusCoS;
                    item.FechaActivo = oli.ReferenciaElara.FechaActivo;
                    item.FechaActualizacion = oli.ReferenciaElara.FechaActualizacion;
                    item.FechaPorInstalar = oli.ReferenciaElara.FechaPorInstalar;
                    item.FechaInstalado = oli.ReferenciaElara.FechaInstalado;
                    item.FechaDesinstalado = oli.ReferenciaElara.FechaDesinstalado;
                    item.FechaDesactivado = oli.ReferenciaElara.FechaDesactivado;
                    item.FechaReemplazo = oli.ReferenciaElara.FechaReemplazo;
                    item.FechaCancelado = oli.ReferenciaElara.FechaCancelado;
                    item.FechaEntregado = oli.ReferenciaElara.FechaEntregado;
                    item.FechaConluido = oli.ReferenciaElara.FechaConcluido;

                    informeUnificado.Add(item);

                }   
            }

        }
    }
}
