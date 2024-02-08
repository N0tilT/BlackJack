using MegaCorps.Core;
using MegaCorps.Core.Model;
using MegaCorps.Core.Model.Cards;
using MegaCorps.Core.Model.Enums;
using MegaCorps.Core.Model.GameUtils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

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
        private bool _thirdPlayerReady;
        private bool _fourthPlayerReady;

        public bool FirstPlayerReady { get => _firstPlayerReady; set { _firstPlayerReady = value; OnPropertyChanged("FirstPlayerReady"); } }
        public bool SecondPlayerReady
        {
            get => _secondPlayerReady; set { _secondPlayerReady = value; OnPropertyChanged("SecondPlayerReady"); }
        }
        public bool ThirdPlayerReady { get => _thirdPlayerReady; set { _thirdPlayerReady = value; OnPropertyChanged("ThirdPlayerReady"); } }
        public bool FourthPlayerReady { get => _fourthPlayerReady; set { _fourthPlayerReady = value; OnPropertyChanged("FourthPlayerReady"); } }

        private GameEngine engine;

        private int _deckCounter;
        public int DeckCounter { get => _deckCounter; set { _deckCounter = value; OnPropertyChanged("DeckCounter"); } }

        private SolidColorBrush _firstPlayerReadyBrush;
        private SolidColorBrush _secondPlayerReadyBrush;
        private SolidColorBrush _thirdPlayerReadyBrush;
        private SolidColorBrush _fourthPlayerReadyBrush;
        public SolidColorBrush FirstPlayerReadyBrush { get => _firstPlayerReadyBrush; set { _firstPlayerReadyBrush = value;OnPropertyChanged("FirstPlayerReadyBrush"); } }
        public SolidColorBrush SecondPlayerReadyBrush { get => _secondPlayerReadyBrush; set { _secondPlayerReadyBrush = value; OnPropertyChanged("SecondPlayerReadyBrush"); } }
        public SolidColorBrush ThirdPlayerReadyBrush { get => _thirdPlayerReadyBrush; set { _thirdPlayerReadyBrush = value; OnPropertyChanged("ThirdPlayerReadyBrush"); } }
        public SolidColorBrush FourthPlayerReadyBrush { get => _fourthPlayerReadyBrush; set { _fourthPlayerReadyBrush = value; OnPropertyChanged("FourthPlayerReadyBrush"); } }

        public MainViewModel()
        {
            engine = new GameEngine();
            engine.Deal(6);
            RefreshScores();
            RefreshCards();
        }

        private void RefreshScores()
        {
            FirstPlayerScore = engine.Players[0].Score;
            SecondPlayerScore = engine.Players[1].Score;
            ThirdPlayerScore = engine.Players[2].Score;
            FourthPlayerScore = engine.Players[3].Score;
        }

        public void RefreshCards()
        {
            DeckCounter = engine.Deck.UnplayedCards.Count;
            FirstPlayerCards = new ObservableCollection<CardViewModel>(engine.Players[0].Hand.Cards.Select(card => new CardViewModel(card, 0, engine)).ToList());
            SecondPlayerCards = new ObservableCollection<CardViewModel>(engine.Players[1].Hand.Cards.Select(card => new CardViewModel(card, 1, engine)).ToList());
            ThirdPlayerCards = new ObservableCollection<CardViewModel>(engine.Players[2].Hand.Cards.Select(card => new CardViewModel(card, 2, engine)).ToList());
            FourthPlayerCards = new ObservableCollection<CardViewModel>(engine.Players[3].Hand.Cards.Select(card => new CardViewModel(card, 3, engine)).ToList());

            FirstPlayerReady = false; 
            FirstPlayerReadyBrush = Brushes.Transparent;
            SecondPlayerReady = false;
            SecondPlayerReadyBrush = Brushes.Transparent;
            ThirdPlayerReady = false;
            ThirdPlayerReadyBrush = Brushes.Transparent;
            FourthPlayerReady = false;
            FourthPlayerReadyBrush = Brushes.Transparent;
        }

        private RelayCommand firstPlayerReadyCommand;
        public RelayCommand FirstPlayerReadyCommand => firstPlayerReadyCommand ?? (
            firstPlayerReadyCommand = new RelayCommand(obj =>
            {
                if (ValidateReady(0))
                {
                    FirstPlayerReady = !FirstPlayerReady;
                    FirstPlayerReadyBrush = FirstPlayerReady ? new SolidColorBrush(Color.FromRgb(54, 180, 69)) : Brushes.Transparent;
                    if (AllPlayersReady())
                    {
                        MakeTurn();
                    }
                }
                else
                {
                    FirstPlayerReadyBrush = Brushes.Transparent;
                    FirstPlayerReady = false;
                }
            }));


        private RelayCommand secondPlayerReadyCommand;
        public RelayCommand SecondPlayerReadyCommand => secondPlayerReadyCommand ?? (
            secondPlayerReadyCommand = new RelayCommand(obj =>
            {
                if (ValidateReady(1))
                {
                    SecondPlayerReady = !SecondPlayerReady;
                    SecondPlayerReadyBrush = SecondPlayerReady ? new SolidColorBrush(Color.FromRgb(54, 180, 69)) : Brushes.Transparent;
                    if (AllPlayersReady())
                    {
                        MakeTurn();
                    }
                }
                else
                {
                    SecondPlayerReadyBrush = Brushes.Transparent;
                    SecondPlayerReady = false;
                }
            }));



        private RelayCommand thirdPlayerReadyCommand;
        public RelayCommand ThirdPlayerReadyCommand => thirdPlayerReadyCommand ?? (
            thirdPlayerReadyCommand = new RelayCommand(obj =>
            {
                if (ValidateReady(2))
                {
                    ThirdPlayerReady = !ThirdPlayerReady;
                    ThirdPlayerReadyBrush = ThirdPlayerReady ? new SolidColorBrush(Color.FromRgb(54, 180, 69)) : Brushes.Transparent;
                    if (AllPlayersReady())
                    {
                        MakeTurn();
                    }
                }
                else
                {
                    ThirdPlayerReadyBrush = Brushes.Transparent;
                    ThirdPlayerReady = false;
                }
            }));
        private RelayCommand fourthPlayerReadyCommand;
        public RelayCommand FourthPlayerReadyCommand => fourthPlayerReadyCommand ?? (
            fourthPlayerReadyCommand = new RelayCommand(obj =>
            {
                if (ValidateReady(3))
                {
                    FourthPlayerReady = !FourthPlayerReady;
                    FourthPlayerReadyBrush = FourthPlayerReady? new SolidColorBrush(Color.FromRgb(54, 180, 69)) : Brushes.Transparent;
                    if (AllPlayersReady())
                    {
                        MakeTurn();
                    }
                }
                else
                {
                    FourthPlayerReadyBrush = Brushes.Transparent;
                    FourthPlayerReady = false;
                }
            }));


        private void MakeTurn()
        {
            engine.FindWinner();
            engine.Deal(3);
            RefreshCards();
            RefreshScores();
            if (engine.Win)
            {
                if (MessageBox.Show($"Победил игрок {engine.Winner}. Начать игру заново?") == MessageBoxResult.OK)
                    RefreshGame();
            }
        }

        private void RefreshGame()
        {
            engine = new GameEngine();
            engine.Deal(6);
            RefreshScores();
            RefreshCards();
        }

        public bool AllPlayersReady()
        {
            return FirstPlayerReady && SecondPlayerReady && ThirdPlayerReady && FourthPlayerReady;
        }

        public bool ValidateReady(int playerPosition)
        {
            return engine.Players[playerPosition].Hand.Cards.Count(card => card.State == CardState.Used) == 3;
        }
    }
}
