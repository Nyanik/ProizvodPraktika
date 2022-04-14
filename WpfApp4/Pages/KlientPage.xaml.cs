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
        public KlientPage()
        {
            InitializeComponent();
            flag = true;
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
                }


                BaseClass.Base.SaveChanges();
                MessageBox.Show("Данные записаны");
                FrameClass.FrameMain.Navigate(new OperatePage());
            }
            catch
            {
                MessageBox.Show("Данные не записаны");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new OperatePage());
        }
    }
}
