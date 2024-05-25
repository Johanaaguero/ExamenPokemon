using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using PokemonAPI.Business.Interfaces;

namespace PokeFav.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetFavoritePokemonInfo(string name)
        {
            try
            {
                // Llamar al método en la capa de negocios para obtener la información del Pokémon favorito
                var pokemonInfo = await _pokemonService.GetFavoritePokemonInfoAsync(name);
                return Ok(pokemonInfo);
            }
            catch (Exception ex)
            {
                // Manejar errores
                return StatusCode(500, $"Error: {ex.Message}");
            }
        }
    }
}
