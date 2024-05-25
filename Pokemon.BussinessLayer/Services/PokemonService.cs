using Newtonsoft.Json.Linq;
using PokemonAPI.Business.Interfaces;
using PokemonAPI.Models;
using System.Xml.Linq;
using RestSharp;
using System.Reflection;
using Newtonsoft.Json;

namespace PokemonAPI.Business.Services
{
    public class PokemonService : IPokemonService
    {

        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> GetFavoritePokemonInfoAsync(string name)
        {
            try
            {
                // URL de la API externa que proporciona información sobre el Pokémon favorito
                
                var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching data from API: {response.ReasonPhrase}");
                }

                var responseData = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<dynamic>(responseData);

                var pokemon = new Pokemon
                {
                    Name = data.name,
                    Type = data.types[0].type.name,
                    SpriteUrl = data.sprites.front_default,
                    Moves = new List<string>()
                };

                foreach (var move in data.moves)
                {
                    pokemon.Moves.Add((string)move.move.name);
                }

                return pokemon;
            }
            catch (HttpRequestException ex)
            {
                // Maneja errores de HTTP
                throw new Exception("Error al comunicarse con la API externa.", ex);
            }
        }

      
    }
    public class PokeApiResponse
    {
        public string Name { get; set; }
        public List<TypeInfo> Types { get; set; }
        public Sprites Sprites { get; set; }
        public List<MoveInfo> Moves { get; set; }
    }

    public class TypeInfo
    {
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
    }

    public class Sprites
    {
        public string FrontDefault { get; set; }
    }

    public class MoveInfo
    {
        public Move Move { get; set; }
    }

    public class Move
    {
        public string Name { get; set; }
    }
}
