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
        int indexDel = 0;
        public CreateOrUpdateHotel(int role, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            List<Гостиница> HotelAdCb = BaseClass.Base.Гостиница.ToList();
            for (int i = 0; i < HotelAdCb.Count; i++)
            {
                CBUpHotel.Items.Add(HotelAdCb[i].Название);
            }
        }
        public CreateOrUpdateHotel(int role, Гостиница HotelUp, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            List<Гостиница> HotelAdCb = BaseClass.Base.Гостиница.ToList();
            for (int i = 0; i < HotelAdCb.Count; i++)
            {
                CBUpHotel.Items.Add(HotelAdCb[i].Название);
            }
            Hotel = HotelUp;
            indexDel = HotelUp.ID;
            TBCreateHotel.Visibility = Visibility.Collapsed;
            TBUpHotel.Visibility = Visibility.Visible;
            BTNAddNewHotel.Visibility = Visibility.Collapsed;
            SPHotelChangeDel.Visibility = Visibility.Visible;
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

        private void BTNDelHotel_Click(object sender, RoutedEventArgs e)
        {
            Гостиница HotelDel = BaseClass.Base.Гостиница.FirstOrDefault(x => x.ID == indexDel);
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить гостиницу?", "Удаление гостиницы", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                BaseClass.Base.Гостиница.Remove(HotelDel);
                BaseClass.Base.SaveChanges();
                FrameClass.FrameMain.Navigate(new CreateOrUpdateTurPage(CreateOrUpRole, Empl));
                MessageBox.Show("Запись удалена!", "Удаление записи");
            }
        }
    }
}
