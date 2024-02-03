using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model.GameUtils
{
    public static class DeckBuilder
    {
        public static readonly int MaxCards = 6;
        public static void UpdateDeck(List<GameCard> deck,int players)
        {
           
        }
        public static Deck GetDeck()
        {
            var deck= new List<GameCard>();

            for (int i = 0; i < 72; i++)
            {
                if (i < 20)
                {
                    deck.Add(new AttackCard(i,CardDirection.Left));
                }
                else if (i < 40)
                {
                    deck.Add(new DefenceCard(i));
                }
                else
                {
                    deck.Add(new DeveloperCard(i));
                }
            }

            return new Deck(deck);
        }

    }
}
