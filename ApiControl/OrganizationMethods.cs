using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UserAdminApp.ApiControl
{
    public class OrganizationMethods: OrganizationProcessor
    {
        //POST 
        public static async void PostMethod(EmployeeModel jsondata)
        {
            string Url = ConfigurationManager.AppSettings["EmployeePostApi"];

            using (HttpResponseMessage response = await ApiHelper.http.PostAsJsonAsync(Url, jsondata))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }


        //PUT
        public static async void  PutMethod(EmployeeModel jsondata,string id )
        {
            string Url = ConfigurationManager.AppSettings["EmployeePutApi"]+id;

            using (HttpResponseMessage response = await ApiHelper.http.PutAsJsonAsync(Url, jsondata))
            {
                if (response.IsSuccessStatusCode)
                {
                   
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        // Delete Method 
        public static async void DeleteMethod(string id)
        {
            string Url = ConfigurationManager.AppSettings["EmployeePutApi"] + id;

            using (HttpResponseMessage response = await ApiHelper.http.DeleteAsync(Url))
            {
                if (response.IsSuccessStatusCode)
                {

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
    // DELETE
}