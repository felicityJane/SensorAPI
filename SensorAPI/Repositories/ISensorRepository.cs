using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public interface ISensorRepository
    {
        //add entry
        SensorData InsertSensorData(SensorData sensorData);

        //get entry by userId
        List<SensorData> GetSensorData(string userId);

        //get all entries by userId
        List<SensorData> GetSensorData();
        
        //delete single entry
        string DeleteSensorData(int id);

        //delete all entries by userId
        string DeleteSensorDataUser(string userId);
    }
}