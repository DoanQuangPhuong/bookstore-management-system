//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_ChiTietDonHang
    {
        public int MaDH { get; set; }
        public int MaSach { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual tb_DONHANG tb_DONHANG { get; set; }
        public virtual tb_SACH tb_SACH { get; set; }
    }
}
