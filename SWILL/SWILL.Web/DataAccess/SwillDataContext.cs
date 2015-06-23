using System.Data.Entity;
using SWILL.Web.Models;

namespace SWILL.Web.DataAccess
{
    //N.B. We need to re-think all of the data access and model classes. 
    //Run the application, save a few dishes, open SQL Management Studio and check what's in the SWILL database.
    public class SwillDataContext : DbContext
    {
        public SwillDataContext()
            : base("Swill") { } //Note that this name corresponds to the name of a connection string in the Web.Config

        public DbSet<Order> Orders { get; set; }
    }
}