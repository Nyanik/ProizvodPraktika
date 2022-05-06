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

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для ViewingPage.xaml
    /// </summary>
    public partial class ViewingPage : Page
    {
        List<КлиентТур> KlientStart = BaseClass.Base.КлиентТур.ToList();
        List<Тур> Tur = BaseClass.Base.Тур.ToList();      
        List<КлиентТур> PRFilter;
        List<Тур> PRFilterTur;
        int ViewRole = 0;
        public ViewingPage(int role)
        {
            InitializeComponent();
            ViewRole = role;
            LVKlientTur.ItemsSource = KlientStart;
            LVTur.ItemsSource = Tur;
            if(ViewRole == 1 || ViewRole == 2)
            {
                BTNTur.Visibility = Visibility.Visible;
            }
        }
       

        private void Filter()
        {
            PRFilter = KlientStart;
            if (!string.IsNullOrWhiteSpace(TBFilter.Text))
            {
                PRFilter = PRFilter.Where(x => x.Клиент.ToLower().Contains(TBFilter.Text) || x.Тур.ToLower().Contains(TBFilter.Text)).ToList();
            }
            LVKlientTur.ItemsSource = PRFilter;
        }
        private void FilterTur()
        {
            PRFilterTur = Tur;
            if (!string.IsNullOrWhiteSpace(TBFilter1.Text))
            {
                PRFilterTur = PRFilterTur.Where(x => x.Название.ToLower().Contains(TBFilter1.Text)).ToList();
            }
            LVTur.ItemsSource = PRFilterTur;
        }
        private void LVKlientTur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnDel.Visibility = Visibility.Visible;
            if (LVKlientTur.SelectedIndex == -1)
            {
                BtnDel.Visibility = Visibility.Collapsed;
            }
        }

        private void TBFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {

            int ind = LVKlientTur.SelectedIndex + 1;
            КлиентТур PrDel = BaseClass.Base.КлиентТур.FirstOrDefault(y => y.ID == ind);
            if (PrDel.ДатаНачала < DateTime.Now)
            {
                MessageBox.Show("Тур уже закончен!");
            }
            else
            {
                BaseClass.Base.КлиентТур.Remove(PrDel);
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Запись удалена!");
                FrameClass.FrameMain.Navigate(new OperatePage(ViewRole));
            }

        }

        private void BTNMainPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new OperatePage(ViewRole));
        }

        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Город> Town = BaseClass.Base.Город.Where(x => x.IDТур == index).ToList();
            string str = "";
            foreach (Город item in Town)
            {               
               if (index == item.IDТур)
               {
                  str += item.Название + ", ";
               }                              
            }
            tb.Text = "Города: " + str.Substring(0, str.Length - 2) + ".";
        }

        private void BTNTur_Click(object sender, RoutedEventArgs e)
        {
            LVKlientTur.Visibility = Visibility.Collapsed;
            LVTur.Visibility = Visibility.Visible;
            BTNTur.Visibility = Visibility.Collapsed;
            BTNApplTur.Visibility = Visibility.Visible;
            SPVeiwMenu.Visibility = Visibility.Collapsed;
            SPVeiwTurMenu.Visibility = Visibility.Visible;
        }

        private void BTNApplTur_Click(object sender, RoutedEventArgs e)
        {
            LVKlientTur.Visibility = Visibility.Visible;
            LVTur.Visibility = Visibility.Collapsed;
            BTNTur.Visibility = Visibility.Visible;
            BTNApplTur.Visibility = Visibility.Collapsed;
            SPVeiwMenu.Visibility = Visibility.Visible;
            SPVeiwTurMenu.Visibility = Visibility.Collapsed;
        }

        private void TBFilter1_TextChanged(object sender, TextChangedEventArgs e)
        {
            FilterTur();
        }
    }
}
