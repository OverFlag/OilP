using OilP.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Dao
{
    class Code_Table_DAO
    {
        /**
         * Get Data By code
         * */
        public static List<Code_Table> getDataByParams(String code)
        {
            List<Code_Table> code_Tables = new List<Code_Table>();
            SqlSugarClient db = DBConnect.GetInstance();
            if (!"".Equals(code))
            {
                code_Tables = db.Queryable<Code_Table>().Where(it => it.Code == code).ToList();
            }
            else
            {
                return null;
            }
            return code_Tables;
        }
    }
}
