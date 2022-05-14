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
    /// Логика взаимодействия для AdminOpPage.xaml
    /// </summary>
    public partial class AdminOpPage : Page
    {
        List<Сотрудники> Operators = BaseClass.Base.Сотрудники.ToList();
        int AdminRole = 1;
        Сотрудники Empl = new Сотрудники();
        public AdminOpPage(Сотрудники empl)
        {
            InitializeComponent();
            LVOperator.ItemsSource = Operators;
            Empl = empl;
        }

       
        private void TextBlock_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;
            int index = Convert.ToInt32(tb.Uid);
            List<Роли> Role = BaseClass.Base.Роли.Where(x => x.ID_Роль == index).ToList();
            string str = "";
            foreach (Роли item in Role)
            {               
                    str += item.Название_роли + "";
                
            }
            tb.Text = "Роль:" + str;
        }

        private void BTNMainPage_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new OperatePage(AdminRole,Empl));
        }

        private void BTNRegOp_Click(object sender, RoutedEventArgs e)
        {
            FrameClass.FrameMain.Navigate(new RegOperatorPage(Empl));
        }

        private void BTNUp_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Сотрудники Oper = BaseClass.Base.Сотрудники.FirstOrDefault(y => y.ID_Сотрудника == ind);
            FrameClass.FrameMain.Navigate(new RegOperatorPage(Oper,Empl));            
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            Button B = (Button)sender;
            int ind = Convert.ToInt32(B.Uid);
            Сотрудники EmplDel = BaseClass.Base.Сотрудники.FirstOrDefault(y => y.ID_Сотрудника == ind);
            BaseClass.Base.Сотрудники.Remove(EmplDel);
            BaseClass.Base.SaveChanges();
            MessageBox.Show("Сотрудник удалён!");
            FrameClass.FrameMain.Navigate(new AdminOpPage(Empl));
        }
    }
}
