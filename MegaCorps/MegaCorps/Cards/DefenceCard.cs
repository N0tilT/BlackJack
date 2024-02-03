using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Cards
{
    public class DefenceCard:GameCard
    {
        public DefenceType Type;
        public DefenceCard(DefenceType type,int id): base(id)
        {
            Type=type;  
        }
    }
}
