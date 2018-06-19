using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
//using Support;
using System.IO.Ports;

namespace Oilp.Com
{
    class RS485Communicate
    {
        support Support = support.GetInstance();
        public SerialPort serialPort = new SerialPort();
        bool bWrite = false;//串口发送信息表征，true表示正在发送报文
        List<StructFrame485>[] llisstruRs485Frame = new List<StructFrame485>[5];//读取并用配置文件中的信息初始化485报文的结构体数组，现在分为五组发送报文，每组报文为在对应状态下需要发送的报文数组。0主/设置界面，1数据库界面，2，检测界面，3点启动按键，4停止/急停
        public RS485Communicate()
        {
            llisstruRs485Frame = Support.llisstruRs485Frame;
        }
        public void Read485FromFile(string strSimulateFilePath, ref int iStreamPosition, ref List<StructFrame485> lstruSendFrames, ref List<StructFrame485> lstruRecFrames)//从文件中读取报文，string strSimulateFilePath文件路径, ref int iStreamPosition文件字符读取位置，用于大数据量多次从记录位置继续读取, ref List<StructFrame485> lstruSendFrames将从文件读取的发送内容填写到报文结构体数组中, ref List<StructFrame485> lstruRecFrames将从文件读取的接收内容填写到报文结构体数组中
        {
            //[2018/5/22, 14:35:59.412]  [FE  88  00  00  00  00  00  00  00  00  00  00  00  00  35  00  00  00  00  00  00  00  BB  01  ]
            //[2018/5/22, 14:35:59.452]  [EF  88  00  00  01  00  00  00  00  00  D1  40  E6  41  F1  FF  1F  C2  00  72  00  00  F3  06  ]
            FileStream File_Stream = new FileStream(strSimulateFilePath, FileMode.Open, FileAccess.Read);
            StreamReader Stream_Reader = new StreamReader(File_Stream, System.Text.Encoding.GetEncoding("gb2312"));
            try
            {
                string one_line_string;
                StructFrame485 struFrame = new StructFrame485();
                Stream_Reader.BaseStream.Position = iStreamPosition;
                List<StructShowData> lisstruDataInfo = Support.lisstruShowData;
                //Stream_Reader.ReadLine();
                Thread.Sleep(10);
                while ((one_line_string = Stream_Reader.ReadLine()) != null)
                {
                    struFrame = new StructFrame485();
                    one_line_string = one_line_string.Remove(0, 1);
                    if (!one_line_string.Contains("["))
                    {
                        continue;
                    }
                    string[] lstrLogData = one_line_string.Split('[');
                    if (lstrLogData.Length < 2)
                    {
                        continue;
                    }
                    struFrame.strTimeStamp = lstrLogData[0].Remove(lstrLogData[0].Length - 3, 3);//时间戳
                    string[] lstrBytes = lstrLogData[1].Split(new string[] { "  " }, StringSplitOptions.None);
                    if (lstrBytes.Length != 25)
                    {
                        continue;
                    }
                    StringArrayToStructure(ref struFrame, lstrBytes);//将报文填充到结构体中
                    for (int iShowData = 0; iShowData < lisstruDataInfo.Count; iShowData++)
                    {
                        if (struFrame.strOrder.Length > 2)
                        {
                            struFrame.strOrder = struFrame.strOrder.Substring(struFrame.strOrder.Length - 2, 2);
                        }

                        if (lisstruDataInfo[iShowData].strOrderAndPageSelect == (struFrame.strPageSelect.PadLeft(2, '0') + struFrame.strOrder.PadLeft(2, '0')))//匹配从调用函数端传来的数据与发送报文
                        {
                            struFrame.strFormat = lisstruDataInfo[iShowData].strFormat;
                            struFrame.strConvertMatherd = lisstruDataInfo[iShowData].strConvertMatherd;
                            struFrame.strResolution = lisstruDataInfo[iShowData].strResolution;

                            break;
                        }
                    }
                    FrameDataConvert(ref struFrame, false);//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用

                    if (struFrame.strFirstByte == "FE")//第一字节，判断接收和发送
                    {
                        lstruSendFrames.Add(struFrame);
                    }
                    else
                    {
                        FrameDataConvert(ref struFrame, false);//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用
                        lstruRecFrames.Add(struFrame);
                    }
                    if (lstruSendFrames.Count > 500)//收集500个字节
                    {
                        iStreamPosition = Convert.ToInt32(Stream_Reader.BaseStream.Position);
                        break;
                    }

                }
                if (one_line_string == null)
                {
                    iStreamPosition = 0;
                }
                Stream_Reader.Close();
                File_Stream.Close();
            }
            catch (Exception ex)
            {
                Stream_Reader.Close();
                Support.FunShow(ex);

            }
        }
        public int StructureToByteArray(StructFrame485 struFrame, ref byte[] lbSendFrame)//将结构体数组填充到24字节报文中，用于发送
        {
            try
            {
                lbSendFrame = new byte[24] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, };
                lbSendFrame[0] = Convert.ToByte(struFrame.strFirstByte, 16);
                lbSendFrame[4] = Convert.ToByte(struFrame.strReadOrWrite, 16);
                //lbSendFrame[5] = 0xFE;
                lbSendFrame[6] = Convert.ToByte(struFrame.strPageSelect, 16);
                struFrame.strOrder = struFrame.strOrder.PadLeft(8, '0');
                lbSendFrame[17] = Convert.ToByte(struFrame.strOrder.Substring(0, 2), 16);
                lbSendFrame[16] = Convert.ToByte(struFrame.strOrder.Substring(2, 2), 16);
                lbSendFrame[15] = Convert.ToByte(struFrame.strOrder.Substring(4, 2), 16);
                lbSendFrame[14] = Convert.ToByte(struFrame.strOrder.Substring(6, 2), 16);
                struFrame.strDataInner = struFrame.strDataInner.PadLeft(8, '0');//strDataInner为已经倒序的数据
                lbSendFrame[18] = Convert.ToByte(struFrame.strDataInner.Substring(0, 2), 16);
                lbSendFrame[19] = Convert.ToByte(struFrame.strDataInner.Substring(2, 2), 16);
                lbSendFrame[20] = Convert.ToByte(struFrame.strDataInner.Substring(4, 2), 16);
                lbSendFrame[21] = Convert.ToByte(struFrame.strDataInner.Substring(6, 2), 16);
                int iSum = 0;
                for (int i = 0; i < 22; i++)
                {
                    iSum += lbSendFrame[i];
                }
                string strTempSum = Convert.ToString(iSum, 16).PadLeft(4, '0');
                lbSendFrame[22] = Convert.ToByte(strTempSum.Substring((strTempSum.Length - 2), 2), 16);
                lbSendFrame[23] = Convert.ToByte(strTempSum.Substring((strTempSum.Length - 4), 2), 16);
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }
        public int StringArrayToStructure(ref StructFrame485 struFrame, string[] lstrBytes)//将报文串24个字节提取的填充到报文结构体中,其中strOrder和strCheckSum为调整完顺序，高位在前格式，strDataInner不进行顺序调整，地位在前
        {
            try
            {
                //struFrame.strTimeStamp = lstrLogData[0].Remove(lstrLogData[0].Length - 3, 3);
                struFrame.strFirstByte = lstrBytes[0];
                struFrame.strReadOrWrite = lstrBytes[4];
                struFrame.strBootLoader = lstrBytes[5];
                struFrame.strPageSelect = lstrBytes[6];
                struFrame.strOrder = lstrBytes[17] + lstrBytes[16] + lstrBytes[15] + lstrBytes[14];
                struFrame.strDataInner = lstrBytes[18] + lstrBytes[19] + lstrBytes[20] + lstrBytes[21];
                struFrame.strCheckSum = lstrBytes[23] + lstrBytes[22];
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }


        public int CycleSendFrame(List<StructShowData> lisstruDataInfo, int iCycleNum, ref List<StructFrame485> lisstruRs485Frame)//连续发送一组报文List<StructShowData> lisstruDataInfo要发送的一组报文数组的数据部分，从调用函数端传过来，填充到对应的发送报文中， int iCycleNum发送报文组号，表示当前发送support提取xml文件得到的几组需要发送的报文中的哪一组报文, ref List<StructFrame485> lisstruRs485Frame当发送读取报文从控制器内部读取数据时的包含所读取数据的返回报文，用于提取控制器当前数据
        {
            try
            {
                StructFrame485 struTempSendFrame = new StructFrame485();
                StructFrame485 struTempReadFrame = new StructFrame485();
                int iResult = 0;
                bool bHasdata = false;
                if (llisstruRs485Frame[iCycleNum] == null || llisstruRs485Frame[iCycleNum].Count == 0)
                {
                    return 1;
                }
                OpenPort();
                for (int i = 0; i < llisstruRs485Frame[iCycleNum].Count; i++)
                {
                    struTempSendFrame = llisstruRs485Frame[iCycleNum][i];
                    for (int iShowData = 0; iShowData < lisstruDataInfo.Count; iShowData++)
                    {
                        if (lisstruDataInfo[iShowData].strOrderAndPageSelect == (struTempSendFrame.strPageSelect.PadLeft(2, '0') + struTempSendFrame.strOrder.PadLeft(2, '0')))//匹配从调用函数端传来的数据与发送报文
                        {
                            struTempSendFrame.strDataPhysical = lisstruDataInfo[iShowData].strData;
                            bHasdata = true;
                            break;
                        }
                    }
                    //if(bHasdata==false)
                    //{
                    //    break;
                    //}
                    FrameDataConvert(ref struTempSendFrame, true);//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用
                    iResult = SendOneFrame(struTempSendFrame);
                    if (iResult != 0)
                    {
                        continue;
                    }

                    iResult = ReadOneFrame(ref struTempReadFrame);

                    if (iResult != 0)
                    {
                        continue;
                    }
                    for (int iShowData = 0; iShowData < lisstruDataInfo.Count; iShowData++)
                    {
                        if (lisstruDataInfo[iShowData].strOrderAndPageSelect == (struTempReadFrame.strPageSelect.PadLeft(2, '0') + struTempReadFrame.strOrder.PadLeft(2, '0')))//匹配从调用函数端传来的数据与发送报文
                        {
                            struTempReadFrame.strFormat = lisstruDataInfo[iShowData].strFormat;
                            struTempReadFrame.strConvertMatherd = lisstruDataInfo[iShowData].strConvertMatherd;
                            struTempReadFrame.strResolution = lisstruDataInfo[iShowData].strResolution;
                            bHasdata = true;
                            break;
                        }
                    }
                    FrameDataConvert(ref struTempReadFrame, false);//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用
                    if (Convert.ToInt32(struTempReadFrame.strReadOrWrite, 16) == 0)
                    {
                        lisstruRs485Frame.Add(struTempReadFrame);
                    }
                }
                ClosePort();
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }
        private int FrameDataConvert(ref StructFrame485 struFrame, bool bDataConvert)//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用
        {
            try
            {
                string strTemp = "";
                //struFrame.strDataInner=struFrame.strDataInner.PadLeft(8, '0');
                if (bDataConvert == false)//FALSE为计算机内部值,转换为物力值,现将内部值顺序调整，变成高位在前，然后如果为float，转为float，如果为unint，转为十进制，然后进行比例缩放转换
                {
                    if (struFrame.strFormat == "FLOAT32")
                    {
                        HexToSingle(struFrame.strDataInner, ref strTemp);//将4字节字符串转换成float字符串。
                        //strTemp = strTemp.Substring(6, 2) + strTemp.Substring(4, 2) + strTemp.Substring(2, 2) + strTemp.Substring(0, 2); //非float32格式，unint32格式直接颠倒位置
                    }
                    else if (struFrame.strFormat == "UINT32")
                    {

                        strTemp = struFrame.strDataInner.Substring(6, 2) + struFrame.strDataInner.Substring(4, 2) + struFrame.strDataInner.Substring(2, 2) + struFrame.strDataInner.Substring(0, 2); //非float32格式，unint32格式直接颠倒位置
                        strTemp = Convert.ToUInt32(strTemp, 16).ToString();
                    }
                    else
                    { return 1; }
                    struFrame.strDataPhysical = (Convert.ToSingle(strTemp) * Convert.ToInt32(struFrame.strConvertMatherd)).ToString();//进行转换比例处理，统一对物力值进行处理
                    struFrame.bDataConvert = true;
                }
                else if (bDataConvert == true)//TRUE为物力值，界面显示用,转换为内部值，先进性比例缩放转换，如果为float，转为float，如果为unint转换成十六进制，然后调整顺序，变成高位在后
                {
                    struFrame.strDataPhysical = (Convert.ToSingle(struFrame.strDataPhysical) / Convert.ToInt32(struFrame.strConvertMatherd)).ToString().PadLeft(8, '0');//进行转换比例处理，统一对物力值进行处理
                    if (struFrame.strFormat == "FLOAT32")
                    {
                        SingleToHex(ref strTemp, struFrame.strDataPhysical);//将float字符串转换成4字节字符串
                    }
                    else if (struFrame.strFormat == "UINT32")
                    {
                        struFrame.strDataPhysical = Convert.ToString(Convert.ToUInt32(struFrame.strDataPhysical, 10), 16).PadLeft(8, '0');
                        strTemp = struFrame.strDataPhysical.Substring(6, 2) + struFrame.strDataPhysical.Substring(4, 2) + struFrame.strDataPhysical.Substring(2, 2) + struFrame.strDataPhysical.Substring(0, 2);//非float32格式，unint32格式直接颠倒位置
                    }
                    else
                    { return 1; }
                    struFrame.strDataInner = strTemp;
                    struFrame.bDataConvert = false;
                }
                else
                { return 1; }
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }
        private void HexToSingle(string str4ByteData, ref string strSingleDate)//将4字节字符串转换成float字符串。str4ByteData为高位在后，内部调换
        {
            try
            {
                byte[] lbTemp = new byte[4] { Convert.ToByte(str4ByteData.Substring(0, 2), 16), Convert.ToByte(str4ByteData.Substring(2, 2), 16), Convert.ToByte(str4ByteData.Substring(4, 2), 16), Convert.ToByte(str4ByteData.Substring(6, 2), 16) };
                strSingleDate = BitConverter.ToSingle(lbTemp, 0).ToString().PadLeft(8, '0');
            }
            catch (Exception e)
            {
                Support.FunShow(e);

            }
        }
        private void SingleToHex(ref string str4ByteData, string strSingleDate)//将float转换成4字节字HEX符串。str4ByteData为高位在后，内部调换
        {
            try
            {
                byte[] lbTemp = BitConverter.GetBytes(Convert.ToSingle(strSingleDate));
                str4ByteData = lbTemp[0].ToString("x2") + lbTemp[1].ToString("x2") + lbTemp[2].ToString("x2") + lbTemp[3].ToString("x2");
            }
            catch (Exception e)
            {
                Support.FunShow(e);

            }
        }
        public int SendOneFrame(StructFrame485 struFrame)//发送一帧报文，传入获得结构体，将结构体转换成字符串组，然后调用串口发送命令
        {
            try
            {
                byte[] lbSendFrame = new byte[24];
                int iResult = 0;
                StructureToByteArray(struFrame, ref lbSendFrame);//将结构体转换成字符串组
                string strSendFrame = "";
                for (int i = 0; i < lbSendFrame.Length; i++)
                {
                    strSendFrame += Convert.ToString(lbSendFrame[i], 16).PadLeft(2, '0');
                }

                iResult = Write(strSendFrame);//调用串口发送命令
                if (iResult != 0)
                {
                    return iResult;
                }
                Support.FrameLog1(strSendFrame, 1, DateTime.Now.ToString("yyyyMMddhhmmss"));
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }
        public int ReadOneFrame(ref StructFrame485 struFrame)//读取一帧报文，将读取的字符串转换填充到结构体中
        {
            try
            {
                string strNewLine = "";
                string[] lstrReadFrameArry = new string[24];

                int iResult = 0;
                iResult = ReadLine(ref strNewLine);
                if (iResult != 0)
                {
                    return iResult;
                }
                Support.FrameLog1(strNewLine, 0, DateTime.Now.ToString("yyyyMMddhhmmss"));
                if (!(strNewLine.Length >= 48))
                {
                    return 1;
                }
                for (int i = 0; i < 24; i++)
                {
                    lstrReadFrameArry[i] = strNewLine.Substring(0, 2);
                    strNewLine.Remove(0, 2);
                }

                StringArrayToStructure(ref struFrame, lstrReadFrameArry);

                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }

        public int OpenPort()//1为新，其他为旧传感器
        {
            string[] ports = System.IO.Ports.SerialPort.GetPortNames();

            if (serialPort.IsOpen)
            {
                return 0;
            }
            else
            {
                serialPort.BaudRate = 115200;
                if (ports.Length > 0)
                {
                    try
                    {
                        if (serialPort.IsOpen)
                        {
                            return 0;
                        }
                        else
                        {
                            serialPort.Open();
                            serialPort.ReadTimeout = 20;
                        }
                        if (serialPort.IsOpen)
                        {
                            return 0;
                        }
                        else { return 2; }
                    }
                    catch (Exception e)
                    {
                        Support.FunShow(e);
                        return 4;
                    }
                }
                else
                { return 2; }
            }
        }
        public int ClosePort()//1为信，其他为旧传感器
        {
            try
            {

                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                }
                return 0;
            }
            catch (Exception e)
            {

                Support.FunShow(e);
                return 1;
            }

        }
        public int Write(string strLine)//1为信，其他为旧传感器
        {
            bWrite = true;
            try
            {
                if (serialPort.IsOpen == true)
                {
                    serialPort.WriteLine(strLine);
                    bWrite = false;
                    return 0;
                }
                else
                { return 1; }
            }
            catch (Exception e)
            {
                bWrite = false;
                Support.FunShow(e);
                return 1;
            }

        }
        private int ReadLine(ref string strNewLine)//old旧传感器
        {
            if (bWrite != false)
            {
                return 1;
            }
            try
            {
                if (serialPort.IsOpen)
                {
                    //string strTemp = serialPort.ReadLine();
                    //while (strTemp!=null)
                    //{
                    //    strNewLine = strTemp;
                    //    strTemp = serialPort.ReadLine();
                    //}
                    strNewLine = serialPort.ReadLine();
                    if (strNewLine.Length <= 0)
                    { return 1; }
                    serialPort.DiscardInBuffer();
                }
                return 0;
            }
            catch (Exception e)
            {
                Support.FunShow(e);
                return 1;
            }
        }
    }
    public struct StructFrame485
    {
        public string strTimeStamp;
        public string strFirstByte;//0xFE from clint,0xEF from sever 
        public string strReadOrWrite;//0 read,1 write
        public string strBootLoader;//升级
        public string strPageSelect;//命令片选
        public string strOrder;//命令
        public string strDataPhysical;//数据
        public string strDataInner;//数据
        public string strCheckSum;//校验和
        public string strSendTime;//发送时机，在哪个状态下发送
        public string strChineseName;//中文名字
        public string strFormat;//数据格式
        public string strUnit;//数据单位
        public string strResolution;//数据分辨率，小数位数
        public string strConvertMatherd;//数据转换方式
        public bool bDataConvert;//数据是否经过转换，FALSE为计算机内部值，TRUE为物力值，界面显示用
    }
    public struct StructShowData
    {
        public string strOrderAndPageSelect;//命令含命令片选
        public string strData;//数据       
        public string strChineseName;//中文名字
        public string strFormat;//数据格式
        public string strUnit;//数据单位
        public string strResolution;//数据分辨率，小数位数
        public string strConvertMatherd;//数据转换方式
    }
}
