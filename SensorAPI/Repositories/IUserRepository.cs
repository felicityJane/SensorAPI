using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SensorAPI.Models;

namespace SensorAPI.Repositories
{
    public interface IUserRepository
    {
        //add user
        User InsertUser(User user);
        // remove user

        //get user by id
        User GetUser(string userName);

        //get all users
        List<User> GetUser();

        //delete users
        string DeleteUser(string user);
    }
}
