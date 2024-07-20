using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.MVC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Protocol;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
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
                    GeneralResponse generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse.IsSuccess)
                    {
                        HttpContext.Session.Set("CustomerID", Encoding.UTF8.GetBytes(generalResponse.Data.ToJson()));

                        return View("Login");
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
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
            return View();
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
                    GeneralResponse generalResponse = JsonConvert.DeserializeObject<GeneralResponse>(jsonResponse);

                    if (generalResponse.IsSuccess)
                    {
                //        // Set authentication cookie
                //        var claims = new List<Claim>
                //{
                //    new Claim(ClaimTypes.Name, userVM.UserName), // Assuming Username is part of your claims
                //    // Add more claims as needed
                //};

                //        var claimsIdentity = new ClaimsIdentity(
                //            claims, CookieAuthenticationDefaults.AuthenticationScheme);

                //        var authProperties = new AuthenticationProperties
                //        {
                //            IsPersistent = true, // Persist the cookie
                //            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30) // Cookie expiration time
                //        };

                //        await HttpContext.SignInAsync(
                //            CookieAuthenticationDefaults.AuthenticationScheme,
                //            new ClaimsPrincipal(claimsIdentity),
                //            authProperties);

                        // Set session variables
                        HttpContext.Session.SetString("Token", generalResponse.Token);
                        HttpContext.Session.SetString("TokenExpires", generalResponse.Expired.ToString());

                        long customerIdLong = generalResponse.Data; // Assuming generalResponse.Data is of type long

                        // Explicitly convert long to int
                        int customerId = (int)customerIdLong;

                        // Store in session
                        HttpContext.Session.SetInt32("CustomerID", customerId);

                        return RedirectToAction("LoginSuccess");
                    }
                    else
                    {
                        // Handle unsuccessful response
                        ViewBag.ResponseMessage = "Invalid Credentials or Login Failed";
                        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
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
    }
}