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
        List<Тур> Tur = BaseClass.Base.Тур.ToList();
        
        public OperatePage()
        {
            InitializeComponent();
            List<Клиент> Klient = BaseClass.Base.Клиент.ToList();

            for (int i = 0; i < Klient.Count; i++)
            {
                CBKlient.Items.Add(Klient[i].ФИО);
            }
            
            for (int i = 0; i < Tur.Count; i++)
            {
                CBTur.Items.Add(Tur[i].Название);
            }
            

            
        }
       
        private void CBTur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            
            int index = CBTown.SelectedIndex+1;
            List<Гостиница> Hotel = BaseClass.Base.Гостиница.Where(x => x.IDГород == index).ToList();
           
            for (int i = 0; i < Hotel.Count; i++)
            {
                CBHotel.Items.Add(Hotel[i].Название);
            }
            
        }
    }
}
