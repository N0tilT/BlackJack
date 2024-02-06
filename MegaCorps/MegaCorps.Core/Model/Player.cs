using MegaCorps.Core.Model.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model
{
    public class Player
    {
        private PlayerHand _hand;
        private List<GameCard> _targeted;
        private int _score;
        public Player() { Score = 1; }

        public PlayerHand Hand { get => _hand; set => _hand = value; }
        public List<GameCard> Targeted { get => _targeted; set => _targeted = value; }
        public int Score { get => _score; set => _score = value; }

        public void PlayHand()
        {
            Score += Hand.Cards.Where((card) => card.Color == "Green").Count() - _targeted.Count();
            Score += Hand.Cards.Where((card) => card.Color == "Yellow").Count();
        }
    }

    public class PlayerHand
    {
        private List<GameCard> _cards;

        public PlayerHand(List<GameCard> cards)
        {
            this._cards = cards;
        }

        public PlayerHand() { }

        public List<GameCard> Cards { get => _cards; set => _cards = value; }
    }
}
