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
    /// Interaction logic for XemHoaDonDetail.xaml
    /// </summary>
    public partial class XemHoaDonDetail : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public XemHoaDonDetail()
        {
            InitializeComponent();
            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string mahd;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mahd = Message; // nhận từ form XemHoaDon
        }

        class sanphamban
        {
            public int STT { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string XuatXu { get; set; }
            public int SoLuong { get; set; }
            public int GiaBan { get; set; }
        }

        private List<sanphamban> getItem()
        {
            var items = new List<sanphamban>();

            // Cập nhật thông tin hóa đơn
            var db = new StoreManagementEntities();
            var hoadon_ = db.HoaDons.Find(mahd); // chắc chắn tìm thấy, vì đã tìm thấy mới sang form này
            lblMaHD2.Content = hoadon_.MaHoaDon;
            lblMaKH2.Content = hoadon_.MaKhachHang;
            var khachang_ = db.KhachHangs.Find(hoadon_.MaKhachHang);
            lblTenKH2.Content = khachang_.TenKhachHang;
            lblMaNV2.Content = hoadon_.MaNhanVien;
            lblNgay2.Content = hoadon_.NgayXuatHoaDon.ToString();

            var sothutu = 0;
            // Cập nhật chi tiết hóa đơn
            var chitiet = db.ChiTietHoaDons.Where(sp => sp.MaHoaDon == mahd).ToList();

            foreach (var index in chitiet)
            {
                sothutu = sothutu + 1;

                var msp = index.MaSanPham;
                var sanpham_ = db.SanPhams.Find(msp);

                var soluong = (int)index.SoLuong;
                var dongia = (int)sanpham_.GiaBan;
                var item = new sanphamban() { STT = sothutu, MaSanPham=msp, TenSanPham = sanpham_.TenSanPham,XuatXu=sanpham_.XuatXu, SoLuong = soluong, GiaBan = dongia };
                items.Add(item);
            }

            // cập nhật thành tiền + điểm
            lblTongtien2.Content = hoadon_.TongTien + " VNĐ";
            lblDiemTichLuy2.Content = hoadon_.DiemThuong.ToString() + " điểm";

            return items;
        }

        /// <summary>
        ///  Load danh sách các sách của hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }


        /// <summary>
        /// Về menu clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
