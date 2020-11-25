using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.ApiControl
{
    public class OrganizationProcessor
    {
        public async Task LoadOrganization(int organizationNumber = 0) 
        {
            string url = "";
            if (organizationNumber > 0)
            {
                url = $"";
            }
            else
            { 
            }
            using (HttpResponseMessage response = await ApiHelper.http.GetAsync(url)) 
            {
                if (response.IsSuccessStatusCode) 
                {

                } 
            }
        }  
    }
}
