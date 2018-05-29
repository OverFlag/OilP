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
        private static String MODEL_NO;
        public Common_Rail_Injector_Test(string model_no)
        {
            InitializeComponent();
            Initialize_Page(model_no);
            MODEL_NO = model_no;
           
        }

        /**
        * set the item name and datagrid
        **/
        public void Initialize_Page(string model_no)
        {
            
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

            //初始化测试步骤列表并填入数据库中数据
            Init_test_names(model_no);


        }

        /**
         * 初始化测试步骤列表
         * */
        // public void Init_test_names(string model_no)
        //{
        //    List<OilP.Model.Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Model.Common_Rail_Injector_Test>();
        //    common_Rail_Injector_Tests = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNo(model_no);
        //    int length = common_Rail_Injector_Tests.Count;
        //    Set_test_names(length, common_Rail_Injector_Tests);
        //    setData(model_no, setp_0.Text);
        //}

        /**
         * 初始化测试步骤列表
         * */
        public void Init_test_names(string model_no)
        {
            List<CRI_Model> cRI_Models = new List<Model.CRI_Model>();
            cRI_Models = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNo(model_no);
            int length = cRI_Models.Count;
            Set_test_names(length, cRI_Models);
            setData(model_no, setp_0.Text);
        }



        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /**
          * 根据model_no和step_name查找详细数据
          * */
        //public void setData(string model_no, string step_name)
        //{
        //    Model.Common_Rail_Injector_Test common_Rail_Injector_Test = new Model.Common_Rail_Injector_Test();
        //    common_Rail_Injector_Test = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNoAndStepName(model_no, step_name);
        //    //在页面上填入step_name和model_no的数据
        //    step_name_TextBox.Text = step_name;
        //    fillData(common_Rail_Injector_Test);

        //}

        /**
         * 根据model_no和step_name查找详细数据
         * */
        public void setData(string model_no, string step_name)
        {
            CRI_Model cRI_Model = new CRI_Model();
            cRI_Model = OilP.Service.Common_Rail_Injector_Test_Service.QueryByModelNoAndStepName(model_no, step_name);
            //在页面上填入step_name和model_no的数据
            step_name_TextBox.Text = step_name;
            fillData(cRI_Model);

        }

        /**
         * 向页面填充数据
         * */
        //public void fillData(Model.Common_Rail_Injector_Test common_Rail_Injector_Test)
        //{
        //    pulse_width_textBox.Text = common_Rail_Injector_Test.Duration.ToString();
        //    hor_rail_pressure_textBox.Text = common_Rail_Injector_Test.Rail_pressure.ToString();
        //    hor_fuel_P_textBox.Text = common_Rail_Injector_Test.Fuel_p_hor.ToString();
        //    ver_fuel_P_textBox.Text = common_Rail_Injector_Test.Fuel_p_ver.ToString();
        //    hor_fuel_h_textBox.Text = common_Rail_Injector_Test.Fuel_h_hor.ToString();
        //    ver_fuel_h_textBox.Text = common_Rail_Injector_Test.Fuel_h_ver.ToString();
        //    test_time_textBox.Text = common_Rail_Injector_Test.Test_time.ToString();
        //    voltage_textBox.Text = common_Rail_Injector_Test.Voltage.ToString();
        //}

        /**
         * 向页面填充数据
         * */
        public void fillData(CRI_Model cRI_Model)
        {
            //脉宽
            pulse_width_textBox.Text = cRI_Model.Pulse_width;
            //共轨压力
            TextBox_rail_pressure.Text = cRI_Model.Rail_pressure;
            //进油压力
            TextBox_oil_j_pressure.Text = cRI_Model.Oil_j_pressure;
            //回油压力
            TextBox_oil_h_pressure.Text = cRI_Model.Oil_h_pressure;
            //喷油标准
            TextBox_oil_p_standard.Text = cRI_Model.Oil_p_standard;
            //喷油偏差
            TextBox_oil_p_deviation.Text = cRI_Model.Oil_p_deviation;
            //回油标准
            TextBox_oil_h_standrad.Text = cRI_Model.Oil_h_standard;
            //回油偏差
            TextBox_oil_h_deviation.Text = cRI_Model.Oil_h_deviation;
            //控制持续时间
            TextBox_control_last_time.Text = cRI_Model.Control_last_time;
            //电压
            voltage_textBox.Text = cRI_Model.Voltage;
        }


        //public void Set_test_names(int length, List<OilP.Model.Common_Rail_Injector_Test> common_Rail_Injector_Tests)
        //{
        //    if (length > 0)
        //    {
        //        setp_0.Text = common_Rail_Injector_Tests[0].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length>1)
        //    {
        //        setp_1.Text = common_Rail_Injector_Tests[1].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 2)
        //    {
        //        setp_2.Text = common_Rail_Injector_Tests[2].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 3)
        //    {
        //        setp_3.Text = common_Rail_Injector_Tests[3].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 4)
        //    {
        //        setp_4.Text = common_Rail_Injector_Tests[4].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 5)
        //    {
        //        setp_5.Text = common_Rail_Injector_Tests[5].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 6)
        //    {
        //        setp_6.Text = common_Rail_Injector_Tests[6].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //    if (length > 7)
        //    {
        //        setp_7.Text = common_Rail_Injector_Tests[7].Step_name.ToString();
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}
        public void Set_test_names(int length, List<CRI_Model> cRI_Models)
        {
            if (length > 0)
            {
                setp_0.Text = cRI_Models[0].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 1)
            {
                setp_1.Text = cRI_Models[1].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 2)
            {
                setp_2.Text = cRI_Models[2].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 3)
            {
                setp_3.Text = cRI_Models[3].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 4)
            {
                setp_4.Text = cRI_Models[4].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 5)
            {
                setp_5.Text = cRI_Models[5].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 6)
            {
                setp_6.Text = cRI_Models[6].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 7)
            {
                setp_7.Text = cRI_Models[7].Step_name.ToString();
            }
            else
            {
                return;
            }
        }
    }
}
