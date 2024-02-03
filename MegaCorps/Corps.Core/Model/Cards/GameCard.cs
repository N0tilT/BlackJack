using Corps.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corps.Core.Model.Cards
{
    public class GameCard
    {
        public int Id { get; set; }
        public CardState Stance { get; set; }
        public int UserId { get; set; }
        public GameCard(int id)
        {
            Id=id;
            UserId=-1;
            Stance= CardState.Unplayed;
        }

    }
}
