using FoodMartMongo.Dtos.DiscountDtos;

namespace FoodMartMongo.Services.DiscountServices
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task<GetDiscountByIdDto> GetDiscountByIdAsync(string id);

        Task CreateDiscountAsync(CreateDiscountDto dto);
        Task UpdateDiscountAsync(UpdateDiscountDto dto);
        Task DeleteDiscountAsync(string id);



    }
}
