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
    /// Interaction logic for TimKiem.xaml
    /// </summary>
    public partial class TimKiem : Window
    {
        public TimKiem()
        {
            InitializeComponent();
        }

        public string check = "00";

        private void cbName_Checked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(0, 1);
            check = check.Insert(0, "1");
            //MessageBox.Show("Box Name checked");
            //MessageBox.Show(check);
        }

        private void cbType_Checked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(1, 1);
            check = check.Insert(1, "1");
            //MessageBox.Show("Box Type checked");
            //MessageBox.Show(check);
        }

        private void cbName_Unchecked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(0, 1);
            check = check.Insert(0, "0");
            //MessageBox.Show("Box Name unchecked");
            //MessageBox.Show(check);
        }

        private void cbType_Unchecked(object sender, RoutedEventArgs e)
        {
            check = check.Remove(1, 1);
            check = check.Insert(1, "0");
            //MessageBox.Show("Box Type unchecked");
            //MessageBox.Show(check);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (check == "00") // Không tick vào checkbox nào cả
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng chọn ít nhất 1 thuộc tính tìm kiếm!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                if (check == "10")
                {
                    check = check.Insert(2, "+");
                    check = check.Insert(3, txtName.Text);
                }

                if (check == "01")
                {
                    check = check.Insert(2, "+");
                    check = check.Insert(3, txtType.Text);
                }

                if (check == "11")
                {
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtName.Text);
                    check = check.Insert(check.Count(), "+");
                    check = check.Insert(check.Count(), txtType.Text);
                }

                var windows = new Result();
                windows.Sender(check);
                windows.Show();
                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TxtName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check[0] == '0')
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng tick vào ô bên cạnh trước khi gõ vào đây!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                txtName.Text = "";
            }
        }

        private void TxtType_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check[1] == '0')
            {
                var img = MessageBoxImage.Error;
                var btn = MessageBoxButton.OK;
                var msg = "Vui lòng tick vào ô bên cạnh trước khi gõ vào đây!";
                MessageBox.Show(msg, "Thông báo", btn, img);
            }
            else
            {
                txtType.Text = "";
            }
        }

        List<string> type = new List<string>();

        private void ItemCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (check[1]=='0') // check type checkbox
            //{
            //    check = check.Remove(1, 1);
            //    check = check.Insert(1, "1");
            //}
            var sel = itemCombo.SelectedIndex;
            txtType.Text = type[sel];
        }

        private void ItemCombo_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new StoreManagementEntities();

            var item = db.LoaiSanPhams.ToList();
            
            foreach (var index in item)
            {
                type.Add(index.TenLoaiSanPham);
            }
            itemCombo.ItemsSource = type;
        }
    }
}
