using CustomerPortalMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortalMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> ViewAllStocks()
        {
            List<Stocks> stocks = new List<Stocks>();

            using (var client = new HttpClient())
            {
                //client.BaseAddress = new Uri("http://localhost:50195");
                client.BaseAddress = new Uri("http://52.150.44.236");
                var responseTask = client.GetAsync("/api/stocks");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = await result.Content.ReadAsStringAsync();
                    stocks = JsonConvert.DeserializeObject<List<Stocks>>(readTask);

                }
            }
            return View(stocks);
        }


        [HttpGet]
        public async Task<IActionResult> ViewAllMutuals()
        {
            List<MutualFunds> mutualFunds = new List<MutualFunds>();
           
            using(var client =new HttpClient())
            {
                // client.BaseAddress = new Uri("http://localhost:50374");
                client.BaseAddress = new Uri("http://52.190.26.226");
                var responseTask = client.GetAsync("/api/MutualFund");
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    
                    var readTask = await result.Content.ReadAsStringAsync();
                    mutualFunds = JsonConvert.DeserializeObject<List<MutualFunds>>(readTask);

                }
            }        
            return View(mutualFunds);
        }

        [HttpPost]
        public async Task<ActionResult> Login(Customer customer)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

                //  using (var response = await httpClient.PostAsync("http://localhost:50511/api/Authorization/authenticate/", content))
                using (var response = await httpClient.PostAsync("http://52.249.209.43/api/Authorization/authenticate/", content))
                {
                    string stringJWT = response.Content.ReadAsStringAsync().Result;
                    JWT jwt = JsonConvert.DeserializeObject<JWT>(stringJWT);
                    if (jwt.Token != null)
                    {
                        HttpContext.Session.SetString("token", jwt.Token);
                        HttpContext.Session.SetString("email", jwt.Email);
                        return View("AfterLoginView");// ViewStockDetails
                    }
                    else
                    {
                        
                        ViewBag.Message = "Invalid Username or Password";
                        return View("Login"); //Login
                    }
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> ViewStockDetails()
        {
            List<StockDetail> stockList = new List<StockDetail>();

            // string baseUrl = "http://localhost:50511";
            string baseUrl = "http://52.249.209.43";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",HttpContext.Session.GetString("token"));
            
            var response = await httpClient.GetAsync("/api/Authorization/GetCustomerByEmail/" + HttpContext.Session.GetString("email"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Login");
            }
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            //  var response2 = await httpClient.PostAsync("http://localhost:64855/api/CalculateNetWorth/GetStockByCustomer", content);
            var response2 = await httpClient.PostAsync("http://104.45.191.101/api/CalculateNetWorth/GetStockByCustomer", content);
            string apiresponse2 = await response2.Content.ReadAsStringAsync();
            stockList = JsonConvert.DeserializeObject<List<StockDetail>>(apiresponse2);

            
            if (stockList.Count == 0)
            {
                
                return View("EmptyStock");
            }
            return View(stockList);
        }

        [HttpGet]
        public async Task<IActionResult> ViewMutualFundDetails()
        {
            List<MutualFundDetail> mutualFundList = new List<MutualFundDetail>();

            //  string baseUrl = "http://localhost:50511";
            string baseUrl = "http://52.249.209.43";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var response = await httpClient.GetAsync("/api/Authorization/GetCustomerByEmail/" + HttpContext.Session.GetString("email"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Login");
            }
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            //  var response2 = await httpClient.PostAsync("http://localhost:64855/api/CalculateNetWorth/GetMutualFundByCustomer", content);
            var response2 = await httpClient.PostAsync("http://104.45.191.101/api/CalculateNetWorth/GetMutualFundByCustomer", content);

            string apiresponse2 = await response2.Content.ReadAsStringAsync();
            mutualFundList = JsonConvert.DeserializeObject<List<MutualFundDetail>>(apiresponse2);

            if (mutualFundList.Count == 0)
            {
                return View("EmptyMutualFund");
            }
            ViewBag.message = null;
            return View(mutualFundList);
        }
        

        [HttpGet]
        public async Task<IActionResult> ViewNetWorth()
        {
            // string baseUrl = "http://localhost:50511";
            string baseUrl = "http://52.249.209.43";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var response = await httpClient.GetAsync("/api/Authorization/GetCustomerByEmail/" + HttpContext.Session.GetString("email"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Login");
            }
            string apiResponse = await response.Content.ReadAsStringAsync();
            var customer = JsonConvert.DeserializeObject<Customer>(apiResponse);
            StringContent content = new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "application/json");

            // var response2 = await httpClient.PostAsync("http://localhost:64855/api/CalculateNetWorth", content);
            var response2 = await httpClient.PostAsync("http://104.45.191.101/api/CalculateNetWorth", content);

            string apiresponse2 = await response2.Content.ReadAsStringAsync();
            ViewBag.Value = apiresponse2;
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SellStock(int id)
        {
            //  string baseUrl = "http://localhost:50511";
            string baseUrl = "http://52.249.209.43";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var response = await httpClient.GetAsync("/api/Authorization/GetCustomerByEmail/" + HttpContext.Session.GetString("email"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Login");
            }

            //  var response2 = await httpClient.GetAsync("http://localhost:64855/api/CalculateNetWorth/sellStock/"+id);
            var response2 = await httpClient.GetAsync("http://104.45.191.101/api/CalculateNetWorth/sellStock/" + id);

            return RedirectToAction("ViewNetWorth");
        }

        [HttpGet]
        public async Task<IActionResult> SellMutualFund(int id)
        {
            //  string baseUrl = "http://localhost:50511";
            string baseUrl = "http://52.249.209.43";
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUrl);
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            httpClient.DefaultRequestHeaders.Accept.Add(contentType);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HttpContext.Session.GetString("token"));

            var response = await httpClient.GetAsync("/api/Authorization/GetCustomerByEmail/" + HttpContext.Session.GetString("email"));
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View("Login");
            }

            //  var response2 = await httpClient.GetAsync("http://localhost:64855/api/CalculateNetWorth/sellMutualFund/" + id);
            var response2 = await httpClient.GetAsync("http://104.45.191.101/api/CalculateNetWorth/sellMutualFund/" + id);

            return RedirectToAction("ViewNetWorth");
        }



        

    }

   
}
