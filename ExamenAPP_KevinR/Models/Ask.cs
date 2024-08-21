using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExamenAPP_KevinR.Models
{
    public class Ask
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public long IdPregunta { get; set; }

        public DateTime Fecha { get; set; }

        public string Pregunta1 { get; set; } = null!;

        public int IdUsuario { get; set; }

        public int IdPreguntaEstado { get; set; }

        public bool? EsStrike { get; set; }

        public string? DireccionImagen { get; set; }

        public string? DetallePregunta { get; set; }


        public string EstadoPregunta { get; set; } = null!;

        public string Usuario { get; set; } = null!;

        public async Task<bool> AddAskAsync()
        {
            try
            {

                string RouteSufix = string.Format("Asks/AddAskFromApp");

                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Post);


                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);



                string SerializedModel = JsonConvert.SerializeObject(this);

                Request.AddBody(SerializedModel);


                RestResponse response = await client.ExecuteAsync(Request);


                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.Created)
                {



                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }


    }
}
