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
        public bool Win { get => _win; set => _win = value; }
        public int Winner { get => _winner; set => _winner = value; }

        private int _winner;

        private bool _win;

        private List<Player> _players;

        public GameEngine()
        {
            Deck = DeckBuilder.GetDeck();
            Deck.Shuffle();
            Players = new List<Player> { new Player(), new Player() };
            _win = false;
        }

        public void Deal(int dealCount, List<int> playersToDeal)
        {
            List<List<GameCard>> hands = Deck.Deal(dealCount, 2, playersToDeal);

            for (int i = 0; i < Players.Count; i++)
            {
                Players[i].Hand.Cards.AddRange(hands[i]);
            }
        }

        public void FindWinner()
        {
                //Самим

            Win = Players.Any(player => player.Score <= 21);
            Winner = Players.FindIndex(player => player.Score == Players.Max((item) => item.Score))+1;

        }

    }
}
