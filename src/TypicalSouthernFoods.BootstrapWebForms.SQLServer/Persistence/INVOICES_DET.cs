//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TypicalSouthernFoods.Webforms.Persistence
{
    using System;
    using System.Collections.Generic;
    
    public partial class INVOICES_DET
    {
        public int ID { get; set; }
        public Nullable<int> ID_INVOICE { get; set; }
        public string RECIPE_NAME { get; set; }
        public Nullable<int> PRICE { get; set; }
    
        public virtual INVOICE INVOICE { get; set; }
    }
}
