using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api
{
    public class ApiConnection
    {
        public static HttpClient ApiClient { get; set; }
        
        //Getting a Request 
        // CLearing its header
        // and Asking For Json so we can parse it 
        public static void InitatializeClient() 
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }




    }
}
