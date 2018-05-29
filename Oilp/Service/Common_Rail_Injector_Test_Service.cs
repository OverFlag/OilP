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
        //public static List<Common_Rail_Injector_Test> QueryForAll()
        //{
        //    List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
        //    common_Rail_Injector_Tests = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryForAll();
        //    return common_Rail_Injector_Tests;
        //}

        /**
         * 通过model_no和step_name查询所单条数据
        **/
        //public static Common_Rail_Injector_Test QueryByModelNoAndStepName(string model_no ,string step_name)
        //{
        //    Common_Rail_Injector_Test common_Rail_Injector_Test = new Common_Rail_Injector_Test();
        //    common_Rail_Injector_Test = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryByModelNoAndStepName(model_no,step_name);
        //    return common_Rail_Injector_Test;
        //}

        /**
         * 通过model_no和step_name查询所单条数据
        **/
        public static CRI_Model QueryByModelNoAndStepName(string model_no, string step_name)
        {
            CRI_Model cRI_Model = new CRI_Model();
            cRI_Model = OilP.Dao.CRI_DAO.QueryByModelNoAndStepName(model_no, step_name);
            return cRI_Model;
        }

        /**
      * 通过model_no获取所有的step_name集合
      **/
        //public static List<Common_Rail_Injector_Test> QueryByModelNo(string model_no)
        //{
        //    List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
        // common_Rail_Injector_Tests = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryByModelNo(model_no);
        //    return common_Rail_Injector_Tests;
        //}

        /**
     * 通过model_no获取所有的step_name集合
     **/
        public static List<CRI_Model> QueryByModelNo(string model_no)
        {
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            cRI_Models = OilP.Dao.CRI_DAO.QueryByModelNo(model_no);
            return cRI_Models;
        }

        /**
         * 添加数据
         * */
        //public static string AddData(Common_Rail_Injector_Test data,string model_no)
        //{
        //    //判断是否是已经存在的测试步骤，根据step_name
        //    List<Common_Rail_Injector_Test> common_Rail_Injector_Tests = new List<Common_Rail_Injector_Test>();
        //    common_Rail_Injector_Tests = OilP.Dao.Common_Rail_Injector_Test_DAO.QueryByModelNo(model_no);
        //    for (int i = 0; i < common_Rail_Injector_Tests.Count; i++)
        //    {
        //        if (common_Rail_Injector_Tests[i].Step_name.ToLower().ToString().Equals(data.Step_name.ToLower().ToString()))
        //        {
        //            return "测试步骤添加失败：已经存在该测试步骤！";
        //        }
        //    }
        //    bool flag = false;
        //    flag = OilP.Dao.Common_Rail_Injector_Test_DAO.AddData(data);
        //    if (flag)
        //    {
        //        return "测试步骤添加成功";
        //    }
        //    else
        //    {
        //        return "测试步骤添加失败";
        //    }
        //}

        /**
         * 添加数据
         * */
        public static string AddData(CRI_Model data, string model_no)
        {
            //判断是否是已经存在的测试步骤，根据step_name
            List<CRI_Model> cRI_Models = new List<CRI_Model>();
            cRI_Models = OilP.Dao.CRI_DAO.QueryByModelNo(model_no);
            for (int i = 0; i < cRI_Models.Count; i++)
            {
                if (cRI_Models[i].Step_name.ToLower().ToString().Equals(data.Step_name.ToLower().ToString()))
                {
                    return "测试步骤添加失败：已经存在该测试步骤！";
                }
            }
            bool flag = false;
            flag = OilP.Dao.CRI_DAO.AddData(data, model_no);
            if (flag)
            {
                return "测试步骤添加成功";
            }
            else
            {
                return "测试步骤添加失败";
            }
        }

        /**
         * 根据model_no和step_name删除数据
         * */
        //public static bool DeleteData(string model_no, string step_name)
        //{
        //    bool flag = false;
        //    flag = OilP.Dao.Common_Rail_Injector_Test_DAO.DeleteData(model_no, step_name);
        //    return flag;
        //}

        /**
        * 根据model_no和step_name删除数据
        * */
        public static bool DeleteData(string model_no, string step_name)
        {
            bool flag = false;
            flag = OilP.Dao.CRI_DAO.DeleteData(model_no, step_name);
            return flag;
        }

        /**
     * 根据model_no和step_name更新选中的数据
     * */
        //public static bool UpdateData(Common_Rail_Injector_Test common_Rail_Injector_Test)
        //{
        //    bool flag = false;
        //    flag = OilP.Dao.Common_Rail_Injector_Test_DAO.UpdateData(common_Rail_Injector_Test);
        //    return flag;
        //}

        /**
        * 根据model_no和step_name更新选中的数据
        * */
        public static bool UpdateData(CRI_Model cRI_Model)
        {
            bool flag = false;
            flag = OilP.Dao.CRI_DAO.UpdateData(cRI_Model);
            return flag;
        }

    }
}
