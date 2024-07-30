using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2
{
    public class Sach_Kho
    {
        private int MaSach;

        public int MaSach1
        {
            get { return MaSach; }
            set { MaSach = value; }
        }

        
        private string TenSach;

        public string TenSach1
        {
            get { return TenSach; }
            set { TenSach = value; }
        }
        public int TongSoLuong;

        public int TongSoLuong1
        {
            get { return TongSoLuong; }
            set { TongSoLuong = value; }
        }

        public int SoLuongTon;

        public int SoLuongTon1
        {
            get { return SoLuongTon; }
            set { SoLuongTon = value; }
        }
    }
}