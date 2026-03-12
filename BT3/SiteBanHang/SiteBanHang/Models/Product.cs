using System.ComponentModel.DataAnnotations;

namespace SiteBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui long nhap ten san pham.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0.01, 100000000, ErrorMessage = "Gia san pham phai lon hon 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Vui long nhap mo ta.")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Hinh anh")]
        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public List<ProductImage>? Images { get; set; }

        [Display(Name = "Danh muc")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui long chon danh muc.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
