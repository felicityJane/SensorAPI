using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using SensorAPI.Models;
using SensorAPI.Repositories;

namespace SensorAPI.Controllers
{
    [RoutePrefix("sensor")]
    public class SensorController : ApiController
    {
        private ISensorRepository _sensorRepository;

        public SensorController(ISensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
        }

        [Route("postdata")]
        [HttpPost]
        [Authorize]
        public IHttpActionResult PostData(SensorData sensorData)
        {        
            try
            {
                _sensorRepository.InsertSensorData(sensorData);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok("sensor data added");
        }

        [Route("getsensordata/{userId}")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetSensorData(string userId)
        {
            List<SensorData> sensorData;
            try
            {
                sensorData = _sensorRepository.GetSensorData(userId);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok(sensorData);
        }

        [Route("getsensordata")]
        [HttpGet]
        [Authorize]
        public IHttpActionResult GetSensorData()
        {
            List<SensorData> sensorData;
            try
            {
                sensorData = _sensorRepository.GetSensorData();
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok(sensorData);
        }

        [Route("deletesensordata/{id}")]
        [Authorize]
        [HttpDelete]
        public IHttpActionResult DeleteSensorData(int id)
        {
            try
            {
                _sensorRepository.DeleteSensorData(id);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok("entry removed");
        }

        [Route("deletesensordatauser/{userId}")]
        [HttpDelete]
        public IHttpActionResult DeleteSensorDataUser(string userId)
        {
            try
            {
                _sensorRepository.DeleteSensorDataUser(userId);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Ok("entry removed");
        }

        [Authorize]
        [Route("claims")]
        [HttpGet]
        public object Claims()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;

            return claimsIdentity.Claims.Select(c =>
                new
                {
                    Type = c.Type,
                    Value = c.Value
                });
        }
    }
}