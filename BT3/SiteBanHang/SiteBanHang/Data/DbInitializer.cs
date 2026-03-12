using SiteBanHang.Models;

namespace SiteBanHang.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Categories.Any())
            {
                return;
            }

            var categories = new List<Category>
            {
                new() { Name = "Dien thoai" },
                new() { Name = "Laptop" },
                new() { Name = "Phu kien" }
            };

            context.Categories.AddRange(categories);
            context.SaveChanges();

            var products = new List<Product>
            {
                new()
                {
                    Name = "iPhone 15",
                    Price = 22990000,
                    Description = "Dien thoai cao cap voi camera sac net va hieu nang manh me.",
                    ImageUrl = "https://images.unsplash.com/photo-1695048133142-1a20484d2569?auto=format&fit=crop&w=600&q=80",
                    CategoryId = categories[0].Id
                },
                new()
                {
                    Name = "Dell XPS 13",
                    Price = 31990000,
                    Description = "Laptop mong nhe phu hop hoc tap va lam viec chuyen nghiep.",
                    ImageUrl = "https://images.unsplash.com/photo-1496181133206-80ce9b88a853?auto=format&fit=crop&w=600&q=80",
                    CategoryId = categories[1].Id
                },
                new()
                {
                    Name = "Tai nghe Bluetooth",
                    Price = 1290000,
                    Description = "Tai nghe khong day am thanh ro rang, pin ben bi.",
                    ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?auto=format&fit=crop&w=600&q=80",
                    CategoryId = categories[2].Id
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
