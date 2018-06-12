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
    /// Common_Rail_Injector_Setting.xaml 的交互逻辑
    /// </summary>
    public partial class Common_Rail_Injector_Setting : Page
    {
        public Common_Rail_Injector_Setting()
        {
            InitializeComponent();
        }

        public List<Setting_Model> GetDataFromPage()
        {
            /*与列表匹配获取里面的数据*/
            List<Setting_Model> data = new List<Setting_Model>();
            Setting_Model temp_data = new Setting_Model();

            /*机油P-0*/
            temp_data.Name = "oil_p";
            temp_data.Value = oil_P_TextBox.Text;
            data.Add(temp_data);
            /*机油I-1*/
            temp_data.Name = "oil_i";
            temp_data.Value = oil_I_TextBox.Text;
            data.Add(temp_data);
            /*机油D-2*/
            temp_data.Name = "oil_d";
            temp_data.Value = oil_D_TextBox.Text;
            data.Add(temp_data);
            /*油箱温度-3*/
            temp_data.Name = "tank_t";
            temp_data.Value = oil_tank_T_Text.Text;
            data.Add(temp_data);
            /*柴油轨压标定1-4*/
            temp_data.Name = "fuel_1_pressure";
            temp_data.Value = fuel_1_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定2-5*/
            temp_data.Name = "fuel_2_pressure";
            temp_data.Value = fuel_2_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定3-6*/
            temp_data.Name = "fuel_3_pressure";
            temp_data.Value = fuel_3_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定4-7*/
            temp_data.Name = "fuel_4_pressure";
            temp_data.Value = fuel_4_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定5-8*/
            temp_data.Name = "fuel_5_pressure";
            temp_data.Value = fuel_5_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定6-9*/
            temp_data.Name = "fuel_6_pressure";
            temp_data.Value = fuel_6_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*柴油轨压标定7-11*/
            temp_data.Name = "fuel_7_pressure";
            temp_data.Value = fuel_7_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*机油轨压标定1-11*/
            temp_data.Name = "oil_1_pressure";
            temp_data.Value = oil_1_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*机油轨压标定2-12*/
            temp_data.Name = "oil_2_pressure";
            temp_data.Value = oil_2_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*机油轨压标定3-13*/
            temp_data.Name = "oil_3_pressure";
            temp_data.Value = oil_3_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*机油轨压标定4-14*/
            temp_data.Name = "oil_4_pressure";
            temp_data.Value = oil_4_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*机油轨压标定5-15*/
            temp_data.Name = "oil_5_pressure";
            temp_data.Value = oil_5_rail_pressure_TextBox.Text;
            data.Add(temp_data);
            /*轨压传感器切换-16*/
            int temp_value;
            if (heat_false.IsChecked == true)
            {
                temp_value = 0;
            }
            else
            {
                temp_value = 1;
            }
            temp_data.Name = "oil_5_pressure";
            temp_data.Value = temp_value.ToString();
            data.Add(temp_data);
            /*柴油目标温度-17*/
            temp_data.Name = "RY_T";
            temp_data.Value = RY_T_TextBox.Text;
            data.Add(temp_data);
            /*机油目标温度-18*/
            temp_data.Name = "JY_T";
            temp_data.Value = JY_T_TextBox.Text;
            data.Add(temp_data);
            /*柴油温度偏差-19*/
            temp_data.Name = "RY_T_deviation";
            temp_data.Value = RY_T_deviation_TextBox.Text;
            data.Add(temp_data);
            /*机油温度偏差-20*/
            temp_data.Name = "JY_T_deviation";
            temp_data.Value = JY_T_deviation_TextBox.Text;
            data.Add(temp_data);
            /*轨压控制P-21*/
            temp_data.Name = "fuel_p";
            temp_data.Value = fuel_P_TextBox.Text;
            data.Add(temp_data);
            /*轨压控制I-22*/
            temp_data.Name = "fuel_i";
            temp_data.Value = fuel_I_TextBox.Text;
            data.Add(temp_data);
            /*轨压控制D-23*/
            temp_data.Name = "fuel_d";
            temp_data.Value = fuel_D_TextBox.Text;
            data.Add(temp_data);
            /*机油流量计K-24*/
            temp_data.Name = "oil_flow_k";
            temp_data.Value = Oilk_TextBox.Text;
            data.Add(temp_data);
            /*油泵油量K-25*/
            temp_data.Name = "pump_flow_k";
            temp_data.Value = Pumpinjk_TextBox.Text;
            data.Add(temp_data);
            /*泵喷油K-26*/
            temp_data.Name = "pump_p_k";
            temp_data.Value = PumpRek_TextBox.Text;
            data.Add(temp_data);
            /*系统状态2-27*/
            temp_data.Name = "sys_version";
            temp_data.Value = Sys_version_TextBox.Text;
            data.Add(temp_data);
            /*读取固件版本-28*/
            temp_data.Name = "gu_version";
            temp_data.Value = Gu_version_TextBox.Text;
            data.Add(temp_data);

            /*0x30的指令*/
        
            return data;
        }

        /**
         * 将页面上的信息写入txt文件
         * */
         public void WriteToTxt()
        {

        }
    }
}
