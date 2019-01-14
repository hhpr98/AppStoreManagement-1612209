using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AppStoreManagement_1612209
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
        }


        public List<SanPham> getItems()
        {
            var db = new StoreManagementEntities();

            var items = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
            return items;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItems();
            itemListView.ItemsSource = items;
        }

        //private void ItemListView_Selected(object sender, MouseButtonEventArgs e)
        //{
        //    //ListViewItem item = sender as ListViewItem;
        //    //object obj = item.Content;
        //    //string mt = ((SanPham)obj).MoTa;
        //    //MessageBox.Show(mt);

        //    //var index = itemListView.SelectedValue;
        //    //string mt = ((SanPham)index).MoTa;
        //    //MessageBox.Show(mt);

        //    var item = itemListView.SelectedItem as SanPham;
        //    var mt = item.TenSanPham;
        //    MessageBox.Show(mt);

        //}

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListViewItem item = e.OriginalSource as ListViewItem;
            //if (item==null)
            //{
            //    MessageBox.Show("NULL");
            //}
            //else
            //{
            //    var i = ((SanPham)item.Content).TenSanPham;
            //    MessageBox.Show(i);
            //}
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            var windows = new TimKiem();
            windows.Show();
        }
    }
}
