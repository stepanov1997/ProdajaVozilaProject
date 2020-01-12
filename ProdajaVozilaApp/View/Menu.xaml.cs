using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using ProdajaVozilaApp.View;
using ProdajaVozilaApp.View.Gost;

namespace ProdajaVozilaApp.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private NavigationWindow navigationWindow;
        private Page _previousPage;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(NavigationWindow navigationWindow) : this()
        {
            this.navigationWindow = navigationWindow;
        }

        public Menu(NavigationWindow navigationWindow, Page previousPage) : this(navigationWindow)
        {
            _previousPage = previousPage;
        }

        private void Admin_Click(object sender, MouseButtonEventArgs e)
        {
            if (_previousPage is Administrator.AdminMenu)
            {
                navigationWindow.Navigate(_previousPage);
            }
            else
            {
                var adminMenu = new Administrator.AdminMenu(navigationWindow);
                navigationWindow.Navigate(adminMenu);
            }
        }

        private void Gost_Click(object sender, MouseButtonEventArgs e)
        {
            if (_previousPage is CarsForSelling)
            {
                navigationWindow.Navigate(_previousPage);
            }
            else
            {
                var carsPage = new CarsForSelling(navigationWindow);
                navigationWindow.Navigate(carsPage);
            }
        }

        private void Sluzbenik_Click(object sender, MouseButtonEventArgs e)
        {
            if (_previousPage is Sluzbenik.SluzbenikMenu)
            {
                navigationWindow.Navigate(_previousPage);
            }
            else
            {
                var sluzbenikMenu = new Sluzbenik.SluzbenikMenu(navigationWindow);
                navigationWindow.Navigate(sluzbenikMenu);
            }
        }
    }
}
