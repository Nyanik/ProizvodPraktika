using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public partial class КлиентТур
    {
        public string Header
        {
            get
            {
                return Тур + " - " + Город;
            }
        }
        public string DateTur
        {
            get
            {                
                return Convert.ToString(ДатаНачала.ToShortDateString()) + " - " + Convert.ToString(ДатаОкончания.ToShortDateString());
            }
        }
        
            }
    public partial class Сотрудники
    {
        public string FIO
        {
            get
            {
                return Фамилия + " " + Имя + " " + Отчество;
            }
        }
    }
    public partial class Тур
    {
        public string Cost
        {
            get
            {
                return Convert.ToString(Convert.ToInt32(Цена));
            }
        }
    }
}
