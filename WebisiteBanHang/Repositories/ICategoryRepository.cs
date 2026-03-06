using WebisiteBanHang.Models;
using System.Collections.Generic; 

namespace WebisiteBanHang.Repositories
{
    // Đổi 'class' thành 'interface'
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategories();
    }
}