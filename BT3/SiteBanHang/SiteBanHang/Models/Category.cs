using System.ComponentModel.DataAnnotations;

namespace SiteBanHang.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
        [StringLength(50)]
        public string Name { get; set; } = string.Empty;

        public List<Product>? Products { get; set; }
    }
}
