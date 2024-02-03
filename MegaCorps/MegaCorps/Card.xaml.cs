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
    /// Логика взаимодействия для Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
            this.HorizontalAlignment= HorizontalAlignment.Stretch;
        }
        public bool color = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!color)
            {
                CardButton.Background=Brushes.Yellow;
                color=true;
            }
            else
            {
                CardButton.Background=Brushes.LightYellow;
                color=false;
            }
        }
    }
}
