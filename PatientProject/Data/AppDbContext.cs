using Microsoft.EntityFrameworkCore;
using PatientProject.Models;

namespace PatientProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Patient> patients { get; set; }
    }
}
