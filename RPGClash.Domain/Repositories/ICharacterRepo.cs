using RPGClash.Domain.Characters;
using RPGClash.Domain.Entities;
using System.Collections.Generic;

namespace RPGClash.Domain.Repositories
{
    public interface ICharacterRepo
    {
        public Task<Character> GetCharacterAsync(CharacterName character);

        public Task<List<Character>> GetCharactersAsync(List<CharacterName> characters);
    }
}
