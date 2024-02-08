using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model.GameUtils
{
    public static class DeckBuilder
    {
        public static Deck GetDeck()
        {
            var deck = new List<GameCard>();
            int value = 5;
            for (int i = 0; i < 36; i+=4)
            {
                if (i % 4 == 0) value++;
                deck.AddRange(new List<GameCard>{ new GameCard(i, value), new GameCard(i, value) , new GameCard(i, value) , new GameCard(i, value) });
            }

            return new Deck(deck);
        }

    }
}
