using FoodMartMongo.Dtos.CategoryDtos;

namespace FoodMartMongo.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsnc(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsnc(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsnc(string id);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(string id);
    }
}
