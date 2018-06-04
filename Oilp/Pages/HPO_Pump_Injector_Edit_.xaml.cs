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
    /// HPO_Pump_Injector_Edit_.xaml 的交互逻辑
    /// </summary>
    public partial class HPO_Pump_Injector_Edit_ : Page
    {
        public static string MODEL_NO;
        public bool EDIT_FLAG = false;
        public bool TEXT_BG_FLAG = false;
        public HPO_Pump_Injector_Edit_(string model_no)
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
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = OilP.Service.HPO_Service.QueryByModelNo(model_no);
            for (int i = 0; i < hPO_Models.Count; i++)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = hPO_Models[i].Step_name;
                item.FontSize = 40;
                item.FontFamily = new FontFamily("Yu Gothic UI Semibold");
                step_ListBox.Items.Add(item);
                //设置listbox的默认值
                //if (i==0)
                //{
                //    item.IsSelected = true;
                //}

                //传入model_no和list仲的第一个step_name向页面填入数据库存在的数据
                setData(model_no, hPO_Models[0].Step_name);
                model_no_TextBox.Text = model_no;
            }
        }

        /**
      * 根据model_no和step_name查找详细数据
      * */
        public void setData(string model_no, string step_name)
        {
            HPO_Model hPO_Model = new HPO_Model();
            hPO_Model = OilP.Service.HPO_Service.QueryByModelNoAndStepName(model_no, step_name);
            //在页面上填入step_name和model_no的数据
            step_name_TextBox.Text = step_name;
            fillData(hPO_Model);

        }

        /**
        * 将Common_Rail_Injector_Test数据初始化到界面上
        * */
        public void fillData(HPO_Model hPO_Model)
        {
            //combobox赋值,测试能否成功
            manus_combobox.Text = hPO_Model.Manufacturer;
            step_name_TextBox.Text = hPO_Model.Step_name;
            drv_a_TextBox.Text = hPO_Model.Drv_a;
            rail_pressure_TextBox.Text = hPO_Model.Rail_pressure;
            oil_p_standard_TextBox.Text = hPO_Model.Oil_p_standard;
            oil_p_deviationr_TextBox.Text = hPO_Model.Oil_p_deviationr;
            oil_h_standard_TextBox.Text = hPO_Model.Oil_h_standard;
            oil_h_deviation_TextBox.Text = hPO_Model.Oil_h_deviationr;
            start_angle_TextBox.Text = hPO_Model.Start_angle;
            voltage_TextBox.Text = hPO_Model.Voltage;
            oil_j_pressure_TextBox.Text = hPO_Model.Oil_j_pressure;
            oil_h_pressure_TextBox.Text = hPO_Model.Oil_h_pressure;
            pump_pressure_TextBox.Text = hPO_Model.Pump_pressure;
            motor_steering_TextBox.Text = hPO_Model.Motor_steering;
            test_time_TextBox.Text = hPO_Model.Test_time;

            //读取数据后设置不可编辑
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes = GetNameOfTextBox();
            SetEditable(false, textBoxes);
        }

        /**
         * 设置textbox是否可编辑
         * */
        public void SetEditable(bool flag,List<TextBox> textBoxes)
        {
            if (flag)
            {
                foreach (TextBox item in textBoxes)
                {
                    item.IsReadOnly = false;
                }
                //显示三个按钮
                step_add.Visibility = Visibility.Visible;
                step_delete.Visibility = Visibility.Visible;
                step_change.Visibility = Visibility.Visible;
                SetTextBoxBG(flag, textBoxes);
            }
            else
            {
                foreach (TextBox item in textBoxes)
                {
                    item.IsReadOnly = true;
                }
                //隐藏三个按钮
                step_add.Visibility = Visibility.Hidden;
                step_delete.Visibility = Visibility.Hidden;
                step_change.Visibility = Visibility.Hidden;
                SetTextBoxBG(flag, textBoxes);
            }
        }

        /**
         * 设置可编辑和不可编辑的颜色
         * */
        public void SetTextBoxBG(bool flag,List<TextBox> textBoxes)
        {
            if (flag)
            {
                foreach (TextBox item in textBoxes)
                {
                    item.Background = Brushes.White;
                }
            }
            else
            {
                foreach (TextBox item in textBoxes)
                {
                    item.Background = Brushes.Gray;
                }
            }
        }

        private void step_add_Click(object sender, RoutedEventArgs e)
        {
            //获取当前页面上的数据
            HPO_Model hPO_Model = new HPO_Model();
            hPO_Model = Get_data_from_page();
            string message = OilP.Service.HPO_Service.AddData(hPO_Model, MODEL_NO);
            MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (dr == MessageBoxResult.OK)
            {
                //重新加载ListBox
                step_ListBox.Items.Clear();
                Init_step_ListBox(MODEL_NO);
            }
        }

        private void step_delete_Click(object sender, RoutedEventArgs e)
        {
            //获取选择的listbox的step_name
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            //根据model_no和step_name删除
            bool flag = OilP.Service.HPO_Service.DeleteData(MODEL_NO, step_name);
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

        private void step_change_Click(object sender, RoutedEventArgs e)
        {
            //获取选择的listbox的step_name
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            HPO_Model hPO_Model = new HPO_Model();
            hPO_Model = Get_data_from_page();
            //根据model_no和step_name更新数据
            bool flag = OilP.Service.HPO_Service.UpdateData(hPO_Model);
            if (flag)
            {
                string message = "测试步骤更新成功";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);          
            }
            else
            {
                string message = "测试步骤更新失败";
                MessageBoxResult dr = MessageBox.Show(message, "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information);         
            }
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            string model_no = MODEL_NO;
            //页面跳转，传递model_no参数
           HPO_Pump_Injector_Test hPO_Pump_Injector_Test_page = new HPO_Pump_Injector_Test(model_no);
            this.NavigationService.Navigate(hPO_Pump_Injector_Test_page);
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            //将textbox设置为可修改
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes = GetNameOfTextBox();
            SetEditable(true, textBoxes);
            SetTextBoxBG(true, textBoxes);
        }

        private void step_ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (step_ListBox.Items.Count == 0)
            {
                return;
            }
            string step_name = ((ListBoxItem)step_ListBox.SelectedItem).Content.ToString();
            setData(MODEL_NO, step_name);
        }

        /*
         * 获取页面上所有TextBox的名字
         */
        public List<TextBox> GetNameOfTextBox()
        {
            List<TextBox> textBoxes = new List<TextBox>();
            textBoxes.Add(model_no_TextBox);
            textBoxes.Add(step_name_TextBox);
            textBoxes.Add(drv_a_TextBox);
            textBoxes.Add(rail_pressure_TextBox);
            textBoxes.Add(oil_p_standard_TextBox);
            textBoxes.Add(oil_p_deviationr_TextBox);
            textBoxes.Add(oil_h_standard_TextBox);
            textBoxes.Add(oil_h_deviation_TextBox);
            textBoxes.Add(start_angle_TextBox);
            textBoxes.Add(voltage_TextBox);
            textBoxes.Add(oil_j_pressure_TextBox);
            textBoxes.Add(oil_h_pressure_TextBox);
            textBoxes.Add(pump_pressure_TextBox);
            textBoxes.Add(motor_steering_TextBox);
            textBoxes.Add(test_time_TextBox);
            return textBoxes;
        }

        /*
         * 获取页面上的数据
         */
        public HPO_Model Get_data_from_page()
        {
            HPO_Model hPO_Model = new HPO_Model();

            hPO_Model.Model_no = MODEL_NO;
            hPO_Model.Manufacturer = manus_combobox.Text;
            hPO_Model.Curve = "curve";
            hPO_Model.Step_name = step_name_TextBox.Text;
            hPO_Model.Round_speed = "round_speed";
            hPO_Model.Drv_a = drv_a_TextBox.Text;
            hPO_Model.Rail_pressure = rail_pressure_TextBox.Text;
            hPO_Model.Oil_p_standard = oil_p_standard_TextBox.Text;
            hPO_Model.Oil_p_deviationr = oil_p_deviationr_TextBox.Text;
            hPO_Model.Oil_h_standard = oil_h_standard_TextBox.Text;
            hPO_Model.Oil_h_deviationr = oil_h_deviation_TextBox.Text;
            hPO_Model.Start_angle = start_angle_TextBox.Text;
            hPO_Model.Voltage = voltage_TextBox.Text;
            hPO_Model.Oil_j_pressure = oil_j_pressure_TextBox.Text;
            hPO_Model.Oil_h_pressure = oil_h_pressure_TextBox.Text;
            hPO_Model.Pump_pressure = pump_pressure_TextBox.Text;
            hPO_Model.Motor_steering = motor_steering_TextBox.Text;
            hPO_Model.Test_time = test_time_TextBox.Text;
     
            return hPO_Model;
        }
    }
}
