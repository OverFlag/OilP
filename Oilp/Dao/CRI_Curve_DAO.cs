using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class CRI_Curve_DAO
    {
        /**
      * 读取曲线数据库
      **/
        public static List<CRI_Curve_Model> QueryAllCurves()
        {
            List<CRI_Curve_Model> cRI_Curve_Models = new List<CRI_Curve_Model>();
            string filePath = "../Data/CRI/CURVE.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.UTF8);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                CRI_Curve_Model cRI_Curve_Model = new CRI_Curve_Model();
                cRI_Curve_Model = StringToCRICurveModel(length, data);
                cRI_Curve_Models.Add(cRI_Curve_Model);
            }
            rd.Close();
            fs.Close();
            return cRI_Curve_Models;
        }

        /**
         * 根据曲线的名称获取曲线数据库的数据
         * */
        public static CRI_Curve_Model QueryByCurveName(string curve_name)
        {
            CRI_Curve_Model cRI_Curve_Model = new CRI_Curve_Model();
            List<CRI_Curve_Model> cRI_Curve_Models = new List<CRI_Curve_Model>();
            cRI_Curve_Models = QueryAllCurves();
            foreach (CRI_Curve_Model item in cRI_Curve_Models)
            {
                if (curve_name.Equals(item.Curve))
                {
                    return item;
                }
            }
            return cRI_Curve_Model;
        }

        public static CRI_Curve_Model StringToCRICurveModel(int length, string[] readline)
        {
            CRI_Curve_Model cRI_Curve_Model = new CRI_Curve_Model();
            cRI_Curve_Model.V_tisheng = readline[0];
            cRI_Curve_Model.V_xidong = readline[1];
            cRI_Curve_Model.V_baochi = readline[2];
            cRI_Curve_Model.A_tisheng = readline[3];
            cRI_Curve_Model.A_xidong = readline[4];
            cRI_Curve_Model.A_baochi = readline[5];
            cRI_Curve_Model.A_xidong_dev = readline[6];
            cRI_Curve_Model.A_baochi_dev = readline[7];
            cRI_Curve_Model.Chixu_time = readline[8];
            cRI_Curve_Model.Min_chixu_time= readline[9];
            cRI_Curve_Model.After_xidong = readline[10];
            cRI_Curve_Model.After_baochi = readline[11];
            cRI_Curve_Model.Fuya = readline[12];
            cRI_Curve_Model.Curve = readline[13];
            cRI_Curve_Model.Qieduan = readline[14];
            
            return cRI_Curve_Model;
        }
    }
}
