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
    /// Логика взаимодействия для KlientPage.xaml
    /// </summary>
    public partial class KlientPage : Page
    {
       Клиент klient = new Клиент();
        bool flag;
        bool staticsflag;
        int KlientRole = 0;
        Сотрудники Empl = new Сотрудники();
        public KlientPage(int role,Сотрудники empl)
        {
            InitializeComponent();
            KlientRole = role;
            flag = true;
            
            Empl = empl;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                klient.ФИО = TBTitle.Text;
                klient.Серия = Convert.ToInt32(TBSer.Text);
                klient.Номер = Convert.ToInt32(TBNamb.Text);
                klient.Телефон = TBTel.Text;
                klient.Возраст = Convert.ToInt32(TBAge.Text);

                if (flag == true)
                {
                    BaseClass.Base.Клиент.Add(klient);
                    staticsflag = true;
                }
                else
                {
                    staticsflag = false;
                }


                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны");
                if(staticsflag == true)
                {
                    Empl.Зарег_клиентов = Empl.Зарег_клиентов + 1;
                    BaseClass.Base.SaveChanges();
                }
                FrameClass.FrameMain.Navigate(new OperatePage(KlientRole,Empl));
            }
            catch
            {
                MessageBox.Show("Данные не записаны");
            }
        }

        private void BTNMainPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new OperatePage(KlientRole, Empl));
        }
    }
}
