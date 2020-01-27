using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ProdajaVozilaApp.Model.Dto.Vozila;

namespace ProdajaVozilaApp.View.Gost
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

        public CarComponent(VoziloOdFirme voziloOdFirme) : this()
        {
            if(voziloOdFirme.Slike == null)
            {
                voziloOdFirme.Slike = new List<byte[]>();
            }
            if (voziloOdFirme.Slike.Count == 0)
            {
                Image.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/no-picture.png")));
            }
            else
            {
                Image.Source = ToImage(voziloOdFirme.Slike[0]);
            }
            Image.MouseUp += (sender, args) =>
            {
                Window detailedInfos = new CarDetailedInfo(voziloOdFirme);
                detailedInfos.Show();
            };
            Name.Text = $"{voziloOdFirme.Vozilo.Marka} {voziloOdFirme.Vozilo.Model} ({voziloOdFirme.Vozilo.GodinaProizvodnje})";
            Price.Text = $"{voziloOdFirme.Cijena} KM";
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
