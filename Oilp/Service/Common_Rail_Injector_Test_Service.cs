using OilP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Service
{
    class Common_Rail_Injector_Test_Service
    {
        /**
      * get all data from table
      **/
        public static List<Common_Rail_Injector_Test> QueryForAll()
        {
            List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
            common_Rail_Injector_Tests = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryForAll();
            return common_Rail_Injector_Tests;
        }

        /**
         * 通过model_no和step_name查询所单条数据
        **/
        public static Common_Rail_Injector_Test QueryByModelNoAndStepName(string model_no ,string step_name)
        {
            Common_Rail_Injector_Test common_Rail_Injector_Test = new Common_Rail_Injector_Test();
            common_Rail_Injector_Test = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryByModelNoAndStepName(model_no,step_name);
            return common_Rail_Injector_Test;
        }

        /**
      * 通过model_no获取所有的step_name集合
      **/
        public static List<Common_Rail_Injector_Test> QueryByModelNo(string model_no)
        {
            List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
            common_Rail_Injector_Tests = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryByModelNo(model_no);
            return common_Rail_Injector_Tests;
        }

    }
}
