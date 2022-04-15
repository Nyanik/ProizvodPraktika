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
                return ДатаНачала + " - " + ДатаОкончания;
            }
        }

    }
}
