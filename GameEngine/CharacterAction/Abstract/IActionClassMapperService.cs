using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGClash.GameEngine.CharacterAction.Abstract
{
    public interface IActionClassMapperService
    {
        List<Actions> GetCharacterActions(Character character);

        Type GetCharacterTypeByActionActions(Character character);
    }
}
