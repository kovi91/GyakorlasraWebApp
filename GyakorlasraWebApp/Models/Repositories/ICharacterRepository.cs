using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GyakorlasraWebApp.Models.Repositories
{
    public interface ICharacterRepository
    {
        IEnumerable<CharacterModel> GetAll();
        void Add(CharacterModel model);
        void Export();
        CharacterModel GetCharacterById(int id);
        void ModifyCharacter(CharacterModel model);
    }
}
