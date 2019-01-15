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

        List<SanPham> dsSanPham = new List<SanPham>();

        public List<SanPham> getItems()
        {
            var db = new StoreManagementEntities();

            var items = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
            return items;
        }

        public int currentPage;
        public int rowPerPage = 6;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            currentPage = 1;
            dsSanPham = getItems();
            itemListView.ItemsSource = dsSanPham.Take(6);
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
            var item = itemListView.SelectedItem;
            if (item == null)
            {
                return;
            }
            else
            {
                var windows = new HienThiChiTietSanPham(item as SanPham);
                windows.ShowDialog();
            }
        }

        private void BtnFind_Click(object sender, RoutedEventArgs e)
        {
            var windows = new TimKiem();
            windows.Show();
        }

        private void BtnPagePrev_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage==1)
            {
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Information;
                //string content = "Trang đầu không thể lùi được!";
                //MessageBox.Show(content, "Thông báo", button, icon);
            }
            else
            {
                currentPage--;
                itemListView.ItemsSource = dsSanPham.Skip((currentPage-1)*rowPerPage).Take(6);
            }
        }

        private void BtnPageNext_Click(object sender, RoutedEventArgs e)
        {
            if ((currentPage*6)>=dsSanPham.Count())
            {
                //MessageBoxButton button = MessageBoxButton.OK;
                //MessageBoxImage icon = MessageBoxImage.Information;
                //string content = "Trang cuối không thể tới được!";
                //MessageBox.Show(content, "Thông báo", button, icon);
            }
            else
            {
                currentPage++;
                itemListView.ItemsSource = dsSanPham.Skip((currentPage - 1) * rowPerPage).Take(6);
            }
        }


        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var sel = (ComboBoxItem)cbSort.SelectedItem;
            //string value = sel.Name.ToString();
            //MessageBox.Show(value);

            //var sel = cbSort.SelectedIndex.ToString();
            //MessageBox.Show(sel);

            var sel = cbSort.SelectedIndex;
            if (sel==0) // A-Z
            {
                currentPage = 1;
                for (int i=0;i<dsSanPham.Count()-1;i++)
                {
                    for (int j=i+1;j<dsSanPham.Count();j++)
                    {
                        if (String.Compare(dsSanPham[i].TenSanPham,dsSanPham[j].TenSanPham)==1)
                        {
                            var temp = dsSanPham[i];
                            dsSanPham[i] = dsSanPham[j];
                            dsSanPham[j] = temp;
                        }
                    }
                }
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
            else if (sel==1) // Z-A
            {
                currentPage = 1;
                for (int i = 0; i < dsSanPham.Count() - 1; i++)
                {
                    for (int j = i + 1; j < dsSanPham.Count(); j++)
                    {
                        if (String.Compare(dsSanPham[i].TenSanPham, dsSanPham[j].TenSanPham) == -1)
                        {
                            var temp = dsSanPham[i];
                            dsSanPham[i] = dsSanPham[j];
                            dsSanPham[j] = temp;
                        }
                    }
                }
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
            else // Type
            {
                currentPage = 1;
                for (int i = 0; i < dsSanPham.Count() - 1; i++)
                {
                    for (int j = i + 1; j < dsSanPham.Count(); j++)
                    {
                        if (String.Compare(dsSanPham[i].MaLoaiSanPham, dsSanPham[j].MaLoaiSanPham) == 1)
                        {
                            var temp = dsSanPham[i];
                            dsSanPham[i] = dsSanPham[j];
                            dsSanPham[j] = temp;
                        }
                    }
                }
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
        }

        List<string> type = new List<string>();
        int index_sel = 0;

        private void CbFill_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            index_sel = cbFill.SelectedIndex;

            txtFill.Text = "";
            currentPage = 1;

            var db = new StoreManagementEntities();

            if (index_sel == 0) // Tất cả
            {
                dsSanPham = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
            else
            {
                var temp_sp = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
                var temp_loaisp = db.LoaiSanPhams.ToList();
                var maloaisp = temp_loaisp[index_sel - 1].MaLoaiSanPham;

                dsSanPham.RemoveRange(0, dsSanPham.Count()); // remove all
                foreach (var index in temp_sp)
                {
                    if (index.MaLoaiSanPham == maloaisp)
                    {
                        dsSanPham.Add(index);
                    }
                }
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
        }

        private void CbFill_Loaded(object sender, RoutedEventArgs e)
        {
            type.Add("Tất cả");
            var db = new StoreManagementEntities();

            foreach (var index in db.LoaiSanPhams)
            {
                type.Add(index.TenLoaiSanPham);
            }
            cbFill.ItemsSource = type;
        }

        private void TxtFill_GotFocus(object sender, RoutedEventArgs e)
        {
            txtFill.Text = "";
            currentPage = 1;
        }


        private void TxtFill_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(txtFill.Text);

            var db = new StoreManagementEntities();

            // Lấy lại danh sách sản phẩm
            if (index_sel == 0)
            {
                dsSanPham = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
            }
            else
            {
                var temp_sp = db.SanPhams.Where(sp => sp.isDeleted == 0).ToList();
                var temp_loaisp = db.LoaiSanPhams.ToList();
                var maloaisp = temp_loaisp[index_sel - 1].MaLoaiSanPham;

                dsSanPham.RemoveRange(0, dsSanPham.Count()); // remove all
                foreach (var index in temp_sp)
                {
                    if (index.MaLoaiSanPham == maloaisp)
                    {
                        dsSanPham.Add(index);
                    }
                }
            }

            if (txtFill.Text=="")
            {
                itemListView.ItemsSource = dsSanPham.Take(6);
                //MessageBox.Show(itemsListViewTemp.Count().ToString());
            }
            else
            {
                var temp = new List<SanPham>();
                foreach (var index in dsSanPham)
                {
                    temp.Add(index);
                } // copy thủ công, chứ gán trực tiếp temp = dsSanPham thì khi xóa dsSanPham thì temp cũng null
                dsSanPham.RemoveRange(0, dsSanPham.Count());
                foreach (var index in temp)
                {
                    if (index.TenSanPham.ToLower().Contains(txtFill.Text.ToLower()))
                    {
                        dsSanPham.Add(index);
                    }
                }
                currentPage = 1;
                itemListView.ItemsSource = dsSanPham.Take(6);
            }
        }
    }
}
