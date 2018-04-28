using OilP.Model;
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
    /// System_Config.xaml 的交互逻辑
    /// </summary>
    public partial class System_Config : Page
    {
        public System_Config()
        {
            InitializeComponent();
            Initialize_Page();
        }

        /**
         * initizlize the data when open the config page
         **/
        public void Initialize_Page()
        {
            //get data from 

            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("con");
            //init names
            setEleName(item_Names);
        }

        /**
         * submit the config
         * */
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            OilP_Config oilP_Config = new OilP_Config();
            string language = language_combobox.Text;
            if ("Chinese".Equals(language)||"简体中文".Equals(language))
            {
                oilP_Config.Language = "zh_CN";
            }
            else
            {
                oilP_Config.Language = "en_US";
            }
            oilP_Config.Config_no = 1;
            OilP.Service.Oilp_Config_Service.updateConfig(oilP_Config);
            Window win = (Window)this.Parent;
            win.Close();
            
        }

        /**
         * close the page
         * */
        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        /**
      * set the names of elements
      * */
        private void setEleName(List<Item_Name> item_Names)
        {
            language.Text = item_Names[0].Item_name;
            confirm.Content = item_Names[1].Item_name;
            cancel.Content = item_Names[2].Item_name;
         
            //change the font family for en_US
            if ("en_US".Equals(item_Names[0].Language))
            {
                //set ComboBoxItem
                en_US.Content = "English";
                zh_CN.Content = "Chinese";
                //set font family
                setFontFamily("Yu Gothic UI Semibold");
            }
        }

        /**
        * set font family for en_US
        **/
        private void setFontFamily(string font)
        {
            language.FontFamily = new FontFamily(font);
            confirm.FontFamily = new FontFamily(font);
            cancel.FontFamily = new FontFamily(font);
        }
    }
}
