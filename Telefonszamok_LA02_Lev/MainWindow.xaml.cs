using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using cnTelefonkonyv;

namespace Telefonszamok_LA02_Lev
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private TelefonkonyvContext _context;
        public MainWindow()
        {
            InitializeComponent();
            _context = new TelefonkonyvContext();
        }

      

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            var teszt = _context.enHelysegek.ToList();

            string helysegek = "";

            foreach (var t in teszt)
            {
                helysegek += t.Nev + " ";
            }

            MessageBox.Show(helysegek);
        }

        private void bt2_Click(object sender, RoutedEventArgs e)
        {
            dgGrid.ItemsSource = _context.enSzemelyek.ToList();
        }

        private void bt3_Click(object sender, RoutedEventArgs e)
        {
            var adatok = from s in _context.enSzemelyek
                         join t in _context.enHelysegek on s.enHelysegId equals t.Id
                         select new
                         {
                             s.Vezeteknev,
                             s.Utonev,
                             t.IRSZ,
                             t.Nev,
                             s.Lakcim
                         };
       

            dgGrid.ItemsSource = adatok.ToList();
        }
    }
}