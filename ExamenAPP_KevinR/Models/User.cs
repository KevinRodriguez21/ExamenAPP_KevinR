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
    public class User
    {
        [JsonIgnore]
        public RestRequest Request { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public async Task<List<User>?> GetUserAsync()
        {
            try
            {
                string RouteSufix = string.Format("Users");

                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);

                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                RestResponse response = await client.ExecuteAsync(Request);

                HttpStatusCode statusCode = response.StatusCode;

                if (response != null && statusCode == HttpStatusCode.OK)
                {

                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);

                    return list;

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw;
            }
        }

        public async Task<User?> ConsultarUsuarioPorID(int IDUsuario = 3)
        {
            try
            {
                string RouteSufix = $"Users/{IDUsuario}";
                string URL = Services.WebAPIConnection.BaseURL + RouteSufix;

                RestClient client = new RestClient(URL);
                Request = new RestRequest(URL, Method.Get);

                Request.AddHeader(Services.WebAPIConnection.ApiKeyName, Services.WebAPIConnection.ApiKeyValue);

                RestResponse response = await client.ExecuteAsync(Request);

                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    var user = JsonConvert.DeserializeObject<User>(response.Content);
                    return user;
                }
                else
                {
                    return null;
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
