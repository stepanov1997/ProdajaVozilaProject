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
    public partial class CarsForSelling : Page
    {
        private NavigationWindow _navigationWindow;
        public CarsForSelling()
        {
            InitializeComponent();
        }

        public CarsForSelling(NavigationWindow navigationWindow) : this()
        {
            _navigationWindow = navigationWindow;
        }
        private void Admin_Click(object sender, MouseButtonEventArgs e)
        {
            Task.Delay(1000);
            MessageBox.Show("Admin", "Admin", MessageBoxButton.OK);
        }

        private void Gost_Click(object sender, MouseButtonEventArgs e)
        {
            Task.Delay(1000);
            MessageBox.Show("Gost", "Gost", MessageBoxButton.OK);
        }

        private void Sluzbenik_Click(object sender, MouseButtonEventArgs e)
        {
            Task.Delay(1000);
            MessageBox.Show("Sluzbenik", "Sluzbenik", MessageBoxButton.OK);
        }
    }
}
