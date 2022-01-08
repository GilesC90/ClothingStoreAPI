using ClothingStoreApi.Models;
using ClothingStoreApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClothingStoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClothingController : ControllerBase
    {
        private readonly ClothingService _clothingService;

        public ClothingController(ClothingService clothingService) =>
            _clothingService = clothingService;

        [HttpGet]
        public async Task<List<Hoodie>> Get() =>
            await _clothingService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Hoodie>> Get(string id)
        {
            var hoodie = await _clothingService.GetAsync(id);

            if (hoodie is null)
            {
                return NotFound();
            }

            return hoodie;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Hoodie newHoodie)
        {
            await _clothingService.CreateAsync(newHoodie);

            return CreatedAtAction(nameof(Get), new { id = newHoodie.Id }, newHoodie);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Hoodie updatedHoodie)
        {
            var hoodie = await _clothingService.GetAsync(id);

            if (hoodie is null)
            {
                return NotFound();
            }

            updatedHoodie.Id = hoodie.Id;

            await _clothingService.UpdateAsync(id, updatedHoodie);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var hoodie = await _clothingService.GetAsync(id);

            if (hoodie is null)
            {
                return NotFound();
            }

            await _clothingService.RemoveAsync(hoodie.Id);

            return NoContent();
        }
    }
}