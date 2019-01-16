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
    /// Interaction logic for ThemSanPham.xaml
    /// </summary>
    public partial class ThemSanPham : Window
    {
        public ThemSanPham()
        {
            InitializeComponent();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text==""||txt2.Text==""||txt3.Text==""||txt4.Text==""||txt5.Text==""||txt6.Text==""||txt7.Text==""||txt8.Text==""||txt9.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập đầy đủ thông tin";
                MessageBox.Show(msg, "Thông báo", btn, img);
                return;
            }

            var db = new StoreManagementEntities();

            var maloai = "";
            foreach (var index in db.LoaiSanPhams)
            {
                if (index.TenLoaiSanPham.ToLower()==txt6.Text.ToLower())
                {
                    maloai = index.MaLoaiSanPham;
                    break;
                }
            }

            if (maloai=="")
            {
                var btn2 = MessageBoxButton.OK;
                var img2 = MessageBoxImage.Error;
                var msg2 = "Không tìm thấy loại sản phẩm này!";
                MessageBox.Show(msg2, "Thông báo", btn2, img2);
                return;
            }

            // Tìm mã sản phẩm tiếp theo để thêm
            var s = "";
            foreach (var index in db.SanPhams)
            {
                s = index.MaSanPham;
            }
            int n = int.Parse(s.Substring(2, 3));
            n = n + 1;
            if (n < 10)
            {
                s = "SP00" + n.ToString();
            }
            else if (n < 100)
            {
                s = "SP0" + n.ToString();
            }
            else
            {
                s = "SP" + n.ToString();
            }

            // Tiến hành thêm vào database
            var itemToAdd = new SanPham() { MaSanPham = s, TenSanPham = txt1.Text, XuatXu = txt2.Text, GiaGoc = int.Parse(txt3.Text), GiaNhap = int.Parse(txt4.Text), GiaBan = int.Parse(txt5.Text), MaLoaiSanPham = maloai, HinhAnh = txt7.Text, MoTa = txt9.Text, SoLuong = int.Parse(txt8.Text), isDeleted = 0 };
            db.SanPhams.Add(itemToAdd);
            db.SaveChanges();
            var btn3 = MessageBoxButton.OK;
            var img3 = MessageBoxImage.Information;
            var msg3 = "Thêm sản phẩm thành công!";
            MessageBox.Show(msg3, "Thông báo", btn3, img3);
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
