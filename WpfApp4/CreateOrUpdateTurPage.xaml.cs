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
    /// Логика взаимодействия для CreateOrUpdateTurPage.xaml
    /// </summary>
    public partial class CreateOrUpdateTurPage : Page
    {
        Тур Tur = new Тур();               
        int CreateOrUpRole = 0;
        Сотрудники Empl = new Сотрудники();
        int indexDel = 0;
        ДатаТур DT = new ДатаТур();
        public CreateOrUpdateTurPage(int role, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            List<Город> TownAddCB = BaseClass.Base.Город.ToList();
            for (int i = 0; i < TownAddCB.Count(); i++)
            {
                if (CBTown.Items.Contains(TownAddCB[i].Название))
                {
                }
                else
                {
                    if(TownAddCB[i].IDТур == null)
                    {
                        CBTown.Items.Add(TownAddCB[i].Название);
                    }
                    
                }
            }
        }
        public CreateOrUpdateTurPage(int role, Тур TurUp, Сотрудники empl)
        {
            InitializeComponent();
            CreateOrUpRole = role;
            Empl = empl;
            indexDel = TurUp.ID;
            BtnCreateTown.Visibility = Visibility.Collapsed;
            BtnCreateHotel.Visibility = Visibility.Collapsed;
            TBCreateTur.Visibility = Visibility.Collapsed;
            TBUpTur.Visibility = Visibility.Visible;
            BTNAddTur.Visibility = Visibility.Collapsed;
            BTNUpTur.Visibility = Visibility.Visible;
            BTNAddDateTur.Visibility = Visibility.Visible;
            BTNDelTur.Visibility = Visibility.Visible;
            List<Город> TownAddCB = BaseClass.Base.Город.ToList();
            for (int i = 0; i < TownAddCB.Count(); i++)
            {
                if (CBTown.Items.Contains(TownAddCB[i].Название))
                {
                }
                else
                {
                    if (TownAddCB[i].IDТур == null)
                    {
                        CBTown.Items.Add(TownAddCB[i].Название);
                    }
                }               
            }
            TBNameTur.Text = TurUp.Название;
            TBCost.Text = Convert.ToString(TurUp.Цена);
            foreach(Город item in TownAddCB)
            {
                if (item.IDТур == TurUp.ID)
                {
                    LBTown.Items.Add(item.Название);
                }
            }

        }

        private void BTNTur_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new ViewingPage(CreateOrUpRole, Empl));
        }

        private void AddTown_Click(object sender, RoutedEventArgs e)
        {
            LBTown.Items.Add(CBTown.SelectedItem);
        }

        private void DelTown_Click(object sender, RoutedEventArgs e)
        {
            LBTown.Items.Remove(CBTown.SelectedItem);
        }

        private void BTNAddTur_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tur.Название = TBNameTur.Text;
                Tur.Цена = Convert.ToInt32(TBCost.Text);
                BaseClass.Base.Тур.Add(Tur);
                BaseClass.Base.SaveChanges();

                List<Тур> TurId = BaseClass.Base.Тур.ToList();
                int indexTur = 0;
                for (int a = 0; a < TurId.Count; a++)
                {
                    foreach (Тур item in TurId)
                    {
                        if (TBNameTur.Text == item.Название)
                        {
                            indexTur = item.ID;
                        }
                    }
                }
                List<Город> Town = BaseClass.Base.Город.ToList();
                
                for (int i = 0; i < LBTown.Items.Count; i++)
                {
                    bool flag=true;
                    int index = 0;
                    string strTown = Convert.ToString(LBTown.Items[i]);
                    foreach (Город item in Town)
                    {
                        for (int y = 0; y < Town.Count; y++)
                        {
                            if (strTown == item.Название)
                            {
                                index = item.ID;
                                Город TownAd = BaseClass.Base.Город.FirstOrDefault(t => t.ID == index);
                                TownAd.IDТур = indexTur;
                                if(flag == true)
                                {                                   
                                    BaseClass.Base.SaveChanges();
                                }
                                flag = false;
                            }
                        }     
                    }
                }
                MessageBox.Show("Тур создан!");
            }
            catch
            {
                MessageBox.Show("Тур не создан!");
            }
        }

        private void BTNAddDateTur_Click(object sender, RoutedEventArgs e)
        {
            BTNAddDateTur.Visibility = Visibility.Collapsed;
            BTNHidAddTur.Visibility = Visibility.Visible;
            SPAddDateTur.Visibility = Visibility.Visible;
        }

        private void BTNHidAddTur_Click(object sender, RoutedEventArgs e)
        {
            BTNAddDateTur.Visibility = Visibility.Visible;
            BTNHidAddTur.Visibility = Visibility.Collapsed;
            SPAddDateTur.Visibility = Visibility.Collapsed;
        }

        private void BTNUpTur_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tur.Название = TBNameTur.Text;
                Tur.Цена = Convert.ToDecimal(TBCost.Text);
                BaseClass.Base.SaveChanges();

                List<Тур> TurId = BaseClass.Base.Тур.ToList();
                int indexTur = 0;
                for (int a = 0; a < TurId.Count; a++)
                {
                    foreach (Тур item in TurId)
                    {
                        if (TBNameTur.Text == item.Название)
                        {
                            indexTur = item.ID;
                        }
                    }
                }
                List<Город> Town = BaseClass.Base.Город.ToList();

                for (int i = 0; i < LBTown.Items.Count; i++)
                {
                    bool flag = true;
                    int index = 0;
                    string strTown = Convert.ToString(LBTown.Items[i]);
                    foreach (Город item in Town)
                    {
                        for (int y = 0; y < Town.Count; y++)
                        {
                            if (strTown == item.Название)
                            {
                                index = item.ID;
                                Город TownAd = BaseClass.Base.Город.FirstOrDefault(t => t.ID == index);
                                TownAd.IDТур = indexTur;
                                if (flag == true)
                                {
                                    BaseClass.Base.SaveChanges();
                                }
                                flag = false;
                            }
                            //if (item.IDТур == indexTur)
                            //{
                            //    if (CBTown.Items.Contains(item.Название))
                            //    {
                            //    }
                            //    else
                            //    {
                            //        index = item.ID;
                            //        Город TownDel = BaseClass.Base.Город.FirstOrDefault(t => t.ID == index);
                            //        TownDel.IDТур =null;                                   
                            //        BaseClass.Base.SaveChanges();
                            //    }
                            //}

                        }
                    }
                }
                MessageBox.Show("Тур изменен!");
            }
            catch
            {
                MessageBox.Show("Тур не изменен!");
            }
        }

        private void BTNDelTur_Click(object sender, RoutedEventArgs e)
        {
            Тур TurDel = BaseClass.Base.Тур.FirstOrDefault(x => x.ID == indexDel);
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить тур?", "Удаление тура", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                BaseClass.Base.Тур.Remove(TurDel);
                BaseClass.Base.SaveChanges();
                FrameClass.FrameMain.Navigate(new ViewingPage(CreateOrUpRole, Empl));
                MessageBox.Show("Запись удалена!", "Удаление записи");
            }
        }

        private void BTNAddDateStEndTur_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DT.IDТур = indexDel;
                DateTime DTStart = (DateTime)DPDateStart.SelectedDate;
                DateTime DTEnd = (DateTime)DPDateEnd.SelectedDate;
                string strstart = Convert.ToString(DTStart.ToShortDateString());
                string strend = Convert.ToString(DTEnd.ToShortDateString());                
                DT.ДатаНачала = Convert.ToDateTime(strstart);
                DT.ДатаОкончания = Convert.ToDateTime(strend);
                BaseClass.Base.ДатаТур.Add(DT);
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Дата тура добавлена!");              
            }
            catch
            {
                MessageBox.Show("Дата тура не добавлена!");
            }
        }

        private void BtnCreateTown_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new CreateOrUpdateTownPage(CreateOrUpRole, Empl));
        }

        private void BtnCreateHotel_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new CreateOrUpdateHotel(CreateOrUpRole, Empl));
        }
    }
}
