using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProdajaVozilaApp.View.Sluzbenik
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class SluzbenikMenu : Page
    {
        private NavigationWindow _navigationWindow;

        public SluzbenikMenu()
        {
            InitializeComponent();
        }

        public SluzbenikMenu(NavigationWindow navigationWindow) : this()
        {
            _navigationWindow = navigationWindow;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _navigationWindow.Navigate(new Menu(_navigationWindow, this));
        }
    }
}
