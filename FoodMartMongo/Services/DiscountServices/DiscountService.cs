using AutoMapper;
using FoodMartMongo.Dtos.DiscountDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<Discount> _discountCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);

            _discountCollection = database.GetCollection<Discount>(databaseSettings.DiscountCollectionName);
            _mapper = mapper;
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountsAsync()
        {
            var values = await _discountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(values);
        }

        public async Task<GetDiscountByIdDto> GetDiscountByIdAsync(string id)
        {
            var value = await _discountCollection.Find(x => x.DiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetDiscountByIdDto>(value);
        }
    
        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            var value = _mapper.Map<Discount>(updateDiscountDto);
            await _discountCollection.FindOneAndReplaceAsync(x => x.DiscountId == updateDiscountDto.DiscountId, value);
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var value = _mapper.Map<Discount>(createDiscountDto);
            await _discountCollection.InsertOneAsync(value);
        }


        public async Task DeleteDiscountAsync(string id)
        {
            await _discountCollection.DeleteOneAsync(x => x.DiscountId == id);
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            var discounts = await _discountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(discounts);
        }
    }
}
