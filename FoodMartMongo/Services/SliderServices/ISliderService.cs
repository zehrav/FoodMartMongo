using FoodMartMongo.Dtos.SliderDtos;

namespace FoodMartMongo.Services.SliderServices
{
    public interface ISliderService
    {
        Task<List<ResultSliderDto>> GetAllSliderListAsync();

        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string sliderId);

        Task<GetSliderByIdDto> GetSliderByIdAsync(string sliderId);

    }
}
