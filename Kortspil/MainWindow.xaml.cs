using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Kortspil
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// 
    /// Kortene er hentet fra https://acbl.mybigcommerce.com/52-playing-cards/
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int kortnummer = Convert.ToInt32(Kort.Text);
            string filnavn = FindBillede(kortnummer);
            string url = $"/Billeder/{filnavn}";
            Uri uri = new (url, UriKind.Relative);
            BitmapImage image = new(uri);
           
            Billede.Source = image;
            
        }

        private string FindBillede(int kortnummer)
        {
            string typer = "";
            string nummer = "";

            switch (kortnummer)
            {
                case >= 1 and <= 13:
                    typer = "Spar"; break;
                case >= 14 and <= 26:
                    typer = "Ruder"; break;
                case >= 27 and <= 39:
                    typer = "Klør"; break;
                case >= 40 and <= 52:
                    typer = "Hjerter"; break;
            }

            //Es, Knægt, Dame, Konge

            switch (kortnummer)
            {
                case 1 or 14 or 27 or 40:
                    nummer = "Es"; break;
                case 11 or 24 or 37 or 50:
                    nummer = "Knægt"; break;
                case 12 or 25 or 38 or 51:
                    nummer = "Dame"; break;
                case 13 or 26 or 39 or 52:
                    nummer = "Konge"; break;
            }

            // Numre sub.

            switch (kortnummer)
            {
                case 2 or > 10:
                    nummer = $"{kortnummer}"; break;
                case 15 or > 23:
                    nummer = $"{kortnummer}"; break;
                case 28 or > 36:
                    nummer = $"{kortnummer}"; break;
                case 41 or > 49:
                    nummer = $"{kortnummer}"; break;
            }

            string resultat = $"{nummer}-{typer}.jpg";
            return resultat;






            /*I spillet bliver alle kort repræsenteret af et tal mellem 1 og 52 (der er 52 kort i et spil kort).

Du skal lave den del af programmet, der finder ud af, hvilket kort der skal vises ud fra kortets tal.

Tallene skal forstås på denne måde:

1-13 er spar
14-26 er ruder
27-39 er klør
40-52 er hjerter

Inden for hver af de fire kulører (spar, ruder, klør og hjerter) er hvert navngivet således:

1 = Es
11 = Knægt
12 = Dame
13 = Konge

For kortene fra 2 til 10 bruges blot deres tal.

Et filnavn består på den måde både af kortets navn og dets kulør, fx "10-spar.jpg" eller "dame-klør.jpg".*/
        }
    }
}
