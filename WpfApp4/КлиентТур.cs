//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp4
{
    using System;
    using System.Collections.Generic;
    
    public partial class КлиентТур
    {
        public int ID { get; set; }
        public int IDТура { get; set; }
        public int IDКлиента { get; set; }
        public string Клиент { get; set; }
        public string Тур { get; set; }
        public System.DateTime ДатаНачала { get; set; }
        public System.DateTime ДатаОкончания { get; set; }
        public string Город { get; set; }
        public string Гостиница { get; set; }
        public decimal Сумма { get; set; }
    
        public virtual Клиент Клиент1 { get; set; }
        public virtual Тур Тур1 { get; set; }
    }
}
