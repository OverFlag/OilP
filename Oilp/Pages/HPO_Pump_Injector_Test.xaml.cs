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
    /// HPO_Pump_Injector_Test.xaml 的交互逻辑
    /// </summary>
    public partial class HPO_Pump_Injector_Test : Page
    {
        private static String MODEL_NO;
        public HPO_Pump_Injector_Test(string model_no)
        {
            InitializeComponent();
            Initialize_Page(model_no);
            MODEL_NO = model_no;
        }

        /**
        * 设置item名称和测试步骤列表数据
        **/
        public void Initialize_Page(string model_no)
        {

            //改变图标显示
            btn_step_1.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,../Resources/exit.png"))
            };

            //get name list
            List<LAN_Model> lAN_Models = new List<LAN_Model>();
            lAN_Models = OilP.Service.LAN_Service.Init_Item_Name("hpo_pump");
            //init names
            setEleName(lAN_Models);

            //初始化测试步骤列表并填入数据库中数据
            Init_test_names(model_no);
        }


        /**
        * set the names of elements
        * */
        private void setEleName(List<LAN_Model> item_Names)
        {
            //model_no_name.Text = item_Names[0].Item_name;

           
            //if ("en_US".Equals(item_Names[0].Language))
            //{
                
            //    setFontFamily("Yu Gothic UI Semibold");
          
            //}
        }

        /**
        * set font family for en_US
        **/
        private void setFontFamily(string font)
        {
            //model_no_name.FontFamily = new FontFamily(font);
            //search.FontFamily = new FontFamily(font);
            //exit_system.FontFamily = new FontFamily(font);
            //add.FontFamily = new FontFamily(font);
            //edit.FontFamily = new FontFamily(font);
            //delete.FontFamily = new FontFamily(font);
            //confirm.FontFamily = new FontFamily(font);
        }

        /**
        * 初始化测试步骤列表
        * */
        public void Init_test_names(string model_no)
        {
            List<HPO_Model> hPO_Models = new List<Model.HPO_Model>();
            hPO_Models = OilP.Service.HPO_Service.QueryByModelNo(model_no);
            int length = hPO_Models.Count;
            Set_test_names(length, hPO_Models);
            setData(model_no, setp_0.Text);
        }

        /*
         * 退出系统
         */
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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
            model_no_TextBox.Text = model_no;
            fillData(hPO_Model);

        }

        /**
        * 向页面填充数据
        * */
        public void fillData(HPO_Model hPO_Model)
        {
            /*转速*/
            round_speed_standard_TextBox.Text = hPO_Model.Round_speed;
            /* DRV电流 */
            DRV_a_standard_textBox.Text = hPO_Model.Drv_a;
            /*共轨压力*/
            rail_pressure_standard_TextBox.Text = hPO_Model.Rail_pressure;
            /*喷油量*/
            oil_p_standard_TextBox.Text = hPO_Model.Oil_p_standard;
            /*喷油量偏差*/
            oil_p_deviation_TextBox.Text = hPO_Model.Oil_p_deviationr;
            /*回油量*/
            oil_h_standard_TextBox.Text = hPO_Model.Oil_h_standard;
            /*回油量偏差*/
            oil_h_deviation_TextBox.Text = hPO_Model.Oil_h_deviationr;
            /*提前角*/
            start_angle_stdasandard_TextBox.Text = hPO_Model.Start_angle;
            /*电压*/
            voltage_TextBox.Text = hPO_Model.Voltage;
            /*进油压力*/
            oil_j_pressure_TextBox.Text = hPO_Model.Oil_j_pressure;
            /*回油压力*/
            oil_h_pressure_TextBox.Text = hPO_Model.Oil_h_pressure;
            /*泵腔压力*/
            pump_pressure_TextBox.Text = hPO_Model.Pump_pressure;
            /*电机转向*/
            /*测量时间*/
            test_time_standard_TextBox.Text = hPO_Model.Test_time;
        }

        public void Set_test_names(int length, List<HPO_Model> hPO_Models)
        {
            if (length > 0)
            {
                setp_0.Text = hPO_Models[0].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 1)
            {
                setp_1.Text = hPO_Models[1].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 2)
            {
                setp_2.Text = hPO_Models[2].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 3)
            {
                setp_3.Text = hPO_Models[3].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 4)
            {
                setp_4.Text = hPO_Models[4].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 5)
            {
                setp_5.Text = hPO_Models[5].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 6)
            {
                setp_6.Text = hPO_Models[6].Step_name.ToString();
            }
            else
            {
                return;
            }
            if (length > 7)
            {
                setp_7.Text = hPO_Models[7].Step_name.ToString();
            }
            else
            {
                return;
            }
        }

    }
}
