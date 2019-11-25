using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticateService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AuthenticateService.Models;


namespace AuthenticateService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginInterface _repository;
        public LoginController(ILoginInterface repository)
        {
            _repository = repository;
        }
        // GET: api/Login
        [HttpGet]
        [Route("Validate/{email}/{pwd}")]
        
        public Token Get(string email, string pwd)

        {
            
            if (_repository.UserLogin(email, pwd) != null)
            {
                User response = _repository.UserLogin(email, pwd);
                return new Token() { message = "User", token =response.User_Name ,user_id=response.User_Id };

            }
            else if (_repository.MentorLogin(email,pwd)!=null)
            {
                Mentor response = _repository.MentorLogin(email, pwd);
                return new Token() { message = "Mentor", token = response.Mentor_Name };
            }
            else if (email == "ankit@gmail.com" && pwd == "adminA123")
            {
                return new Token() { message = "Admin", token ="Admin"  };
            }
            else
            {
                return new Token() { message = "Invalid User", token = "" };
            }
        }
        public string GetToken()
        {
            return "";
        }
    }
   
}
