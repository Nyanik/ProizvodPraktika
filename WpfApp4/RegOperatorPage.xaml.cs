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
    /// Логика взаимодействия для RegOperatorPage.xaml
    /// </summary>
    public partial class RegOperatorPage : Page
    {
        Сотрудники Oper = new Сотрудники();
        bool flag;
        public RegOperatorPage()
        {
            InitializeComponent();
            flag = true;
            List<Роли> Role = BaseClass.Base.Роли.ToList();

            for (int i = 0; i < Role.Count; i++)
            {
                CBSetRole.Items.Add(Role[i].Название_роли);
            }
        }
        public RegOperatorPage(Сотрудники Empl)
        {
            InitializeComponent();
            GBLogin.Visibility = Visibility.Collapsed;
            GBPass.Visibility = Visibility.Collapsed;
            BTNChange.Visibility = Visibility.Visible;
            BTNRegOp.Visibility = Visibility.Collapsed;
            flag = true;
            List<Роли> Role = BaseClass.Base.Роли.ToList();
            for (int i = 0; i < Role.Count; i++)
            {
                CBSetRole.Items.Add(Role[i].Название_роли);
            }
            Oper = Empl;
            TBSurname.Text = Empl.Фамилия;
            TBName.Text= Empl.Имя;
            TBMidName.Text = Empl.Отчество;
            CBSetRole.SelectedIndex = Empl.ID_Роль - 1;
            TBPhone.Text = Empl.Телефон;
            TBLogin.Text = Empl.Логин;                        
        }

        private void BTNEmpl_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new AdminOpPage());
        }

        private void BTNRegOp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Oper.Фамилия = TBSurname.Text;
                Oper.Имя = TBName.Text;
                Oper.Отчество = TBMidName.Text;
                Oper.Телефон = TBPhone.Text;
                List<Сотрудники> Operators = BaseClass.Base.Сотрудники.ToList();
                foreach (Сотрудники item in Operators)
                {
                    for (int i = 0; i < Operators.Count; i++)
                    {
                        if (TBLogin.Text == item.Логин)
                        {
                            flag = false;
                            MessageBox.Show("Такой логин уже существует!");
                        }
                    }
                }
                Oper.Логин = TBLogin.Text;               
                if (TBPass.Text.Length < 8)
                {
                    flag = false;
                    MessageBox.Show("Пароль должен содержать не меньше 8 символов!");
                }
                else
                {
                    int paswordCode = TBPass.Text.GetHashCode();
                    Oper.Пароль = paswordCode;
                }
               
                Oper.Оформ_туров = 0;
                Oper.Зарег_клиентов = 0;
                Oper.ID_Роль = CBSetRole.SelectedIndex + 1;
                if (flag == true)
                {
                    BaseClass.Base.Сотрудники.Add(Oper);
                    BaseClass.Base.SaveChanges();
                    MessageBox.Show("Сотрудник зарегистрирован");
                    FrameClass.FrameMain.Navigate(new AdminOpPage());
                }
                else
                {
                    MessageBox.Show("Сотрудник не зарегистрирован");
                }
                
            }
            catch
            {
                MessageBox.Show("Сотрудник не зарегистрирован");
            }
        }

        private void BTNChange_Click(object sender, RoutedEventArgs e)
        {           
            try
            {               
                Oper.Фамилия = TBSurname.Text;
                Oper.Имя = TBName.Text;
                Oper.Отчество = TBMidName.Text;
                Oper.Телефон = TBPhone.Text;               
                Oper.ID_Роль = CBSetRole.SelectedIndex + 1;                
                if (flag == true)
                {
                    BaseClass.Base.Сотрудники.Add(Oper);
                    BaseClass.Base.SaveChanges();
                    MessageBox.Show("Данные сотрудника изменены");
                    FrameClass.FrameMain.Navigate(new AdminOpPage());
                }
                else
                {
                    MessageBox.Show("Данные сотрудника не изменены");
                }

            }
            catch
            {
                MessageBox.Show("Данные сотрудника не изменены");
            }
        }
    }
}
