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

namespace OilP.Pages
{
    /// <summary>
    /// HPO_Pump_Injector.xaml 的交互逻辑
    /// </summary>
    public partial class HPO_Pump_Injector : Page
    {
        public HPO_Pump_Injector()
        {
            InitializeComponent();
            Initialize_Page();
        }

        /**
        * set the item name and datagrid
        **/
        public void Initialize_Page()
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            //get hpo pump device information
            device_Information = OilP.Service.Device_Information_Service.getDataByType("hpo");
            device_information_datagrid.ItemsSource = device_Information;

            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("hpo");
            //init names
            setEleName(item_Names);
        }

        /**
       * set the names of elements
       * */
        private void setEleName(List<Item_Name> item_Names)
        {
            model_no_name.Text = item_Names[0].Item_name;

            search.Content = item_Names[1].Item_name;
            exit_system.Content = item_Names[2].Item_name;
            add.Content = item_Names[3].Item_name;
            edit.Content = item_Names[4].Item_name;
            delete.Content = item_Names[5].Item_name;
            confirm.Content = item_Names[6].Item_name;
            //change the font family for en_US
            if ("en_US".Equals(item_Names[0].Language))
            {
                //set font family
                setFontFamily("Yu Gothic UI Semibold");
            }
        }

        /**
         * set font family for en_US
         **/
        private void setFontFamily(string font)
        {
            model_no_name.FontFamily = new FontFamily(font);
            search.FontFamily = new FontFamily(font);
            exit_system.FontFamily = new FontFamily(font);
            add.FontFamily = new FontFamily(font);
            edit.FontFamily = new FontFamily(font);
            delete.FontFamily = new FontFamily(font);
            confirm.FontFamily = new FontFamily(font);
        }

        /**
           * exit the system
        **/
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
        }
    }
}

    

