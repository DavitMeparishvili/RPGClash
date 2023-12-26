using RPGClash.Domain.CharacterAction;
using RPGClash.Domain.Characters;
using RPGClash.GameEngine.CharacterAction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGClash.UnitTests.Shared
{
    public class CharacterAllowedActionsData
    {
        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { new Cedrick(), new List<Actions>() { Actions.BasicAttack, Actions.Regenerate, Actions.Heal, Actions.Shoot } };
                yield return new object[] { new Guladi(), new List<Actions>() { Actions.BasicAttack, Actions.Regenerate,  Actions.Taunt } };
                yield return new object[] { new Lucia(), new List<Actions>() { Actions.BasicAttack, Actions.Regenerate, Actions.Heal} };
            }
        }
    }
}
