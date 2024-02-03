using MegaCorps.Core.Model.Cards;

namespace MegaCorps.ViewModel
{
    internal class CardViewModel
    {
        private GameCard card;

        public CardViewModel(GameCard card, Core.Model.GameEngine engine)
        {
            this.card = card;
        }
    }
}