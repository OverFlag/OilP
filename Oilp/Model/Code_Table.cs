using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    class Code_Table
    {
        private String code;
        private String name;
        private DateTime create_time;
        private String op;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Create_time { get => create_time; set => create_time = value; }
        public string Op { get => op; set => op = value; }
    }
}
