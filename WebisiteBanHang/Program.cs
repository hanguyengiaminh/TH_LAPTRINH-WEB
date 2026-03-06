using WebisiteBanHang.Repositories;

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm các dịch vụ vào container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IProductRepository, MockProductRepository>();
// Sử dụng Scoped cho Category
builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();

var app = builder.Build();

// 3. Cấu hình HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Cho phép truy cập các file trong wwwroot 
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();