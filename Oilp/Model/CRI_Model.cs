using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class CRI_Model
    {
        /*型号*/
        private string model_no;
        /*制造商*/
        private string manufacturer;
        /*曲线*/
        private string curve;
        /*工况名*/
        private string step_name;

        /*转速*/
        private string round_speed;
        /*喷油标准*/
        private string oil_p_standard;
        /*喷油偏差*/
        private string oil_p_deviation;
        /*回油标准*/
        private string oil_h_standard;
        /*回油偏差*/
        private string oil_h_deviation;
        /*脉宽*/
        private string pulse_width;
        /*共轨压力*/
        private string rail_pressure;
        /*进油压力*/
        private string oil_j_pressure;
        /*回油压力*/
        private string oil_h_pressure;
        /*泵强压力*/
        private string punmp_pressure;
        /*控制持续时间*/
        private string control_last_time;
        /*电压*/
        private string voltage;
        /*油箱温度*/
        private string oil_tank_T;
        /*进油温度*/
        private string oil_j_T;
        /*回油温度*/
        private string oil_h_T;
        /*magnification*/
        private string magnification;
        /*period*/
        private string period;

        public string Model_no { get => model_no; set => model_no = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Curve { get => curve; set => curve = value; }
        public string Step_name { get => step_name; set => step_name = value; }
        public string Round_speed { get => round_speed; set => round_speed = value; }
        public string Oil_p_standard { get => oil_p_standard; set => oil_p_standard = value; }
        public string Oil_p_deviation { get => oil_p_deviation; set => oil_p_deviation = value; }
        public string Oil_h_standard { get => oil_h_standard; set => oil_h_standard = value; }
        public string Oil_h_deviation { get => oil_h_deviation; set => oil_h_deviation = value; }
        public string Pulse_width { get => pulse_width; set => pulse_width = value; }
        public string Rail_pressure { get => rail_pressure; set => rail_pressure = value; }
        public string Oil_j_pressure { get => oil_j_pressure; set => oil_j_pressure = value; }
        public string Oil_h_pressure { get => oil_h_pressure; set => oil_h_pressure = value; }
        public string Punmp_pressure { get => punmp_pressure; set => punmp_pressure = value; }
        public string Control_last_time { get => control_last_time; set => control_last_time = value; }
        public string Voltage { get => voltage; set => voltage = value; }
        public string Oil_tank_T { get => oil_tank_T; set => oil_tank_T = value; }
        public string Oil_j_T { get => oil_j_T; set => oil_j_T = value; }
        public string Oil_h_T { get => oil_h_T; set => oil_h_T = value; }
        public string Magnification { get => magnification; set => magnification = value; }
        public string Period { get => period; set => period = value; }
    }
}
