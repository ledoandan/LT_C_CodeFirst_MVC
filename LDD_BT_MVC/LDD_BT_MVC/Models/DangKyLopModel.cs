using System.Security.Claims;

namespace LDD_BT_MVC.Models
{
    public class DangKyLopModel
    {
        public int Id { get; set; }

        public int SinhVienId { get; set; }
        public SinhVienModel SinhVien { get; set; }

        public int LopId { get; set; }
        public LopModel Lop { get; set; }
    }
}
