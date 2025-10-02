using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FoodMartMongo.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Admin> _adminCollection;

        public AdminService(IDatabaseSettings databaseSettings)
        {
         

            var client = new MongoClient(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);

            // Collection adı "Admins"
            _adminCollection = db.GetCollection<Admin>("Admins");
        }

        // Kullanıcı adıyla admin bul
        public async Task<Admin> GetByUsernameAsync(string username)
        {
            if (string.IsNullOrEmpty(username))
                return null;

            return await _adminCollection
                .Find(a => a.Username == username)
                .FirstOrDefaultAsync();
        }

        // Yeni admin ekle
        public async Task CreateAdminAsync(Admin admin)
        {
            if (admin == null)
                throw new ArgumentNullException(nameof(admin));
        
            await _adminCollection.InsertOneAsync(admin);
        }
    }
}
