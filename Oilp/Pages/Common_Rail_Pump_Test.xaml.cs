﻿
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
    /// Common_Rail_Pump_Test.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Pump_Test : Page
    {

        public Common_Rail_Pump_Test()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            /*close page     -1s*/
            (Application.Current as App).WindowCount--;
        }
    }
}

