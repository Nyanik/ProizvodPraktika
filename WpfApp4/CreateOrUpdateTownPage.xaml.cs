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
    /// Логика взаимодействия для CreateOrUpdateTownPage.xaml
    /// </summary>
    public partial class CreateOrUpdateTownPage : Page
    {
        Город Town = new Город();
        int CreateOrUpRole = 0;
        Сотрудники Empl = new Сотрудники();
        int indexDel = 0;
        public CreateOrUpdateTownPage(int role, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            List<Город> TownAdCb = BaseClass.Base.Город.ToList();
            for (int i = 0; i < TownAdCb.Count; i++)
            {
                CBUpTown.Items.Add(TownAdCb[i].Название);
            }
            List<Гостиница> HotelAddCB = BaseClass.Base.Гостиница.ToList();
            for (int i = 0; i < HotelAddCB.Count(); i++)
            {
                if (CBHotel.Items.Contains(HotelAddCB[i].Название))
                {
                }
                else
                {
                    if (HotelAddCB[i].IDГород == null)
                    {
                        CBHotel.Items.Add(HotelAddCB[i].Название);
                    }

                }
            }
        }
        public CreateOrUpdateTownPage(int role, Город TownUp, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            Town = TownUp;
            indexDel = TownUp.ID;
            TBCreateTown.Visibility = Visibility.Collapsed;
            TBUpTown.Visibility = Visibility.Visible;
            btnSaveNewTown.Visibility = Visibility.Collapsed;
            SPChangeDelMenu.Visibility = Visibility.Visible;
            List<Город> TownAdCb = BaseClass.Base.Город.ToList();
            for (int i = 0; i < TownAdCb.Count; i++)
            {
                CBUpTown.Items.Add(TownAdCb[i].Название);
            }
            List<Гостиница> HotelAddCB = BaseClass.Base.Гостиница.ToList();
            for (int i = 0; i < HotelAddCB.Count(); i++)
            {
                if (CBHotel.Items.Contains(HotelAddCB[i].Название))
                {
                }
                else
                {
                    if (HotelAddCB[i].IDГород == null)
                    {
                        CBHotel.Items.Add(HotelAddCB[i].Название);
                    }

                }
            }
            TBNameTown.Text = Town.Название;
            TBCost.Text = Convert.ToString(Town.Цена);
            foreach (Гостиница item in HotelAddCB)
            {
                if (item.IDГород == TownUp.ID)
                {
                    LBHotel.Items.Add(item.Название);
                }
            }
        }
    
        private void BTNAddHotel_Click(object sender, RoutedEventArgs e)
        {
            LBHotel.Items.Add(CBHotel.SelectedItem);
        }

        private void BTNDelHotel_Click(object sender, RoutedEventArgs e)
        {
            LBHotel.Items.Remove(CBHotel.SelectedItem);
        }

        private void btnSaveNewTown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Town.Название = TBNameTown.Text;
                Town.Цена = Convert.ToInt32(TBCost.Text);
                BaseClass.Base.Город.Add(Town);
                BaseClass.Base.SaveChanges();

                List<Город> TownId = BaseClass.Base.Город.ToList();
                int indexTown = 0;
                for (int a = 0; a < TownId.Count; a++)
                {
                    foreach (Город item in TownId)
                    {
                        if (TBNameTown.Text == item.Название)
                        {
                            indexTown = item.ID;
                        }
                    }
                }
                List<Гостиница> Hotel = BaseClass.Base.Гостиница.ToList();

                for (int i = 0; i < LBHotel.Items.Count; i++)
                {
                    bool flag = true;
                    int index = 0;
                    string strHotel = Convert.ToString(LBHotel.Items[i]);
                    foreach (Гостиница item in Hotel)
                    {
                        for (int y = 0; y < Hotel.Count; y++)
                        {
                            if (strHotel == item.Название)
                            {
                                index = item.ID;
                                Гостиница HotelAd = BaseClass.Base.Гостиница.FirstOrDefault(t => t.ID == index);
                                HotelAd.IDГород = indexTown;
                                if (flag == true)
                                {
                                    BaseClass.Base.SaveChanges();
                                }
                                flag = false;
                            }
                        }
                    }
                }
                MessageBox.Show("Город создан!");
                FrameClass.FrameMain.Navigate(new CreateOrUpdateTownPage(CreateOrUpRole, Empl));
            }
            catch
            {
                MessageBox.Show("Город не создан!");
            }
        }

        private void BTNTur_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new CreateOrUpdateTurPage(CreateOrUpRole, Empl));
        }

        private void BtnUpTownVis_Click(object sender, RoutedEventArgs e)
        {
            SPUpTownMenu.Visibility = Visibility.Visible;
        }

        private void BtnUpTown_Click(object sender, RoutedEventArgs e)
        {
            string strTown = Convert.ToString(CBUpTown.SelectedValue);
            Город TownUp = BaseClass.Base.Город.FirstOrDefault(y => y.Название == strTown);
            FrameClass.FrameMain.Navigate(new CreateOrUpdateTownPage(CreateOrUpRole,TownUp, Empl));
        }

        private void btnChangeTown_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Town.Название = TBNameTown.Text;
                Town.Цена = Convert.ToDecimal(TBCost.Text);
                
                BaseClass.Base.SaveChanges();

                List<Город> TownId = BaseClass.Base.Город.ToList();
                int indexTown = 0;
                for (int a = 0; a < TownId.Count; a++)
                {
                    foreach (Город item in TownId)
                    {
                        if (TBNameTown.Text == item.Название)
                        {
                            indexTown = item.ID;
                        }
                    }
                }
                List<Гостиница> Hotel = BaseClass.Base.Гостиница.ToList();

                for (int i = 0; i < LBHotel.Items.Count; i++)
                {
                    bool flag = true;
                    int index = 0;
                    string strHotel = Convert.ToString(LBHotel.Items[i]);
                    foreach (Гостиница item in Hotel)
                    {
                        for (int y = 0; y < Hotel.Count; y++)
                        {
                            if (strHotel == item.Название)
                            {
                                index = item.ID;
                                Гостиница HotelAd = BaseClass.Base.Гостиница.FirstOrDefault(t => t.ID == index);
                                HotelAd.IDГород = indexTown;
                                if (flag == true)
                                {
                                    BaseClass.Base.SaveChanges();
                                }
                                flag = false;
                            }
                        }
                    }
                }
                MessageBox.Show("Город изменен!");
                FrameClass.FrameMain.Navigate(new CreateOrUpdateTownPage(CreateOrUpRole, Empl));
            }
            catch
            {
                MessageBox.Show("Город не изменен!");
            }
        }

        private void btnDelTown_Click(object sender, RoutedEventArgs e)
        {
            Город TownDel = BaseClass.Base.Город.FirstOrDefault(x => x.ID == indexDel);
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить город?", "Удаление города", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                BaseClass.Base.Город.Remove(TownDel);
                BaseClass.Base.SaveChanges();
                FrameClass.FrameMain.Navigate(new CreateOrUpdateTurPage(CreateOrUpRole, Empl));
                MessageBox.Show("Запись удалена!", "Удаление записи");
            }
        }
    }
}
