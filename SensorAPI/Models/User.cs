
using System.ComponentModel.DataAnnotations;

namespace SensorAPI.Models
{
    public class User
    {
        public User(){}

        public User(string userName, string device)
        {
            this.UserName = userName;
            this.Device = device;
        }

        [Key]
        public string UserName { get; set; }

        public string Device { get; set; }

    }
}