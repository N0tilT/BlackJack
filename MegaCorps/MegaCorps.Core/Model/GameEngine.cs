using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
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
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int ThirdPlayerScore { get; set; }
        public int FourthPlayerScore { get; set; }

        public GameEngine()
        {
            Deck = DeckBuilder.GetDeck();
            Deck.Shuffle();
            FirstPlayerScore = 0;
            SecondPlayerScore = 0;
            ThirdPlayerScore = 0;
            FourthPlayerScore = 0;
        }

        public void Deal(int dealCount)
        {
            List<List<GameCard>> hands = Deck.Deal(dealCount, 4);
            FirstPlayerHand = hands[0];
            SecondPlayerHand = hands[1];
            ThirdPlayerHand = hands[2];
            FourthPlayerHand = hands[3];
        }

        public void Turn()
        {
            //В деке пихать из анплеед в плеед сыгранные карты
        }

        public void SelectCard(GameCard card, int playerPosition)
        {
            int cardIndex;
            switch (playerPosition)
            {
                case 0:
                    cardIndex = FirstPlayerHand.FindIndex((element) => element.Id == card.Id);
                    if (FirstPlayerHand[cardIndex].State == CardState.Used)
                    {
                        FirstPlayerHand[cardIndex].State = CardState.Unused;
                    }
                    else if (FirstPlayerHand[cardIndex].State == CardState.Unused)
                    {
                        FirstPlayerHand[cardIndex].State = CardState.Used;
                    }
                    break;
                case 1:
                    cardIndex = SecondPlayerHand.FindIndex((element) => element.Id == card.Id);
                    if (SecondPlayerHand[cardIndex].State == CardState.Used)
                    {
                        SecondPlayerHand[cardIndex].State = CardState.Unused;
                    }
                    else if (SecondPlayerHand[cardIndex].State == CardState.Unused)
                    {
                        SecondPlayerHand[cardIndex].State = CardState.Used;
                    }
                    break;
                case 2:
                    cardIndex = ThirdPlayerHand.FindIndex((element) => element.Id == card.Id);
                    if (ThirdPlayerHand[cardIndex].State == CardState.Used)
                    {
                        ThirdPlayerHand[cardIndex].State = CardState.Unused;
                    }
                    else if (ThirdPlayerHand[cardIndex].State == CardState.Unused)
                    {
                        ThirdPlayerHand[cardIndex].State = CardState.Used;
                    }
                    break;
                case 3:
                    cardIndex = FourthPlayerHand.FindIndex((element) => element.Id == card.Id);
                    if (FourthPlayerHand[cardIndex].State == CardState.Used)
                    {
                        FourthPlayerHand[cardIndex].State = CardState.Unused;
                    }
                    else if (FourthPlayerHand[cardIndex].State == CardState.Unused)
                    {
                        FourthPlayerHand[cardIndex].State = CardState.Used;
                    }
                    break;
            }
        }
    }
}
