using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hattertar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            sliSebesseg.ValueChanged += sliSebesseg_ValueChanged;
            sliSebesseg.Value = 3200;
        }

        private void btnSzamol_Click(object sender, RoutedEventArgs e)
        {
            int.TryParse(tbKapacitas.Text, out int kapacitas);
            if (kapacitas < 1) {
                MessageBox.Show("A kapacitás nem lehet kisebb mint 1!");
                return;
            }
            int kapacitasMe = cbKapacitas.SelectedIndex;
            double kapacitasKB = kapacitas * Math.Pow(1000, kapacitasMe);

            double sebesseg = sliSebesseg.Value;
            int sebessegsMe = cbSebesseg.SelectedIndex;
            double sebessegKB = sebesseg * Math.Pow(1000, sebessegsMe);

            TimeSpan ido = TimeSpan.FromSeconds(Math.Round(kapacitasKB / sebessegKB));
            lblEredmeny.Content = ido.ToString();
        }

        private void sliSebesseg_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblSebesseg.Content = sliSebesseg.Value.ToString().PadLeft(4, '0');
        }
    }
}
