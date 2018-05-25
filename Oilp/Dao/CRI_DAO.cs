using OilP.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Dao
{
    class CRI_DAO
    {

        /**
       * 根据model_no获取数据集合
       **/
        public static List<CRI_Model> QueryByModelNo(string model_no)
        {
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            string filePath = "../Data/CRI/"+ model_no + ".txt";
            FileStream fs = new FileStream(filePath,FileMode.Open,FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine=rd.ReadLine())!=null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                CRI_Model cRI_Model = new CRI_Model();
                cRI_Model = StringToCRIModel(length, data);
                cRI_Models.Add(cRI_Model);
            }
            rd.Close();
            fs.Close();       
            return cRI_Models;
        }

        /**
         * 根据model_no和step_name获取数据
         * */
        public static CRI_Model QueryByModelNoAndStepName(string model_no, string step_name)
        {
            CRI_Model cRI_Model = new CRI_Model();
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            cRI_Models = QueryByModelNo(model_no);
            //遍历取出step_name为传入值的数据
            foreach (CRI_Model item in cRI_Models)
            {
                if (step_name.Equals(item.Step_name))
                {
                    return item;
                }
            }
            return new CRI_Model();
        }

        /**
        * 新增测试步骤
        **/
        public static bool AddData(CRI_Model data,string model_no)
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
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            cRI_Models = QueryByModelNo(model_no);
            //删除需要移除的一个实例
            foreach (CRI_Model item in cRI_Models)
            {
                if (step_name.Equals(item.Step_name))
                {
                    //找到后删除该条测试步骤后跳出枚举
                    cRI_Models.Remove(item);
                    break;
                }
            }
            //写入txt文件
            WriteListToTxt(model_no, cRI_Models);
            return true;
        }

        /**
          * 根据model_no和step_name更新选中的数据
        * */
        public static bool UpdateData(CRI_Model cRI_Model)
        {
            //读取当前model_no的文件内容保存在list中
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            cRI_Models = QueryByModelNo(cRI_Model.Model_no);
            //将该测试步骤的数据更新进list
            for (int i = 0; i < cRI_Models.Count; i++)
            {
                if (cRI_Model.Step_name.Equals(cRI_Models[i].Step_name))
                {
                    cRI_Models[i] = cRI_Model;
                }
            }
            WriteListToTxt(cRI_Model.Model_no, cRI_Models);
            return true;
        }

        /**
          * 根据model_no和step_name更新选中的数据
        * */
        public List<string> GetManuNames(string device_name)
        {
            List<string> manu_names = new List<string>();

            return manu_names;
        }



        public static CRI_Model StringToCRIModel(int length, string[] readline)
        {
            CRI_Model cRI_Model = new CRI_Model();
            cRI_Model.Model_no = readline[0];
            cRI_Model.Manufacturer = readline[1];
            cRI_Model.Curve = readline[2];
            cRI_Model.Step_name = readline[3];
            cRI_Model.Round_speed = readline[4];
            cRI_Model.Oil_p_standard = readline[5];
            cRI_Model.Oil_p_deviation = readline[6];
            cRI_Model.Oil_h_standard = readline[7];
            cRI_Model.Oil_h_deviation = readline[8];
            cRI_Model.Pulse_width = readline[9];
            cRI_Model.Rail_pressure = readline[10];
            cRI_Model.Oil_j_pressure = readline[11];
            cRI_Model.Oil_h_pressure = readline[12];
            cRI_Model.Punmp_pressure = readline[13];
            cRI_Model.Control_last_time = readline[14];
            cRI_Model.Voltage = readline[15];
            cRI_Model.Oil_tank_T = readline[16];
            cRI_Model.Oil_j_T = readline[17];
            cRI_Model.Oil_h_T = readline[18];
            return cRI_Model;
        }


        /**
         * 通过反射将实体类转化成string字符串
         * */
        public static string GetEntityToString(CRI_Model t)
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

        /**
         * 将list写入指定txt文件
         * */
         public static void WriteListToTxt(string model_no,List<CRI_Model> cRI_Models)
        {
            string filePath = "../Data/CRI/" + model_no + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
            foreach (CRI_Model item in cRI_Models)
            {
                string write_string = GetEntityToString(item);
                wr.WriteLine(write_string);
            }
            wr.Close();
            fs.Close();
        }
    }
}
