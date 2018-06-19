using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Windows.Forms;

namespace Oilp.Com
{
    public class support
    {

        private static support instance;
        private static object _lock = new object();
        private int iNumOfOptionToRecord = 0;//记录操作记录条数


        #region//主要参数
        public List<StructFrame485>[] llisstruRs485Frame = new List<StructFrame485>[5];//读取并用Congfig文件中的信息初始化发动机的结构体数组。0主/设置界面，1数据库界面，2，检测界面，3点启动按键，4停止/急停
        public List<StructShowData> lisstruShowData = new List<StructShowData>();//用于显示数据，提取转换方式和变量类型来计算

        public List<Setting_Model> lisstruSettingModelRead = new List<Setting_Model>();//用于从界面提取数据和向界面标签赋值
        public List<Setting_Model> lisstruSettingModelWrite = new List<Setting_Model>();//用于从界面提取数据和向界面标签赋值
        //主界面
        #endregion
        string strConfigFilePath = Application.StartupPath + "\\Config-new.xml";
        int iRecordNum = 0;//记录底层接收的报文计数
        List<string> lsRecordLogString = new List<string>();//存储记录底层报文
        //List<string> lsRecordParaString = new List<string>();//存储记录底层报文
        List<string> lstrCollect = new List<string>();//存储要记录的语句，用于集中记录-倾角信息
        //List<string> lstrCollectInclo = new List<string>();//用于FFTDrawTest中的精确高频率倾角数值
        //private int iNumOfInclinationToRecord = 0;//记录倾角信息条数
        XmlDocument xmldocumentConfig = new XmlDocument();//读取Config 文件
        List<string> lstrExceptionLastSentence = new List<string>();
        List<int> lintNumberOfSameException = new List<int>();
        public string strDataFileFoldPath = "";

        private support()
        {
            LoadConfig();
            string[] lstrTemp = Application.StartupPath.Split('\\');
            for (int i = 0; i < lstrTemp.Length - 1; i++)
            {
                strDataFileFoldPath += lstrTemp[i] + "\\";
            }
            CheckFileFolderAndCreat();
        }
        public static support GetInstance()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new support();
                    }
                }
            }
            return instance;
        }
        private void Message(Exception ex)
        {
            //MessageBox.Show(ex.ToString());
            //ErrorRecord(ex);
        }
        private void ErrorRecord(string ex)//记录程序崩溃时间及位置ex.tostring()
        {
            try
            {
                string strTemp = DateTime.Now.ToString("yyyyMMddhhmmss");

                StreamWriter Stresm_Writer = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + "ErrorRecordCatch" + strTemp.Substring(0, strTemp.Length - 6) + ".txt", true);
                Stresm_Writer.WriteLine(strTemp + " " + ex.ToString());
                Stresm_Writer.Close();
            }
            catch (Exception ee)
            {
                Message(ee);
            }
        }
        public void LoadConfig()
        {
            try
            {
                //iNumOfMainFram = 19;//MainFrame界面的配置条目数量
                xmldocumentConfig.Load(strConfigFilePath);
                XmlNode nodeMainFrame = xmldocumentConfig.SelectSingleNode("Config");
                #region//发动机信息、航海信息结构读取
                int iTempNodeCout = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes.Count - 1;
                for (int iFrameArry = 0; iFrameArry < llisstruRs485Frame.Length; iFrameArry++)
                {
                    llisstruRs485Frame[iFrameArry] = new List<StructFrame485>();
                }
                StructFrame485 struFrameData = new StructFrame485();
                StructShowData struShowdata1 = new StructShowData();
                Setting_Model struSettingMoelRead = new Setting_Model();
                Setting_Model struSettingMoelWrite = new Setting_Model();
                for (int i = 0; i < iTempNodeCout; i++)
                {
                    struFrameData = new StructFrame485();
                    struShowdata1 = new StructShowData();
                    struSettingMoelRead = new Setting_Model();
                    struSettingMoelWrite = new Setting_Model();
                    //struFrameData.strTimeStamp = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                    //struFrameData.strFirstByte = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                    struFrameData.strFirstByte = "FE";
                    struFrameData.strReadOrWrite = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[1].InnerText;
                    //struFrameData.strBootLoader = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                    struFrameData.strPageSelect = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[2].InnerText;
                    struFrameData.strOrder = Convert.ToInt32(nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText).ToString("X");
                    //struFrameData.strData = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                    //struFrameData.strCheckSum = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[0].InnerText;
                    struFrameData.strSendTime = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[3].InnerText;
                    struFrameData.strChineseName = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[4].InnerText;
                    struFrameData.strFormat = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[5].InnerText;
                    struFrameData.strUnit = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[6].InnerText;
                    struFrameData.strResolution = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[7].InnerText;
                    struFrameData.strConvertMatherd = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[8].InnerText;
                    switch (nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[3].InnerText)
                    {
                        case "主/设置界面":
                            llisstruRs485Frame[0].Add(struFrameData);
                            break;
                        case "数据库界面":
                            llisstruRs485Frame[1].Add(struFrameData);
                            break;
                        case "检测界面":
                            llisstruRs485Frame[2].Add(struFrameData);
                            break;
                        case "点启动按键":
                            llisstruRs485Frame[3].Add(struFrameData);
                            break;
                        case "停止/急停":
                            llisstruRs485Frame[4].Add(struFrameData);
                            break;
                        default:
                            break;
                    }
                    struShowdata1.strData = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[10].InnerText;
                    struShowdata1.strOrderAndPageSelect = struFrameData.strPageSelect.PadLeft(2, '0') + struFrameData.strOrder.PadLeft(2, '0');
                    struShowdata1.strFormat = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[5].InnerText;
                    struShowdata1.strUnit = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[6].InnerText;
                    struShowdata1.strResolution = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[7].InnerText;
                    struShowdata1.strConvertMatherd = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[8].InnerText;
                    lisstruShowData.Add(struShowdata1);

                    struSettingMoelRead.Name = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[12].InnerText;
                    struSettingMoelRead.Command = struShowdata1.strOrderAndPageSelect;
                    struSettingMoelRead.strSendTime = struFrameData.strSendTime;
                    lisstruSettingModelRead.Add(struSettingMoelRead);
                    struSettingMoelWrite.Name = nodeMainFrame.FirstChild.ChildNodes[0].ChildNodes[i].ChildNodes[12].InnerText;
                    struSettingMoelWrite.Command = struShowdata1.strOrderAndPageSelect;
                    struSettingMoelWrite.strSendTime = struFrameData.strSendTime;
                    lisstruSettingModelWrite.Add(struSettingMoelWrite);
                    //int iTempNodeCoutNMEA = nodeMainFrame.FirstChild.ChildNodes[iNumOfMainFram + 2].ChildNodes.Count - 1;
                    #endregion
                }
            }
            catch (Exception e)
            {
                FunShow(e);
            }
        }
        public void CheckFileFolderAndCreat()
        {
            if (Directory.Exists(strDataFileFoldPath + "DataLog") == false)//如果不存在就创建file文件夹
            {
                Directory.CreateDirectory(strDataFileFoldPath + "DataLog");
            }
        }
        public void FunShow(Exception ex)
        {
            bool bHaveSameException = false;
            string[] lstrException = ex.ToString().Split('\n');
            if (lstrExceptionLastSentence.Count > 0)
            {
                for (int i = 0; i < lstrExceptionLastSentence.Count; i++)
                {
                    if (lstrExceptionLastSentence[i] == lstrException[lstrException.Length - 1])
                    {
                        lintNumberOfSameException[i] = lintNumberOfSameException[i] + 1;
                        bHaveSameException = true;
                    }
                }
                if (bHaveSameException == false)
                {
                    lstrExceptionLastSentence.Add(lstrException[lstrException.Length - 1]);
                    lintNumberOfSameException.Add(1);
                    ErrorRecord(ex.ToString());
                }
            }
            else
            {
                lstrExceptionLastSentence.Add(lstrException[lstrException.Length - 1]);
                lintNumberOfSameException.Add(1);
                ErrorRecord(ex.ToString());
            }
            //ErrorRecord(ex);
            //MessageBox.Show(ex.ToString());
        }
        public void StopTestSaveAllData()
        {
            try
            {
                if (lintNumberOfSameException.Count > 0)
                {
                    for (int i = 0; i < lintNumberOfSameException.Count; i++)
                    {
                        if (lintNumberOfSameException[i] > 1)
                        {
                            ErrorRecord(lstrExceptionLastSentence[i] + "@@@@@@@@@@@@@" + lintNumberOfSameException[i].ToString() + "\n");
                        }
                    }
                }
                if (lsRecordLogString.Count > 0)
                {

                    StreamWriter Stresm_Writer3;

                    Stresm_Writer3 = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + "last" + ".txt", true);
                    for (int j = 0; j < lsRecordLogString.Count; j++)
                    {
                        Stresm_Writer3.WriteLine(lsRecordLogString[j]);
                    }
                    lsRecordLogString.Clear();
                    Stresm_Writer3.Close();
                }
            }
            catch (Exception ex)
            {
                ErrorRecord(ex.ToString());
            }
        }
        public void OpreationRecord(string strTempData)//操作记录，记录每一步按键操作。
        {
            try
            {
                string strRecord = "";
                string strTemp = DateTime.Now.ToString("yyyyMMddhhmmss");

                strRecord = strTemp + "--" + strTempData;
                StreamWriter Stresm_Writer = new StreamWriter(strDataFileFoldPath + "DataLog\\OperationRecord" + strTemp.Substring(0, strTemp.Length - 6) + ".txt", true);
                Stresm_Writer.WriteLine(strRecord);
                Stresm_Writer.Close();


            }
            catch (Exception ex)
            { FunShow(ex); }
        }
        public void FrameLog(List<byte> lsData, int iTraRec, string strTime)//记录底层接收的报文
        {
            try
            {
                string strTempData = "";
                StreamWriter Stresm_Writer3;
                iRecordNum++;
                if (iTraRec == 1)
                {
                    strTempData = strTime + " Tra" + iRecordNum.ToString() + " ";
                }
                else
                {
                    strTempData = strTime + " Rec" + iRecordNum.ToString() + " ";
                }
                for (int i = 0; i < lsData.Count; i++)
                {
                    strTempData += Convert.ToString(lsData[i], 16).PadLeft(2, '0') + " ";
                }

                lsRecordLogString.Add(strTempData);

                if (lsRecordLogString.Count > 500)
                {
                    Stresm_Writer3 = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + strTime.Substring(0, strTime.Length - 3) + ".txt", true);
                    for (int j = 0; j < lsRecordLogString.Count; j++)
                    {
                        Stresm_Writer3.WriteLine(lsRecordLogString[j]);
                    }
                    lsRecordLogString.Clear();
                    Stresm_Writer3.Close();
                }
            }
            catch (Exception ex)
            { FunShow(ex); }
        }
        public void FrameLog1(string strFrame, int iTraRec, string strTime)//记录底层接收的报文
        {
            try
            {
                StreamWriter Stresm_Writer3;
                string strTempData;
                iRecordNum++;
                if (iTraRec == 1)
                {
                    strTempData = strTime + " Tra " + iRecordNum.ToString() + " " + strFrame;
                }
                else
                {
                    strTempData = strTime + " Rec " + iRecordNum.ToString() + " " + strFrame;
                }
                lsRecordLogString.Add(strTempData);

                if (lsRecordLogString.Count > 0)
                {
                    Stresm_Writer3 = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + strTime.Substring(0, strTime.Length - 3) + ".txt", true);
                    for (int j = 0; j < lsRecordLogString.Count; j++)
                    {
                        Stresm_Writer3.WriteLine(lsRecordLogString[j]);
                    }
                    lsRecordLogString.Clear();
                    Stresm_Writer3.Close();
                }
            }
            catch (Exception ex)
            { FunShow(ex); }
        }
        public void ErrorRecordString(string ex)//记录出现异常时间及位置
        {
            try
            {
                string strTemp = DateTime.Now.ToString("yyyyMMddhhmmss");
                StreamWriter Stresm_Writer = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + "WrongRecordString" + strTemp.Substring(0, strTemp.Length - 6) + ".txt", true);
                Stresm_Writer.WriteLine(strTemp + " " + ex);
                Stresm_Writer.Close();
            }
            catch (Exception ee)
            {
                ErrorRecord(ee.ToString());
            }
        }
        public void ConfigModifyRecord(string strModifyRecord)//记录config文件修改情况
        {
            try
            {
                string strTemp = DateTime.Now.ToString("yyyyMMddhhmmss");
                StreamWriter Stresm_Writer3;
                lstrCollect.Add(DateTime.Now.Minute.ToString().PadLeft(2, '0') + DateTime.Now.Second.ToString().PadLeft(2, '0') + DateTime.Now.TimeOfDay.ToString().Substring(9, 4) + "," + iNumOfOptionToRecord.ToString() + "," + strModifyRecord);
                if (lstrCollect.Count > 0)
                {
                    Stresm_Writer3 = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + "ConfigModify" + strTemp.Substring(0, strTemp.Length - 6) + ".txt", true);
                    for (int i = 0; i < lstrCollect.Count; i++)
                    {
                        Stresm_Writer3.WriteLine(lstrCollect[i]);
                    }
                    lstrCollect.Clear();
                    Stresm_Writer3.Close();
                    Stresm_Writer3.Dispose();

                }
            }
            catch (Exception ex)
            {
                ErrorRecord(ex.ToString());
            }
        }
        public void CreatParList()//记录底层接收的报文
        {
            try
            {
                StreamWriter Stresm_Writer3;

                Stresm_Writer3 = new StreamWriter(strDataFileFoldPath + "DataLog\\Log" + "CreatParList" + ".txt", true);
                string strLastSendTime = "";
                string strThisSendTime = "";
                for (int j = 0; j < lisstruSettingModelRead.Count; j++)
                {
                    if (lisstruSettingModelRead[j].Name != ".")
                    {
                        strThisSendTime = lisstruSettingModelRead[j].strSendTime;
                        if (strThisSendTime != strLastSendTime)
                        {
                            Stresm_Writer3.WriteLine(lisstruSettingModelRead[j].strSendTime);
                        }
                        Stresm_Writer3.WriteLine("temp_data.Name=" + "\"" + lisstruSettingModelRead[j].Name + "\";");
                        Stresm_Writer3.WriteLine("temp_data.Value =" + lisstruSettingModelRead[j].Name + ".Text;");
                        Stresm_Writer3.WriteLine("temp_data.Command =" + "\"" + lisstruSettingModelRead[j].Command + "\";");
                        Stresm_Writer3.WriteLine("data.Add(temp_data);");
                        strLastSendTime = lisstruSettingModelRead[j].strSendTime;
                    }
                }
                for (int j = 0; j < lisstruSettingModelWrite.Count; j++)
                {
                    if (lisstruSettingModelWrite[j].Name != ".")
                    {
                        strThisSendTime = lisstruSettingModelRead[j].strSendTime;
                        if (strThisSendTime != strLastSendTime)
                        {
                            Stresm_Writer3.WriteLine(lisstruSettingModelRead[j].strSendTime);
                        }
                        Stresm_Writer3.WriteLine(lisstruSettingModelWrite[j].Name + ".Text=" + "data[" + j.ToString() + "].Value;");
                        strLastSendTime = lisstruSettingModelRead[j].strSendTime;
                    }
                }
                lsRecordLogString.Clear();
                Stresm_Writer3.Close();

            }
            catch (Exception ex)
            { FunShow(ex); }
        }
    }
}

public struct physicalDataStruct
{
    public string strName;
    public string value;
    public string unit;
    public int iPGN;
    public string strSPN;
    public string strTime;
    public int iLeftOrRight;
}
public struct PGNInformation
{
    public string PGNName;
    public string transmitType;
    public string PGNNumber;
    public string PF;
    public string PS;//用作表示单帧多帧。0为单帧，其他为多帧表示帧数。
    public string Priority;
    public string parameterNumber;
    public SPNStruct[] spnStruct;

}
public struct SPNStruct
{
    public string SPNName;
    public string SPNNumber;
    public string parameterPosition;
    public string parameterLength;
    public string resolution;
    public string dataRange;
    public string PGNofSPN;
    public string strUnit;
    public string strAcruate;
    public string strConvert;
}
public struct EngineInfoAll
{
    public physicalDataStruct[] sEngineInfo1;
    public physicalDataStruct[] sEngineInfo2;
    public physicalDataStruct[] sEngineInfo3;
    public physicalDataStruct[] sNMEAInfo;
    public string[] lstrInclino;//高精度传感器传递倾角信号
    public string[] lstrInclinoAll;//蓝牙传感器，传递所有加速度角速度倾角信号
}
public struct struDataInFrame
{
    public string strName;
    public string strUnit;
    public string strValue;
    public string strTime;
}
public class Setting_Model
{
    private string name;
    private string value;
    private string command;
    private string strSendTime1;
    private string pageSelect;
    public string Name { get => name; set => name = value; }
    public string Value { get => value; set => this.value = value; }
    public string Command { get => command; set => command = value; }
    public string strSendTime { get => strSendTime1; set => strSendTime1 = value; }
    public string PageSelect { get => pageSelect; set => pageSelect = value; }
}