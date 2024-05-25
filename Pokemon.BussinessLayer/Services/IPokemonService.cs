using PokemonAPI.Models;
using System.Threading.Tasks;

// Interfaz para el servicio de Pokémon en la capa de negocios

namespace PokemonAPI.Business.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemon> GetFavoritePokemonInfoAsync(string name);
    }
}

