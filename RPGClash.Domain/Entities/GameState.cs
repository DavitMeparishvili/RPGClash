using RPGClash.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGClash.Domain.Entities
{
    public class GameState
    {
        public int Id { get; set; }

        public PlayerState Player1 { get; set; } = default!;

        public PlayerState Player2 { get; set; } = default!;

        public int Round { get; set; } = default!;
    }
}
