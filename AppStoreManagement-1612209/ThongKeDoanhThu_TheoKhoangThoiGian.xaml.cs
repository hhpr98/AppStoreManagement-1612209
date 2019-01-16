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
    /// Interaction logic for ThongKeDoanhThu_TheoKhoangThoiGian.xaml
    /// </summary>
    public partial class ThongKeDoanhThu_TheoKhoangThoiGian : Window
    {
        public ThongKeDoanhThu_TheoKhoangThoiGian()
        {
            InitializeComponent();
        }

        class LoaiItem
        {
            public string Loai { get; set; }
            public int DoanhThu { get; set; }
        }

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {

            if (picker1.Text == "" || picker2.Text == "")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Lỗi : Vui lòng chọn thời điểm hợp lệ!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                System.Collections.ArrayList data = new System.Collections.ArrayList();
                chart.ItemsSource = data;
                lbl1.Content = "0 VNĐ";
                lbl2.Content = "0 VNĐ";
                lbl3.Content = "HÒA VỐN";
            }
            else
            {

                var b = DateTime.Compare(DateTime.Parse(picker1.Text), DateTime.Parse(picker2.Text));
                if (b > 0)
                {
                    var btn = MessageBoxButton.OK;
                    var img = MessageBoxImage.Error;
                    var msg = "Lỗi : Thời gian trước không được lớn hơn thời gian sau!";
                    MessageBox.Show(msg, "Thông báo", btn, img);
                    System.Collections.ArrayList data1 = new System.Collections.ArrayList();
                    chart.ItemsSource = data1;
                    lbl1.Content = "0 VNĐ";
                    lbl2.Content = "0 VNĐ";
                    lbl3.Content = "HÒA VỐN";
                    return;
                }

                var db = new StoreManagementEntities();

                // Lấy những hóa đơn có tháng cần tra
                List<LoaiItem> items = new List<LoaiItem>()
                {
                     new LoaiItem() { Loai="Thu",DoanhThu=0},
                    new LoaiItem() { Loai="Chi",DoanhThu=0}
                };

                foreach (var index in db.HoaDons)
                {
                    var date = (DateTime)index.NgayXuatHoaDon;
                    var ss1 = DateTime.Compare(date, DateTime.Parse(picker1.Text)); // ss1>=0 => ngày lớn hơn from
                    var ss2 = DateTime.Compare(DateTime.Parse(picker2.Text), date); // ss2>=0 => to lớn hơn ngày

                    if (ss1 >= 0 && ss2 >= 0)
                    {
                        items[0].DoanhThu += (int)index.TongTien;
                    }
                }

                foreach (var index in db.PhieuNhaps)
                {
                    var date = (DateTime)index.NgayNhap;
                    var ss1 = DateTime.Compare(date, DateTime.Parse(picker1.Text)); // ss1>=0 => ngày lớn hơn from
                    var ss2 = DateTime.Compare(DateTime.Parse(picker2.Text), date); // ss2>=0 => to lớn hơn ngày

                    if (ss1 >= 0 && ss2 >= 0)
                    {
                        items[1].DoanhThu += (int)index.TongTien;
                    }
                }


                // Trả về mảng
                System.Collections.ArrayList data = new System.Collections.ArrayList();

                foreach (var index in items)
                {
                    data.Add(index);
                }

                chart.ItemsSource = data;

                lbl1.Content = items[0].DoanhThu + " VNĐ";
                lbl2.Content = items[1].DoanhThu + " VNĐ";
                if (items[0].DoanhThu > items[1].DoanhThu)
                {
                    lbl3.Content = "LỜI";
                }
                else if (items[0].DoanhThu < items[1].DoanhThu)
                {
                    lbl3.Content = "LỖ";
                }
                else
                {
                    lbl3.Content = "HÒA VỐN";
                }
            }
        }
    }
}
