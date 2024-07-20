using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelBookingSystem.MVC.Controllers
{
    public class AccountController : Controller
    {
        //Uri baseAddress = new Uri("http://localhost:5006/api/");

        private readonly HttpClient httpClient;
        //private readonly IHttpClientFactory httpClientFactory;

        public AccountController
          (IHttpClientFactory httpClientFactory)
        {
            httpClient = httpClientFactory.CreateClient();
            httpClient.BaseAddress = new Uri("http://localhost:5006/api/");
        }

        //***********************************************

        public IActionResult Index()
        {
            return View("Register");
        }

        [HttpGet]
        public IActionResult Register()
        {
            Logout();

            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserDTO userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("Account/Register", userVM);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        return RedirectToAction("RegisterSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"Server : {generalResponse.Data}");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return Logout();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogInUserDTO userVM)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                HttpResponseMessage httpResponse = await httpClient.PostAsJsonAsync("Account/Login", userVM);

                if (httpResponse.IsSuccessStatusCode)
                {
                    string jsonResponse = await httpResponse.Content.ReadAsStringAsync();

                    // Deserialize the entire response into GeneralResponse
                    GeneralResponse? generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse?.IsSuccess ?? false)
                    {
                        // Set session variables
                        HttpContext.Session.SetString("Token", generalResponse?.Token ?? string.Empty);
                        HttpContext.Session.SetString("TokenExpires", generalResponse?.Expired?.ToString() ?? string.Empty);

                        long customerIdLong = generalResponse?.Data; // Assuming generalResponse.Data is of type long

                        // Explicitly convert long to int
                        int customerId = (int)customerIdLong;

                        // Store in session
                        HttpContext.Session.SetString("CustomerID", customerId.ToString());

                        return RedirectToAction("LoginSuccess");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid User name or Password , Try Again ...");
                        //ModelState.AddModelError(string.Empty, $"Server Message : {generalResponse?.Message??string.Empty}");
                    }
                }
                else
                {
                    // Handle unsuccessful HTTP response
                    ViewBag.ResponseMessage = "Server error. Please contact administrator.";
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            catch (Exception ex)
            {
                ViewBag.ResponseMessage = $"Error occurred: {ex.Message}";
                ModelState.AddModelError(string.Empty, $"Error occurred: {ex.Message}");
            }

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("account/RegisterSuccess")]
        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("account/LoginSuccess")]
        public IActionResult LoginSuccess()
        {
            return View();
        }

        [HttpGet]
        [Route("account/debug-session")]
        public IActionResult DebugSession()
        {
            var token = HttpContext.Session.GetString("Token");
            var tokenExpired = HttpContext.Session.GetString("TokenExpires");

            if (string.IsNullOrEmpty(token))
            {
                return Content("Token was not found in the session.");
            }

            return Content($"Token found in the session: {token} and the Expire Date: {tokenExpired}");
        }

        private bool CheckSessionToken()
        {
            var token = HttpContext.Session.GetString("Token");
            var tokenExpired = HttpContext.Session.GetString("TokenExpires");

            if (string.IsNullOrEmpty(token))
            {
                return false;
            }
            return true;
        }

        public IActionResult Logout()
        {
            bool tokenExisted = CheckSessionToken();

            if (tokenExisted)
            {
                // clear session first before registering new customer
                HttpContext.Session.Clear();
            }

            // to make sure Session is Empty :

            bool tokenExistedAgain = CheckSessionToken();

            if (tokenExistedAgain)
            {
                throw new Exception("Can't Clear Session before Regisering a new User .");
            }

            return View("Login");
        }

    }
}