using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aspose.Pdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProdajaPrepisVozila.Model.Dto.Lica;
using ProdajaPrepisVozila.Model.Dto.Vozila;
using HorizontalAlignment = System.Windows.HorizontalAlignment;
using Hyperlink = System.Windows.Documents.Hyperlink;
using Image = System.Drawing.Image;
using Page = System.Windows.Controls.Page;
using VerticalAlignment = System.Windows.VerticalAlignment;

namespace ProdajaPrepisVozila.View
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class CarsForSelling : Page
    {
        private NavigationWindow _navigationWindow;
        public int Column { get; set; }
        public int Row { get; set; }
        public int NumOfPages { get; set; }
        public int CurrentPage { get; set; }
        // ReSharper disable once InconsistentNaming
        private const int ROWS = 3;
        // ReSharper disable once InconsistentNaming
        private const int COLUMNS = 4;
        private TextBlock header;
        private StackPanel footer;
        public List<CarComponent[,]> ListOfPages { get; set; } = new List<CarComponent[,]>();
        public CarsForSelling()
        {
            InitializeComponent();
            AddCars();
            ShowPage(0);
        }
        private byte[] GetImage(Vozilo vozilo)
        {
            string link = "https://picsum.photos/300/150";
            var webClient = new WebClient();
            return webClient.DownloadData(link);
        }

        private void AddFooter()
        {
            List<Label> hyperlinks = Enumerable.Range(0, NumOfPages).Select(page =>
            {
                var hyperlink = new Hyperlink(new Run($"{page + 1}"));
                hyperlink.Click += (sender, args) => { ShowPage(page); };
                return new Label { Content = hyperlink };
            }).ToList();
            footer.Children.Add(new TextBlock() { Text = "Stranice: " });
            for (var index = 0; index < hyperlinks.Count; index++)
            {
                var e = hyperlinks[index];
                if (index == CurrentPage)
                {
                    footer.Children.Add(new TextBlock() { Text = $"{index+1}" + (index==hyperlinks.Count-1?"":", "), VerticalAlignment = VerticalAlignment.Center, TextAlignment = TextAlignment.Center });
                }
                else
                {
                    footer.Children.Add(e);
                    if (index != hyperlinks.Count - 1)
                    {
                        footer.Children.Add(new TextBlock() { Text = ", ", VerticalAlignment = VerticalAlignment.Center, TextAlignment = TextAlignment.Center });
                    }
                }

            }
        }

        private void AddCars()
        {
            int i = 0;
            Random rand = new Random();
            List<VoziloProxy> list = File.ReadAllLines("cars.csv")
                    .Skip(1)
                    .OrderBy(e => Guid.NewGuid())
                    .Take(50)
                    .Select(e => e.Split(','))
                    .Select(e =>
                    {
                        var vozilo = new Vozilo(i++, e[1], e[2], int.Parse(e[0]), 0, null, null, null);
                        return new VoziloProxy(i, vozilo, GetImage(vozilo),
                        rand.Next((vozilo.GodinaProizvodnje - 1900) * 200, (vozilo.GodinaProizvodnje - 1900) * 300),
                        rand.Next(5), "Ovo je opis");
                    })
                    .ToList();

            foreach (var voziloProxy in list)
            {
                if (Column == 0 && Row == 0)
                {
                    NumOfPages++;
                    ListOfPages.Add(new CarComponent[ROWS, COLUMNS]);
                }
                var component = new CarComponent(voziloProxy);
                ListOfPages[ListOfPages.Count - 1][Row, Column] = component;
                Column++;
                if (Column == COLUMNS)
                {
                    Column = 0;
                    Row++;
                    if (Row == ROWS)
                    {
                        Row = 0;
                    }
                }
            }
        }

        public void ShowPage(int page)
        {
            CurrentPage = page;
            Grid.Children.Clear();
            header = new TextBlock()
            {
                FontWeight = FontWeights.Bold,
                FontSize = 15,
                TextAlignment = TextAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Text = "AUTA KOJA SU NA PRODAJI",
                Height = 20
            };
            Grid.Children.Add(header);
            Grid.SetColumn(header, 1);
            Grid.SetRow(header, 0);
            Grid.SetColumnSpan(header, 2);

            footer = new StackPanel()
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            Grid.Children.Add(footer);
            Grid.SetColumn(footer, 1);
            Grid.SetColumnSpan(footer, 2);
            Grid.SetRow(footer, 4);

            for (int row = 0; row < ListOfPages[page].GetLength(0); row++)
            {
                for (int column = 0; column < ListOfPages[page].GetLength(1); column++)
                {
                    var component = ListOfPages[page][row, column];
                    if(component==null) continue;
                    Grid.Children.Add(component);
                    Grid.SetRow(component, row + 1);
                    Grid.SetColumn(component, column);
                }
            }
            AddFooter();
        }

        public CarsForSelling(NavigationWindow navigationWindow) : this()
        {
            _navigationWindow = navigationWindow;
        }
    }
}
