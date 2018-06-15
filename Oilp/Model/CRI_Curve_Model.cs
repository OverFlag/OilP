using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class CRI_Curve_Model
    {
        private string v_tisheng;
        private string v_xidong;
        private string v_baochi;
        private string a_tisheng;
        private string a_xidong;
        private string a_baochi;
        private string a_xidong_dev;
        private string a_baochi_dev;
        private string chixu_time;
        private string min_chixu_time;
        private string after_xidong;
        private string after_baochi;
        private string fuya;
        private string curve;
        private string qieduan;

        public string V_tisheng { get => v_tisheng; set => v_tisheng = value; }
        public string V_xidong { get => v_xidong; set => v_xidong = value; }
        public string V_baochi { get => v_baochi; set => v_baochi = value; }
        public string A_tisheng { get => a_tisheng; set => a_tisheng = value; }
        public string A_xidong { get => a_xidong; set => a_xidong = value; }
        public string A_baochi { get => a_baochi; set => a_baochi = value; }
        public string A_xidong_dev { get => a_xidong_dev; set => a_xidong_dev = value; }
        public string A_baochi_dev { get => a_baochi_dev; set => a_baochi_dev = value; }
        public string Chixu_time { get => chixu_time; set => chixu_time = value; }
        public string Min_chixu_time { get => min_chixu_time; set => min_chixu_time = value; }
        public string After_xidong { get => after_xidong; set => after_xidong = value; }
        public string After_baochi { get => after_baochi; set => after_baochi = value; }
        public string Fuya { get => fuya; set => fuya = value; }
        public string Curve { get => curve; set => curve = value; }
        public string Qieduan { get => qieduan; set => qieduan = value; }
    }
}
