﻿using System;
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
            List<Device_Information> device_Information = new List<Device_Information>();
            //get common rail injector device information
            device_Information = OilP.Service.Device_Information_Service.getDataByType("cri");
            device_information_datagrid.ItemsSource = device_Information;

            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("cri");
            //init names
            setEleName(item_Names);
        }

        /**
         * exit the system
         * */
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
             Application.Current.Shutdown();
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
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
            delete.FontFamily = new FontFamily(font); 
            confirm.FontFamily = new FontFamily(font);
        }

        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            //获取datagrid选中行，并获取其model_no
            Device_Information device_Information = new Device_Information();
            device_Information = (Device_Information) device_information_datagrid.SelectedItem;
            String model_no = device_Information.Model_no;
            //页面跳转，传递model_no参数
            Common_Rail_Injector_Test Common_Rail_Injector_Test_page = new Common_Rail_Injector_Test(model_no);
            this.NavigationService.Navigate(Common_Rail_Injector_Test_page);
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector_Test.xaml", UriKind.Relative));
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            //获取listbox中选择的项
            try
            {
                String manu = ((ListBoxItem)manufacturer_list.SelectedItem).Content.ToString();
                String no = model_no.Text;
                device_Information = OilP.Service.Device_Information_Service.getDataByParams(no,manu);
                device_information_datagrid.ItemsSource = device_Information;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
