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
            string Typer = "";
            string Numb = "";

            if (kortnummer is > 1 and < 14) {
                Typer = "Spar";
            } else if (kortnummer is > 14 and < 27)
            {
                Typer = "Ruder";
            } else if (kortnummer is > 27 and < 40)
            {
                Typer = "Klør";
            } else if (kortnummer is > 40 and < 53)
            {
                Typer = "Hjerter";
            }

            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (Numb = 1)
            {
                Numb = "Es";
            }
            else if (kortnummer = 11)
            {
                Numb = "Knægt";
            }
            else if (kortnummer = 12)
            {
                Numb = "Dame";
            }
            else if (kortnummer = 13)
            {
                Numb = "Konge";
            }

            string resultat = $"{Numb}-{Typer}.jpg";
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
