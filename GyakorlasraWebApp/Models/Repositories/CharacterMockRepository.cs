using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakorlasraWebApp.Models.Repositories
{
    public class CharacterMockRepository : ICharacterRepository
    {
        List<CharacterModel> repo;

        public CharacterMockRepository()
        {
            repo = new List<CharacterModel>();
            string[] input = File.ReadAllLines("wwwroot/repo.txt");
            foreach (string item in input)
            {
                string [] linecontent = item.Split('#');
                CharacterModel cm = new CharacterModel()
                {
                    Id = repo.Count(),
                    Name = linecontent[0],
                    Side = (CharacterSide)int.Parse(linecontent[1]),
                    Power = int.Parse(linecontent[2]),
                    Speed = int.Parse(linecontent[3]),
                    ImageUrl = linecontent[4],
                    Description = linecontent[5]
                };
                repo.Add(cm);
            }
        }

        public void Export()
        {
            StreamWriter sw = new StreamWriter("wwwroot/repo.txt");
            foreach (var item in repo)
            {
                string outwrite = item.Name + "#" + (int)item.Side + "#" + item.Power + "#" + item.Speed + "#" + item.ImageUrl + "#" + item.Description;
                sw.WriteLine(outwrite);
            }
            sw.Close();
        }

        public IEnumerable<CharacterModel> GetAll()
        {
            return repo;
        }

        public void Add(CharacterModel model)
        {
            model.Id = repo.Count;
            repo.Add(model);
        }
    }
}
