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
    
    public partial class INVOICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICE()
        {
            this.INVOICES_DET = new HashSet<INVOICES_DET>();
        }
    
        public int ID { get; set; }
        public Nullable<int> ID_CLIENT { get; set; }
        public Nullable<int> ID_TABLE { get; set; }
        public Nullable<int> ID_WAITER { get; set; }
        public Nullable<System.DateTime> INVOICE_DATE { get; set; }
    
        public virtual CLIENT CLIENT { get; set; }
        public virtual TABLE TABLE { get; set; }
        public virtual WAITER WAITER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INVOICES_DET> INVOICES_DET { get; set; }
    }
}
