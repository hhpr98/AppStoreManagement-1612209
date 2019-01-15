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
    /// Interaction logic for ThongKeMaster_TheoKhoangThoiGian.xaml
    /// </summary>
    public partial class ThongKeMaster_TheoKhoangThoiGian : Window
    {
        public ThongKeMaster_TheoKhoangThoiGian()
        {
            InitializeComponent();
        }

        class SanPhamItem
        {
            public string TenSanPham { get; set; }
            public int SoLuong { get; set; }
        }

        public string getDateString(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf(' ');
            var dateformat = date.Substring(0, index);
            return dateformat;
        }

        public int getYear(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf(' ');
            var year = date.Substring(index - 4, 4);
            return int.Parse(year);
        }

        public int getMonth(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf('/');
            var month = date.Substring(0, index);
            return int.Parse(month);
        }

        public int getDate(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf('/'); //1
            var index2 = date.LastIndexOf('/'); // 4
            var day = date.Substring(index + 1, index2 - index - 1);
            return int.Parse(day);
        }

        //public bool NamGiua(string from,string to,string day) // date1>=date2
        //{
        //    var d1 = getDate(from);
        //    var d2 = getDate(to);
        //    var m1 = getMonth(from);
        //    var m2 = getMonth(to);
        //    var y1 = getYear(from);
        //    var y2 = getYear(to);
        //    var d = getDate(day);
        //    var m = getMonth(day);
        //    var y = getYear(day);

        //    if (y<y1 || y>y2) // y1<=y2, y không nằm trong khoảng này
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        if (y1==y2) // cùng năm
        //        {
        //            if (m<m1 || m>m2)
        //            {
        //                return false;
        //            }
        //            else
        //            {
        //                if (m1==m2) // cùng tháng
        //                {
        //                }
        //                else
        //                {
        //                }
        //            }
        //        }
        //        else // khác năm, tức y1<y2
        //        {
        //        }
        //    }
        //    return true;
        //}


        

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {

            if (picker1.Text == "" || picker2.Text=="")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Lỗi : Vui lòng chọn ngày hợp lệ!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                System.Collections.ArrayList data = new System.Collections.ArrayList();
                chart.ItemsSource = data;
            }
            else
            {
                var b = DateTime.Compare(DateTime.Parse(picker1.Text), DateTime.Parse(picker2.Text));
                if (b>0)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Lỗi : Thời gian trước không được lớn hơn thời gian sau!";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                    System.Collections.ArrayList data1 = new System.Collections.ArrayList();
                    chart.ItemsSource = data1;
                    return;
                }

                var db = new StoreManagementEntities();

                // Lấy những hóa đơn có ngày cần tra
                List<string> list_mahd = new List<string>();

                foreach (var index in db.HoaDons)
                {
                    var date = (DateTime)index.NgayXuatHoaDon;
                    var ss1 = DateTime.Compare(date, DateTime.Parse(picker1.Text)); // ss1>=0 => ngày lớn hơn from
                    var ss2 = DateTime.Compare(DateTime.Parse(picker2.Text), date ); // ss2>=0 => to lớn hơn ngày

                    if (ss1>=0 && ss2>=0)
                    {
                        list_mahd.Add(index.MaHoaDon);
                    }
                }

                if (list_mahd.Count() == 0) // không có hóa đơn nào trong ngày này
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Information;
                    var msg = "Khoảng thời gian bạn chọn không có sản phẩm nào được bán!";
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
