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
    /// Interaction logic for XemPhieuNhapDetail.xaml
    /// </summary>
    public partial class XemPhieuNhapDetail : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public XemPhieuNhapDetail()
        {
            InitializeComponent();
            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string mapn;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            mapn = Message; // nhận từ form XemPhieuNhap
        }

        class sanphamnhap
        {
            public int STT { get; set; }
            public string MaSanPham { get; set; }
            public string TenSanPham { get; set; }
            public string XuatXu { get; set; }
            public int SoLuong { get; set; }
            public int GiaNhap { get; set; }
        }

        private List<sanphamnhap> getItem()
        {
            var items = new List<sanphamnhap>();

            // Cập nhật thông tin phiếu nhập
            var db = new StoreManagementEntities();
            var phieunhap_ = db.PhieuNhaps.Find(mapn); // chắc chắn tìm thấy, vì đã tìm thấy mới sang form này
            lblMaHD2.Content = phieunhap_.MaPhieuNhap;
            lblMaNV2.Content = phieunhap_.MaNhanVien;
            lblNgay2.Content = phieunhap_.NgayNhap.ToString();

            var sothutu = 0;
            // Cập nhật chi tiết phiếu nhập
            var chitiet = db.ChiTietPhieuNhaps.Where(sp => sp.MaPhieuNhap == mapn).ToList();

            foreach (var index in chitiet)
            {
                sothutu = sothutu + 1;

                var msp = index.MaSanPham;
                var sanpham_ = db.SanPhams.Find(msp);

                var soluong = (int)index.SoLuong;
                var dongia = (int)sanpham_.GiaBan;
                var item = new sanphamnhap() { STT = sothutu, MaSanPham = msp, TenSanPham = sanpham_.TenSanPham, XuatXu = sanpham_.XuatXu, SoLuong = soluong, GiaNhap = dongia };
                items.Add(item);
            }

            // cập nhật thành tiền
            lblTongtien2.Content = phieunhap_.TongTien + " VNĐ";

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
