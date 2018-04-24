using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;
/**
 * author:Slytherin
 * date:2018.04.23
 **/
 
namespace OilP.Service
{
    class Item_Name_Service
    {
        /**
         * get names according to language
         **/
        public  static List<Item_Name> Init_Item_Name()
        {
            //Get Language Type
            OilP_Config oilP_Config = new OilP_Config();
            oilP_Config = OilP.Service.Oilp_Config_Service.getOilConfig();
            string language = oilP_Config.Language;
            //get item names
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Dao.Item_Name_DAO.QueryForAll();
            //set return list
            List<Item_Name> return_list = new List<Item_Name>();
            if ("zh_CN".Equals(language))
            {
                for (int i = 0; i <= item_Names.Count;i=i+2)
                {
                    Item_Name temp = new Item_Name();
                    temp = item_Names[i];
                    return_list.Add(temp);
                }
            }
            else
            {
                for (int i = 1; i <= item_Names.Count; i = i + 2)
                {
                    Item_Name temp = new Item_Name();
                    temp = item_Names[i];
                    return_list.Add(temp);
                }
            }     
            return return_list;
        }
    }
}
