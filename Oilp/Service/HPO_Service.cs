using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Service
{
    class HPO_Service
    {
        /**
        * 通过model_no和step_name查询所单条数据
        **/
        public static HPO_Model QueryByModelNoAndStepName(string model_no, string step_name)
        {
            HPO_Model hPO_Model = new HPO_Model();
            hPO_Model = OilP.Dao.HPO_DAO.QueryByModelNoAndStepName(model_no, step_name);
            return hPO_Model;
        }

        /**
        * 通过model_no获取所有的step_name集合
        **/
        public static List<HPO_Model> QueryByModelNo(string model_no)
        {
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = OilP.Dao.HPO_DAO.QueryByModelNo(model_no);
            return hPO_Models;
        }

        /**
        * 添加数据
        * */
        public static string AddData(HPO_Model data, string model_no)
        {
            //判断是否是已经存在的测试步骤，根据step_name
            List<HPO_Model> hPO_Models = new List<HPO_Model>();
            hPO_Models = OilP.Dao.HPO_DAO.QueryByModelNo(model_no);
            for (int i = 0; i < hPO_Models.Count; i++)
            {
                if (hPO_Models[i].Step_name.ToLower().ToString().Equals(data.Step_name.ToLower().ToString()))
                {
                    return "测试步骤添加失败：已经存在该测试步骤！";
                }
            }
            bool flag = false;
            flag = OilP.Dao.HPO_DAO.AddData(data, model_no);
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
        public static bool DeleteData(string model_no, string step_name)
        {
            bool flag = false;
            flag = OilP.Dao.HPO_DAO.DeleteData(model_no, step_name);
            return flag;
        }

        /**
        * 根据model_no和step_name更新选中的数据
        * */
        public static bool UpdateData(HPO_Model hPO_Model)
        {
            bool flag = false;
            flag = OilP.Dao.HPO_DAO.UpdateData(hPO_Model);
            return flag;
        }
    }
}
