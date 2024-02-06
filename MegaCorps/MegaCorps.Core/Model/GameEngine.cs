using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
using MegaCorps.Core.Model.GameUtils;
using System;
using System.CodeDom;
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
        public List<Player> Players { get => _players; set => _players = value; }

        private List<Player> _players;

        public GameEngine()
        {
            Deck = DeckBuilder.GetDeck();
            Deck.Shuffle();
            Players = new List<Player> { new Player(), new Player(), new Player(), new Player() };
        }

        public void Deal(int dealCount)
        {
            List<List<GameCard>> hands = Deck.Deal(dealCount, 4);

            for (int i = 0; i < Players.Count; i++)
            {
                Player player = Players[i];
                player.Hand = new PlayerHand(hands[i]);
            }
        }

        public void Turn()
        {


        }

        public void SelectCard(GameCard card, int playerPosition)
        {
            int cardIndex;
            for (int i = 0; i < Players.Count; i++)
            {
                cardIndex = Players[i].Hand.Cards.FindIndex((element) => element.Id == card.Id);
                if (Players[i].Hand.Cards[cardIndex].State == CardState.Used)
                {
                    Players[i].Hand.Cards[cardIndex].State = CardState.Unused;
                }
                else if (Players[i].Hand.Cards[cardIndex].State == CardState.Unused)
                {
                    Players[i].Hand.Cards[cardIndex].State = CardState.Used;
                }
            }
        }
    }
}
