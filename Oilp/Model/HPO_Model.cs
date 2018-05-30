using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class HPO_Model
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
        /* DRV电流 */
        private string drv_a;
        /*共轨压力*/
        private string rail_pressure;
        /*喷油量*/
        private string oil_p_standard;
        /*喷油量偏差*/
        private string oil_p_deviationr;
        /*回油量*/
        private string oil_h_standard;
        /*回油量偏差*/
        private string oil_h_deviationr;
        /*提前角*/
        private string start_angle;
        /*电压*/
        private string voltage;
        /*进油压力*/
        private string oil_j_pressure;
        /*回油压力*/
        private string oil_h_pressure;
        /*泵腔压力*/
        private string pump_pressure;
        /*电机转向*/
        private string motor_steering;
        /*测量时间*/
        private string test_time;

        public string Model_no { get => model_no; set => model_no = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Curve { get => curve; set => curve = value; }
        public string Step_name { get => step_name; set => step_name = value; }
        public string Round_speed { get => round_speed; set => round_speed = value; }
        public string Drv_a { get => drv_a; set => drv_a = value; }
        public string Rail_pressure { get => rail_pressure; set => rail_pressure = value; }
        public string Oil_p_standard { get => oil_p_standard; set => oil_p_standard = value; }
        public string Oil_p_deviationr { get => oil_p_deviationr; set => oil_p_deviationr = value; }
        public string Oil_h_standard { get => oil_h_standard; set => oil_h_standard = value; }
        public string Oil_h_deviationr { get => oil_h_deviationr; set => oil_h_deviationr = value; }
        public string Start_angle { get => start_angle; set => start_angle = value; }
        public string Voltage { get => voltage; set => voltage = value; }
        public string Oil_j_pressure { get => oil_j_pressure; set => oil_j_pressure = value; }
        public string Oil_h_pressure { get => oil_h_pressure; set => oil_h_pressure = value; }
        public string Pump_pressure { get => pump_pressure; set => pump_pressure = value; }
        public string Motor_steering { get => motor_steering; set => motor_steering = value; }
        public string Test_time { get => test_time; set => test_time = value; }
    }
}
