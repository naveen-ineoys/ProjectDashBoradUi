using Microsoft.EntityFrameworkCore;
using ProjectUi.Models;

namespace ProjectUi.Data
{
    public class AppContentClass :DbContext
    {
        public AppContentClass(DbContextOptions<AppContentClass> options) : base(options)
        {
        }
        public DbSet<MainModel> User { get; set; }
        
    }
}
