using RPGClash.Domain.Characters;
using RPGClash.Domain.Entities;
using System.Collections.Generic;

namespace RPGClash.Domain.Repositories
{
    public interface ICharacterRepo
    {
        public Task<DbCharacter> GetCharacterAsync(CharacterName character);

        public Task<List<DbCharacter>> GetCharactersAsync(List<CharacterName> characters);
    }
}
