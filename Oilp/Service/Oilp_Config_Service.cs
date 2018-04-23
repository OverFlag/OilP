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
    class Oilp_Config_Service
    {
        /**
         * get DB Config Table data
         **/
        public static OilP_Config getOilConfig()
        {
            List<OilP_Config> oilP_Configs = new List<OilP_Config>();          
            oilP_Configs = OilP.Dao.Oilp_Config_DAO.QueryForAll();
            //get the first element
            OilP_Config oilP_Config = new OilP_Config();
            oilP_Config = oilP_Configs[0];
            return oilP_Config;
        }
    }
}
