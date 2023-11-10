using RPGClash.Domain.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGClash.GameEngine.Dtos
{
    public class GameStateDto
    {
        public string UserId { get; set; }
        public List<CharacterName> Characters { get; set; }
    }
}
