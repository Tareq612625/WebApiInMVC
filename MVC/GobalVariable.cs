using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
namespace MVC
{
    public static class GobalVariable
    {
        public static HttpClient WebApiClient = new HttpClient();

         static GobalVariable() {
            WebApiClient.BaseAddress = new Uri("https://localhost:44383/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}