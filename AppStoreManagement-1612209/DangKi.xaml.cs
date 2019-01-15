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
    /// Interaction logic for DangKi.xaml
    /// </summary>
    public partial class DangKi : Window
    {
        public DangKi()
        {
            InitializeComponent();
        }

        public string maxacnhan;
        private void Lbl6_Loaded(object sender, RoutedEventArgs e)
        {
            string[] s = new string[] { "ak5vj1", "1gj42s", "2gs3xj", "jkj111", "adminnb1", "kkitzome1", "mono118zk", "kk5vvz1", "axzv014a", "k5xx31" };
            var k = new Random();
            var sz = s.Count();
            maxacnhan = s[k.Next(sz)];
            lbl6.Content = maxacnhan;
            lbl6.Foreground = Brushes.Red;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (txt1.Text == "" || txt2.Text == "" || txt3.Password == "" || txt4.Password == "" || txt5.Text == "")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Vui lòng nhập đầy đủ thông tin";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else if (txt3.Password != txt4.Password)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Mật khẩu nhập lại không đúng!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else if (txt5.Text != maxacnhan)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Mã xác nhận không hợp lệ";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                var db = new StoreManagementEntities();

                var name = txt1.Text;
                bool flags = true; // không có tên nhân viên
                bool flag2 = false; // Tên đăng nhập chưa tồn tại
                var manv = "";

                foreach (var index in db.NhanViens)
                {
                    if (index.TenNhanVien.ToLower() == name.ToLower())
                    {
                        flags = false; // có tên nhân viên
                        manv = index.MaNhanVien;
                    }
                }

                foreach (var index in db.TaiKhoans)
                {
                    if (index.TenDangNhap == txt2.Text)
                    {
                        flag2 = true; // tên đăng nhập đã tồn tại
                    }
                }

                if (flags)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Chỉ nhân viên mới được đăng kí tài khoản, vui lòng nhập đúng tên nhân viên";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else if (flag2)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Tồn tại tên đăng nhập, vui lòng chọn tên đăng nhập khác";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                }
                else
                {
                    var s = "";
                    foreach (var index in db.TaiKhoans)
                    {
                        s = index.MaTaiKhoan;
                    }
                    int n = int.Parse(s.Substring(2, 3));
                    n = n + 1;
                    if (n < 10)
                    {
                        s = "TK00" + n.ToString();
                    }
                    else if (n < 100)
                    {
                        s = "TK0" + n.ToString();
                    }
                    else
                    {
                        s = "TK" + n.ToString();
                    }

                    var taikhoanToAdd = new TaiKhoan() { MaTaiKhoan = s, TenDangNhap = txt2.Text, MatKhau = txt3.Password, MaNhanVien = manv, LoaiTaiKhoan="0",isDeleted=0 };
                    db.TaiKhoans.Add(taikhoanToAdd);
                    db.SaveChanges();

                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Information;
                    var msg = "Thêm tài khoản thành công";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                    this.Close();
                }

            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            string[] s = new string[] { "ak5vj1", "1gj42s", "2gs3xj", "jkj111", "adminnb1", "kkitzome1", "mono118zk", "kk5vvz1", "axzv014a", "k5xx31" };
            var k = new Random();
            var sz = s.Count();
            maxacnhan = s[k.Next(sz)];
            lbl6.Content = maxacnhan;
            lbl6.Foreground = Brushes.Red;
        }
    }
}
