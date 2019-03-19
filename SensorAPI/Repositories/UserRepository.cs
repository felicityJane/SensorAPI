using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using SensorAPI.DataAccess;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        public User InsertUser(User user)
        {
            try
            {
                using (var context = new HeadsUpContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
               throw e;
            }
            return user;
        }

        //get user by userName
        public User GetUser(string userName)
        {
            User user;
            try
            {
                using (var context = new HeadsUpContext())
                {
                    user = context.Users.Find(userName);                  
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        //get all users
        public List<User> GetUser()
        {
            List<User> user;
            try
            {
                using (var context = new HeadsUpContext())
                {
                    user = context.Users.ToList();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return user;
        }

        public string DeleteUser(User user)
        {
            try
            {
                using (var context = new HeadsUpContext())
                {
                    context.Users.Attach(user);
                    context.Users.Remove(user);
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