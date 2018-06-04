using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class LAN_Dao
    {
        /**
       * 根据type获取该种类型的中英文
       **/
        public static List<LAN_Model> QueryByType(string type)
        {
            List<LAN_Model> lAN_Models = new List<LAN_Model>();
            /* type 转大写*/
            string H_type = type.ToUpper();

            string filePath = "../Data/LANGUAGE/"+ H_type + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.Default);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                LAN_Model lAN_Model = new LAN_Model();
                lAN_Model = StringToLANModel(length, data);
                lAN_Models.Add(lAN_Model);
            }
            rd.Close();
            fs.Close();
            return lAN_Models;
        }

        /**
         * 字符串转换成Model
         * */
        public static LAN_Model StringToLANModel(int length, string[] readline)
        {
            LAN_Model lAN_Model = new LAN_Model();
            lAN_Model.Item_name = readline[0];
            lAN_Model.Language = readline[1];
            lAN_Model.Type = readline[2];
            return lAN_Model;
        }

        /**
         * 获取config的信息key value
         * */
        public static List<CONFIG_Model> QueryConfig()
        {
            List<CONFIG_Model> cONFIG_Models = new List<CONFIG_Model>();

            string filePath = "../Data/CONFIG/CONFIG.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                CONFIG_Model cONFIG_Model = new CONFIG_Model();
                cONFIG_Model = StringToCONFIGModel(length, data);
                cONFIG_Models.Add(cONFIG_Model);
            }
            rd.Close();
            fs.Close();
            return cONFIG_Models;
        }

        /**
         * 字符串转换成Model
         * */
        public static CONFIG_Model StringToCONFIGModel(int length, string[] readline)
        {
            CONFIG_Model cONFIG_Model = new CONFIG_Model();
            cONFIG_Model.Name = readline[0];
            cONFIG_Model.Value = readline[1];
            return cONFIG_Model;
        }


        /**
         * 更新配置文件
       * */
        public static bool UpdateConfig(CONFIG_Model cONFIG_Model)
        {
            //读取当前配置文件
            List<CONFIG_Model> cONFIG_Models = new List<CONFIG_Model>();
            cONFIG_Models = QueryConfig();
            //将config_model更新进list
            for (int i = 0; i < cONFIG_Models.Count; i++)
            {
                if (cONFIG_Model.Name.Equals(cONFIG_Models[i].Name))
                {
                    cONFIG_Models[i] = cONFIG_Model;
                }
            }
            WriteListToTxt(cONFIG_Models);
            return true;
        }

        /**
     * 将list写入指定txt文件
     * */
        public static void WriteListToTxt( List<CONFIG_Model> cONFIG_Models)
        {
            string filePath = "../Data/CONFIG/CONFIG.txt";
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);
            foreach (CONFIG_Model item in cONFIG_Models)
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
        public static string GetEntityToString(CONFIG_Model t)
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

        
    }
}
