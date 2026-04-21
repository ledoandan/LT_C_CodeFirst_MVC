using LDD_BT_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LDD_BT_MVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<KhoaHocModel> Courses { get; set; }
        public DbSet<SinhVienModel> Students { get; set; }
        public DbSet<GiaoVienModel> Teachers { get; set; }
        public DbSet<LopModel> Classes { get; set; }
        public DbSet<DangKyLopModel> Enrollments { get; set; }
    }
}
