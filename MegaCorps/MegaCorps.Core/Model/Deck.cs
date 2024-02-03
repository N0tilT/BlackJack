using MegaCorps.Core.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model
{
    public class Deck
    {
        private List<GameCard> playedCards;
        private List<GameCard> unplayedCards;

        public List<GameCard> PlayedCards { get => playedCards; set => playedCards = value; }
        public List<GameCard> UnplayedCards { get => unplayedCards; set => unplayedCards = value; }

        public Deck(List<GameCard> cards) 
        {
            UnplayedCards = cards;
            PlayedCards = new List<GameCard>();
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int n = UnplayedCards.Count - 1; n > 0; --n)
            {
                int k = r.Next(n + 1);
                GameCard temp = UnplayedCards[n];
                UnplayedCards[n] = UnplayedCards[k];
                UnplayedCards[k] = temp;
            }
        }

        public List<List<GameCard>> Deal(int dealCount, int playersCount)
        {
            if(UnplayedCards.Count < dealCount * playersCount)
            {
                UnplayedCards = new List<GameCard>(PlayedCards);
                PlayedCards = new List<GameCard>();
            }
            Random random = new Random();
            List<List<GameCard>> hands = (List<List<GameCard>>)Enumerable.Range(0, playersCount).Select(i => new List<GameCard>());
            
            while (UnplayedCards.Count > 0)
            {
                foreach (var player in hands)
                {
                    player.Add(UnplayedCards[UnplayedCards.Count - 1]);
                    UnplayedCards.RemoveAt(UnplayedCards.Count - 1);
                    if (UnplayedCards.Count == 0)
                        break;
                }
            }
            return hands;
        }
    }
}
