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
    /// Логика взаимодействия для PersonalAccountPage.xaml
    /// </summary>
    public partial class PersonalAccountPage : Page
    {
        Сотрудники Empl = new Сотрудники();
        int PARole = 0;
        string path;
        public PersonalAccountPage(int role,Сотрудники empl)
        {
            InitializeComponent();
            Empl = empl;
            PARole = role;           
            TBFIO.Text = "Имя: " + Empl.Имя + " " + Empl.Фамилия + " " + Empl.Отчество;
            int index = Empl.ID_Роль;            
            path = Empl.Аватар;
            BitmapImage BI = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
            ImgAvatar.Source = BI;
            List<Роли> Role = BaseClass.Base.Роли.Where(x => x.ID_Роль == index).ToList();
            string str = "";
            foreach (Роли item in Role)
            {
                str += item.Название_роли + "";
            }           ;
            TBRole.Text = "Роль: " + str;
            TBPhone.Text = "Телефон: " + Empl.Телефон;
            TBRegKlient.Text ="Зарегистрированно клиентов: " + Convert.ToString(Empl.Зарег_клиентов);
            TBOformTur.Text ="Оформленно туров: " + Convert.ToString(Empl.Оформ_туров);
            TBLogin.Text = Empl.Логин;
            TBPass.Text = "";
        }

        private void BTNMainPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new OperatePage(PARole, Empl));
        }
        

        private void BTNChnagePassLog_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(TBLogin.Text != Empl.Логин && TBPass.Text != "")
                {
                    Empl.Логин = TBLogin.Text;
                    int paswordCode = TBPass.Text.GetHashCode();
                    Empl.Пароль = paswordCode;
                    BaseClass.Base.SaveChanges();
                    MessageBox.Show("Данные сотрудника изменены");
                }
                else
                {
                    if (TBLogin.Text != Empl.Логин)
                    {
                        Empl.Логин = TBLogin.Text;
                        BaseClass.Base.SaveChanges();
                        MessageBox.Show("Логин изменен");
                    }
                    if (TBPass.Text != "")
                    {
                        if (TBPass.Text.Length < 8)
                        {                            
                            MessageBox.Show("Пароль должен содержать не меньше 8 символов!");
                        }
                        else
                        {
                            int paswordCode = TBPass.Text.GetHashCode();
                            Empl.Пароль = paswordCode;
                            BaseClass.Base.SaveChanges();
                            MessageBox.Show("Пароль изменен");
                        }                        
                    }
                }                              
            }
            catch
            {
                MessageBox.Show("Данные не изменены");
            }
            
        }

        private void BTNViewLogPas_Click(object sender, RoutedEventArgs e)
        {
            SPLoginPass.Visibility = Visibility.Visible;
            BTNHideLogPas.Visibility = Visibility.Visible;
            BTNViewLogPas.Visibility = Visibility.Collapsed;
        }

        private void BTNHideLogPas_Click(object sender, RoutedEventArgs e)
        {
            SPLoginPass.Visibility = Visibility.Collapsed;
            BTNHideLogPas.Visibility = Visibility.Collapsed;
            BTNViewLogPas.Visibility = Visibility.Visible;
        }
    }
}
