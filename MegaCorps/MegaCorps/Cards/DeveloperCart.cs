﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Cards
{
    public class DeveloperCart:GameCard
    {
       public int EvolutionPoint { get; set; }
        public DeveloperCart(int id,int evpoint):base(id)
        {
                EvolutionPoint = evpoint;
        }
    }
}
