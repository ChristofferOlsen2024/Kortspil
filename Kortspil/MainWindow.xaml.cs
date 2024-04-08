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

            if (kortnummer is >= 1 and <= 13) {
                typer = "Spar";
                switch (kortnummer)
                {
                    case 1:
                        nummer = "Es"; break;
                    case 11:
                        nummer = "Knægt"; break;
                    case 12:
                        nummer = "Dame"; break;
                    case 13:
                        nummer = "Konge"; break;
                }
            } else if (kortnummer is >= 14 and <= 26)
            {
                typer = "Ruder";
                switch (kortnummer)
                {
                    case 14:
                        nummer = "Es"; break;
                    case 24:
                        nummer = "Knægt"; break;
                    case 25:
                        nummer = "Dame"; break;
                    case 26:
                        nummer = "Konge"; break;
                }
            } else if (kortnummer is >= 27 and <= 39)
            {
                typer = "Klør";
                switch (kortnummer)
                {
                    case 27:
                        nummer = "Es"; break;
                    case 37:
                        nummer = "Knægt"; break;
                    case 38:
                        nummer = "Dame"; break;
                    case 39:
                        nummer = "Konge"; break;
                }
            } else if (kortnummer is >= 40 and <= 52)
            {
                typer = "Hjerter";
                switch (kortnummer)
                {
                    case 40:
                        nummer = "Es"; break;
                    case 50:
                        nummer = "Knægt"; break;
                    case 51:
                        nummer = "Dame"; break;
                    case 52:
                        nummer = "Konge"; break;
                } 
            }

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

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
