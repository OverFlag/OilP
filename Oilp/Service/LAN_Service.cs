using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Service
{
    class LAN_Service
    {
        /**
        * 获取配置文件
        **/
        public static CONFIG_Model GetLanConfig()
        {
            List<CONFIG_Model> cONFIG_Models = new List<CONFIG_Model>();
            cONFIG_Models = Dao.LAN_Dao.QueryConfig();
            CONFIG_Model cONFIG_Model = new CONFIG_Model();
            foreach (CONFIG_Model item in cONFIG_Models)
            {
                if ("language".Equals(item.Name))
                {
                    cONFIG_Model.Name = item.Name;
                    cONFIG_Model.Value = item.Value;
                }
            }           
            return cONFIG_Model;
        }

        /**
         * 更新配置文件 
         * */
        public static void UpdateConfig(CONFIG_Model cONFIG_Model)
        {
            Dao.LAN_Dao.UpdateConfig(cONFIG_Model);
        }

        /**
         * 获取界面元素中英文
         **/
        public static List<LAN_Model> Init_Item_Name(string type)
        {
            //Get Language Type
            CONFIG_Model cONFIG_Model = new CONFIG_Model();
            cONFIG_Model = GetLanConfig();
            string language = cONFIG_Model.Value;
            //get item names
            List<LAN_Model> lAN_Models = new List<LAN_Model>();
            lAN_Models = OilP.Dao.LAN_Dao.QueryByType(type);
            //set return list
            List<LAN_Model> return_list = new List<LAN_Model>();
            if ("zh_CN".Equals(language))
            {
                for (int i = 0; i < lAN_Models.Count; i = i + 2)
                {
                    LAN_Model temp = new LAN_Model();
                    temp = lAN_Models[i];
                    return_list.Add(temp);
                }
            }
            else
            {
                for (int i = 1; i <= lAN_Models.Count; i = i + 2)
                {
                    LAN_Model temp = new LAN_Model();
                    temp = lAN_Models[i];
                    return_list.Add(temp);
                }
            }
            return return_list;
        }
    }
}
