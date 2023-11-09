using AspNewCoreAPI_Intro.Entities;

namespace AspNewCoreAPI_Intro.Interfaces
{
    public interface IRepository
    {
        Task<List<City>> GetAllAsync();
        Task<City> GetByIdAsync(int id);
        Task<City> CreateAsync(City city);
        Task UpdateAsync(City city);
        Task DeleteAsync(City city);
    }
}
