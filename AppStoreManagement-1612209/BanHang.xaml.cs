using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppStoreManagement_1612209
{
    /// <summary>
    /// Interaction logic for BanHang.xaml
    /// </summary>
    public partial class BanHang : Window
    {
        public BanHang()
        {
            InitializeComponent();
        }

        private void Txt1_GotFocus(object sender, RoutedEventArgs e)
        {
            txt1.Text = "";
        }

        private void Txt1_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txt1.Text!="")
            {
                if (txt1.Text.ToLower()==lblNhacLenhKH.Content.ToString().ToLower())
                {
                    lblNhacLenhKH.Content = "";
                }
                else
                {
                    bool flag = true;

                    var db = new StoreManagementEntities();
                    foreach (var index in db.KhachHangs)
                    {
                        if (index.TenKhachHang.ToLower().Contains(txt1.Text.ToLower()))
                        {
                            flag = false;
                            lblNhacLenhKH.Content = index.TenKhachHang;
                            break;
                        }
                    }

                    if (flag)
                    {
                        lblNhacLenhKH.Content = "";
                    }
                }
            }
            else
            {
                lblNhacLenhKH.Content = "";
            }
        }

        private void LblNhacLenhKH_Loaded(object sender, RoutedEventArgs e)
        {
            lblNhacLenhKH.Content = "";
        }

        private void LblNhacLenhSP_Loaded(object sender, RoutedEventArgs e)
        {
            lblNhacLenhSP.Content = "";
        }

        private void TxtSanPham_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSanPham.Text = "";
        }

        private void TxtSanPham_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (txtSanPham.Text != "")
            {
                if (txtSanPham.Text.ToLower() == lblNhacLenhSP.Content.ToString().ToLower())
                {
                    lblNhacLenhSP.Content = "";
                }
                else
                {
                    bool flag = true;

                    var db = new StoreManagementEntities();
                    foreach (var index in db.SanPhams)
                    {
                        if (index.TenSanPham.ToLower().Contains(txtSanPham.Text.ToLower()))
                        {
                            flag = false;
                            lblNhacLenhSP.Content = index.TenSanPham;
                            break;
                        }
                    }

                    if (flag)
                    {
                        lblNhacLenhSP.Content = "";
                    }
                }
            }
            else
            {
                lblNhacLenhSP.Content = "";
            }
        }

        class sanphamban
        {
            public int STT { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public int GiaBan { get; set; }
        }

        List<sanphamban> items = new List<sanphamban>();
        public string mahd;
        public string manv;
        public DateTime date;
        public string makhachhang;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            itemListView.ItemsSource = items;
            manv = MainWindow.manv;
            lbl31.Content = manv;
            date = DateTime.Now;
            lbl41.Content = date.ToShortDateString();

            // Tìm mã hóa đơn tiếp theo để thêm
            var db = new StoreManagementEntities();
            var s = "";
            foreach (var index in db.HoaDons)
            {
                s = index.MaHoaDon;
            }
            int n = int.Parse(s.Substring(2, 3));
            n = n + 1;
            if (n < 10)
            {
                s = "HD00" + n.ToString();
            }
            else if (n < 100)
            {
                s = "HD0" + n.ToString();
            }
            else
            {
                s = "HD" + n.ToString();
            }

            mahd = s;
            lbl11.Content = mahd;
        }

        int sothutu = 0;
        int tongtien = 0;
        int diemthuong = 0;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSanPham.Text=="" || txtSoLuong.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Warning;
                var msg = "Vui lòng nhập đầy đủ thông tin!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var flag = true;

                var db = new StoreManagementEntities();

                foreach (var index in db.SanPhams)
                {
                    if (index.TenSanPham.ToLower()==txtSanPham.Text.ToLower())
                    {
                        sothutu++;
                        flag = false;
                        var item = new sanphamban() { STT = sothutu, MaSanPham = index.MaSanPham, TenSanPham = index.TenSanPham, SoLuong = int.Parse(txtSoLuong.Text), GiaBan = (int)index.GiaBan };
                        items.Add(item);
                        tongtien += int.Parse(txtSoLuong.Text) * (int)index.GiaBan;
                        lblTongtien.Content = tongtien.ToString() + " VNĐ";
                        diemthuong = tongtien / 100000;
                        lblDiemthuong.Content = diemthuong.ToString() + " điểm";
                        index.SoLuong -= int.Parse(txtSoLuong.Text); // đặt ở đây nghĩa là thêm vào rồi phải mua
                        break;
                    }
                }

                db.SaveChanges();

                if (flag)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Không tìm thấy tên sản phẩm";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }

                itemListView.ItemsSource = items.Take(10); // méo biết bug này tại sao, nếu k dùng take thì dòng này vô tác dụng mặc dù trong list items vẫn có items???
            }
        }

        private void ThanhToan_Click(object sender, RoutedEventArgs e)
        {
            if (items.Count()==0)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Chưa có sản phẩm nào trong giỏ hàng!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                return;
            }

            var db = new StoreManagementEntities();

            var makh = "";
            var diemcuaKH = 0;
            // Tìm mã khách hàng
            foreach (var index in db.KhachHangs)
            {
                if (index.TenKhachHang.ToLower()==txt1.Text.ToLower())
                {
                    makh = index.MaKhachHang;
                    diemcuaKH = (int)index.DiemTichLuy;
                    break;
                }
            }

            if (makh=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Không tìm thấy mã khách hàng";
                MessageBox.Show(msg, "Thông báo", btn, img);
                return;
            }

            var btn1 = MessageBoxButton.OKCancel;
            var img1 = MessageBoxImage.Information;
            var msg1 = "Khách hàng hiện đang có " + diemcuaKH.ToString() + " điểm, bạn có muốn trừ vào hóa đơn không?";
            var res = MessageBox.Show(msg1, "Thông báo", btn1, img1,MessageBoxResult.Cancel);

            if (res==MessageBoxResult.OK)
            {
                var find = db.KhachHangs.Find(makh);
                tongtien -= diemcuaKH * 1000;
                find.DiemTichLuy = diemthuong;
            }
            else
            {
                var find = db.KhachHangs.Find(makh);
                find.DiemTichLuy += diemthuong;
            }
            db.SaveChanges(); // save điểm thưởng


            // Tạo hóa đơn
            var hoadonToAdd = new HoaDon() { MaHoaDon = mahd, MaKhachHang = makh, MaNhanVien = manv, NgayXuatHoaDon = date, TongTien = tongtien, DiemThuong = diemthuong };
            db.HoaDons.Add(hoadonToAdd);
            db.SaveChanges(); // save hóa đơn


            // Tạo từng chi tiết hóa đơn
            foreach (var index in items)
            {
                // Tìm chi tiết hóa đơn tiếp theo để thêm
                var s = "";
                foreach (var i in db.ChiTietHoaDons)
                {
                    s = i.MaChiTietHoaDon;
                }
                int n = int.Parse(s.Substring(2, 3));
                n = n + 1;
                if (n < 10)
                {
                    s = "CD00" + n.ToString();
                }
                else if (n < 100)
                {
                    s = "CD0" + n.ToString();
                }
                else
                {
                    s = "CD" + n.ToString();
                }

                // Tạo chi tiết hóa đơn
                var chitietToAdd = new ChiTietHoaDon() {MaChiTietHoaDon=s,MaHoaDon=mahd,MaSanPham=index.MaSanPham,SoLuong=index.SoLuong,GiaBan=index.GiaBan};
                db.ChiTietHoaDons.Add(chitietToAdd);
                db.SaveChanges();

            }

            var bt = MessageBoxButton.OK;
            var im = MessageBoxImage.Information;
            var ms = "Thanh toán thành công!";
            MessageBox.Show(ms, "Thông báo", bt, im);
            this.Close();
        }
    }
}
