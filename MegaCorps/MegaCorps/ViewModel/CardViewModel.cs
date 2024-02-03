using MegaCorps.Core;
using MegaCorps.Core.Model;
using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;

namespace MegaCorps.ViewModel
{
    public class CardViewModel
    {
        private GameCard _card;
        public GameCard Card { get => _card; set => _card = value; }

        private GameEngine _engine;
        public GameEngine Engine { get => _engine; set => _engine = value; }

        private int _playerPosition;
        public int PlayerPosition { get => _playerPosition; set => _playerPosition = value; }

        public CardViewModel(GameCard card, int playerPosition, GameEngine engine)
        {
            this.Card = card;
            this.Engine = engine;
            this.PlayerPosition = playerPosition;
        }

        private RelayCommand cardClickedCommand;
        public RelayCommand CardClickedCommand => cardClickedCommand ?? (
            cardClickedCommand = new RelayCommand(obj =>
            {
                if(Card.State == CardState.Used)
                {
                    Card.State = CardState.Unused;
                }
                else if(Card.State == CardState.Unused)
                {
                    Card.State = CardState.Used;
                }
                Engine.SelectCard(Card,PlayerPosition);
            }));

    }
}