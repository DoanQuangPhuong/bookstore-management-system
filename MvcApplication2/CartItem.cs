using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2
{
    public class CartItem
    {
        int masach;
        public int Masach
        {
          get { return masach; }
          set { masach = value; }
        }
        string tenSach;

        public string TenSach
        {
            get { return tenSach; }
            set { tenSach = value; }
        }
        string image;

        public string Image
        {
            get { return image; }
            set { image = value; }
        }
        float gia;

        public float Gia
        {
            get { return gia; }
            set { gia = value; }
        }
        private int soluong;

        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
    }
}