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
    /// Interaction logic for DanhSachKhachHang.xaml
    /// </summary>
    public partial class DanhSachKhachHang : Window
    {
        public DanhSachKhachHang()
        {
            InitializeComponent();
        }

        private List<KhachHang> getItem()
        {
            var db = new StoreManagementEntities();

            var items = db.KhachHangs.Where(kh=>kh.isDeleted==0).ToList();

            return items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }
    }
}
