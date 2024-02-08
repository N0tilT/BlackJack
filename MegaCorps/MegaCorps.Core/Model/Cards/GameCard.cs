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
        public int Value { get; set; }
        public GameCard(int id, int value)
        {
            Id = id;
            Value = value;
        }

    }
}
