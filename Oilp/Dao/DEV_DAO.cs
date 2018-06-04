using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class DEV_DAO
    {
        /**
       * 根据type获取dev_info集合，取出的是txt文件中的所有数据
       **/
        public static List<DEV_I_Model> QueryByType(string type)
        {
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            /* type 转大写*/
            string H_type = type.ToUpper();

            string filePath = "../Data/"+ H_type + "/" + H_type + ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                DEV_I_Model dEV_I_Model = new DEV_I_Model();
                dEV_I_Model = StringToDEVModel(length, data);
                dEV_I_Models.Add(dEV_I_Model);
            }
            rd.Close();
            fs.Close();
            return dEV_I_Models;
        }

        /**
         * 根据manu品牌获取数据
         * 参数manu品牌类型，type所属设备类型
         * */
        public static List<DEV_I_Model> QueryByManu(string manu,string type)
        {
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            List<DEV_I_Model> retrun_list = new List<DEV_I_Model>();
            dEV_I_Models = QueryByType(type);
            //遍历匹配品牌类型，配对就放入return的list中
            foreach (DEV_I_Model item in dEV_I_Models)
            {
                if (manu.ToLower().Equals(item.Manufacturer.ToLower()))
                {
                    retrun_list.Add(item);
                }
            }
            return retrun_list;
        }

        /**
         * 根据manu品牌获取数据
         * 参数manu品牌类型，type所属设备类型
         * */
        public static List<DEV_I_Model> QueryByModelNo(string model_no, string type)
        {
            DEV_I_Model dEV_I_Model = new DEV_I_Model();        
            List<DEV_I_Model> dEV_I_Models = new List<DEV_I_Model>();
            List<DEV_I_Model> retrun_list = new List<DEV_I_Model>();
            dEV_I_Models = QueryByType(type);
            //遍历匹配传入的model_no，包含，配对就放入return的list中
            foreach (DEV_I_Model item in dEV_I_Models)
            {
                if (item.Model_no.ToLower().Contains(model_no.ToLower()))
                {
                    retrun_list.Add(item);
                }
            }
            return retrun_list;
        }



        public static DEV_I_Model StringToDEVModel(int length, string[] readline)
        {
            DEV_I_Model dEV_I_Model = new DEV_I_Model();
            dEV_I_Model.Model_no = readline[0];
            dEV_I_Model.Manufacturer = readline[1];
            dEV_I_Model.Version = readline[2];
            dEV_I_Model.Create_time = readline[3];
            dEV_I_Model.Type = readline[4];
            dEV_I_Model.Description = readline[5];
            return dEV_I_Model;
        }

        /**
       * 根据type获取该类型的Histoyry集合，取出的是txt文件中的所有数据
       **/
        public static List<HIS_Model> QueryHistoryByType(string type)
        {
            List<HIS_Model> hIS_Models = new List<HIS_Model>();
            /* type 转大写*/
            string H_type = type.ToUpper();

            string filePath = "../Data/" + H_type + "/HISTORY.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;

          
            while ((readLine = rd.ReadLine()) != null)
            {
                HIS_Model temp = new HIS_Model();
                temp.Model_no = readLine;
                hIS_Models.Add(temp);
            }
            rd.Close();
            fs.Close();
            return hIS_Models;
        }


        /**
      * 根据type类型，往history文件中写入数据
      **/
        public static bool WriteToHistory(string type, HIS_Model hIS_Model)
        {
            List<HIS_Model> hIS_Models = new List<HIS_Model>();
            hIS_Models = QueryHistoryByType(type);
            bool flag = false;
            /* type 转大写*/
            string H_type = type.ToUpper();
            string filePath = "../Data/"+H_type+ "/HISTORY.txt";       
            FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite);
            StreamWriter wr = new StreamWriter(fs, Encoding.UTF8);

            //先写入新的一条记录放在开头
            wr.WriteLine(hIS_Model.Model_no);

            //写入之前的99条记录，超过100条的记录会被覆盖
           
            int i = 1;
            foreach (HIS_Model item in hIS_Models)
            {
                
                wr.WriteLine(item.Model_no);
                i++;
                if (i>=99)
                {
                    break;
                }
            }
            wr.Close();
            fs.Close();
            return true;
        }

        /**
        * 将list写入指定txt文件
        * */
        public static void WriteListToTxt(string type, List<CRI_Model> cRI_Models)
        {
            
        }


    }
}
