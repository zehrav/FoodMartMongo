using AutoMapper;
using FoodMartMongo.Dtos.SliderDtos;
using FoodMartMongo.Entities;
using FoodMartMongo.Settings;
using MongoDB.Driver;

namespace FoodMartMongo.Services.SliderServices
{
    public class SliderService : ISliderService
    {
        private readonly IMongoCollection<Slider> _sliderCollection;
        private readonly IMapper _mapper;

        public SliderService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);

            var database = client.GetDatabase(_databaseSettings.DatabaseName);

            _sliderCollection = database.GetCollection<Slider>(_databaseSettings.SliderCollectionName);

            _mapper = mapper;
        }

        public async Task CreateSliderAsync(CreateSliderDto createSliderDto)
        {
            var value = _mapper.Map<Slider>(createSliderDto);
            await _sliderCollection.InsertOneAsync(value);
        }

        public async Task<List<ResultSliderDto>> GetAllSliderListAsync()
        {
            var values = await _sliderCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultSliderDto>>(values);
        }

        public async Task<GetSliderByIdDto> GetSliderByIdAsync(string id)
        {
            var value = await _sliderCollection.Find(x => x.SliderId == id).FirstOrDefaultAsync();

            return _mapper.Map<GetSliderByIdDto>(value);
        }
        public async Task UpdateSliderAsync(UpdateSliderDto updateSliderDto)
        {
            // DTO -> Entity
            var value = _mapper.Map<Slider>(updateSliderDto);

            // ID ile bul ve değiştir
            await _sliderCollection.FindOneAndReplaceAsync(x => x.SliderId == updateSliderDto.SliderId, value);
        }

        // Slider silme
        public async Task DeleteSliderAsync(string id)
        {
            // ID ile bul ve sil
            await _sliderCollection.DeleteOneAsync(x => x.SliderId == id);
        }
    }
}
