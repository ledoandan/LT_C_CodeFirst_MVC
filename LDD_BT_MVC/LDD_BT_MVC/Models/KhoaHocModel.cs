using System.Security.Claims;

namespace LDD_BT_MVC.Models
{
    public class KhoaHocModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<LopModel> Lops { get; set; }
    }
}
