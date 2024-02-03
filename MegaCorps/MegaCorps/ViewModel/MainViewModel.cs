using MegaCorps.Core;
using MegaCorps.Core.Model;
using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.GameUtils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaCorps.ViewModel
{
    public class MainViewModel : ObservableObject
    {
        private ObservableCollection<CardViewModel> _firstPlayerCards = new ObservableCollection<CardViewModel>();
        public ObservableCollection<CardViewModel> FirstPlayerCards { get => _firstPlayerCards; set { _firstPlayerCards = value; OnPropertyChanged("FirstPlayerCards"); } }

        private ObservableCollection<CardViewModel> _secondPlayerCards = new ObservableCollection<CardViewModel>();
        public ObservableCollection<CardViewModel> SecondPlayerCards { get => _secondPlayerCards; set { _secondPlayerCards = value; OnPropertyChanged("SecondPlayerCards"); } }

        private ObservableCollection<CardViewModel> _thirdPlayerCards = new ObservableCollection<CardViewModel>();
        public ObservableCollection<CardViewModel> ThirdPlayerCards { get => _thirdPlayerCards; set { _thirdPlayerCards = value; OnPropertyChanged("ThirdPlayerCards"); } }

        private ObservableCollection<CardViewModel> _fourthPlayerCards = new ObservableCollection<CardViewModel>();
        public ObservableCollection<CardViewModel> FourthPlayerCards { get => _fourthPlayerCards; set { _fourthPlayerCards = value; OnPropertyChanged("FourthPlayerCards"); } }

        private int _firstPlayerScore;
        private int _secondPlayerScore;
        private int _thirdPlayerScore;
        private int _fourthPlayerScore;
        public int FirstPlayerScore { get => _firstPlayerScore; set { _firstPlayerScore = value; OnPropertyChanged("FirstPlayerScore"); } }
        public int SecondPlayerScore { get => _secondPlayerScore; set { _secondPlayerScore = value; OnPropertyChanged("SecondPlayerScore"); } }
        public int ThirdPlayerScore { get => _thirdPlayerScore; set { _thirdPlayerScore = value; OnPropertyChanged("ThirdPlayerScore"); } }
        public int FourthPlayerScore { get => _fourthPlayerScore; set { _fourthPlayerScore = value; OnPropertyChanged("FourthPlayerScore"); } }

        private bool _firstPlayerReady;
        private bool _secondPlayerReady;
        private bool _thirdPlayerReady ;
        private bool _fourthPlayerReady;

        public bool FirstPlayerReady { get => _firstPlayerReady; set => _firstPlayerReady = value; }
        public bool SecondPlayerReady { get => _secondPlayerReady; set => _secondPlayerReady = value; }
        public bool ThirdPlayerReady { get => _thirdPlayerReady; set => _thirdPlayerReady = value; }
        public bool FourthPlayerReady { get => _fourthPlayerReady; set => _fourthPlayerReady = value; }

        private GameEngine engine;

        private int _deckCounter;
        public int DeckCounter { get => _deckCounter; set { _deckCounter = value; OnPropertyChanged("DeckCounter"); } }

        public MainViewModel()
        {
            FirstPlayerReady = false;
            SecondPlayerReady = false;
            ThirdPlayerReady = false;
            FourthPlayerReady = false;

            engine = new GameEngine();
            engine.Deal(6);
            RefreshScores();
            RefreshCards();
        }

        private void RefreshScores()
        {
            FirstPlayerScore = engine.FirstPlayerScore;
            SecondPlayerScore = engine.SecondPlayerScore;
            ThirdPlayerScore = engine.ThirdPlayerScore;
            FourthPlayerScore = engine.FourthPlayerScore;
        }

        private void RefreshCards()
        {
            DeckCounter = engine.Deck.UnplayedCards.Count;
            foreach (var card in engine.FirstPlayerHand)
            {
                FirstPlayerCards.Add(new CardViewModel(card,0,engine));
            }
            foreach (var card in engine.SecondPlayerHand)
            {
                SecondPlayerCards.Add(new CardViewModel(card, 1, engine));
            }
            foreach (var card in engine.ThirdPlayerHand)
            {
                ThirdPlayerCards.Add(new CardViewModel(card, 2, engine));
            }
            foreach (var card in engine.FourthPlayerHand)
            {
                FourthPlayerCards.Add(new CardViewModel(card, 3, engine));
            }
            FirstPlayerReady = false;
            SecondPlayerReady = false;
            ThirdPlayerReady = false;
            FourthPlayerReady = false;
        }

        private RelayCommand firstPlayerReadyCommand;
        public RelayCommand FirstPlayerReadyCommand => firstPlayerReadyCommand ?? (
            firstPlayerReadyCommand = new RelayCommand(obj =>
            {
                FirstPlayerReady = true;
                if (FirstPlayerReady && SecondPlayerReady && ThirdPlayerReady && FourthPlayerReady)
                {
                    engine.Turn();
                    engine.Deal(3);
                    RefreshCards();
                }
            }));

        private RelayCommand secondPlayerReadyCommand;
        public RelayCommand SecondPlayerReadyCommand => secondPlayerReadyCommand ?? (
            secondPlayerReadyCommand = new RelayCommand(obj =>
            {
                SecondPlayerReady = true;
                if (FirstPlayerReady && SecondPlayerReady && ThirdPlayerReady && FourthPlayerReady)
                {
                    engine.Turn();
                    engine.Deal(3);
                    RefreshCards();
                }
            }));
        private RelayCommand thirdPlayerReadyCommand;
        public RelayCommand ThirdPlayerReadyCommand => thirdPlayerReadyCommand ?? (
            thirdPlayerReadyCommand = new RelayCommand(obj =>
            {
                ThirdPlayerReady = true;
                if (FirstPlayerReady && SecondPlayerReady && ThirdPlayerReady && FourthPlayerReady)
                {
                    engine.Turn();
                    engine.Deal(3);
                    RefreshCards();
                }
            }));
        private RelayCommand fourthPlayerReadyCommand;
        public RelayCommand FourthPlayerReadyCommand => fourthPlayerReadyCommand ?? (
            fourthPlayerReadyCommand = new RelayCommand(obj =>
            {
                FourthPlayerReady = true;
                if (FirstPlayerReady && SecondPlayerReady && ThirdPlayerReady && FourthPlayerReady)
                {
                    engine.Turn();
                    engine.Deal(3);
                    RefreshCards();
                }
            }));

    }
}
