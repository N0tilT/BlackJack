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
        internal ObservableCollection<CardViewModel> FirstPlayerCards { get => _firstPlayerCards; set { _firstPlayerCards = value; OnPropertyChanged("FirstPlayerCards"); } }

        private ObservableCollection<CardViewModel> _secondPlayerCards = new ObservableCollection<CardViewModel>();
        internal ObservableCollection<CardViewModel> SecondPlayerCards { get => _secondPlayerCards; set { _secondPlayerCards = value; OnPropertyChanged("SecondPlayerCards"); } }

        private ObservableCollection<CardViewModel> _thirdPlayerCards = new ObservableCollection<CardViewModel>();
        internal ObservableCollection<CardViewModel> ThirdPlayerCards { get => _thirdPlayerCards; set { _thirdPlayerCards = value; OnPropertyChanged("ThirdPlayerCards"); } }

        private ObservableCollection<CardViewModel> _fourthPlayerCards = new ObservableCollection<CardViewModel>();
        internal ObservableCollection<CardViewModel> FourthPlayerCards { get => _fourthPlayerCards; set { _fourthPlayerCards = value; OnPropertyChanged("FourthPlayerCards"); } }

        private int _firstPlayerScore;
        private int _secondPlayerScore;
        private int _thirdPlayerScore;
        private int _fourthPlayerScore;
        public int FirstPlayerScore { get => _firstPlayerScore; set { _firstPlayerScore = value; OnPropertyChanged("FirstPlayerScore"); } }
        public int SecondPlayerScore { get => _secondPlayerScore; set { _secondPlayerScore = value; OnPropertyChanged("SecondPlayerScore"); } }
        public int ThirdPlayerScore { get => _thirdPlayerScore; set { _thirdPlayerScore = value; OnPropertyChanged("ThirdPlayerScore"); } }
        public int FourthPlayerScore { get => _fourthPlayerScore; set { _fourthPlayerScore = value; OnPropertyChanged("FourthPlayerScore"); } }


        private int _deckCounter;
        public int DeckCounter { get => _deckCounter; set { _deckCounter = value; OnPropertyChanged("DeckCounter"); } }

        MainViewModel()
        {

        }

    }
}
