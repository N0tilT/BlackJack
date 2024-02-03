using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps
{
    public class GameCard
    {
        public int Id { get; set; }
        public CardStance Stance { get; set; }
        public int UserId { get; set; }
        public GameCard(int id)
        {
            Id=id;
            UserId=-1;
            Stance=CardStance.unplayed;
        }

    }
}
