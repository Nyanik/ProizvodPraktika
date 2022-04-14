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
    /// Логика взаимодействия для OperatePage.xaml
    /// </summary>
    public partial class OperatePage : Page
    {
        КлиентТур KT = new КлиентТур();
        bool flag;

        public OperatePage()
        {
            InitializeComponent();
            List<Клиент> Klient = BaseClass.Base.Клиент.ToList();

            for (int i = 0; i < Klient.Count; i++)
            {
                CBKlient.Items.Add(Klient[i].ФИО);
            }
            List<Тур> Tur = BaseClass.Base.Тур.ToList();
            for (int i = 0; i < Tur.Count; i++)
            {
                CBTur.Items.Add(Tur[i].Название);
            }
            

            
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new KlientPage());
        }
        private void CBTur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBsumm.Text = "";
            CBDateTur.Items.Clear();
            CBTown.Items.Clear();
            CBHotel.Items.Clear();
            int index = CBTur.SelectedIndex+1;
            List<ДатаТур> DateTur = BaseClass.Base.ДатаТур.Where(x => x.IDТур == index).ToList();
                     
            for (int i = 0; i < DateTur.Count; i++)
            {            
             CBDateTur.Items.Add(DateTur[i].ДатаНачала);
            }
            
            List<Город> Town = BaseClass.Base.Город.Where(x => x.IDТур == index).ToList();
                      
            for (int i = 0; i < Town.Count; i++)
            {
                CBTown.Items.Add(Town[i].Название);
            }
            
            
        }

        private void CBTown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TBsumm.Text = "";
            CBHotel.Items.Clear();
            List<Город> Town = BaseClass.Base.Город.ToList();           
            int index = 0;
            string strTown = (string)CBTown.SelectedValue;
            foreach(Город item in Town)
            {
                for (int i = 0; i < Town.Count; i++)
                {
                    if (strTown == item.Название)
                    {
                        index = item.ID;
                    }
                }
            }           
            List<Гостиница> Hotel = BaseClass.Base.Гостиница.Where(x => x.IDГород == index).ToList();           
            for (int i = 0; i < Hotel.Count; i++)
            {
                CBHotel.Items.Add(Hotel[i].Название);
            }           
        }
        private void CBDateTur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBDateTur.SelectedIndex != -1)
            {
                TBEndTur.Text = "";
                List<ДатаТур> DT = BaseClass.Base.ДатаТур.ToList();
                DateTime Date = (DateTime)CBDateTur.SelectedValue;
                foreach (ДатаТур item in DT)
                {
                    for (int i = 0; i < DT.Count; i++)
                    {
                        if (Date == item.ДатаНачала)
                        {
                            TBEndTur.Text = Convert.ToString(item.ДатаОкончания);
                        }
                    }
                }
            }
            else
            {
                TBEndTur.Text = "";
            }
            
        }
       
      
        private void CBHotel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBHotel.SelectedIndex != -1 && CBKlient.SelectedIndex != -1)
            {
                int indTur = CBTur.SelectedIndex + 1;
                int indTown = CBTown.SelectedIndex + 1;
                int indHotel = CBHotel.SelectedIndex + 1;
                int indKlient = CBKlient.SelectedIndex + 1;
                List<Тур> T = BaseClass.Base.Тур.Where(x => x.ID == indTur).ToList();
                List<Город> Town = BaseClass.Base.Город.Where(x => x.ID == indTown).ToList();
                List<Гостиница> H = BaseClass.Base.Гостиница.Where(x => x.ID == indHotel).ToList();
                List<Клиент> K = BaseClass.Base.Клиент.Where(x => x.ID == indKlient).ToList();
                int cost = 0;
                int vozr = 0;
                foreach (Тур item in T)
                {
                    cost += (int)item.Цена;
                }
                foreach (Город item in Town)
                {
                    cost += (int)item.Цена;
                }
                foreach (Гостиница item in H)
                {
                    cost += (int)item.Цена;
                }
                foreach (Клиент item in K)
                {
                    vozr += item.Возраст;
                }
                if (vozr < 20)
                {
                    TBsumm.Text = cost - (cost * 0.2) + "";
                }
                else
                {
                    TBsumm.Text = cost + "";
                }
            }          
        }

        private void BtnWrite_Click(object sender, RoutedEventArgs e)
        {
            if (CBKlient.SelectedIndex != -1 && CBTur.SelectedIndex != -1 && CBDateTur.SelectedIndex != -1 && CBTown.SelectedIndex != -1 && CBHotel.SelectedIndex != -1)
            {
                flag = true;
            }
            try
            {
                int idKl = CBKlient.SelectedIndex+1;
                KT.IDКлиента = idKl;
                int idTur = CBTur.SelectedIndex+1;
                KT.IDТура = idTur;
                string DateStart = Convert.ToString(CBDateTur.SelectedValue);
                KT.ДатаНачала = Convert.ToDateTime(DateStart);
                KT.ДатаОкончания = Convert.ToDateTime(TBEndTur.Text);
                List<Город> Town = BaseClass.Base.Город.ToList();
                int index = 0;
                string strTown = (string)CBTown.SelectedValue;
                foreach (Город item in Town)
                {
                    for (int i = 0; i < Town.Count; i++)
                    {
                        if (strTown == item.Название)
                        {
                            index = item.ID;
                        }
                    }
                }
                KT.IDГорода = index;
                List<Гостиница> Hotel = BaseClass.Base.Гостиница.ToList();
                int indexD = 0;
                string strHotel = (string)CBHotel.SelectedValue;
                foreach (Гостиница item in Hotel)
                {
                    for (int i = 0; i < Hotel.Count; i++)
                    {
                        if (strHotel == item.Название)
                        {
                            indexD = item.ID;
                        }
                    }
                }
                KT.IDГостиницы = indexD;
                KT.Сумма = Convert.ToInt32(TBsumm.Text);
                if (flag == true)
                {
                    BaseClass.Base.КлиентТур.Add(KT);
                }
                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны");
                CBKlient.SelectedIndex = -1;
                CBTur.SelectedIndex = -1;
                CBDateTur.Items.Clear();
                TBEndTur.Text = "";
                CBTown.Items.Clear();
                CBHotel.Items.Clear();
                TBsumm.Text = "";                      
            }
            catch
            {
                MessageBox.Show("Данные не записаны");
            }
        }

        
    }
}
