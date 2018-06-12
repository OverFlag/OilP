using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            //需要修改的读取item_name，改成读txt文件的
            List<LAN_Model> lAN_Models = new List<LAN_Model>();
            lAN_Models = OilP.Service.LAN_Service.Init_Item_Name("cri_test");
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
            //common_rail_injector_test.Content = item_Names[0].Item_name;
            //cri_model_no.Content = item_Names[1].Item_name;
            //cri_step_name.Content = item_Names[2].Item_name;

         
            ////change the datagrid header language
            //Regex regChina = new Regex("^[^\x00-\xFF]");
            //Regex regEnglish = new Regex("^[a-zA-Z]");
            //if (regEnglish.IsMatch(item_Names[1].Item_name))
            //{
            //    //set font family
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

        
        public List<Setting_Model> GetDataFromPage()
        {
            List<Setting_Model> data = new List<Setting_Model>();
            Setting_Model temp_data = new Setting_Model();
            /* 测试类型-0*/
            temp_data.Name = "test_type";
            temp_data.Value = "1";
            data.Add(temp_data);
            /* 柴油加热使能-1*/
            temp_data.Name = "fuel_heat";
            int temp_value;
            if (fuel_heat_true.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_data.ToString();
            data.Add(temp_data);
            /* 机油加热使能-2*/
            temp_data.Name = "oil_heat";
            if (oil_heat_false.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_data.ToString();
            data.Add(temp_data);
            /* 上位机状态-3*/
            temp_data.Name = "up_status";
            /* 根据不同的进入方式改变*/
            temp_data.Value = "1";
            data.Add(temp_data);

            /* 喷油器类型-4*/
            temp_data.Name = "injector_type";
            temp_data.Value = "1";
            data.Add(temp_data);

            /* 驱动目标通道-5*/
            temp_data.Name = "tongdao";
            if (tongdao_1.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_value.ToString();
            data.Add(temp_data);

            /* 电磁喷油器升压电压-6*/
            temp_data.Name = "v_TiSheng";
            temp_data.Value = null;
            data.Add(temp_data);

            /* 电磁喷油器脉宽最大值-7*/
            temp_data.Name = "max_pulse";
            temp_data.Value = max_pulse_TextBox.Text;
            data.Add(temp_data);

            /* 电磁喷油器1开启时间1-8*/
            temp_data.Name = "1_open_time_1";
            temp_data.Value = "100";
            data.Add(temp_data);

            /* 电磁喷油器1开启时间2-9*/
            /* 曲线数据库中持续吸动时间-开启时间1*/
            temp_data.Name = "1_open_time_2";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器1开启时间3-10*/
            
            temp_data.Name = "1_open_time_3";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器1开启电流1-11*/
            /*曲线数据库--电流提升*/
            temp_data.Name = "1_open_A_1";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器1开启电流2-12*/
            /*曲线数据库--电流吸动*/
            temp_data.Name = "1_open_A_2";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器1开启电流3-13*/
            /*曲线数据库--电流保持*/
            temp_data.Name = "1_open_A_3";
            temp_data.Value = null;
            data.Add(temp_data);

            /* 电磁喷油器2开启时间1-14*/
            /*默认值*/
            temp_data.Name = "2_open_time_1";
            temp_data.Value = "100";
            data.Add(temp_data);

            /* 电磁喷油器2开启时间2-15*/
            /* 曲线数据库中持续吸动时间-开启时间1*/
            temp_data.Name = "2_open_time_2";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器2开启时间3-16*/
            /*2000-持续吸动时间*/
            temp_data.Name = "2_open_time_3";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器2开启电流1-17*/
            /*曲线数据库--电流提升*/
            temp_data.Name = "2_open_A_1";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器2开启电流2-18*/
            /*曲线数据库--电流吸动*/
            temp_data.Name = "2_open_A_2";
            temp_data.Value = null;
            data.Add(temp_data);

            /*电磁喷油器2开启电流3-19*/
            /*曲线数据库--电流保持*/
            temp_data.Name = "2_open_A_3";
            temp_data.Value = null;
            data.Add(temp_data);

            return data;
        }

        public List<Setting_Model> StartData()
        {
            List<Setting_Model> data = new List<Setting_Model>();
            Setting_Model temp_data = new Setting_Model();

            /*泵转向-0*/
            temp_data.Name = "direction";
            int temp_value;
            if (forward.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_value.ToString();
            data.Add(temp_data);

            /*电机转速-1*/
            /*从数据库来*/
            temp_data.Name = "round_speed";
            temp_data.Value = null;
            data.Add(temp_data);

            /*目标轨压-1*/
            /*从数据库来*/
            temp_data.Name = "rail_pressure";
            temp_data.Value = null;
            data.Add(temp_data);    

            /*喷油器1频率-1*/
            /*从数据库来*/
            temp_data.Name = "1_pinlv";
            temp_data.Value = null;
            data.Add(temp_data);
            /*喷油器1脉宽-1*/
            /*从数据库来*/
            temp_data.Name = "1_pulse";
            temp_data.Value = null;
            data.Add(temp_data);

            /*喷油器2频率-1*/
            /*从数据库来*/
            temp_data.Name = "2_pinlv";
            temp_data.Value = null;
            data.Add(temp_data);
            /*喷油器2脉宽-1*/
            /*从数据库来*/
            temp_data.Name = "2_pulse";
            temp_data.Value = null;
            data.Add(temp_data);

            /* 喷油器油量系数-1*/
            temp_data.Name = "flow_c2_r1";
            temp_data.Value = null;
            data.Add(temp_data);

            /* 喷油1使能-1*/
            temp_data.Name = "penyou_1";
            if (PenYou_1_ShiNeng.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_value.ToString();
            data.Add(temp_data);

            /* 喷油2使能-1*/
            temp_data.Name = "penyou_2";
            if (PenYou_2_ShiNeng.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Value = temp_value.ToString();
            data.Add(temp_data);

            /*柴油当前温度-1*/
            /*下位机返回*/
            temp_data.Name = "fuel_T";
            temp_data.Value = show_fuel_T_TextBox.Text;
            data.Add(temp_data);

            /*喷油器流量-1*/
            /*下位机返回*/
            temp_data.Name = "inj_flow";
            temp_data.Value = show_inj_flow_TextBox.Text;
            data.Add(temp_data);

            /*油泵流量-1*/
            /*下位机返回*/
            temp_data.Name = "pump_flow";
            temp_data.Value = show_pump_flow_TextBox.Text;
            data.Add(temp_data);

            /*读取轨压-1*/
            /*下位机返回*/
            temp_data.Name = "read_pressure";
            temp_data.Value = show_read_pressure_TextBox.Text;
            data.Add(temp_data);

            /*读取机油流量-1*/
            /*下位机返回*/
            temp_data.Name = "read_oil_flow";
            temp_data.Value = show_read_oil_flow_TextBox.Text;
            data.Add(temp_data);

            /*系统状态1-1*/
            /*下位机返回*/
            temp_data.Name = "sys_status_1";
            temp_data.Value = show_sys_status_1_TextBox.Text;
            data.Add(temp_data);
            /*系统状态2-1*/
            /*下位机返回*/
            temp_data.Name = "sys_status_2";
            temp_data.Value = show_sys_status_2_TextBox.Text;
            data.Add(temp_data);

            /*读取机油压力-1*/
            /*下位机返回*/
            temp_data.Name = "read_oil_pressure";
            temp_data.Value = show_read_oil_pressure_TextBox.Text;
            data.Add(temp_data);

            /*燃油压力电压EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_fuel_V";
            temp_data.Value = show_el_fuel_V_TextBox.Text;
            data.Add(temp_data);

            /*机油压力电压EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_oil_V";
            temp_data.Value = show_el_oil_V_TextBox.Text;
            data.Add(temp_data);

            /*燃油DRV电流EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_fuel_drv";
            temp_data.Value = show_el_fuel_drv_TextBox.Text;
            data.Add(temp_data);

            /*机油DRV电流EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_oil_drv";
            temp_data.Value = show_el_oil_drv_TextBox.Text;
            data.Add(temp_data);

            /*燃油流量计EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_fuel_flow";
            temp_data.Value = show_el_fuel_flow_TextBox.Text;
            data.Add(temp_data);


            /*机油流量计EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_oil_flow";
            temp_data.Value = show_el_oil_flow_TextBox.Text;
            data.Add(temp_data);

            /*喷油器驱动电压EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_inj_drive_V";
            temp_data.Value = show_el_inj_drive_V_TextBox.Text;
            data.Add(temp_data);

            /*喷油器电流EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_inj_A";
            temp_data.Value = show_el_inj_A_V_TextBox.Text;
            data.Add(temp_data);

            /*机油温度EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_oil_T";
            temp_data.Value = show_el_oil_T_V_TextBox.Text;
            data.Add(temp_data);


            /*回油温度EL-1*/
            /*下位机返回*/
            temp_data.Name = "el_oil_h";
            temp_data.Value = show_el_oil_h_V_TextBox.Text;
            data.Add(temp_data);

            /*机油温度-1*/
            /*下位机返回*/
            temp_data.Name = "oil_T";
            temp_data.Value = show_oil_T_V_TextBox.Text;
            data.Add(temp_data);
            return data;
        }

        public List<Setting_Model> StopData()
        {
            List<Setting_Model> data = new List<Setting_Model>();
            Setting_Model temp_data = new Setting_Model();
            /*电机转速-1*/
            /*下位机返回*/
            temp_data.Name = "round_speed";
            temp_data.Value = null;
            data.Add(temp_data);

            /*目标轨压-1*/
            /*下位机返回*/
            temp_data.Name = "rail_pressure";
            temp_data.Value = null;
            data.Add(temp_data);

            /*目标机油压力-1*/
            /*下位机返回*/
            temp_data.Name = "oil_pressure";
            temp_data.Value = null;
            data.Add(temp_data);

            return data;
        }
    }
}
