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
    /// Common_Rail_Injector_Edit.xaml 的交互逻辑
    /// </summary>
   
    public partial class Common_Rail_Injector_Edit : Page
    {
        public static string MODEL_NO;
        public bool EDIT_FLAG = false;
        public bool TEXT_BG_FLAG = false;

        public Common_Rail_Injector_Edit(string model_no)
        {
            //构造函数传入model_no
            InitializeComponent();
            MODEL_NO = model_no;
            Init_step_ListBox(model_no);
            
        }
        /**
         * 根据model_no获取ListBox的填入项
         * */
        public void Init_step_ListBox(string model_no)
        {
            List<OilP.Model.Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Model.Common_Rail_Injector_Test>();
            common_Rail_Injector_Tests = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNo(model_no);
            for (int i = 0; i < common_Rail_Injector_Tests.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = common_Rail_Injector_Tests[i].Step_name;
                item.FontSize = 40;
                item.FontFamily = new FontFamily("Yu Gothic UI Semibold");
                step_ListBox.Items.Add(item);
                //设置listbox的默认值
                //if (i==0)
                //{
                //    item.IsSelected = true;
                //}
            }
            
            //传入model_no和list仲的第一个step_name向页面填入数据库存在的数据
            setData(model_no, common_Rail_Injector_Tests[0].Step_name);
            model_no_TextBox.Text = model_no;
        }

        /**
          * 根据model_no和step_name查找详细数据
          * */
        public void setData(string model_no,string step_name)
        {
            Model.Common_Rail_Injector_Test common_Rail_Injector_Test = new Model.Common_Rail_Injector_Test();
            common_Rail_Injector_Test = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNoAndStepName(model_no, step_name);
            //在页面上填入step_name和model_no的数据
            step_name_TextBox.Text = step_name;
            fillData(common_Rail_Injector_Test);

        }
        /**
         * 将Common_Rail_Injector_Test数据初始化到界面上
         * */
         public void fillData(Model.Common_Rail_Injector_Test common_Rail_Injector_Test)
        {
            
            last_time_TextBox.Text = common_Rail_Injector_Test.Duration.ToString();
            pressure_TextBox.Text = common_Rail_Injector_Test.Rail_pressure.ToString();
            oil_p_hor_TextBox.Text = common_Rail_Injector_Test.Fuel_p_hor.ToString();
            oil_p_ver_TextBox.Text = common_Rail_Injector_Test.Fuel_p_ver.ToString();
            oil_h_hor_TextBox.Text = common_Rail_Injector_Test.Fuel_h_hor.ToString();
            oil_h_ver_TextBox.Text = common_Rail_Injector_Test.Fuel_h_hor.ToString();
            test_time_TextBox.Text = common_Rail_Injector_Test.Test_time.ToString();
            if (null == common_Rail_Injector_Test.Curve|| common_Rail_Injector_Test.Curve.Length ==0)
            {
                curve_TextBox.Text = null;
            }
            else
            {
                curve_TextBox.Text = common_Rail_Injector_Test.Curve.ToString();
            }         
            magn_TextBox.Text = common_Rail_Injector_Test.Magnification.ToString();
            period_TextBox.Text = common_Rail_Injector_Test.Period.ToString();
            voltage_TextBox.Text = common_Rail_Injector_Test.Voltage.ToString();
            //读取数据后设置不可读
            setEditable(false);
        }

        /**
         * 将界面上的所有控件设置为不可使用,将三个按钮隐藏和显示
         * */
         public void setEditable(bool flag)
        {
            if (flag == true)
            {
                model_no_TextBox.IsReadOnly = false;
                step_name_TextBox.IsReadOnly = false;
                last_time_TextBox.IsReadOnly = false;
                pressure_TextBox.IsReadOnly = false;
                oil_p_hor_TextBox.IsReadOnly = false;
                oil_p_ver_TextBox.IsReadOnly = false;
                oil_h_hor_TextBox.IsReadOnly = false;
                oil_h_ver_TextBox.IsReadOnly = false;
                test_time_TextBox.IsReadOnly = false;
                curve_TextBox.IsReadOnly = false;
                magn_TextBox.IsReadOnly = false;
                period_TextBox.IsReadOnly = false;
                voltage_TextBox.IsReadOnly = false;
                //显示三个按钮
                step_add.Visibility = Visibility.Visible;
                step_delete.Visibility = Visibility.Visible;
                step_change.Visibility = Visibility.Visible;
                setTextBoxBG(true);
            }
            else
            {
                model_no_TextBox.IsReadOnly = true;
                step_name_TextBox.IsReadOnly = true;
                last_time_TextBox.IsReadOnly = true;
                pressure_TextBox.IsReadOnly = true;
                oil_p_hor_TextBox.IsReadOnly = true;
                oil_p_ver_TextBox.IsReadOnly = true;
                oil_h_hor_TextBox.IsReadOnly = true;
                oil_h_ver_TextBox.IsReadOnly = true;
                test_time_TextBox.IsReadOnly = true;
                curve_TextBox.IsReadOnly = true;
                magn_TextBox.IsReadOnly = true;
                period_TextBox.IsReadOnly = true;
                voltage_TextBox.IsReadOnly = true;
                //隐藏三个按钮
                step_add.Visibility = Visibility.Hidden;
                step_delete.Visibility = Visibility.Hidden;
                step_change.Visibility = Visibility.Hidden;
                setTextBoxBG(false);

            }      
        }
        /**
           * 设置textbox背景颜色，不可编辑状态下为灰色
           * */
        public void setTextBoxBG(bool flag)
        {
            if (flag == false)
            {
                model_no_TextBox.Background = Brushes.LightGray;
                step_name_TextBox.Background = Brushes.LightGray; 
                last_time_TextBox.Background = Brushes.LightGray;
                pressure_TextBox.Background = Brushes.LightGray; 
                oil_p_hor_TextBox.Background = Brushes.LightGray; 
                oil_p_ver_TextBox.Background = Brushes.LightGray; 
                oil_h_hor_TextBox.Background = Brushes.LightGray; 
                oil_h_ver_TextBox.Background = Brushes.LightGray; 
                test_time_TextBox.Background = Brushes.LightGray; 
                curve_TextBox.Background = Brushes.LightGray; 
                magn_TextBox.Background = Brushes.LightGray; 
                period_TextBox.Background = Brushes.LightGray; 
                voltage_TextBox.Background = Brushes.LightGray; 
            }
            else
            {
                model_no_TextBox.Background = Brushes.White;
                step_name_TextBox.Background = Brushes.White; 
                last_time_TextBox.Background = Brushes.White; 
                pressure_TextBox.Background = Brushes.White; 
                oil_p_hor_TextBox.Background = Brushes.White; 
                oil_p_ver_TextBox.Background = Brushes.White; 
                oil_h_hor_TextBox.Background = Brushes.White; 
                oil_h_ver_TextBox.Background = Brushes.White; 
                test_time_TextBox.Background = Brushes.White; 
                curve_TextBox.Background = Brushes.White; 
                magn_TextBox.Background = Brushes.White; 
                period_TextBox.Background = Brushes.White; 
                voltage_TextBox.Background = Brushes.White; 
            }
        }

        /**
         * 根据选择的测试步骤更新页面数据
         * */
        private void step_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (step_ListBox.Items.Count==0)
            {
                return;
            }
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            setData(MODEL_NO,step_name);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            
            //将textbox设置为可修改
            
            setEditable(true);
            setTextBoxBG(true);
            //将listbox的选中项默认为第一个

        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            string model_no = MODEL_NO;
            //页面跳转，传递model_no参数
            Common_Rail_Injector_Test Common_Rail_Injector_Test_page = new Common_Rail_Injector_Test(model_no);
            this.NavigationService.Navigate(Common_Rail_Injector_Test_page);
            //NavigationService.GetNavigationService(this).Navigate(new Uri("Pages/Common_Rail_Injector_Test.xaml", UriKind.Relative));
        }

        /**
         * 新增测试步骤
         * */
        private void step_add_Click(object sender, RoutedEventArgs e)
        {
            //获取当前页面上的数据
            Model.Common_Rail_Injector_Test common_Rail_Injector_Test = new Model.Common_Rail_Injector_Test();
            common_Rail_Injector_Test = Get_data_from_page();
            string message =  OilP.Service.Common_Rail_Injector_Test_Service.AddData(common_Rail_Injector_Test, MODEL_NO);
            MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (dr == MessageBoxResult.OK)
            {
                //重新加载ListBox
                step_ListBox.Items.Clear();
                Init_step_ListBox(MODEL_NO);
            }

        }

        /**
         * 获取页面上需要新增的测试步骤数据
         * */
        public Model.Common_Rail_Injector_Test Get_data_from_page()
        {
            Model.Common_Rail_Injector_Test common_Rail_Injector_Test = new Model.Common_Rail_Injector_Test();
            common_Rail_Injector_Test.Model_no = model_no_TextBox.Text.ToString();
            common_Rail_Injector_Test.Step_name = step_name_TextBox.Text.ToString();
            common_Rail_Injector_Test.Duration = double.Parse(last_time_TextBox.Text.ToString()) ;
            common_Rail_Injector_Test.Rail_pressure = double.Parse(pressure_TextBox.Text.ToString());
            common_Rail_Injector_Test.Fuel_p_hor = double.Parse(oil_p_hor_TextBox.Text.ToString());
            common_Rail_Injector_Test.Fuel_p_ver = double.Parse(oil_p_ver_TextBox.Text.ToString());
            common_Rail_Injector_Test.Fuel_h_hor = double.Parse(oil_h_hor_TextBox.Text.ToString());
            common_Rail_Injector_Test.Fuel_h_ver = double.Parse(oil_h_ver_TextBox.Text.ToString());
            common_Rail_Injector_Test.Test_time = int.Parse(test_time_TextBox.Text.ToString());
            common_Rail_Injector_Test.Curve = curve_TextBox.Text.ToString();
            common_Rail_Injector_Test.Magnification = double.Parse(magn_TextBox.Text.ToString());
            common_Rail_Injector_Test.Period = int.Parse(period_TextBox.Text.ToString());
            common_Rail_Injector_Test.Voltage = int.Parse(voltage_TextBox.Text.ToString());
            return common_Rail_Injector_Test;
        }

        /**
         * 删除选中listbox的一项
         * */
        private void step_delete_Click(object sender, RoutedEventArgs e)
        {
            //获取选择的listbox的step_name
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            //根据model_no和step_name删除
            bool flag = OilP.Service.Common_Rail_Injector_Test_Service.DeleteData(MODEL_NO, step_name);
            if (flag)
            {
                string message = "删除成功";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (dr == MessageBoxResult.OK)
                {
                    //重新加载ListBox
                    step_ListBox.Items.Clear();
                    Init_step_ListBox(MODEL_NO);
                }
            }
            else
            {
                string message = "删除失败";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (dr == MessageBoxResult.OK)
                {
                    //重新加载ListBox
                    step_ListBox.Items.Clear();
                    Init_step_ListBox(MODEL_NO);
                }
            }

        }

        /**
         * 更新选择的step_name的数据信息
         * */
        private void step_change_Click(object sender, RoutedEventArgs e)
        {
            //获取选择的listbox的step_name
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            Model.Common_Rail_Injector_Test common_Rail_Injector_Test = new Model.Common_Rail_Injector_Test();
            common_Rail_Injector_Test = Get_data_from_page();
            //根据model_no和step_name更新数据
            bool flag = OilP.Service.Common_Rail_Injector_Test_Service.UpdateData(common_Rail_Injector_Test);
            if (flag)
            {
                string message = "测试步骤更新成功";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                //if (dr == MessageBoxResult.OK)
                //{
                //    //重新加载ListBox
                //    step_ListBox.Items.Clear();
                //    Init_step_ListBox(MODEL_NO);
                //}
            }
            else
            {
                string message = "测试步骤更新失败";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                //if (dr == MessageBoxResult.OK)
                //{
                //    //重新加载ListBox
                //    step_ListBox.Items.Clear();
                //    Init_step_ListBox(MODEL_NO);
                //}
            }
        }
    }
}
