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
    /// Interaction logic for ThongKeDoanhThu_TheoNam.xaml
    /// </summary>
    public partial class ThongKeDoanhThu_TheoNam : Window
    {
        public ThongKeDoanhThu_TheoNam()
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

        private void BtnStatis_Click(object sender, RoutedEventArgs e)
        {

            if (txtYear.Text == "")
            {
                var btn = MessageBoxButton.OK;
                var img = MessageBoxImage.Error;
                var msg = "Lỗi : Vui lòng chọn năm hợp lệ!";
                MessageBox.Show(msg, "Thông báo", btn, img);
                System.Collections.ArrayList data = new System.Collections.ArrayList();
                chart.ItemsSource = data;
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
                    if (getYear(date) == txtYear.Text) // cùng năm
                    {
                        items[0].DoanhThu += (int)index.TongTien;
                    }
                }

                foreach (var index in db.PhieuNhaps)
                {
                    var date = index.NgayNhap.ToString();
                    if (getYear(date) == txtYear.Text) // cùng năm
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
            }
        }
    }
}
