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
    /// Interaction logic for ThongKeMaster_TheoThang.xaml
    /// </summary>
    public partial class ThongKeMaster_TheoThang : Window
    {
        public ThongKeMaster_TheoThang()
        {
            InitializeComponent();
        }

        class SanPhamItem
        {
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
        }

        public string getYear(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf(' ');
            var year = date.Substring(index-4,4);
            return year;
        }

        public string getMonth(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf('/');
            var month = date.Substring(0,index);
            return month;
        }

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {

            if (txtMonth.Text == "" || txtYear.Text=="" || int.Parse(txtMonth.Text)<1 || int.Parse(txtMonth.Text) > 12)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Lỗi : Vui lòng chọn tháng, năm hợp lệ!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                System.Collections.ArrayList data = new System.Collections.ArrayList();
                chart.ItemsSource = data;
            }
            else
            {
                var db = new StoreManagementEntities();

                // Lấy những hóa đơn có tháng cần tra
                List<string> list_mahd = new List<string>();

                foreach (var index in db.HoaDons)
                {
                    var date = index.NgayXuatHoaDon.ToString();
                    if (getMonth(date) == txtMonth.Text && getYear(date)==txtYear.Text) // cùng tháng cùng năm
                    {
                        list_mahd.Add(index.MaHoaDon);
                    }
                }

                if (list_mahd.Count() == 0) // không có hóa đơn nào trong tháng này
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Information;
                    var msg = "Tháng bạn chọn không có sản phẩm nào được bán!";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                    System.Collections.ArrayList data1 = new System.Collections.ArrayList();
                    chart.ItemsSource = data1;
                    return;
                }

                // Lấy những chi tiết hóa đơn có mã hóa đơn ở trên
                List<ChiTietHoaDon> list_chitiethd = new List<ChiTietHoaDon>();
                foreach (var index in db.ChiTietHoaDons)
                {
                    if (list_mahd.Contains(index.MaHoaDon))
                    {
                        list_chitiethd.Add(index);
                    }
                }

                // Lưu vào từ điển, đếm số lượng
                var dic = new Dictionary<string, int>();

                foreach (var index in list_chitiethd)
                {
                    if (dic.ContainsKey(index.MaSanPham))  // đã tồn tại chuỗi này rồi
                    {
                        dic[index.MaSanPham] += (int)index.SoLuong; // tăng value của chuỗi này lên số lượng
                    }
                    else
                    {
                        dic[index.MaSanPham] = (int)index.SoLuong; // gán = x (ghi nhận chuỗi xuất hiện x lần)
                    }
                }

                // Trả về mảng
                System.Collections.ArrayList data = new System.Collections.ArrayList();

                foreach (var index in dic)
                {
                    var sp = db.SanPhams.Find(index.Key);
                    var item = new SanPhamItem() { TenSanPham = sp.TenSanPham, SoLuong = index.Value };

                    data.Add(item);
                }

                chart.ItemsSource = data;
            }
        }
    }
}
