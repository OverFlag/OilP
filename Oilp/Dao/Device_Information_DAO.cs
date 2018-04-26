using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OilP.Model;
using SqlSugar;
/**
* author:Slytherin
* date:2018.04.25
* Device_Information Table's QueryFunctions
* */
namespace OilP.Dao
{
    class Device_Information_DAO
    {
        /**
         * get all data from table
         **/
        public static List<Device_Information> QueryForAll()
        {
            List<Device_Information>  device_Information= new List<Device_Information>();
            SqlSugarClient db = DBConnect.GetInstance();
            device_Information = db.Queryable<Device_Information>().ToList();
            return device_Information;
        }

        /**
         * Get Data By Model_no And Manufacturer
         * */
        public static List<Device_Information> getDataByParams(String model_no, String manufacturer)
        {
            return null;
        }

        /**
         *Get Data By Type
         * */
        public static List<Device_Information> getDataByType(String type)
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            SqlSugarClient db = DBConnect.GetInstance();
            device_Information = db.Queryable<Device_Information>().Where(it => it.Type == type).ToList();
            return device_Information;
        }
    }
}
