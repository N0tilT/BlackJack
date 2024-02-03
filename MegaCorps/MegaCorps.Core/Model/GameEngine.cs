using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.GameUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.Core.Model
{
    public class GameEngine
    {
        private Deck _deck;
        public Deck Deck { get => _deck; set => _deck = value; }

        private List<GameCard> _firstPlayerHand;
        private List<GameCard> _secondPlayerHand;
        private List<GameCard> _thirdPlayerHand;
        private List<GameCard> _fourthPlayerHand;
        public List<GameCard> FirstPlayerHand { get => _firstPlayerHand; set => _firstPlayerHand = value; }
        public List<GameCard> SecondPlayerHand { get => _secondPlayerHand; set => _secondPlayerHand = value; }
        public List<GameCard> ThirdPlayerHand { get => _thirdPlayerHand; set => _thirdPlayerHand = value; }
        public List<GameCard> FourthPlayerHand { get => _fourthPlayerHand; set => _fourthPlayerHand = value; }
        public GameEngine() 
        {
            Deck = DeckBuilder.GetDeck();
            Deck.Shuffle();
        }

        public void Deal(int dealCount)
        {
            List<List<GameCard>> hands = Deck.Deal(dealCount, 4);
            FirstPlayerHand = hands[0];
            SecondPlayerHand = hands[1];
            ThirdPlayerHand = hands[2];
            FourthPlayerHand = hands[3];
        }

        public void FirstPlayerReady()
        {
            throw new NotImplementedException();
        }

        public void SecondPlayerReady()
        {
            throw new NotImplementedException();
        }

        public void ThirdPlayerReady()
        {
            throw new NotImplementedException();
        }

        public void FourthPlayerReady()
        {
            throw new NotImplementedException();
        }

        public void Turn()
        {
            throw new NotImplementedException();
        }
    }
}
