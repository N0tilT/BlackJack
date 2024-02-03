using MegaCorps.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model.Cards
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
