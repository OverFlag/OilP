using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class HPO_DAO
    {
        /**
      * 根据model_no获取数据集合
      **/
        public static List<HPO_Model> QueryByModelNo(string model_no)
        {
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            string filePath = "../Data/CRI/" + model_no + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                HPO_Model hPO_Model = new HPO_Model();
                hPO_Model = StringToHPOModel(length, data);
                hPO_Models.Add(hPO_Model);
            }
            rd.Close();
            fs.Close();
            return hPO_Models;
        }


        /**
        * 根据model_no和step_name获取数据
        * */
        public static HPO_Model QueryByModelNoAndStepName(string model_no, string step_name)
        {
            HPO_Model hPO_Model = new HPO_Model();
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = QueryByModelNo(model_no);
            //遍历取出step_name为传入值的数据
            foreach (HPO_Model item in hPO_Models)
            {
                if (step_name.Equals(item.Step_name))
                {
                    return item;
                }
            }
            return new HPO_Model();
        }

        /**
        * 新增测试步骤
        **/
        public static bool AddData(HPO_Model data, string model_no)
        {
            bool flag = false;
            string filePath = "../Data/CRI/" + model_no + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
            //写入末尾
            string data_string = GetEntityToString(data);
            wr.BaseStream.Seek(0, SeekOrigin.End);

            wr.WriteLine(data_string);
            wr.Close();
            fs.Close();

            return true;
        }

        /**
     * 根据model_no和step_name删除选中的测试步骤
     * */
        public static bool DeleteData(string model_no, string step_name)
        {
            //读取当前model_no的文件内容保存在list中
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = QueryByModelNo(model_no);
            //删除需要移除的一个实例
            foreach (HPO_Model item in hPO_Models)
            {
                if (step_name.Equals(item.Step_name))
                {
                    //找到后删除该条测试步骤后跳出枚举
                    hPO_Models.Remove(item);
                    break;
                }
            }
            //写入txt文件
            WriteListToTxt(model_no, hPO_Models);
            return true;
        }

        /**
          * 根据model_no和step_name更新选中的数据
        * */
        public static bool UpdateData(HPO_Model hPO_Model)
        {
            //读取当前model_no的文件内容保存在list中
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = QueryByModelNo(hPO_Model.Model_no);
            //将该测试步骤的数据更新进list
            for (int i = 0; i < hPO_Models.Count; i++)
            {
                if (hPO_Model.Step_name.Equals(hPO_Models[i].Step_name))
                {
                    hPO_Models[i] = hPO_Model;
                }
            }
            WriteListToTxt(hPO_Model.Model_no, hPO_Models);
            return true;
        }

        /**
       * 将list写入指定txt文件
       * */
        public static void WriteListToTxt(string model_no, List<HPO_Model> hPO_Models)
        {
            string filePath = "../Data/CRI/" + model_no + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
            foreach (HPO_Model item in hPO_Models)
            {
                string write_string = GetEntityToString(item);
                wr.WriteLine(write_string);
            }
            
            wr.Close();
            fs.Close();
        }

        /**
         * 通过反射将实体类转化成string字符串
         * */
        public static string GetEntityToString(HPO_Model t)
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

        public static HPO_Model StringToHPOModel(int length, string[] readline)
        {
            HPO_Model hPO_Model = new HPO_Model();
            hPO_Model.Model_no = readline[0];
            hPO_Model.Manufacturer = readline[1];
            hPO_Model.Curve = readline[2];
            hPO_Model.Step_name = readline[3];
            hPO_Model.Round_speed = readline[4];
            hPO_Model.Drv_a = readline[5];
            hPO_Model.Rail_pressure = readline[6];
            hPO_Model.Oil_p_standard = readline[7];
            hPO_Model.Oil_p_deviationr = readline[8];
            hPO_Model.Oil_h_standard = readline[9];
            hPO_Model.Oil_h_deviationr = readline[10];
            hPO_Model.Start_angle = readline[11];
            hPO_Model.Voltage = readline[12];
            hPO_Model.Oil_j_pressure = readline[13];
            hPO_Model.Oil_h_pressure = readline[14];
            hPO_Model.Pump_pressure = readline[15];
            hPO_Model.Motor_steering = readline[16];
            hPO_Model.Test_time = readline[17];
           
            return hPO_Model;
        }
    }
}
