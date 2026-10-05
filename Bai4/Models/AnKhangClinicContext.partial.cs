using Microsoft.EntityFrameworkCore;

namespace Bai4.Models
{
    public partial class AnKhangClinicContext
    {
        public static string ConnectionString { get; set; } =
            "Data Source=.\\SQLEXPRESS;Initial Catalog=AnKhangClinic;Integrated Security=True;TrustServerCertificate=True";

        public AnKhangClinicContext()
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
