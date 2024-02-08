using MegaCorps.Core.Model;
using MegaCorps.Core.Model.Cards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleAPp
{
    public class Program
    {
        static List<GameCard> FirstPlayerCards;
        static List<GameCard> SecondPlayerCards;
        static GameEngine engine;
        private static int FirstPlayerScore;
        private static int SecondPlayerScore;

        static void Main(string[] args)
        {
            engine = new GameEngine();
            engine.Deal(1,new List<int>{0,1});
            RefreshScores();
            RefreshCards();

            Console.WriteLine("Это игра блекджек!\n");
            while (true)
            {
                Console.WriteLine("Ваши карты!\n");
                PrintHand(FirstPlayerCards);
                Console.WriteLine("Возьмёте ещё одну?(y/n)");
                String input = Console.ReadLine();
                if (input == "y")
                {
                    engine.Deal(1, new List<int> { 0 });
                }

                if (engine.Players[1].Hand.Cards.Sum((card) => card.Value) < 21)
                {
                    engine.Deal(1, new List<int> { 1 });
                }

                if (input == "n")
                {
                    PrintHand(FirstPlayerCards);
                    PrintHand(SecondPlayerCards);
                    //Определить победителя
                    break;
                }

            }

        }

        private static void PrintHand(List<GameCard> cards)
        {
            foreach (GameCard card in cards)
            {
                Console.WriteLine(card.Value);
            }
        }

        private static void RefreshCards()
        {
            FirstPlayerCards = engine.Players[0].Hand.Cards;
            SecondPlayerCards = engine.Players[1].Hand.Cards;
        }

        private static void RefreshScores()
        {
            FirstPlayerScore = engine.Players[0].Score;
            SecondPlayerScore = engine.Players[1].Score;
        }
    }
}
