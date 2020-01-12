using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ProdajaVozilaApp.View.Administrator
{
    /// <summary>
    /// Interaction logic for AdminMenu.xaml
    /// </summary>
    public partial class AdminMenu : Page
    {
        private NavigationWindow _navigationWindow;

        public AdminMenu()
        {
            InitializeComponent();
        }

        public AdminMenu(NavigationWindow navigationWindow) : this()
        {
            _navigationWindow = navigationWindow;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            _navigationWindow.Navigate(new Menu(_navigationWindow, this));
        }
    }
}
