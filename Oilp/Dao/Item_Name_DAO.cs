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
* Item_Name Table's QueryFunctions
* */
namespace OilP.Dao
{
    class Item_Name_DAO
    {
        /**
         * get all data from table
         **/
        public static List<Item_Name> QueryForAll()
        {
            List<Item_Name> item_Names = new List<Item_Name>();
            SqlSugarClient db = DBConnect.GetInstance();
           item_Names =  db.Queryable<Item_Name>().ToList();
            return item_Names;
        }

        /**
         * get item names from table by type  zh_CN or en_US
         * e.g. index,cri,hpo...
         **/
        public static List<Item_Name> QueryByType(string type)
        {
            List<Item_Name> item_Names = new List<Item_Name>();
            SqlSugarClient db = DBConnect.GetInstance();
            item_Names = db.Queryable<Item_Name>().Where(it => it.Type == type).ToList();
            return item_Names;
        }
    }
}
