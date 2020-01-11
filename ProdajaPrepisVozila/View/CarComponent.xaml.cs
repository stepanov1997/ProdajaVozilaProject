using System;
using System.Collections.Generic;
using System.Globalization;
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
using ProdajaPrepisVozila.Model.Dto.Vozila;

namespace ProdajaPrepisVozila.View
{
    /// <summary>
    /// Interaction logic for CarComponent.xaml
    /// </summary>
    public partial class CarComponent : UserControl
    {
        public CarComponent()
        {
            InitializeComponent();
        }

        public CarComponent(VoziloProxy voziloProxy) : this()
        {
            Image.Source = ToImage(voziloProxy.Slika);
            Name.Text = $"{voziloProxy.Vozilo.Marka} {voziloProxy.Vozilo.Model} ({voziloProxy.Vozilo.GodinaProizvodnje})";
            Price.Text = $"{voziloProxy.Cijena}";
        }

        private static BitmapImage ToImage(byte[] array)
        {
            using (var ms = new System.IO.MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; 
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }
    }
}
