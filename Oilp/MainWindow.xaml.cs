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
using OilP.Model;

/**
 * author:Slytherin
 * date:2018.04.19
 * Main Window
 **/

namespace OilP
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Initialize_Item_Name();
           
        }

        /**
         * Initialize Item Name(zn_CN or en_US)
         **/
        public void Initialize_Item_Name()
        {
            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name();
            //init names
            setEleName(item_Names);

        }
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }


        /**
         * set the names of elements
         * */
        private void setEleName(List<Item_Name> item_Names)
        {
            common_rail_injector.Content = item_Names[0].Item_name;
            common_rail_pump.Content = item_Names[1].Item_name;
            hpo_pump.Content = item_Names[2].Item_name;
            eup_eui.Content = item_Names[3].Item_name;
            heui.Content = item_Names[4].Item_name;
            heui_pump.Content = item_Names[5].Item_name;
            cat_pump.Content = item_Names[6].Item_name;
            electronically_controlled_combination_pump.Content = item_Names[7].Item_name;
            vp37.Content = item_Names[8].Item_name;
            vp44.Content = item_Names[9].Item_name;
            tics_pump.Content = item_Names[10].Item_name;
            first_to_control_the_pump.Content = item_Names[11].Item_name;
            mechanical_ve_pump.Content = item_Names[12].Item_name;
            mechanical_pump.Content = item_Names[13].Item_name;
            measuring_unit_zme.Content = item_Names[14].Item_name;
            armature_stroke_ahe.Content = item_Names[15].Item_name;
            electronic_control_common_rail_system_test_software.Content = item_Names[16].Item_name;
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new Pages.Common_Rail_Injector();
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector.xaml", UriKind.Relative));
        }

        private void common_rail_injector_Click(object sender, RoutedEventArgs e)
        {
            //this.Content = new Pages.Common_Rail_Injector();

            //可以实现
            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Pages/Common_Rail_Injector.xaml", UriKind.Relative);
            window.Height = 1000;
            window.Width = 1400;
            window.Show();


        }
    }
}
    
   
