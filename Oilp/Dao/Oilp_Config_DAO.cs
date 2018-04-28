using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;
using SqlSugar;
/**
* author:Slytherin
* date:2018.04.23
* Config Table's QueryFunctions(In order to distinguish Config.cs from Config table,use Oilp as the prefix)
**/
namespace OilP.Dao
{
    class Oilp_Config_DAO
    {
        /**
         * get all data from table
         **/
        public static List<OilP_Config> QueryForAll()
        {
            List<OilP_Config> oilP_Configs = new List<OilP_Config>();
            SqlSugarClient db = DBConnect.GetInstance();
            oilP_Configs = db.Queryable<OilP_Config>().ToList();
            return oilP_Configs;
        }

        /**
            * update the config 
          * */
          public static void updateConfig(OilP_Config oilP_Config)
        {
            List<OilP_Config> oilP_Configs = new List<OilP_Config>();
            SqlSugarClient db = DBConnect.GetInstance();
            //updata one object
            db.Updateable(oilP_Config).ExecuteCommand();
            //update one column
            //db.Updateable(oilP_Config).UpdateColumns(it => new { it.Language }).ExecuteCommand();
        }
    }
}
