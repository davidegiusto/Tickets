using Assistenze.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Assistenze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //nothing if changed from button1
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            //Filtro ricerca Aperte
            Sysgest sg = new Sysgest();
            //this.dataGridAssitenze.ItemsSource = sg.GetListaAssistenze();
            this.dataGridAssitenze.ItemsSource = sg.GetDataTableAssistenze().DefaultView;

        }

        private void dataGridAssitenze_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           // long i = this.dataGridAssitenze.SelectedIndex;

           
        }
    }
}
