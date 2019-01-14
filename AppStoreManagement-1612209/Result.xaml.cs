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
    /// Interaction logic for Result.xaml
    /// </summary>
    public partial class Result : Window
    {

        // Khai báo delegate
        public delegate void SendMessage(string Message);
        public SendMessage Sender;

        public Result()
        {
            InitializeComponent();

            // Tạo con trỏ tới hàm GetMessage
            Sender = new SendMessage(GetMessage);
        }

        public static string checkstring;
        // Hàm có nhiệm vụ nhận thông điệp
        private void GetMessage(string Message)
        {
            checkstring = Message; // nhận từ form Find
        }

        private List<SanPham> getItem()
        {
            var check = checkstring.Substring(0, 2);

            var items = new List<SanPham>();

            var db = new StoreManagementEntities();

            if (check == "10") // Tìm theo tên
            {
                var name_text = checkstring.Substring(3, checkstring.Count() - 3);
                //MessageBox.Show(name_text, check);

                foreach (var index in db.SanPhams)
                {
                    if (index.isDeleted==0 && index.TenSanPham.ToLower() == name_text.ToLower()) // tìm thấy tên
                    {
                        items.Add(index);
                    }
                }
            }

            if (check == "01") // Tìm theo loại
            {
                var type_text = checkstring.Substring(3, checkstring.Count() - 3);

                var maloaisp = "";
                foreach (var index in db.LoaiSanPhams)
                {
                    if (index.TenLoaiSanPham.ToLower()==type_text.ToLower())
                    {
                        maloaisp = index.MaLoaiSanPham;
                    }
                }

                foreach (var index in db.SanPhams)
                {
                    if (index.isDeleted == 0 && index.MaLoaiSanPham == maloaisp) // tìm thấy loại
                    {
                        items.Add(index);
                    }
                }
            }

            if (check == "11") // Tìm theo tên và loại
            {
                var chiso = checkstring.LastIndexOf('+');
                var type_text = checkstring.Substring(chiso + 1, checkstring.Count() - 1 - chiso);
                var name_text = checkstring.Substring(3, checkstring.Count() - 1 - 3 - type_text.Count());

                var maloaisp = "";
                foreach (var index in db.LoaiSanPhams)
                {
                    if (index.TenLoaiSanPham.ToLower() == type_text.ToLower())
                    {
                        maloaisp = index.MaLoaiSanPham;
                    }
                }

                foreach (var index in db.SanPhams)
                {
                    if (index.isDeleted == 0 && index.TenSanPham.ToLower() == name_text.ToLower() && index.MaLoaiSanPham==maloaisp) // tìm thấy tên và mã loại
                    {
                        items.Add(index);
                    }
                }
            }

            return items;
        }

        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var items = getItem();
            itemListView.ItemsSource = items;

            if (items.Count() == 0)
            {
                var img = MessageBoxImage.Information;
                var btn = MessageBoxButton.OK;
                var msg = "Không có sản phẩm cần tìm!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                this.Close();
            }
        }

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
    }
}
