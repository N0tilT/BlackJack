using MegaCorps.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model.Cards
{
    public class GameCard
    {
        public int Id { get; set; }
        public CardState State { get; set; }
        public int UserId { get; set; }

        public string Color { get; set; }
        public GameCard(int id)
        {
            Id=id;
            UserId=-1;
            State= CardState.Unplayed;
        }

    }
}
