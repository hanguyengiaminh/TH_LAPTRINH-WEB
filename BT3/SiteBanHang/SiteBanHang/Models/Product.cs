using System.ComponentModel.DataAnnotations;

namespace SiteBanHang.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá")]
        [Range(0.01, 100000000, ErrorMessage = "Giá sản phẩm phải lớn hơn 0.")]
        public decimal Price { get; set; }

        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Vui lòng nhập mô tả.")]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Hình ảnh")]
        [StringLength(500)]
        public string? ImageUrl { get; set; }

        public List<ProductImage>? Images { get; set; }

        [Display(Name = "Danh mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn danh mục.")]
        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
