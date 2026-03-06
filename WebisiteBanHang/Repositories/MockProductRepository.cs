using System;
using System.Collections.Generic;
using System.Linq;
using WebisiteBanHang.Models;

namespace WebisiteBanHang.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public MockProductRepository()
        {
            
            _products = new List<Product>
            {
                new Product {
                    Id = 1,
                    Name = "Xiaomi Mi Band 4",
                    Price = 500,
                    Description = "AMOLED color touch screen with better brightness.",
                    ImageUrl = "/images/buy-1.jpg",
                    CategoryId = 1
                },
                new Product {
                    Id = 2,
                    Name = "Smart Watch Black",
                    Price = 750,
                    Description = "Track physical activity including swimming.",
                    ImageUrl = "/images/exclusive.png",
                    CategoryId = 1
                },
                new Product {
                    Id = 3,
                    Name = "HRX Sneakers",
                    Price = 1200,
                    Description = "High-quality running shoes from HRX brand.",
                    ImageUrl = "/images/product-1.jpg",
                    CategoryId = 2
                }
            };
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            // Logic để tự động tăng ID an toàn ngay cả khi danh sách rỗng
            int nextId = _products.Any() ? _products.Max(p => p.Id) + 1 : 1;
            product.Id = nextId;
            _products.Add(product);
        }

        public void Update(Product product)
        {
            // Tìm sản phẩm trong danh sách dựa trên Id
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }

        public void Delete(int id)
        {
            // Xóa sản phẩm nếu tìm thấy Id tương ứng
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}