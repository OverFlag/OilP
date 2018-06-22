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

namespace OilP.Pages
{
    /// <summary>
    /// Common_Rail_Injector.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Injector : Page
    {
        public Common_Rail_Injector()
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
            //填充查询结果datagrid
            dEV_I_Models = OilP.Service.Device_Information_Service.getDataByType("cri");
            device_information_datagrid.ItemsSource = dEV_I_Models;

            //填充itemname
            List<LAN_Model> lAN_Models = new List<LAN_Model>();
            lAN_Models = OilP.Service.LAN_Service.Init_Item_Name("cri");
            //init names
            setEleName(lAN_Models);
            //填充历史记录datagrid
            List<HIS_Model> hIS_Models = new List<HIS_Model>();
            hIS_Models = Dao.DEV_DAO.QueryHistoryByType("cri");
            history_datagrid.ItemsSource = hIS_Models;
        }

        /**
         * exit the system
         * */
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            //关闭窗口数量减1
            (Application.Current as App).WindowCount--;
             Application.Current.Shutdown();
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
        }

        /**
        * set the names of elements
        * */
        private void setEleName(List<LAN_Model> item_Names)
        {
            model_no_name.Text = item_Names[0].Item_name;
            
            search.Content = item_Names[1].Item_name;
            exit_system.Content = item_Names[2].Item_name;
            add.Content = item_Names[3].Item_name;
            edit.Content = item_Names[4].Item_name;
            set.Content = item_Names[5].Item_name;
            confirm.Content = item_Names[6].Item_name;
            //change the datagrid header language
            Regex regChina = new Regex("^[^\x00-\xFF]");
            Regex regEnglish = new Regex("^[a-zA-Z]");
            if (regEnglish.IsMatch(item_Names[1].Item_name))
            {
                //set font family
                setFontFamily("Yu Gothic UI Semibold");
                // i don't know how to rewrite the header of wpf datagrid
                //do nothing
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
            set.FontFamily = new FontFamily(font); 
            confirm.FontFamily = new FontFamily(font);
        }

        //private void confirm_Click(object sender, RoutedEventArgs e)
        //{
        //    //获取datagrid选中行，并获取其model_no
        //    Device_Information device_Information = new Device_Information();
        //    device_Information = (Device_Information) device_information_datagrid.SelectedItem;
        //    String model_no = device_Information.Model_no;
        //    //页面跳转，传递model_no参数
        //    Common_Rail_Injector_Test Common_Rail_Injector_Test_page = new Common_Rail_Injector_Test(model_no);
        //    this.NavigationService.Navigate(Common_Rail_Injector_Test_page);
        //    //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector_Test.xaml", UriKind.Relative));
        //}

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            //获取datagrid选中行，并获取其model_no
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            dEV_I_Model = (DEV_I_Model)device_information_datagrid.SelectedItem;
            String model_no = dEV_I_Model.Model_no;

            //往history添加记录
            HIS_Model hIS_Model = new HIS_Model();
            hIS_Model.Model_no = model_no;
            Dao.DEV_DAO.WriteToHistory("cri", hIS_Model);

            //页面跳转，传递model_no参数
            Common_Rail_Injector_Test Common_Rail_Injector_Test_page = new Common_Rail_Injector_Test(model_no);
            this.NavigationService.Navigate(Common_Rail_Injector_Test_page);
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector_Test.xaml", UriKind.Relative));
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            //获取listbox中选择的项
            try
            {
                String manu = ((ListBoxItem)manufacturer_list.SelectedItem).Content.ToString();
                String no = model_no.Text;
                if ("".Equals(no)||no==null)
                {
                    dEV_I_Models = OilP.Service.Device_Information_Service.getDataByManu(manu,"cri");
                }
                else
                {
                    dEV_I_Models = OilP.Service.Device_Information_Service.getDataByModelNo(no, "cri");
                }
              
                device_information_datagrid.ItemsSource = dEV_I_Models;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //获取datagrid选中行，并获取其model_no
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            dEV_I_Model = (DEV_I_Model)device_information_datagrid.SelectedItem;
            String model_no = dEV_I_Model.Model_no;

            //往history添加记录
            HIS_Model hIS_Model = new HIS_Model();
            hIS_Model.Model_no = model_no;
            Dao.DEV_DAO.WriteToHistory("cri", hIS_Model);

            //页面跳转，传递model_no参数
            Common_Rail_Injector_Edit common_Rail_Injector_Edit_page = new Common_Rail_Injector_Edit(model_no);
            this.NavigationService.Navigate(common_Rail_Injector_Edit_page);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            //页面跳转，传递model_no参数
            Common_Rail_Inejector_Add common_Rail_Injector_Add_Page= new Common_Rail_Inejector_Add();
            this.NavigationService.Navigate(common_Rail_Injector_Add_Page);
        }

        public List<Setting_Model> GetData()
        {
            List<Setting_Model> data = new List<Setting_Model>();
            Setting_Model temp_data = new Setting_Model();
            /*系统状态2-1*/
            /*下位机返回*/
            temp_data.Name = "sys_status";
            temp_data.Value = null;
            data.Add(temp_data);

            return data;
        }

        /**
         * 关闭窗口调用的方法
         **/
        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            /*close page     -1s*/
            (Application.Current as App).WindowCount--;
        }

        private void set_Click(object sender, RoutedEventArgs e)
        {
            //页面跳转
            Common_Rail_Injector_Setting common_Rail_Injector_Setting_Page = new Common_Rail_Injector_Setting();
            this.NavigationService.Navigate(common_Rail_Injector_Setting_Page);
        }
    }
}
