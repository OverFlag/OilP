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

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
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

        public static LAN_Model StringToLANModel(int length, string[] readline)
        {
            LAN_Model lAN_Model = new LAN_Model();
            lAN_Model.Item_name = readline[0];
            lAN_Model.Language = readline[1];
            lAN_Model.Type = readline[2];
            return lAN_Model;
        }
    }
}
