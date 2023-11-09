using AspNewCoreAPI_Intro.Data;
using AspNewCoreAPI_Intro.Entities;
using AspNewCoreAPI_Intro.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AspNewCoreAPI_Intro.Repositories
{
    public class Repository : IRepository
    {
        private readonly CityDbContext _context;

        public Repository(CityDbContext context)
        {
            _context = context;
        }

        public async Task<City> CreateAsync(City city)
        {
            await _context.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task DeleteAsync(City city)
        {

            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();

        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetByIdAsync(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            return city;
        }

        public async Task UpdateAsync(City city)
        {
            var orjCity = await _context.Cities.FirstOrDefaultAsync(c => c.Id == city.Id);
            _context.Entry(orjCity).CurrentValues.SetValues(city);
            await _context.SaveChangesAsync();
        }
    }
}
