using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.ApiControl
{
    class EmployeeProcessor
    {
        // async because it wont overload your host 
        // Tasks class to let you create tasks
        // and run them asynchronously.
        // A task is an object that represents some work that should be done. 
        // The task can tell you if the work is completed and if the operation returns a result

        public static async Task<ObservableCollection<EmployeeModel>> LoadEmployee()
        {
            string Url = ConfigurationManager.AppSettings["EmployeeGetApi"];


            using (HttpResponseMessage response = await ApiHelper.http.GetAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {
                    var employees =  await response.Content.ReadAsAsync<ObservableCollection<EmployeeModel>>();
                    return employees;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}

