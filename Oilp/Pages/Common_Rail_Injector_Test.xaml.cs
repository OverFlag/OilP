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
    /// Common_Rail_Injector_Test.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Injector_Test : Page
    {
        public Common_Rail_Injector_Test(string model_no)
        {
            InitializeComponent();
            Initialize_Page(model_no);
           
        }

        /**
        * set the item name and datagrid
        **/
        public void Initialize_Page(string model_no)
        {
            string no = model_no;
            //根据model_no读取数据库测试表的数据

            //the way to change the pic of button
            btn_step_1.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,../Resources/exit.png"))
            };

            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("cri");
            //init names
            //setelename(item_names);
        }


       
    }
}
