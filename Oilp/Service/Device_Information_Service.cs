using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using OilP.Model;
/**
 * author:Slytherin
 * date:2018.04.23
 **/
namespace OilP.Service
{
    class Device_Information_Service
    {
        /**
         * Get All Date From Table
         **/
        public static List<Device_Information> InitAll()
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            device_Information = OilP.Dao.Device_Information_DAO.QueryForAll();
            return device_Information;
        }

        /**
         * Get Data By Model_no And Manufacturer
         * */
        public static List<Device_Information> getDataByParams(String model_no,String manufacturer)
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            device_Information = OilP.Dao.Device_Information_DAO.getDataByParams(model_no, manufacturer);
            return device_Information;
        }

        /**
         *Get Data By Type
         * */
         public static List<Device_Information> getDataByType(String type)
        {
            List<Device_Information> device_Information = new List<Device_Information>();
            device_Information = OilP.Dao.Device_Information_DAO.getDataByType(type);
            return device_Information;
        }
    }
}