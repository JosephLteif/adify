using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedProjectCMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace AdvancedProjectCMS.Controllers
{
    public class AuthenticationController : Controller
    {
        // GET: Authentication
        public ActionResult Index()
        {
            return View();
        }

        // GET: Authentication/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Authentication/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Authentication/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([FromBody] Register register)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new RestClient("http://localhost:59065/api/authenticate/register");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                var body = JsonConvert.SerializeObject(register);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);

                Console.WriteLine(response.Content);
                return Ok(response);
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authentication/Create
        public ActionResult Login()
        {
            return View();
        }

        // POST: Authentication/Create
        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Login([FromBody] Login login)
        {
            try
            {
                // TODO: Add insert logic here
                var client = new RestClient("http://localhost:59065/api/authenticate/login");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(login);
                Console.WriteLine(body);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                Console.WriteLine(response.Content);
                return Ok(response.Content);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Authentication/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Authentication/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}