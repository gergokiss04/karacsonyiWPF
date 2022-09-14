using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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
using System.Xml.Linq;

namespace karacsanyidiszekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            richtextbox.Document.Blocks.Clear();
            label5.Visibility = Visibility.Collapsed;
            for (int i = 0; i < 40; i++)
            {
                combobox.Items.Add(i + 1);
            }
            combobox.SelectedIndex = 0;

            (label5).Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            int nap = Convert.ToInt32(combobox.Text);
            int szam = Convert.ToInt32(textbox1.Text) - Convert.ToInt32(textbox2.Text);
            String szoveg="";
            szoveg += nap+".nap +"+textbox1.Text+"  -"+textbox2.Text+"  ="+szam;
            richtextbox.Document.Blocks.Add(new Paragraph(new Run(szoveg)));
            textbox1.Clear();
            textbox2.Clear();
            combobox.Items.Clear();

            for (int i = nap; i < 40; i++)
            {
                combobox.Items.Add(i + 1);
            }
            combobox.SelectedIndex = 0;

        }

        private void textbox2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox2.Text.Contains("-"))
            {
                label5.Visibility = Visibility.Visible;
                label5.Content = "Negatív számot nem adhat meg";
                button1.IsEnabled = false;
            }
            else
            {
                label5.Visibility = Visibility.Collapsed;
                button1.IsEnabled = true;

            }

            int szam1;
            int szam2;

            bool szam3=int.TryParse(textbox1.Text, out szam1);
            bool szam4 = int.TryParse(textbox2.Text, out szam2);



             if  (szam2>szam1)
            {
                label5.Visibility = Visibility.Visible;
                button1.IsEnabled = false;
                label5.Content = "Túl sok az eladott angyalka!";
                

            }
            else
            {
                label5.Visibility = Visibility.Collapsed;
                button1.IsEnabled = true;
            }
        }

        private void textbox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textbox1.Text.Contains("-"))
            {
                label5.Visibility = Visibility.Visible;
                label5.Content = "Negatív számot nem adhat meg!";
                button1.IsEnabled = false;
            }
            else
            {
                label5.Visibility = Visibility.Collapsed;
                button1.IsEnabled = true;

            }
        }
    }
}
