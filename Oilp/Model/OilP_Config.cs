using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/**
 * author:Slytherin
 * date:2018.04.23
 * entity of table config
 **/
namespace OilP.Model
{
    class OilP_Config
    {
        private string language;
        private int config_no;

        public string Language { get => language; set => language = value; }
        public int Config_no { get => config_no; set => config_no = value; }
    }
}
