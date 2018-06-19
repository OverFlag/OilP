using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class SF485
    {
        private string strTimeStamp;
        private string strFirstByte;//0xFE from clint,0xEF from sever 
        private string strReadOrWrite;//0 read,1 write
        private string strBootLoader;//升级
        private string strPageSelect;//命令片选
        private string strOrder;//命令
        private string strDataPhysical;//数据
        private string strDataInner;//数据
        private string strCheckSum;//校验和
        private string strSendTime;//发送时机，在哪个状态下发送
        private string strChineseName;//中文名字
        private string strFormat;//数据格式
        private string strUnit;//数据单位
        private string strResolution;//数据分辨率，小数位数
        private string strConvertMatherd;//数据转换方式
        private bool bDataConvert;//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用

        public string StrTimeStamp { get => strTimeStamp; set => strTimeStamp = value; }
        public string StrFirstByte { get => strFirstByte; set => strFirstByte = value; }
        public string StrReadOrWrite { get => strReadOrWrite; set => strReadOrWrite = value; }
        public string StrBootLoader { get => strBootLoader; set => strBootLoader = value; }
        public string StrPageSelect { get => strPageSelect; set => strPageSelect = value; }
        public string StrOrder { get => strOrder; set => strOrder = value; }
        public string StrDataPhysical { get => strDataPhysical; set => strDataPhysical = value; }
        public string StrDataInner { get => strDataInner; set => strDataInner = value; }
        public string StrCheckSum { get => strCheckSum; set => strCheckSum = value; }
        public string StrSendTime { get => strSendTime; set => strSendTime = value; }
        public string StrChineseName { get => strChineseName; set => strChineseName = value; }
        public string StrFormat { get => strFormat; set => strFormat = value; }
        public string StrUnit { get => strUnit; set => strUnit = value; }
        public string StrResolution { get => strResolution; set => strResolution = value; }
        public string StrConvertMatherd { get => strConvertMatherd; set => strConvertMatherd = value; }
        public bool BDataConvert { get => bDataConvert; set => bDataConvert = value; }
    }
}
