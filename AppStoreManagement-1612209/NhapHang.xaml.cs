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
    /// Interaction logic for NhapHang.xaml
    /// </summary>
    public partial class NhapHang : Window
    {
        public NhapHang()
        {
            InitializeComponent();
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

        class sanphamnhap
        {
            public int STT { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
            public int GiaNhap { get; set; }
        }

        List<sanphamnhap> items = new List<sanphamnhap>();
        public string mapn;
        public string manv;
        public DateTime date;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            itemListView.ItemsSource = items;
            manv = MainWindow.manv;
            lbl31.Content = manv;
            date = DateTime.Now;
            lbl41.Content = date.ToShortDateString();

            // Tìm mã phiếu nhập tiếp theo để thêm
            var db = new StoreManagementEntities();
            var s = "";
            foreach (var index in db.PhieuNhaps)
            {
                s = index.MaPhieuNhap;
            }
            int n = int.Parse(s.Substring(2, 3));
            n = n + 1;
            if (n < 10)
            {
                s = "PN00" + n.ToString();
            }
            else if (n < 100)
            {
                s = "PN0" + n.ToString();
            }
            else
            {
                s = "PN" + n.ToString();
            }

            mapn = s;
            lbl11.Content = mapn;
        }

        int sothutu = 0;
        int tongtien = 0;
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (txtSanPham.Text == "" || txtSoLuong.Text == "")
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
                    if (index.TenSanPham.ToLower() == txtSanPham.Text.ToLower())
                    {
                        sothutu++;
                        flag = false;
                        var item = new sanphamnhap() { STT = sothutu, MaSanPham = index.MaSanPham, TenSanPham = index.TenSanPham, SoLuong = int.Parse(txtSoLuong.Text), GiaNhap = (int)index.GiaNhap };
                        items.Add(item);
                        tongtien += int.Parse(txtSoLuong.Text) * (int)index.GiaBan;
                        lblTongtien.Content = tongtien.ToString() + " VNĐ";
                        index.SoLuong += int.Parse(txtSoLuong.Text); // đặt ở đây nghĩa là thêm vào rồi phải nhập
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
            if (items.Count() == 0)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Chưa có sản phẩm nào trong phiếu nhập!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                return;
            }

            var db = new StoreManagementEntities();

            // Tạo phiếu nhập
            var phieunhapToAdd = new PhieuNhap() { MaPhieuNhap = mapn, MaNhanVien = manv, NgayNhap = date, TongTien = tongtien };
            db.PhieuNhaps.Add(phieunhapToAdd);
            db.SaveChanges(); // save phiếu nhập


            // Tạo từng chi tiết phiếu nhập
            foreach (var index in items)
            {
                // Tìm chi tiết phiếu nhập tiếp theo để thêm
                var s = "";
                foreach (var i in db.ChiTietPhieuNhaps)
                {
                    s = i.MaChiTietPhieuNhap;
                }
                int n = int.Parse(s.Substring(2, 3));
                n = n + 1;
                if (n < 10)
                {
                    s = "CP00" + n.ToString();
                }
                else if (n < 100)
                {
                    s = "CP0" + n.ToString();
                }
                else
                {
                    s = "CP" + n.ToString();
                }

                // Tạo chi tiết phiếu nhập
                var chitietToAdd = new ChiTietPhieuNhap() { MaChiTietPhieuNhap = s, MaPhieuNhap = mapn, MaSanPham = index.MaSanPham, SoLuong = index.SoLuong, GiaNhap = index.GiaNhap };
                db.ChiTietPhieuNhaps.Add(chitietToAdd);
                db.SaveChanges(); // save chi tiết phiếu nhập

            }

            var bt = MessageBoxButton.OK;
            var im = MessageBoxImage.Information;
            var ms = "Nhập hàng thành công!";
            MessageBox.Show(ms, "Thông báo", bt, im);

            this.Close();
        }

    }
}
