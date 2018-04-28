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
        public Common_Rail_Injector_Test()
        {
            InitializeComponent();
            Initialize_Page();
        }

        /**
        * set the item name and datagrid
        **/
        public void Initialize_Page()
        {
            //get name list
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Service.Item_Name_Service.Init_Item_Name("cri");
            //init names
            //setelename(item_names);
        }
    }
}
