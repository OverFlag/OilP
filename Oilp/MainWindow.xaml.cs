using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("index");
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
            system_set.Content = item_Names[17].Item_name;
            //change the font family for en_US
            if ("en_US".Equals(item_Names[0].Language))
            {
                //set font family
                setFontFamily("Yu Gothic UI Semibold");
            }
        }

        private void setFontFamily(string font)
        {
            common_rail_injector.FontFamily = new FontFamily(font);
            common_rail_pump.FontFamily = new FontFamily(font);
            hpo_pump.FontFamily = new FontFamily(font);
            eup_eui.FontFamily = new FontFamily(font);
            heui.FontFamily = new FontFamily(font);
            heui_pump.FontFamily = new FontFamily(font);
            cat_pump.FontFamily = new FontFamily(font);
            electronically_controlled_combination_pump.FontFamily = new FontFamily(font);
            vp37.FontFamily = new FontFamily(font);
            vp44.FontFamily = new FontFamily(font);
            tics_pump.FontFamily = new FontFamily(font);
            first_to_control_the_pump.FontFamily = new FontFamily(font);
            mechanical_ve_pump.FontFamily = new FontFamily(font);
            measuring_unit_zme.FontFamily = new FontFamily(font);
            armature_stroke_ahe.FontFamily = new FontFamily(font);
            electronic_control_common_rail_system_test_software.FontFamily = new FontFamily(font);
            system_set.FontFamily = new FontFamily(font);
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
            window.Height = 1100;
            window.Width = 1500;
            window.Show();
        }

        private void common_rail_pump_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void hpo_pump_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Pages/HPO_Pump_Injector.xaml", UriKind.Relative);
            window.Height = 1000;
            window.Width = 1400;
            window.Show();
        }

        private void system_set_Click(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();
            window.Source = new Uri("Pages/Common_Rail_Injector_Edit.xaml", UriKind.Relative);
            //window.Source = new Uri("Pages/System_Config.xaml", UriKind.Relative);
            window.Height =500;
            window.Width =700;
            window.Show();
        }
    }
}
    
   
