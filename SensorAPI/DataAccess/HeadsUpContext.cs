using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SensorAPI.Models;

namespace SensorAPI.DataAccess
{
    public class HeadsUpContext : DbContext
    {
        public HeadsUpContext() : base("name=HeadsUpContext") { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<SensorData> SensorData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}