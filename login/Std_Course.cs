//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace login
{
    using System;
    using System.Collections.Generic;
    
    public partial class Std_Course
    {
        public int Std_ID { get; set; }
        public int Crs_ID { get; set; }
        public Nullable<int> Grade { get; set; }
    
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }
}