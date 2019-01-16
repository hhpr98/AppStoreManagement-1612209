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
    /// Interaction logic for DanhSachTaiKhoan.xaml
    /// </summary>
    public partial class DanhSachTaiKhoan : Window
    {
        public DanhSachTaiKhoan()
        {
            InitializeComponent();
        }

        class TK
        {
            public string MaTK { get; set; }
            public string TenDangNhap { get; set; }
            public string MatKhau { get; set; }
            public string LoaiTK { get; set; }
            public string color { get; set; }
        }

        public static string vcolor = "White";


        private List<TK> getItem()
        {
            var items = new List<TK>();

            var db = new StoreManagementEntities();

            foreach (var index in db.TaiKhoans)
            {
                var loai = "";
                if (index.LoaiTaiKhoan == "1")
                {
                    loai = "Quản trị viên";
                }
                else
                {
                    loai = "Nhân viên";
                }
                var item = new TK() { MaTK = index.MaTaiKhoan, TenDangNhap = index.TenDangNhap, MatKhau = index.MatKhau, LoaiTK = loai, color = vcolor };
                items.Add(item);
            }
            return items;
        }

        /// <summary>
        /// Windows loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            vcolor = "Black";
            var items = getItem();
            for (int i = 0; i < items.Count(); i++)
            {
                items[i].color = vcolor;
            }
            itemListView.ItemsSource = items;

        }

        private void BtnHide_Click(object sender, RoutedEventArgs e)
        {
            vcolor = "White";
            var items = getItem();
            for (int i = 0; i < items.Count(); i++)
            {
                items[i].color = vcolor;
            }
            itemListView.ItemsSource = items;
        }
    }
}
