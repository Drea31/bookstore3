//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace bookstore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ratings
    {
        public int RatingID { get; set; }
        public Nullable<int> BookID { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> RatingValue { get; set; }
    
        public virtual Books Books { get; set; }
        public virtual Users Users { get; set; }
    }
}
