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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OilP.Pages
{
    /// <summary>
    /// HPO_Pump_Injector_Edit_.xaml 的交互逻辑
    /// </summary>
    public partial class HPO_Pump_Injector_Edit_ : Page
    {
        public static string MODEL_NO;
        public bool EDIT_FLAG = false;
        public bool TEXT_BG_FLAG = false;
        public HPO_Pump_Injector_Edit_(string model_no)
        {
            //构造函数传入model_no
            InitializeComponent();
            MODEL_NO = model_no;
            Init_step_ListBox(model_no);
        }

        private void step_add_Click(object sender, RoutedEventArgs e)
        {

        }

        private void step_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void step_change_Click(object sender, RoutedEventArgs e)
        {

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void step_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
