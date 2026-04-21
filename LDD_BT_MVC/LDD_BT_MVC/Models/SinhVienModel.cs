namespace LDD_BT_MVC.Models
{
    public class SinhVienModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<DangKyLopModel> DangKyLops { get; set; }
    }
}
