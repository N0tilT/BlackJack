using MegaCorps.Core.Model;
using MegaCorps.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCorps
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SolidColorBrush readyBrush = new SolidColorBrush(Color.FromRgb(54, 180, 69));
        MainViewModel viewModel;
        public MainWindow()
        {

            viewModel = new MainViewModel();
            DataContext = viewModel;

            InitializeComponent();

        }

        private void FirstPlayerReady_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.ValidateReady(0))
                if (this.FirstPlayerCardContainerBorder.BorderBrush != readyBrush)
                {
                    this.FirstPlayerCardContainerBorder.BorderBrush = readyBrush;
                    this.FirstPlayerCardContainer.IsEnabled = false;
                }
                else
                {
                    this.FirstPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
                    this.FirstPlayerCardContainer.IsEnabled = true;
                }
            else
            {
                this.FirstPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
            }
        }

        private void SecondPlayerReady_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.ValidateReady(1)) 
                if (this.SecondPlayerCardContainerBorder.BorderBrush != readyBrush)
                {
                    this.SecondPlayerCardContainerBorder.BorderBrush = readyBrush;
                    this.SecondPlayerCardContainer.IsEnabled = false;
                }
                else
                {
                    this.SecondPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
                    this.SecondPlayerCardContainer.IsEnabled = true;
                }
            else
            {
                this.SecondPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
            }
        }

        private void ThirdPlayerReady_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.ValidateReady(2))
                if (this.ThirdPlayerCardContainerBorder.BorderBrush != readyBrush)
                {
                    this.ThirdPlayerCardContainerBorder.BorderBrush = readyBrush;
                    this.ThirdPlayerCardContainer.IsEnabled = false;
                }
                else
                {
                    this.ThirdPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
                    this.ThirdPlayerCardContainer.IsEnabled = true;
                }
            else
            {
                this.ThirdPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
            }
        }

        private void FourthPlayerReady_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.ValidateReady(3))
                if (this.FourthPlayerCardContainerBorder.BorderBrush != readyBrush)
                {
                    this.FourthPlayerCardContainerBorder.BorderBrush = readyBrush;
                    this.FourthPlayerCardContainer.IsEnabled = false;
                }
                else
                {
                    this.FourthPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
                    this.FourthPlayerCardContainer.IsEnabled = true;
                }
            else
            {
                this.FourthPlayerCardContainerBorder.BorderBrush = Brushes.Transparent;
            }
        }
    }
}
