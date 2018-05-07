using OilP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Dao;

namespace OilP.Service
{
    class Code_Table_Service
    {
        /**
         * Get Data By code
         * */
        public static List<Code_Table> getDataByParams(String code)
        {
            List<Code_Table> code_Tables = new List<Code_Table>();
            code_Tables = Code_Table_DAO.getDataByParams(code);
            return code_Tables;
        }
    }
}
