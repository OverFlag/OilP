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
    /// Common_Rail_Injector.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Injector : Page
    {
        public Common_Rail_Injector()
        {
            InitializeComponent();
        }

        /**
         * exit the system
         * */
        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
             Application.Current.Shutdown();
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Page1.xaml", UriKind.Relative));
        }
    }
}
