//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OilP.Model
//{
//    class temp
//    {
//        public List<Setting_Model> GetDataFromPage()
//        {
//            /*与列表匹配获取里面的数据*/
//            List<Setting_Model> data = new List<Setting_Model>();
//            Setting_Model temp_data = new Setting_Model();

//            temp_data.Name = "oil_1_rail_pressure_TextBox";
//            temp_data.Value = oil_1_rail_pressure_TextBox.Text;
//            temp_data.Command = "0010";
//            data.Add(temp_data);
//            temp_data.Name = "oil_2_rail_pressure_TextBox";
//            temp_data.Value = oil_2_rail_pressure_TextBox.Text;
//            temp_data.Command = "0011";
//            data.Add(temp_data);
//            temp_data.Name = "oil_3_rail_pressure_TextBox";
//            temp_data.Value = oil_3_rail_pressure_TextBox.Text;
//            temp_data.Command = "0012";
//            data.Add(temp_data);
//            temp_data.Name = "oil_4_rail_pressure_TextBox";
//            temp_data.Value = oil_4_rail_pressure_TextBox.Text;
//            temp_data.Command = "0013";
//            data.Add(temp_data);
//            temp_data.Name = "oil_5_rail_pressure_TextBox";
//            temp_data.Value = oil_5_rail_pressure_TextBox.Text;
//            temp_data.Command = "0014";
//            data.Add(temp_data);
//            temp_data.Name = "rail_pressure_group";
//            int temp_value;
//            if (MPA_180.IsChecked == true)
//            {
//                /*MPA180*/
//                temp_value = 0;
//            }
//            else
//            {
//                /*MPA240*/
//                temp_value = 1;
//            }
//            temp_data.Value = temp_value.ToString();

//            temp_data.Command = "0015";
//            data.Add(temp_data);
//            temp_data.Name = "RY_T_deviation_TextBox";
//            temp_data.Value = RY_T_deviation_TextBox.Text;
//            temp_data.Command = "0016";
//            data.Add(temp_data);
//            temp_data.Name = "JY_T_deviation_TextBox";
//            temp_data.Value = JY_T_deviation_TextBox.Text;
//            temp_data.Command = "0017";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_1_rail_pressure_TextBox";
//            temp_data.Value = fuel_1_rail_pressure_TextBox.Text;
//            temp_data.Command = "0319";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_2_rail_pressure_TextBox";
//            temp_data.Value = fuel_2_rail_pressure_TextBox.Text;
//            temp_data.Command = "031A";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_3_rail_pressure_TextBox";
//            temp_data.Value = fuel_3_rail_pressure_TextBox.Text;
//            temp_data.Command = "031B";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_4_rail_pressure_TextBox";
//            temp_data.Value = fuel_4_rail_pressure_TextBox.Text;
//            temp_data.Command = "031C";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_5_rail_pressure_TextBox";
//            temp_data.Value = fuel_5_rail_pressure_TextBox.Text;
//            temp_data.Command = "031D";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_6_rail_pressure_TextBox";
//            temp_data.Value = fuel_6_rail_pressure_TextBox.Text;
//            temp_data.Command = "031E";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_7_rail_pressure_TextBox";
//            temp_data.Value = fuel_7_rail_pressure_TextBox.Text;
//            temp_data.Command = "031F";
//            data.Add(temp_data);
//            temp_data.Name = "rail_pressure_group(根据180mpa和240mpa)";
//            if (MPA_180.IsChecked == true)
//            {
//                /*MPA180*/
//                temp_value = 0;
//            }
//            else
//            {
//                /*MPA240*/
//                temp_value = 1;
//            }
//            temp_data.Value = temp_value.ToString();
//            temp_data.Command = "0320";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_P_TextBox";
//            temp_data.Value = fuel_P_TextBox.Text;
//            temp_data.Command = "0023";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_I_TextBox";
//            temp_data.Value = fuel_I_TextBox.Text;
//            temp_data.Command = "0024";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_D_TextBox";
//            temp_data.Value = fuel_D_TextBox.Text;
//            temp_data.Command = "0025";
//            data.Add(temp_data);
//            temp_data.Name = "RY_T_TextBox";
//            temp_data.Value = RY_T_TextBox.Text;
//            temp_data.Command = "0029";
//            data.Add(temp_data);
//            temp_data.Name = "JY_T_TextBox";
//            temp_data.Value = JY_T_TextBox.Text;
//            temp_data.Command = "002A";
//            data.Add(temp_data);
//            temp_data.Name = "Sys_version_TextBox";
//            temp_data.Value = Sys_version_TextBox.Text;
//            temp_data.Command = "003C";
//            data.Add(temp_data);
//            temp_data.Name = "Oilk_TextBox";
//            temp_data.Value = Oilk_TextBox.Text;
//            temp_data.Command = "003E";
//            data.Add(temp_data);
//            temp_data.Name = "oil_P_TextBox";
//            temp_data.Value = oil_P_TextBox.Text;
//            temp_data.Command = "0004";
//            data.Add(temp_data);
//            temp_data.Name = "Pumpinjk_TextBox";
//            temp_data.Value = Pumpinjk_TextBox.Text;
//            temp_data.Command = "0040";
//            data.Add(temp_data);
//            temp_data.Name = "oil_I_TextBox";
//            temp_data.Value = oil_I_TextBox.Text;
//            temp_data.Command = "0005";
//            data.Add(temp_data);
//            temp_data.Name = "Gu_version_TextBox";
//            temp_data.Value = Gu_version_TextBox.Text;
//            temp_data.Command = "005C";
//            data.Add(temp_data);
//            temp_data.Name = "PumpRek_TextBox";
//            temp_data.Value = PumpRek_TextBox.Text;
//            temp_data.Command = "005D";
//            data.Add(temp_data);
//            temp_data.Name = "oil_D_TextBox";
//            temp_data.Value = oil_D_TextBox.Text;
//            temp_data.Command = "0006";
//            data.Add(temp_data);
//            temp_data.Name = "oil_tank_T_Text";
//            temp_data.Value = oil_tank_T_Text.Text;
//            temp_data.Command = "0008";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_1_rail_pressure_TextBox";
//            temp_data.Value = fuel_1_rail_pressure_TextBox.Text;
//            temp_data.Command = "0009";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_2_rail_pressure_TextBox";
//            temp_data.Value = fuel_2_rail_pressure_TextBox.Text;
//            temp_data.Command = "000A";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_3_rail_pressure_TextBox";
//            temp_data.Value = fuel_3_rail_pressure_TextBox.Text;
//            temp_data.Command = "000B";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_4_rail_pressure_TextBox";
//            temp_data.Value = fuel_4_rail_pressure_TextBox.Text;
//            temp_data.Command = "000C";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_5_rail_pressure_TextBox";
//            temp_data.Value = fuel_5_rail_pressure_TextBox.Text;
//            temp_data.Command = "000D";
//            data.Add(temp_data);
//            temp_data.Name = "Oilk_TextBox";
//            temp_data.Value = Oilk_TextBox.Text;
//            temp_data.Command = "030D";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_6_rail_pressure_TextBox";
//            temp_data.Value = fuel_6_rail_pressure_TextBox.Text;
//            temp_data.Command = "000E";
//            data.Add(temp_data);
//            temp_data.Name = "PumpRek_TextBox";
//            temp_data.Value = PumpRek_TextBox.Text;
//            temp_data.Command = "030E";
//            data.Add(temp_data);
//            temp_data.Name = "fuel_7_rail_pressure_TextBox";
//            temp_data.Value = fuel_7_rail_pressure_TextBox.Text;
//            temp_data.Command = "000F";
//            data.Add(temp_data);

//            return data;
//        }
//    }
//}
