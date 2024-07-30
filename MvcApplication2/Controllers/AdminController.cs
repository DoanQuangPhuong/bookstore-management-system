using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using System.Data.SqlClient;
using System.Data;

namespace MvcApplication2.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        HTQLNSEntities1 db = new HTQLNSEntities1();
        //Trang Admin
        public ActionResult Index(string search = "")
        {
            
            //Danh sách Sách
            ViewBag.Values = search;
            List<tb_SACH> ds = db.tb_SACH.Where(row => row.TenSach.Contains(search)).ToList();
            ViewBag.ListBook = ds;

            //Danh sách số lượng sách sách trong kho
            var query = from book in db.tb_SACH
                        join kho in db.tb_KhoSach on book.MaSach equals kho.MaSach
                        select new Sach_Kho
                        {
                            MaSach1 = book.MaSach,
                            TenSach1 = book.TenSach,
                            TongSoLuong1 = kho.TongSoLuong ?? 0,
                            SoLuongTon1 = kho.SoLuongTon ?? 0
                        };
            var List_SachKho = query.ToList();
            ViewBag.List_SachKho = List_SachKho;

            //Danh sách nhật kí nhập sách
            List<tb_NhatKiNhapSach> ds_NKNS = db.tb_NhatKiNhapSach.ToList();
            ViewBag.ds_NKNS = ds_NKNS;
            //Danh Sách Nhân Viên
            List<tb_NHANVIEN> ds_NV = db.tb_NHANVIEN.ToList();
            ViewBag.ds_NV = ds_NV;
            //Danh Sách Khách Hàng
            List<tb_KHACHHANG> ds_KH = db.tb_KHACHHANG.ToList();
            ViewBag.ds_KH = ds_KH;
            //Danh Sách Khách Hàng
            List<tb_TaiKhoan> ds_TK = db.tb_TaiKhoan.ToList();
            ViewBag.ds_TK = ds_TK;

            return View();
        }

        //Thêm Sách
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(FormCollection form)
        {
            tb_SACH sach = new tb_SACH();
            sach.MaSach = int.Parse(form["maSach"]);
            sach.TenSach = form["tenSach"];
            sach.Image = form["hinhAnh"];
            sach.Gia = double.Parse(form["gia"], System.Globalization.CultureInfo.InvariantCulture);
            sach.NamXuatBan = int.Parse(form["namXuatBan"]);
            sach.TenNXB = form["nhaXuatBan"];
            sach.TacGia = form["tacGia"];
            sach.TheLoai = form["theLoai"];
            db.tb_SACH.Add(sach);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Sửa Sách
        public ActionResult Edit(int id)
        {
            tb_SACH sach = db.tb_SACH.Where(row => row.MaSach == id).FirstOrDefault();
            return View(sach);
        }

        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            int oldId = int.Parse(form["maSach"]);
            tb_SACH sach = db.tb_SACH.Where(row => row.MaSach == oldId).FirstOrDefault();
            sach.TenSach = form["tenSach"];
            sach.Image = form["hinhAnh"];
            sach.Gia = double.Parse(form["gia"], System.Globalization.CultureInfo.InvariantCulture);
            sach.NamXuatBan = int.Parse(form["namXuatBan"]);
            sach.TenNXB = form["nhaXuatBan"];
            sach.TacGia = form["tacGia"];
            sach.TheLoai = form["theLoai"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Xóa Sách
        public ActionResult Delete(int id)
        {
            tb_KhoSach ks = db.tb_KhoSach.Where(row => row.MaSach == id).FirstOrDefault();
            tb_SACH s = db.tb_SACH.Where(row => row.MaSach == id).FirstOrDefault();
            db.tb_KhoSach.Remove(ks);
            db.tb_SACH.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Nhập Sách Vào Kho
        public ActionResult ADD_NhatKiNS()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ADD_NhatKiNS(FormCollection form)
        {
            int soluong = int.Parse(form["soLuong"]);
            int maSach =  int.Parse(form["maSach"]);
            //Lưu kết quả nhập form vào class
            tb_NhatKiNhapSach nk = new tb_NhatKiNhapSach();
            nk.STT = int.Parse(form["stt"]);
            nk.MaSach = int.Parse(form["maSach"]);
            nk.SoLuong = int.Parse(form["soLuong"]);
            nk.NgayNhap = DateTime.Parse(form["ngayNhap"]);
            nk.MaNV = int.Parse(form["maNhanVien"]);
            //Tìm mã sách trong kho và thêm số lượng của mã sách đó vào
            tb_KhoSach k = db.tb_KhoSach.Where(row => row.MaSach == maSach).FirstOrDefault();
            k.TongSoLuong = k.TongSoLuong + soluong;
            k.SoLuongTon = k.SoLuongTon + soluong;
            db.tb_NhatKiNhapSach.Add(nk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Thêm Sách Vào Kho
        //public ActionResult ThemSachMoiVaoKho()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ThemSachMoiVaoKho(FormCollection form)
        //{
        //    tb_KhoSach k = new tb_KhoSach();
        //    k.MaKho = int.Parse(form["maKho"]);
        //    k.MaSach = int.Parse(form["maSach"]);
        //    k.TongSoLuong = int.Parse(form["tongSoLuong"]);
        //    k.SoLuongTon = int.Parse(form["soLuongTon"]);
        //    db.tb_KhoSach.Add(k);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        //Thêm Tài Khoản Nhân Viên
        public ActionResult ThemTaiKhoanNhanVien()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemTaiKhoanNhanVien(FormCollection form)
        {
            tb_TaiKhoan k = new tb_TaiKhoan();
            tb_NHANVIEN nv = new tb_NHANVIEN();
            nv.MaNV = int.Parse(form["maNV"]);
            nv.HoTen = form["hoTen"];
            nv.SDT = form["sdt"];
            nv.DiaChi = form["diaChi"];
            nv.Email = form["email"];
            k.Email = nv.Email;
            k.MatKhau = "123456";
            k.Quyen = "Admin";
            k.MaNV = null;
            k.MaKH = null;
            db.tb_TaiKhoan.Add(k);
            db.tb_NHANVIEN.Add(nv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Sửa Nhân Viên
        public ActionResult SuaNhanVien(int id)
        {
            tb_NHANVIEN nv = db.tb_NHANVIEN.Where(row => row.MaNV == id).FirstOrDefault();
            return View(nv);
        }

        [HttpPost]
        public ActionResult SuaNhanVien(FormCollection form)
        {
            int oldID = int.Parse(form["maNV"]);
            tb_NHANVIEN nv = db.tb_NHANVIEN.Where(row => row.MaNV == oldID).FirstOrDefault();
            nv.HoTen = form["hoTen"];
            nv.SDT = form["sdt"];
            nv.DiaChi = form["diaChi"];
            nv.Email = form["email"];
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Xóa Nhân Viên
        public ActionResult XoaNhanVien(int id)
        {
            string Email = string.Empty;
            tb_NHANVIEN nv = db.tb_NHANVIEN.Where(row => row.MaNV == id).FirstOrDefault();
            Email = nv.Email;
            db.tb_NHANVIEN.Remove(nv);
            db.SaveChanges();
            tb_TaiKhoan tk = db.tb_TaiKhoan.Where(row => row.Email == Email).FirstOrDefault();
            db.tb_TaiKhoan.Remove(tk);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult SuaTaiKhoan(string id = "")
        {
            tb_TaiKhoan tk = db.tb_TaiKhoan.Where(row => row.Email.Contains(id)).FirstOrDefault();
            return View(tk);
        }

        [HttpPost]
        public ActionResult SuaTaiKhoan(FormCollection form)
        {
            tb_TaiKhoan tk = db.tb_TaiKhoan.Where(row => row.Email == form["Email"]).FirstOrDefault();
            tk.MatKhau = form["MatKhau"];
           tk.Quyen = form["Quyen"];
           db.SaveChanges();
            return RedirectToAction("Index");
        }

       


    }
}
