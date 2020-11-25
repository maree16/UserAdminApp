using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace UserAdminApp
{
    public class ApiHelper
    {
            public static HttpClient http { get; set; }


        public static void InitializeClient()
        {
            http = new HttpClient();
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
