using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Cards
{
    public class AttackCard:GameCard
    {
        public int Damage {  get; set; }
        public CardDirection Direction { get; set; }
        public AttackType AttackType { get; set; }
        public AttackCard(int id,AttackType attackType,CardDirection direction) : base(id)
        {
            AttackType = attackType;
            Direction = direction;
        }
        

    }
}
