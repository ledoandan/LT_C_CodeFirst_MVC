namespace LDD_BT_MVC.Models
{
    public class LopModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int KhoaHocId { get; set; }
        public KhoaHocModel KhoaHoc { get; set; }

        public int GiaoVienId { get; set; }
        public GiaoVienModel GiaoVien { get; set; }

        public ICollection<DangKyLopModel> DangKyLops { get; set; }
    }
}
