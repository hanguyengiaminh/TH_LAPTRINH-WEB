using System.ComponentModel.DataAnnotations;

namespace SiteBanHang.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten danh muc.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<Product>? Products { get; set; }
    }
}
