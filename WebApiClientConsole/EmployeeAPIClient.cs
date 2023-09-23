using FirstWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
namespace WebApiClientConsole
{
    internal class EmployeeAPIClient
    {
        static Uri uri = new Uri("http://localhost:5266/");
        public static async Task CallGetEmployee()
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = uri;
            //    List<EmpViewModel> employee = new List<EmpViewModel>();
            //    client.DefaultRequestHeaders
            //        .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    //HttpGet:
            //    HttpResponseMessage response = await client.GetAsync("GetAll");
            //    response.EnsureSuccessStatusCode();
            //    if (response.IsSuccessStatusCode)
            //    {
            //        string x = await response.Content.ReadAsStringAsync();
            //        await Console.Out.WriteLineAsync(x);
            //    }

            //}
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                List<EmpViewModel> employee = new List<EmpViewModel>();
                client.DefaultRequestHeaders
                  .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HttpGet:
                HttpResponseMessage response = await client.GetAsync("GetAll");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    String json = await response.Content.ReadAsStringAsync();
                    employee = JsonConvert.DeserializeObject<List<EmpViewModel>>(json);
                    foreach (EmpViewModel emp in employee)
                    {
                        await Console.Out.WriteLineAsync($"{emp.EmpId},{emp.FirstName},{emp.LastName},{emp.Title},{emp.BirthDate},{emp.HireDate},{emp.City},{emp.ReportsTo}");
                    }

                }

            }


        }
        public static async Task AddEmployee()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "Shri",
                    LastName = "Lekha",
                    City = "Chennai",
                    BirthDate = new DateTime(2001, 01, 01),
                    HireDate = new DateTime(2023, 06, 16),
                    Title = "Manager"
                };

                var myContent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //[HttpPut]
                HttpResponseMessage response = await client.PutAsync("AddnewEmployee", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }


            }
        }
        public static async Task UpdateEmployee(int Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                EmpViewModel employee = new EmpViewModel()
                {
                    FirstName = "Shri",
                    LastName = "Lekha",
                    City = "Chennai",
                    BirthDate = new DateTime(2001, 01, 01),
                    HireDate = new DateTime(2023, 06, 16),
                    Title = "Manager"
                };

                var myContent = JsonConvert.SerializeObject(employee);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //[HttpPost]
                HttpResponseMessage response = await client.PostAsync($"ModifyEmployees?{Id}", byteContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    await Console.Out.WriteLineAsync(response.StatusCode.ToString());
                }

            }
        }
    }
}

                    
            
