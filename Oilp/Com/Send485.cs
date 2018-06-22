using Oilp.Com;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Com
{
    public class Send485
    {
        /**
         * List<SettingModel>转换成list<StructShowData>
         * */
        public static List<StructShowData> SettingModelToStructShowData(List<Setting_Model> setting_Models)
        {
            List<StructShowData> retrunData = new List<StructShowData>();
            foreach (Setting_Model item in setting_Models)
            {
                StructShowData temp = new StructShowData();
                temp.strOrderAndPageSelect = item.Command;
                temp.strData = item.Value;
                retrunData.Add(temp);
                
            }        
            return retrunData;
        }
        /**
         * 根据片选和偏移匹配命令并为命令值赋值
         * */
         public static List<StructFrame485> MatchOrder(List<Setting_Model> setting_Models,int match_type)
        {
            List<StructFrame485> structFrame485s = new List<StructFrame485>();
            /*获取待匹配的StructFrame485*/
            support Support = support.GetInstance();
            structFrame485s = Support.llisstruRs485Frame[match_type];
            foreach (Setting_Model set in setting_Models)
            {
                for (int i = 0; i < structFrame485s.Count; i++)
                {
                    string commond = structFrame485s[i].strPageSelect + structFrame485s[i].strOrder;
                    if (commond.Equals(set.Command))
                    {
                        StructFrame485 temp = new StructFrame485();
                        temp.strDataPhysical = set.Value;
                        structFrame485s[i] = temp;
                    }
                }            
            }
            return structFrame485s;
        }

        /**
         * 循环发送，根据传入的发送时机和setting_models
         **/
         public static  List<StructFrame485> CycleSend(int send_type, List<Setting_Model> setting_Models)
        {
            RS485Communicate send = new RS485Communicate();
            /* 获取List<StructShowData>参数*/
            List<StructShowData> showDatas = new List<StructShowData>();
            showDatas = SettingModelToStructShowData(setting_Models);
            /* 获取 List<StructFrame485>参数*/
            List<StructFrame485> structFrame485s = new List<StructFrame485>();
            structFrame485s = MatchOrder(setting_Models, send_type);
            /*发送报文*/
            send.CycleSendFrame(showDatas, send_type,ref structFrame485s);

            /*返回实参structFrame485s，其中包含了下位机返回的数值*/
            return structFrame485s;
        }
    }
}
