using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Birthday
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static readonly string[] Verses = new string[]{
@"Katra diena ir diena,
lai atpūstos un sapņotu,
lai smietos un brīnītos,
lai mīlētu un baudītu mīlu,
lai runātu un klausītos,
lai priecātos un justos laimīgs.
Katra diena ir diena,
lai dzīvotu!",

@"Lai viss ko vēlies - piepildās.
Lai viss ko dari - izdodās,
Lai viss ko gribi ir sasniedzams.
Bet nekad lai nav tā, ka nav nekā!",

@"Novēlu Tev pārsteigumu, kas rada prieku,
Prieku, kas rada iedvesmu;
Iedvesmu, kas iepriecina draugus,
Draugus, kas sagādā pārsteigumus !",

@"Līksmai dienai - putnu dziesma,
Aukstai - ugunskura liesmu, 
Labam miegam - jūras šalku, 
Lielām slāpēm - rasas malku, 
Karstai dienai - vēju lēnu, 
Nogurumam - vēsu ēnu, 
Skumjām - pūpolmīkstu glāstu, 
Tukšiem brīžiem - brīnumstāstu, 
Tumšai naktij - zvaigžņu lietu, 
Sirdī mīlai - siltu vietu!"
        };

        private DispatcherTimer timer;
        private int verseIndex;

        public MainWindow()
        {
            InitializeComponent();
            InitVerse();
            InitiTimer();
        }

        private void InitiTimer()
        {
            this.timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += new EventHandler(OnTimerElapsed);
            timer.Start();
        }

        private void InitVerse()
        {
            var random = new Random();
            this.verseIndex = random.Next(Verses.Length - 1);
            uxVerse.Content = Verses[this.verseIndex];
        }

        private void OnTimerElapsed(object sender, EventArgs e)
        {
            this.verseIndex = (this.verseIndex + 1) % Verses.Length;
            uxVerse.Content = Verses[this.verseIndex];
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
