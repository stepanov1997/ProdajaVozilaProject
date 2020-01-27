using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ProdajaVozilaApp.Model.Dto.Vozila;
using ProdajaVozilaApp.Model.Dto.Alati;

namespace ProdajaVozilaApp.View.Gost
{
    /// <summary>
    /// Interaction logic for CarDetailedInfo.xaml
    /// </summary>
    public partial class CarDetailedInfo : Window
    {
        public CarDetailedInfo()
        {
            InitializeComponent();
        }

        public CarDetailedInfo(VoziloOdFirme voziloOdFirme) : this()
        {
            //var dictionary = GetProperties.MakeDictionaryOfProperties(voziloOdFirme, 2);
            DataGrid.ItemsSource = voziloOdFirme.NapraviRječnikOsobina();
            DataGrid.HeadersVisibility = DataGridHeadersVisibility.None;
            DataGrid.ColumnWidth = new DataGridLength(50, DataGridLengthUnitType.Star);

            if (voziloOdFirme.Slike == null)
            {
                voziloOdFirme.Slike = new List<byte[]>();
            }
            if (voziloOdFirme.Slike.Count == 0)
            {
                Slika.Source = new BitmapImage(new Uri(Path.GetFullPath("../../../Resources/no-picture.png")));
            }
            else
            {
                Slika.Source = ToImage(voziloOdFirme.Slike[0]);
            }
            Slika.MouseLeftButtonDown += (sender, args) =>
            {
                if (args.ClickCount < 2) return;
                Window window = new Window();
                Border border = new Border();
                border.BorderBrush = Border.BorderBrush;
                var img = new Image() {Source = Slika.Source};
                int i = 0;
                window.KeyDown += (o, eventArgs) =>
                {
                    if (eventArgs.Key == Key.Right)
                    {
                        img.Source = (Slicice.Children[(i += 2) % Slicice.Children.Count] as Image)?.Source;
                    }
                    if (eventArgs.Key == Key.Left)
                    {
                        img.Source = (Slicice.Children[(i -= 2) % Slicice.Children.Count] as Image)?.Source;
                    }
                };
                border.Child =img;
                border.BorderThickness = Border.BorderThickness;
                window.Content = border;
                window.ResizeMode = ResizeMode.CanMinimize;
                
                window.Show();
            };
            Slicice.ScrollOwner = ScrollViewer;
            foreach (var imageBytes in voziloOdFirme.Slike)
            {
                Image image = new Image()
                {
                    Source = ToImage(imageBytes),
                    Width = 60,
                    Height = 60,
                    Stretch = Stretch.Uniform
                };
                image.MouseEnter += (sender, args) => Slika.Source = image.Source;
                Slicice.Children.Add(image);
                Slicice.Children.Add(new TextBlock() { Width = 10, Height = 60 });
            }

        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public static object GetPropertyValue(object source, string propertyName)
        {
            PropertyInfo property = source.GetType().GetProperty(propertyName);
            return property.GetValue(source, null);
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
