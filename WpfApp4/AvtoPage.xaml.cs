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
    /// Логика взаимодействия для AvtoPage.xaml
    /// </summary>
    public partial class AvtoPage : Page
    {
        public AvtoPage()
        {
            InitializeComponent();
        }

        private void BTNAvto_Click(object sender, RoutedEventArgs e)
        {
            int paswordCode = TBPasAvto.Password.GetHashCode();
            int role = 0;
            Сотрудники Empl = BaseClass.Base.Сотрудники.FirstOrDefault(z => z.Логин == TBLoginAvto.Text && z.Пароль == paswordCode);
            if (Empl == null)
            {
                MessageBox.Show("Вы не зарегистрированы");
            }
            else
            {
                switch (Empl.ID_Роль)
                {
                    case 1:
                        MessageBox.Show("Здравствуйте, администратор " + Empl.Имя);
                        role = Empl.ID_Роль;
                        FrameClass.FrameMain.Navigate(new OperatePage(role));                        
                        break;
                    case 2:
                        MessageBox.Show("Здравствуйте, Ст. оператор " + Empl.Имя);
                        role = Empl.ID_Роль;
                        FrameClass.FrameMain.Navigate(new OperatePage(role));  
                        break;
                    case 3:
                        MessageBox.Show("Здравствуйте, оператор " + Empl.Имя);
                        role = Empl.ID_Роль;
                        FrameClass.FrameMain.Navigate(new OperatePage(role));  
                        break;
                }
            }
        }
    }
}
