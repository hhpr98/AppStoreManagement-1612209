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
    /// Interaction logic for ThongKeDoanhThu_TheoThang.xaml
    /// </summary>
    public partial class ThongKeDoanhThu_TheoThang : Window
    {
        public ThongKeDoanhThu_TheoThang()
        {
            InitializeComponent();
        }

        class LoaiItem
        {
            public string Loai { get; set; }
            public int DoanhThu { get; set; }
        }

        public string getYear(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf(' ');
            var year = date.Substring(index - 4, 4);
            return year;
        }

        public string getMonth(string date) // 1/13/2018 12:00:00 AM
        {
            var index = date.IndexOf('/');
            var month = date.Substring(0, index);
            return month;
        }

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {

            if (txtMonth.Text == "" || txtYear.Text == "" || int.Parse(txtMonth.Text) < 1 || int.Parse(txtMonth.Text) > 12)
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Lỗi : Vui lòng chọn tháng, năm hợp lệ!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                System.Collections.ArrayList data = new System.Collections.ArrayList();
                chart.ItemsSource = data;
                lbl1.Content = "0 VNĐ";
                lbl2.Content = "0 VNĐ";
                lbl3.Content = "HÒA VỐN";
            }
            else
            {
                var db = new StoreManagementEntities();

                // Lấy những hóa đơn có tháng cần tra
                List<LoaiItem> items = new List<LoaiItem>()
                {
                     new LoaiItem() { Loai="Thu",DoanhThu=0},
                    new LoaiItem() { Loai="Chi",DoanhThu=0}
                };

                foreach (var index in db.HoaDons)
                {
                    var date = index.NgayXuatHoaDon.ToString();
                    if (getMonth(date) == txtMonth.Text && getYear(date) == txtYear.Text) // cùng tháng cùng năm
                    {
                        items[0].DoanhThu += (int)index.TongTien;
                    }
                }

                foreach (var index in db.PhieuNhaps)
                {
                    var date = index.NgayNhap.ToString();
                    if (getMonth(date) == txtMonth.Text && getYear(date) == txtYear.Text) // cùng tháng cùng năm
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
