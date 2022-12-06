# Acerca de este proyecto

1. En este proyecto, se realiza un llamado WebClient al web service de WCFSalesforceCoS

2. Se utiliza newtonsoft, para deserealizar el llamado del web service

3. Se utiliza la notación ``` [JsonProperty("Fecha_Concluido__c")] ``` para usar un alias a las propiesdades de la clase en la que se deserealiza la respuesta

ejemplo

``` c#

///En el json, el atributo se llama referencia__c, pero al deserealizaron en el objeto, se va a utilizar en el atributo referencia de la clase Referencia_Elara__r

 public class Referencia_Elara__r
    {
        [JsonProperty("Referencia__c")]
        public string referencia { get; set; }
    }

```

