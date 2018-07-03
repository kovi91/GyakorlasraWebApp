using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyakorlasraWebApp.Models
{
    public enum CharacterSide
    {
        good, evil
    }
    public class CharacterModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CharacterSide Side { get; set; }

        public int Power { get; set; }

        public int Speed { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public IFormFile Picture { get; set; }

    }
}
