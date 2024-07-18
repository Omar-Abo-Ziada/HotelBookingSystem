using HotelBookingSystem.API.Responses;
using HotelBookingSystem.Core.DTOs;
using HotelBookingSystem.Core.Interfaces;
using HotelBookingSystem.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelBookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration configuration;

        public AccountController(ICustomerRepository customerRepository , UserManager<ApplicationUser> userManager , IConfiguration configuration)
        {
            this.customerRepository = customerRepository;
            this.userManager = userManager;
            this.configuration = configuration;
        }

        //**********************************************

        [HttpPost("register")]
        public async Task<ActionResult<GeneralResponse>> Register(RegisterUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    NationalID = userDTO.NationalID,
                    Name = userDTO.Name,
                    PhoneNumber = userDTO.PhoneNumber,
                    AgeCategory = userDTO.AgeCategory,
                };

                customerRepository.Add(customer);

                customerRepository.Save();

                ApplicationUser user = new ApplicationUser()
                {
                    UserName = userDTO.Name,
                    PasswordHash = userDTO.Password,
                    Email = userDTO.Email,
                    PhoneNumber = userDTO.PhoneNumber,

                    CustomerID = customer.ID,
                };

                customer.ApplicationUser = user;

                // create Account in database
                IdentityResult createAccResult = await userManager.CreateAsync(user, userDTO.Password);

                if (createAccResult.Succeeded)
                {
                    // Adding user Role by default
                    IdentityResult addRoleResult = await userManager.AddToRoleAsync(user, "Customer");

                    if (!addRoleResult.Succeeded)
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Message = "Couldn't Add the default Role to this user ,, check that you already added Roles first"
                        };
                    }

                    //// Generate email confirmation token
                    //var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    //var confirmationLink = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, token }, Request.Scheme);

                    //string mailBody = $"<!DOCTYPE html>\r\n<html>\r\n<head>\r\n  <title>Email Confirmation</title>\r\n  <meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\" />\r\n  <style>\r\n    body {{\r\n      background: #f9f9f9;\r\n      margin: 0;\r\n      padding: 0;\r\n    }}\r\n    .container {{\r\n      max-width: 640px;\r\n      margin: 0 auto;\r\n      background: #ffffff;\r\n      box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);\r\n      border-radius: 4px;\r\n      overflow: hidden;\r\n    }}\r\n  </style>\r\n</head>\r\n<body>\r\n  <div class=\"container\">\r\n    <div style=\"background-color: #7289da; padding: 57px; text-align: center;\">\r\n      <div style=\"cursor: auto; color: white; font-family: Arial, sans-serif; font-size: 36px; font-weight: 600;\">\r\n        Welcome to SkyLink!\r\n      </div>\r\n    </div>\r\n    \r\n    <div style=\"padding: 40px 70px;\">\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <h2 style=\"font-weight: 500; font-size: 20px; color: #4f545c;\">Hey {user.UserName},</h2>\r\n        <p>\r\n          Welcome aboard SkyLink! 🚀 Thanks for signing up! We're thrilled to have you join our community.\r\n        </p>\r\n        <p>\r\n          To get started, we just need to confirm your email address to ensure everything runs smoothly.\r\n        </p>\r\n        <p>\r\n          Click the button below to verify your email and unlock all the amazing features SkyLink has to offer:\r\n        </p>\r\n      </div>\r\n      <div style=\"text-align: center; padding: 20px;\">\r\n        <a href=\"{confirmationLink}\" style=\"display: inline-block; background-color: #7289da; color: white; text-decoration: none; padding: 15px 30px; border-radius: 3px;\">Verify Email</a>\r\n      </div>\r\n      <div style=\"color: #737f8d; font-family: Arial, sans-serif; font-size: 16px; line-height: 24px;\">\r\n        <p>If you have any questions or need assistance, feel free to reach out to our support team.</p>\r\n        <p>Omar<br>SkyLink Team</p>\r\n      </div>\r\n    </div>\r\n  </div>\r\n</body>\r\n</html>\r\n";

                    // Send email confirmation link
                    //await _emailService.SendEmailAsync(userDTO.Email, "Email Confiramtion", mailBody, true);

                    //----------------------------------

                    return new GeneralResponse()
                    {
                        IsSuccess = true,
                        Data = user.Id,
                        Message = "Account Created and Customer Added  Successfully"
                    };
                }
                else
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = createAccResult.Errors,
                        Message = "Couldn't create Account due to these errors"
                    };
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<GeneralResponse>> Login(LogInUserDTO userDTO)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser? userFromDB = await userManager.FindByNameAsync(userDTO.UserName);

                if (userFromDB is null)
                {
                    return new GeneralResponse()
                    {
                        IsSuccess = false,
                        Data = null,
                        Message = "can't find this user name"
                    };
                }
                //else if (!userFromDB.EmailConfirmed)
                //{
                //    return new GeneralResponse()
                //    {
                //        IsSuccess = false,
                //        Data = null,
                //        Message = "this user Email is not confirmed"
                //    };
                //}
                else
                {
                    bool IsPasswordMatched = await userManager.CheckPasswordAsync(userFromDB, userDTO.Password);

                    if (IsPasswordMatched)
                    {
                        // create token steps : 
                        List<Claim> myClaims = new List<Claim>();
                        myClaims.Add(new Claim(ClaimTypes.Name, userFromDB.UserName ?? "Not Available"));
                        myClaims.Add(new Claim(ClaimTypes.NameIdentifier, userFromDB.Id));
                        //myClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // if u want for the same user => his token be unique for each login => uncomment this

                        // claim roles
                        IList<string> roles = await userManager.GetRolesAsync(userFromDB);

                        foreach (string role in roles)
                        {
                            myClaims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        //  security key 
                        SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:SecretKey"]));

                        // in the JWT header =>  credentials : key + ALgorithm
                        SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                        // in the JWT payload => JwtSecurityToken is a class that design the token
                        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
                            (
                            issuer: configuration["JWT:ValidIss"], // the povider API who is responsible for creating the token
                            audience: configuration["JWT:ValidAud"],  // the consumer (React domain)
                            expires: DateTime.Now.AddHours(1),
                            claims: myClaims,
                            signingCredentials: signingCredentials
                            );

                        //return the token
                        return new GeneralResponse()
                        {
                            IsSuccess = true,
                            Data = null,
                            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                            Expired = jwtSecurityToken.ValidTo,
                            Message = "Token Created Successfully"
                        };
                    }
                    else
                    {
                        return new GeneralResponse()
                        {
                            IsSuccess = false,
                            Data = null,
                            Message = "Wrong Password"
                        };
                    }
                }
            }
            else
            {
                return new GeneralResponse()
                {
                    IsSuccess = false,
                    Data = ModelState,
                    Message = "Invalid Model State"
                };
            }
        }
    }
}