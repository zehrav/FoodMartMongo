using FoodMartMongo.Entities;

namespace FoodMartMongo.Services.AdminServices
{
    public interface IAdminService
    {
        Task<Admin> GetByUsernameAsync(string username);
        Task CreateAdminAsync(Admin admin);
    }
}
