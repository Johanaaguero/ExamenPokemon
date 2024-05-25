using System.Collections.Generic;

namespace PokemonAPI.Models
{
    public class Pokemon
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string SpriteUrl { get; set; } = string.Empty;
        public List<string> Moves { get; set; } = new List<string>();
    }
}
