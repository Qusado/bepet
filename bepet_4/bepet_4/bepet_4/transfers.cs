//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bepet_4
{
    using System;
    using System.Collections.Generic;
    
    public partial class transfers
    {
        public int id_tr { get; set; }
        public int id_exp_fk { get; set; }
        public int id_h_fk { get; set; }
        public System.DateTime date { get; set; }
        public Nullable<int> stay { get; set; }
    
        public virtual expanate expanate { get; set; }
        public virtual hall hall { get; set; }
    }
}
