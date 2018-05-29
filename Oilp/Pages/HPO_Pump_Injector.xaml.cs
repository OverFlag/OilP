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
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            //get hpo pump device information
            dEV_I_Models = OilP.Service.Device_Information_Service.getDataByType("hpo");
            device_information_datagrid.ItemsSource = dEV_I_Models;

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

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //获取datagrid选中行，并获取其model_no
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            dEV_I_Model = (DEV_I_Model)device_information_datagrid.SelectedItem;
            String model_no = dEV_I_Model.Model_no;
            //页面跳转，传递model_no参数
            HPO_Pump_Injector_Edit_ hPO_Pump_Injector_Edit_Page = new HPO_Pump_Injector_Edit_(model_no);
            this.NavigationService.Navigate(hPO_Pump_Injector_Edit_Page);
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            //获取listbox中选择的项
            try
            {
                String manu = ((ListBoxItem)manufacturer_list.SelectedItem).Content.ToString();
                String no = model_no.Text;
                if ("".Equals(no) || no == null)
                {
                    dEV_I_Models = OilP.Service.Device_Information_Service.getDataByManu(manu, "hpo");
                }
                else
                {
                    dEV_I_Models = OilP.Service.Device_Information_Service.getDataByModelNo(no, "hpo");
                }

                device_information_datagrid.ItemsSource = dEV_I_Models;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            //获取datagrid选中行，并获取其model_no
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            dEV_I_Model = (DEV_I_Model)device_information_datagrid.SelectedItem;
            String model_no = dEV_I_Model.Model_no;
            //页面跳转，传递model_no参数
            HdasfasPO_Pump_Injector_test_ Common_Rail_Injector_Test_page = new Common_Rail_Injector_Test(model_no);
            this.NavigationService.Navigate(Common_Rail_Injector_Test_page);
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector_Test.xaml", UriKind.Relative));
        }
    }
}

    

