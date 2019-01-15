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
    /// Interaction logic for ThongKe.xaml
    /// </summary>
    public partial class ThongKe : Window
    {
        public ThongKe()
        {
            InitializeComponent();
        }

        private void CbMaster_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = cbMaster.SelectedIndex;
            if (sel == 0)
            {
                var windows = new ThongKeMaster_TheoNgay();
            }

            if (sel == 1)
            {

            }

            if (sel == 2)
            {

            }

            if (sel == 3)
            {

            }

            cbMaster.SelectedIndex = -1;
        }

        private void CbMoney_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sel = cbMoney.SelectedIndex;
            if (sel == 0)
            {

            }

            if (sel == 1)
            {

            }

            if (sel == 2)
            {

            }

            if (sel == 3)
            {

            }

            cbMoney.SelectedIndex = -1;
        }

        
    }
}
