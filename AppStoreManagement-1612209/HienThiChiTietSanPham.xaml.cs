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
    /// Interaction logic for HienThiChiTietSanPham.xaml
    /// </summary>
    public partial class HienThiChiTietSanPham : Window
    {
        public HienThiChiTietSanPham()
        {
            InitializeComponent();
        }

        public SanPham sp;
        public HienThiChiTietSanPham(SanPham sanphamSelected)
        {
            this.sp = sanphamSelected;
            InitializeComponent();
            //MessageBox.Show(sp.TenSanPham);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var name = "Điện thoại " + sp.TenSanPham;
            lblTitle.Content = name;
            imgProduce.Source = new BitmapImage(new Uri(sp.HinhAnh, UriKind.Relative));
            var xx = "Xuất xứ \t: " + sp.XuatXu;
            lblXuatXu.Content = xx;
            var giaban = "Giá bán \t: " + sp.GiaBan.ToString() + " VNĐ";
            lblGiaBan.Content = giaban;
            var mota = "Mô tả \t: " + sp.MoTa;
            txtDescription.Text = mota;
        }
    }
}
