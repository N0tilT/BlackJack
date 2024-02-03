using MegaCorps.SetupHelper;
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
        public MainWindow()
        {
            InitializeComponent();
            List<GameUser> Users = UserSetup.CreateUserList(2);
            foreach(var user in Users)
            {

            }
            for (int i = 0; i < 6; i++)
            {
                CardList.Children.Add(new Card());
            }
        }
        public List<GameUser> Users {get; set;}
        public List<Card> Deck { get; set;}
    }
}
