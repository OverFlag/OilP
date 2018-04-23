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
        public  List<Item_Name> Init_Item_Name()
        {
            //Get Language Type
            OilP_Config oilP_Config = new OilP_Config();
            oilP_Config = OilP.Service.Oilp_Config_Service.getOilConfig();
            string language = oilP_Config.Language;
            //get item names
            List<Item_Name> item_Names = new List<Item_Name>();
            item_Names = OilP.Dao.Item_Name_DAO.QueryForAll();
            //set return list
            if ("zh_CN".Equals(language))
            {
                for (int i = 0; i < item_Names.Count/2;i=i+2)
                {
                    
                }
            }
            
            
            
            return item_Names;
        }
    }
}
