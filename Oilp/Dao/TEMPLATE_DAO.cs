using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;

namespace OilP.Dao
{
    class TEMPLATE_DAO
    {
        /**
       * 根据type和模板编号获取模板信息
       **/
        public static List<TEMPLATE_Model> QueryByTypeAndTEMPNo(string type,string no)
        {
            List<TEMPLATE_Model> tEMPLATE_Models = new List<TEMPLATE_Model>();
            /* type 转大写*/
            string H_type = type.ToUpper();

            string filePath = "../Data/TPL/" + H_type +"/"+no+ ".txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.Default);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                string[] data = readLine.Split(',');
                int length = data.Length;
                TEMPLATE_Model tEMPLATE_Model = new TEMPLATE_Model();
                tEMPLATE_Model = StringToTEMPLATEModel(length, data);
                tEMPLATE_Models.Add(tEMPLATE_Model);
            }
            rd.Close();
            fs.Close();
            return tEMPLATE_Models;
        }

        public static TEMPLATE_Model StringToTEMPLATEModel(int length, string[] readline)
        {
            TEMPLATE_Model tEMPLATE_Model = new TEMPLATE_Model();

            tEMPLATE_Model.Manufacturer = readline[0];
            tEMPLATE_Model.Curve = readline[1];
            tEMPLATE_Model.Step_name = readline[2];
            tEMPLATE_Model.Round_speed = readline[3];
            tEMPLATE_Model.Oil_p_standard = readline[4];
            tEMPLATE_Model.Oil_p_deviation = readline[5];
            tEMPLATE_Model.Oil_h_standard = readline[6];
            tEMPLATE_Model.Oil_h_deviation = readline[7];
            tEMPLATE_Model.Pulse_width = readline[8];
            tEMPLATE_Model.Rail_pressure = readline[9];
            tEMPLATE_Model.Oil_j_pressure = readline[10];
            tEMPLATE_Model.Oil_h_pressure = readline[11];
            tEMPLATE_Model.Punmp_pressure = readline[12];
            tEMPLATE_Model.Control_last_time = readline[13];
            tEMPLATE_Model.Voltage = readline[14];
            tEMPLATE_Model.Oil_tank_T = readline[15];
            tEMPLATE_Model.Oil_j_T = readline[16];
            tEMPLATE_Model.Oil_h_T = readline[17];
            return tEMPLATE_Model;
        }

        /**
         * 获取template的列表
         * */
        public static List<string> QueryTEMPListByType(string type)
        {
            List<string> templateList = new List<string>();
            /* type 转大写*/
            string H_type = type.ToUpper();

            string filePath = "../Data/TPL/" + H_type + "/LIST.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);

            StreamReader rd = new StreamReader(fs, Encoding.Default);
            string readLine;
            while ((readLine = rd.ReadLine()) != null)
            {
                templateList.Add(readLine);
            }
            rd.Close();
            fs.Close();
            return templateList;
        }
    }
}
