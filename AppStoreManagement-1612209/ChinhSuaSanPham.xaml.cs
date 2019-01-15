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
    /// Interaction logic for ChinhSuaSanPham.xaml
    /// </summary>
    public partial class ChinhSuaSanPham : Window
    {
        public ChinhSuaSanPham()
        {
            InitializeComponent();
        }

        public SanPham sp;
        public ChinhSuaSanPham(SanPham sanpham)
        {
            InitializeComponent();
            sp = sanpham;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt1.Text = sp.TenSanPham;
            txt2.Text = sp.XuatXu;
            txt3.Text = sp.GiaBan.ToString();
            txt4.Text = sp.MoTa;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            var db = new StoreManagementEntities();
            var itemToEdit = db.SanPhams.Find(sp.MaSanPham);
            itemToEdit.TenSanPham = txt1.Text;
            itemToEdit.XuatXu = txt2.Text;
            itemToEdit.GiaBan = int.Parse(txt3.Text);
            itemToEdit.MoTa = txt4.Text;
            db.SaveChanges();

            var btn = MessageBoxButton.OK;
            var img = MessageBoxImage.Information;
            var msg = "Chỉnh sửa hoàn tất";
            MessageBox.Show(msg, "Thông báo", btn, img);

            var windows = new HienThiChiTietSanPham(sp);
            windows.ShowDialog();
            this.Close();

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

            var windows = new HienThiChiTietSanPham(sp);
            windows.ShowDialog();
            this.Close();
        }
    }
}
