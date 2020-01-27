using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LinqToDB.Common;
using Microsoft.Win32;
using ProdajaVozilaApp.Model.Dao.VozilaDAO;
using ProdajaVozilaApp.Model.Dto.Vozila;
using Path = System.Windows.Shapes.Path;

namespace ProdajaVozilaApp.View.Sluzbenik
{
    /// <summary>
    /// Interaction logic for AddNewCarWindow.xaml
    /// </summary>
    public partial class AddNewCarWindow : Window
    {
        private List<byte[]> pictures = new List<byte[]>();
        public AddNewCarWindow()
        {
            InitializeComponent();
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DodajButton_OnClick(object sender, RoutedEventArgs e)
        {
            string model = ModelBox.Text;
            if (model.IsNullOrEmpty())
            {
                ModelBox.BorderBrush = new SolidColorBrush(Colors.Red);
                ModelBox.BorderThickness = new Thickness(1);
                return;
            }

            string marka = MarkaBox.Text;
            if (marka.IsNullOrEmpty())
            {
                MarkaBox.BorderBrush = new SolidColorBrush(Colors.Red);
                MarkaBox.BorderThickness = new Thickness(1);
                return;
            }

            string godiste = GodisteBox.Text;
            if (godiste.IsNullOrEmpty())
            {
                GodisteBox.BorderBrush = new SolidColorBrush(Colors.Red);
                GodisteBox.BorderThickness = new Thickness(1);
                return;
            }

            string regBroj = RegistarskiBrojBox.Text;
            if (regBroj.IsNullOrEmpty())
            {
                RegistarskiBrojBox.BorderBrush = new SolidColorBrush(Colors.Red);
                RegistarskiBrojBox.BorderThickness = new Thickness(1);
                return;
            }

            string brojSasije = BrojSasijeBox.Text;
            if (brojSasije.IsNullOrEmpty())
            {
                BrojSasijeBox.BorderBrush = new SolidColorBrush(Colors.Red);
                BrojSasijeBox.BorderThickness = new Thickness(1);
                return;
            }

            string brojMotora = BrojMotoraBox.Text;
            if (brojMotora.IsNullOrEmpty())
            {
                BrojMotoraBox.BorderBrush = new SolidColorBrush(Colors.Red);
                BrojMotoraBox.BorderThickness = new Thickness(1);
                return;
            }

            string cijena = CijenaBox.Text;
            if (cijena.IsNullOrEmpty())
            {
                CijenaBox.BorderBrush = new SolidColorBrush(Colors.Red);
                CijenaBox.BorderThickness = new Thickness(1);
                return;
            }

            string snizenje = SnizenjeBox.Text;
            if (snizenje.IsNullOrEmpty())
            {
                SnizenjeBox.BorderBrush = new SolidColorBrush(Colors.Red);
                SnizenjeBox.BorderThickness = new Thickness(1);
                return;
            }

            string opis = new TextRange(OpisBox.Document.ContentStart, OpisBox.Document.ContentEnd).Text;
            if (opis.IsNullOrEmpty())
            {
                OpisBox.BorderBrush = new SolidColorBrush(Colors.Red);
                OpisBox.BorderThickness = new Thickness(1);
                return;
            }

            //SlikaButton;
            //SlikaText;
            //SlikePanel;
            VoziloOdFirmeDao voziloOdFirmeDao = new VoziloOdFirmeDao();
            VoziloOdFirme voziloOdFirme = new VoziloOdFirme(null,
                new Vozilo(
                    null,
                    marka,
                    model,
                    int.Parse(godiste),
                    regBroj,
                    brojSasije,
                    brojMotora,
                    null),
                new List<byte[]>(pictures),
                double.Parse(cijena),
                double.Parse(snizenje),
                opis);
            voziloOdFirmeDao.Save(voziloOdFirme);

            MessageBox.Show("Uspjesno ste dodali vozilo za prodaju.", "Uspjesno dodavanje", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Close();
        }

        private void SlikaButton_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Image files (*.png,*.bmp,*.jpg)|*.png;*.bmp;*.jpg|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //openFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + "\\..\\..\\..\\Resources\\";
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    SlikaText.Visibility = Visibility.Collapsed;
                    SlikePanel.Visibility = Visibility.Visible;
                    byte[] pic = File.ReadAllBytes(filename);
                    SlikePanel.Children.Add(new Image
                    {
                        Source = ToImage(pic),
                        Width = 10,
                        Height = 10,
                        Stretch = Stretch.Uniform
                    });
                    pictures.Add(pic);
                }
            }
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
