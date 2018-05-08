using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;
using SqlSugar;

namespace OilP.Dao
{
    class Common_Rail_Injector_Test_DAO
    {
        /**
       * get all data from table
       **/
        public static List<Common_Rail_Injector_Test> QueryForAll()
        {
            List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
            SqlSugarClient db = DBConnect.GetInstance();
            common_Rail_Injector_Tests = db.Queryable<Common_Rail_Injector_Test>().ToList();
            return common_Rail_Injector_Tests;
        }

        /**
         * 根据model_no和step_name获取数据
         * */
        public static Common_Rail_Injector_Test QueryByModelNo(string model_no ,string step_name)
        {
            Common_Rail_Injector_Test common_Rail_Injector_Test = new Common_Rail_Injector_Test();
            SqlSugarClient db = DBConnect.GetInstance();

            return common_Rail_Injector_Test;
        }
    }
}
