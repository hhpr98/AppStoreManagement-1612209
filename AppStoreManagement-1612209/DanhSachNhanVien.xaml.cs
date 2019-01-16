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
    /// Interaction logic for DanhSachNhanVien.xaml
    /// </summary>
    public partial class DanhSachNhanVien : Window
    {
        public DanhSachNhanVien()
        {
            InitializeComponent();
        }

        private List<NhanVien> getItem()
        {
            var db = new StoreManagementEntities();

            var items = db.NhanViens.Where(nv => nv.isDeleted == 0).ToList();

            return items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;
        }
    }
}
