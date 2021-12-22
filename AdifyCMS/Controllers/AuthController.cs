using AdifyCMS.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace AdifyCMS.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult RegisterView()
        {
            return View();
        }

        public IActionResult Register([Bind("UserName, Email, Password")] User user)
        {
            var client = new RestClient("http://localhost:5002/api/Authenticate/register");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + "\n" +
                @$"    ""Username"": ""{user.UserName}"",
                " + "\n" +
                @$"    ""Email"": ""{user.Email}"",
                " + "\n" +
                @$"    ""Password"": ""{user.Password}""
                " + "\n" +
                @"}";
            request.AddParameter("application/json", (body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            if((response.StatusCode).ToString() == "OK")
            {
                return View("LoginView");
            } else
            {
                return View();
            }

        }

        public IActionResult LoginView()
        {
            return View();
        }

        private string extractValue(string data)
        {
            dynamic temp = data.Split("\"");
            return temp[3];
        }

        public IActionResult Login([Bind("UserName, Password")] User user)
        {
            var client = new RestClient("http://localhost:5002/api/Authenticate/login");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            var body = @"{
                " + "\n" +
                @$"    ""Username"": ""{user.UserName}"",
                " + "\n" +
                @$"    ""Password"": ""{user.Password}""
                " + "\n" +
                @"}";
            request.AddParameter("application/json", (body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            
            
            if ((response.StatusCode).ToString() == "OK")
            {
                dynamic result = JsonConvert.DeserializeObject(response.Content);
                List<string> items = new List<string>();
                foreach (var item in result)
                {
                    items.Add(Convert.ToString(item));
                }
                TempData["Username"] = extractValue(items[0]);
                TempData["jwt"] = extractValue(items[1]);
                TempData["userid"] = extractValue(items[2]);
                var token = new JwtSecurityToken(jwtEncodedString: TempData.Peek("jwt").ToString());

                try
                {
                    TempData["isAdmin"] = token.Claims.First(c => c.Type.Contains("role")).Value.ToString() == "Admin" ? "true" : "false";
                }
                catch
                {
                    TempData["isAdmin"] = "false";
                }
                TempData["isLoggedIn"] = "true";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            TempData.Clear();
            TempData["isLoggedIn"] = "false";
            TempData["isAdmin"] = "false";
            return View("LoginView");
        }
    }
}
