using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Xps.Packaging;
using Aspose.Pdf;
using PdfSharp.Pdf;
using ProdajaPrepisVozila.Model.Bridge.MySQL_NoLINQ.LicaStorage;
using ProdajaPrepisVozila.Model.Dao;
using ProdajaPrepisVozila.Model.Dto.Lica;
using TheArtOfDev.HtmlRenderer.PdfSharp;
using ColorSpace = Aspose.Pdf.ColorSpace;
using PageSize = PdfSharp.PageSize;
using PrintDialog = System.Windows.Controls.PrintDialog;

namespace ProdajaPrepisVozila
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var menuPage = new View.Menu(this);
            Navigate(menuPage);

            // Navigate to object using the Navigate method
            //DaoObject<Lice> liceDaoObject = new DaoObject<Lice>(new LiceStorageMySqlNoLinq());
            //foreach (var lice in liceDaoObject.GetAll())
            //{
            //    MessageBox.Show(lice.ToString());
            //}

            //liceDaoObject.GetAll();
        }

        public static void stampajUgovor()
        {
            PdfDocument pdf = PdfGenerator.GeneratePdf(
                @"<html>
                            <body style=""text-align:center;background-color:red"">
                                <p>
                                    <a href=""www.google.rs"">Hello World</a>
                                    This is html rendered text
                                </p>
                            </body>
                      </html>", PageSize.A4);
            pdf.Save("document.pdf");
            PrintDialog pDialog = new PrintDialog();
            pDialog.PageRangeSelection = PageRangeSelection.AllPages;
            pDialog.UserPageRangeEnabled = true;

            // Display the dialog. This returns true if the user presses the Print button.
            bool? print = pDialog.ShowDialog();
            Aspose.Pdf.Document.Convert("document.pdf", null, "hello.xps", new XpsSaveOptions());
            if (print == true)
            {
                XpsDocument xpsDocument = new XpsDocument("hello.xps", FileAccess.ReadWrite);
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                pDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }
        }
    }

}
