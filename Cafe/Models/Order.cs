//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cafe.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int ID { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public string Status { get; set; }
        public int Count { get; set; }
        public Nullable<int> NumberTable { get; set; }
        public int EmployeeID { get; set; }
        public string Dishes { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
    }
}
