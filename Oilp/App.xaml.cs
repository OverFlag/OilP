using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace OilP
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        /*用于确定当前有几个page页面开启，用于page页面的开启数量*/
        public  int WindowCount { set; get; }

    }
}
