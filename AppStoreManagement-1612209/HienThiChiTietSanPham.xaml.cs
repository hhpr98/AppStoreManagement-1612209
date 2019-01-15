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
            //this.sp = sanphamSelected;
            var db = new StoreManagementEntities(); ;
            var item = db.SanPhams.Find(sanphamSelected.MaSanPham);
            this.sp = item;
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

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap!="admin")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Stop;
                var msg = "Lỗi : chỉ admin mới có quyền chỉnh sửa!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var windows = new ChinhSuaSanPham(sp);
                windows.ShowDialog();
                this.Close();
            }
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.tendangnhap != "admin")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Stop;
                var msg = "Lỗi : chỉ admin mới có quyền xóa!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new StoreManagementEntities();

                var btn = MessageBoxButton.OKCancel;
                var img = MessageBoxImage.Warning;
                var msg = "Bạn chắc chắn muốn xóa sản phẩm này?";
                var res = MessageBox.Show(msg, "Thông báo", btn, img,MessageBoxResult.Cancel);
                if (res==MessageBoxResult.Cancel)
                {
                    // do nothing
                }
                else
                {
                    var itemToDel = db.SanPhams.Find(sp.MaSanPham);
                    itemToDel.isDeleted = 1;
                    db.SaveChanges();
                    this.Close();
                }
            }
        }
    }
}
