using System;
using System.Collections.Generic;
using System.Web.Http;
using SensorAPI.Models;
using SensorAPI.Repositories;

namespace SensorAPI.Controllers
{
    [RoutePrefix("user")]
    public class UserController : ApiController
    {
        private IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("adduser")]
        [Authorize]
        [HttpPost]
        public IHttpActionResult AddUser(User user)
        {
            try
            {
                _userRepository.InsertUser(user);
            }
            catch(Exception e)
            {
                return Json(e.Message);
            }
           return Ok("user added");
        }

        [Route("getuser/{userName}")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUser(string userName)
        {
            User user;
            try
            {
                user = _userRepository.GetUser(userName);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok(user);
        }

        [Route("getuser")]
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUser()
        {
            List<User> user;
            try
            {
                user = _userRepository.GetUser();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok(user);
        }

        [Route("deleteuser/{userId}")]
        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteUser(string userId)
        {
            try
            {
                _userRepository.DeleteUser(userId);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok("user deleted");
        }
    }
}