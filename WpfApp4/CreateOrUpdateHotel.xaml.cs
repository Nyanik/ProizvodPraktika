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
    /// Логика взаимодействия для CreateOrUpdateHotel.xaml
    /// </summary>
    public partial class CreateOrUpdateHotel : Page
    {
        Гостиница Hotel = new Гостиница();
        int CreateOrUpRole = 0;
        Сотрудники Empl = new Сотрудники();
        public CreateOrUpdateHotel(int role, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
        }
        public CreateOrUpdateHotel(int role, Гостиница HotelUp, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            Hotel = HotelUp;
            TBCreateHotel.Visibility = Visibility.Collapsed;
            TBUpHotel.Visibility = Visibility.Visible;
            BTNAddNewHotel.Visibility = Visibility.Collapsed;
            BTNUpHotel.Visibility = Visibility.Visible;
            TBNameHotel.Text = Hotel.Название;
            TBDesHotel.Text = Hotel.Описание;
            TBCost.Text = Convert.ToString(Hotel.Цена);
        }

        private void BTNAddNewHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotel.Название = TBNameHotel.Text;
                Hotel.Описание = TBDesHotel.Text;
                Hotel.Цена = Convert.ToInt32(TBCost.Text);
                BaseClass.Base.Гостиница.Add(Hotel);
                BaseClass.Base.SaveChanges();               
                MessageBox.Show("Гостиница создана!");
                FrameClass.FrameMain.Navigate(new CreateOrUpdateHotel(CreateOrUpRole, Empl));
            }
            catch
            {
                MessageBox.Show("Гостиница не создана!");
            }
        }

        private void BTNTur_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new CreateOrUpdateTurPage(CreateOrUpRole, Empl));
        }

        private void BtnUpHotel_Click(object sender, RoutedEventArgs e)
        {
            string strTown = Convert.ToString(CBUpHotel.SelectedValue);
            Гостиница HotelUp = BaseClass.Base.Гостиница.FirstOrDefault(y => y.Название == strTown);
            FrameClass.FrameMain.Navigate(new CreateOrUpdateHotel(CreateOrUpRole, HotelUp, Empl));
        }

        private void BtnViewUpMenu_Click(object sender, RoutedEventArgs e)
        {
            SPUpHotelMenu.Visibility = Visibility.Visible;
        }

        private void BTNUpHotel_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Hotel.Название = TBNameHotel.Text;
                Hotel.Описание = TBDesHotel.Text;
                Hotel.Цена = Convert.ToDecimal(TBCost.Text);                
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Гостиница изменена!");
                FrameClass.FrameMain.Navigate(new CreateOrUpdateHotel(CreateOrUpRole, Empl));
            }
            catch
            {
                MessageBox.Show("Гостиница не изменена!");
            }
        }
    }
}
