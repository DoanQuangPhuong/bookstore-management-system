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
    
    public partial class tb_SACH
    {
        public tb_SACH()
        {
            this.tb_ChiTietDonHang = new HashSet<tb_ChiTietDonHang>();
            this.tb_KhoSach = new HashSet<tb_KhoSach>();
            this.tb_NhatKiNhapSach = new HashSet<tb_NhatKiNhapSach>();
        }
    
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string Image { get; set; }
        public Nullable<double> Gia { get; set; }
        public Nullable<int> NamXuatBan { get; set; }
        public string TenNXB { get; set; }
        public string TacGia { get; set; }
        public string TheLoai { get; set; }
    
        public virtual ICollection<tb_ChiTietDonHang> tb_ChiTietDonHang { get; set; }
        public virtual ICollection<tb_KhoSach> tb_KhoSach { get; set; }
        public virtual ICollection<tb_NhatKiNhapSach> tb_NhatKiNhapSach { get; set; }
    }
}
