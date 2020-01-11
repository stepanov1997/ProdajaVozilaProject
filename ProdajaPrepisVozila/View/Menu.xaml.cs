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

namespace ProdajaPrepisVozila.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        private NavigationWindow navigationWindow;
        public Menu()
        {
            InitializeComponent();
        }

        public Menu(NavigationWindow navigationWindow) : this()
        {
            this.navigationWindow = navigationWindow;
        }
        private void Admin_Click(object sender, MouseButtonEventArgs e)
        {
            Task.Delay(1000);
            MessageBox.Show("Admin", "Admin", MessageBoxButton.OK);
        }

        private void Gost_Click(object sender, MouseButtonEventArgs e)
        {
            var carsPage = new CarsForSelling(navigationWindow);
            navigationWindow.Navigate(carsPage);
        }

        private void Sluzbenik_Click(object sender, MouseButtonEventArgs e)
        {
            Task.Delay(1000);
            MessageBox.Show("Sluzbenik", "Sluzbenik", MessageBoxButton.OK);
        }
    }
}
