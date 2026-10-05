using Microsoft.EntityFrameworkCore;

namespace Bai3.Models
{
    public partial class SunriseHomestayContext
    {
        public static string ConnectionString { get; set; } =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=SunriseHomestay;Integrated Security=True;TrustServerCertificate=True";

        public SunriseHomestayContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
        }
    }
}
