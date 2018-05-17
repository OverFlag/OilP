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
        public static Common_Rail_Injector_Test QueryByModelNoAndStepName(string model_no ,string step_name)
        {
            Common_Rail_Injector_Test common_Rail_Injector_Test = new Common_Rail_Injector_Test();
            SqlSugarClient db = DBConnect.GetInstance();
            //查询单条，不用single，single超过一条会报错。
            common_Rail_Injector_Test = db.Queryable<Common_Rail_Injector_Test>().Where(it => it.Model_no == model_no && it.Step_name == step_name).First();
            return common_Rail_Injector_Test;
        }

        /**
       * 根据model_no获取数据集合
       **/
        public static List<Common_Rail_Injector_Test> QueryByModelNo(string model_no)
        {
            List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
            SqlSugarClient db = DBConnect.GetInstance();
            common_Rail_Injector_Tests = db.Queryable<Common_Rail_Injector_Test>().Where(it=>it.Model_no==model_no).ToList();
            return common_Rail_Injector_Tests;
        }

        /**
      * 新增数据
      **/
        public static bool AddData (Common_Rail_Injector_Test data)
        {
            bool flag = false;
           SqlSugarClient db = DBConnect.GetInstance();
            flag = db.Insertable(data).ExecuteCommandIdentityIntoEntity();
            return true;
        }
    }
}
