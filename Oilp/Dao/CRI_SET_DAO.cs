using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class CRI_SET_DAO
    {
        public static string suffix = ".EQCRI";
        /**
         * 读取设置文件信息
         * */
        public static CRI_SET QueryCriSetting()
        {
            CRI_SET cRI_SET=  new CRI_SET();
            string filePath = "../Data/CRI/SET" + suffix;
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;

                cRI_SET = StringToCRISet(length, data);
              
            }
            rd.Close();
            fs.Close();
            return cRI_SET;
        }

        /**
       * 更新设置数据
     * */
        public static bool UpdateData(CRI_SET cRI_SET)
        {
            //将传入的CRI_SET写入
            WriteListToTxt(cRI_SET);
            return true;
        }

        /**
        * 将list写入指定txt文件
        * */
        public static void WriteListToTxt(CRI_SET cRI_SET)
        {
            string filePath = "../Data/CRI/SET" + suffix;
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);      
            string write_string = GetEntityToString(cRI_SET);
            wr.WriteLine(write_string);
            wr.Close();
            fs.Close();
        }


        /**
     * 通过反射将实体类转化成string字符串
     * */
        public static string GetEntityToString(CRI_SET t)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            Type type = t.GetType();
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                //带变量名的字符串
                //sb.Append(propertyInfos[i].Name + ":" + propertyInfos[i].GetValue(t, null) + ",");
                //不带变量名的字符串
                sb.Append(propertyInfos[i].GetValue(t, null) + ",");
            }
            return sb.ToString().TrimEnd(new char[] { ',' });
        }

        public static CRI_SET StringToCRISet(int length, string[] readline)
        {
            CRI_SET cRI_SET = new CRI_SET();
            cRI_SET.Oil_tank_T = readline[0];
            cRI_SET.Fuel_P = readline[1];
            cRI_SET.Fuel_I = readline[2];
            cRI_SET.Fuel_D = readline[3];
            cRI_SET.Oil_P = readline[4];
            cRI_SET.Oil_I = readline[5];
            cRI_SET.Oil_D = readline[6];
            cRI_SET.RY_T1 = readline[7];
            cRI_SET.JY_T1 = readline[8];
            cRI_SET.RY_T_deviation1 = readline[9];
            cRI_SET.JY_T_deviation1 = readline[10];
            cRI_SET.Flow_c1_r1 = readline[11];
            cRI_SET.Flow_c1_r2 = readline[12];
            cRI_SET.Flow_c1_r3 = readline[13];
            cRI_SET.Flow_c1_r4 = readline[14];
            cRI_SET.Flow_c1_r5 = readline[15];
            cRI_SET.Flow_c1_r6 = readline[16];
            cRI_SET.Flow_c2_r1 = readline[17];
            cRI_SET.Flow_c2_r2 = readline[18];
            cRI_SET.Flow_c2_r3 = readline[19];
            cRI_SET.Flow_c2_r4 = readline[20];
            cRI_SET.Flow_c2_r5 = readline[21];
            cRI_SET.Flow_c2_r6 = readline[22];
            cRI_SET.Flow_c3_r1 = readline[23];
            cRI_SET.Flow_c3_r2 = readline[24];
            cRI_SET.Flow_c3_r3 = readline[25];
            cRI_SET.Flow_c3_r4 = readline[26];
            cRI_SET.Flow_c3_r5 = readline[27];
            cRI_SET.Flow_c3_r6 = readline[28];
            cRI_SET.Flow_c4_r1 = readline[29];
            cRI_SET.Flow_c4_r2 = readline[30];
            cRI_SET.Flow_c4_r3 = readline[31];
            cRI_SET.Flow_c4_r4 = readline[32];
            cRI_SET.Flow_c4_r5 = readline[33];
            cRI_SET.Flow_c4_r6 = readline[34];
            cRI_SET.Fuel_1_rail_pressure = readline[35];
            cRI_SET.Fuel_2_rail_pressure = readline[36];
            cRI_SET.Fuel_3_rail_pressure = readline[37];
            cRI_SET.Fuel_4_rail_pressure = readline[38];
            cRI_SET.Fuel_5_rail_pressure = readline[39];
            cRI_SET.Fuel_6_rail_pressure = readline[40];
            cRI_SET.Fuel_7_rail_pressure = readline[41];
            cRI_SET.Oil_1_rail_pressure = readline[42];
            cRI_SET.Oil_2_rail_pressure = readline[43];
            cRI_SET.Oil_3_rail_pressure = readline[44];
            cRI_SET.Oil_4_rail_pressure = readline[45];
            cRI_SET.Oil_5_rail_pressure = readline[46];
            cRI_SET.Gu_version = readline[47];
            cRI_SET.Sys_version = readline[48];
            cRI_SET.Oilk = readline[49];
            cRI_SET.Pumpinjk = readline[50];
            cRI_SET.PumpRek = readline[51];
            cRI_SET.Fuel_heat = readline[52];
            cRI_SET.Rail_pressure_group = readline[53];

            return cRI_SET;
        }
  
    }
}
