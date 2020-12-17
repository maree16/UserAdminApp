using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace UserAdminApp.ApiControl
{
    public class OrganizationProcessor
    {
        // async because it wont overload your host 
        // Tasks class to let you create tasks
        // and run them asynchronously.
        // A task is an object that represents some work that should be done. 
        // The task can tell you if the work is completed and if the operation returns a result

        public static async Task<OrganizationModel> LoadOrganization() 
        {
            string Url = ConfigurationManager.AppSettings["OrganizationPostApiUrl"];

          
            using (HttpResponseMessage response = await ApiHelper.http.GetAsync(Url)) 
            {
                if (response.IsSuccessStatusCode) 
                {
                        OrganizationModel organization = await response.Content.ReadAsAsync<OrganizationModel>();
                        
                        return organization;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }  
    }
}
