using AspNewCoreAPI_Intro.Entities;
using AspNewCoreAPI_Intro.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspNewCoreAPI_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {

        private readonly IRepository _repository;

        public CitiesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetAllAsync();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            // Veritabanından belirtilen ID'ye sahip şehri asenkron olarak alın.
            var city = await _repository.GetByIdAsync(id);

            // Eğer şehir bulunamazsa, 404 Not Found yanıtı döndürün.
            if (city == null)
            {
                return NotFound();
            }

            // Şehri JSON olarak döndürün.
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(City city)
        {
            
            var addedCity = await _repository.CreateAsync(city);
            return Created(string.Empty, addedCity);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] City city)
        {
            var entity =await _repository.GetByIdAsync(city.Id);
            if (entity ==null)
            {
                return NotFound(city.Id);
            }
            await _repository.UpdateAsync(city);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound(id);
            }
            await _repository.DeleteAsync(entity);
            return NoContent();
        }
    }
}

