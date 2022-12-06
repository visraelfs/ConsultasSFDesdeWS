using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsultasSFDesdeWS.Clases
{
    class WCFSalesForceCoSCall : IRestCall
    {
        public string GET(string url)
        {
            throw new NotImplementedException();
        }

        public string POST(string url, object jsonBody)
        {
            string respuestaPOST = string.Empty;
            try
            {



                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentType = "application/json; charset=utf-8";
                request.Method = "POST";


                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    streamWriter.Write(Newtonsoft.Json.JsonConvert.SerializeObject(jsonBody));
                }

                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            respuestaPOST = objReader.ReadToEnd();
                        }
                    }
                }

                return respuestaPOST;
            }
            catch (WebException ex)
            {
                using (Stream strReader = ex.Response.GetResponseStream())
                {
                    if (strReader == null) return null;
                    using (StreamReader objReader = new StreamReader(strReader))
                    {
                        string respuestaError = objReader.ReadToEnd();

                        throw new Exception(respuestaError, ex);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}