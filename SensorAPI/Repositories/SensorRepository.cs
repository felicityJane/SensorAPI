using System;
using System.Collections.Generic;
using System.Linq;
using SensorAPI.DataAccess;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public class SensorRepository : ISensorRepository
    {

        public SensorData InsertSensorData(SensorData sensorData)
        {
            try
            {
                using (var context = new HeadsUpContext())
                {
                    context.SensorData.Add(sensorData);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return sensorData;
        }

        //get specific entry buy userId
        public List<SensorData> GetSensorData(string userId)
        {
            List<SensorData> sensorData;
            try
            {
                using (var context = new HeadsUpContext())
                {
                    sensorData = context.SensorData.Where(x => x.UserId == userId).ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return sensorData;
        }


        //get all entries 
        public List<SensorData> GetSensorData()
        {
            List<SensorData> sensorData;
            try
            {
                using (var context = new HeadsUpContext())
                {
                    sensorData = context.SensorData.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return sensorData;
        }

        //remove single sensor entry
        public string DeleteSensorData(int id)
        {
            try
            {
                using (var context = new HeadsUpContext())
                {
                    var sensorData = context.SensorData.Find(id);
                    context.SensorData.Remove(sensorData ?? throw new InvalidOperationException());
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return "ok";
        }

        //remove all sensor entry for user
        public string DeleteSensorDataUser(string userId)
        {
            try
            {
                using (var context = new HeadsUpContext())
                {
                    var sensorData = context.SensorData.Where(x => x.UserId == userId).ToList();
                    context.SensorData.RemoveRange(sensorData ?? throw new InvalidOperationException());
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return "ok";
        }
    }
}