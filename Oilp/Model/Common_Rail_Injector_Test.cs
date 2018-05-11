using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class Common_Rail_Injector_Test
    {
        private string model_no;
        private string step_name;
        private double duration;
        private double rail_pressure;
        private double fuel_p_hor;
        private double fuel_p_ver;
        private double fuel_h_hor;
        private double fuel_h_ver;
        private int test_time;
        private string curve;
        private double magnification;
        private int period;
        private int voltage;
        private string line;

        public string Model_no { get => model_no; set => model_no = value; }
        public string Step_name { get => step_name; set => step_name = value; }
        public double Duration { get => duration; set => duration = value; }
        public double Rail_pressure { get => rail_pressure; set => rail_pressure = value; }
        public double Fuel_p_hor { get => fuel_p_hor; set => fuel_p_hor = value; }
        public double Fuel_p_ver { get => fuel_p_ver; set => fuel_p_ver = value; }
        public double Fuel_h_hor { get => fuel_h_hor; set => fuel_h_hor = value; }
        public double Fuel_h_ver { get => fuel_h_ver; set => fuel_h_ver = value; }
        public int Test_time { get => test_time; set => test_time = value; }
        public double Magnification { get => magnification; set => magnification = value; }
        public int Period { get => period; set => period = value; }
        public int Voltage { get => voltage; set => voltage = value; }
        public string Line { get => line; set => line = value; }
        public string Curve { get => curve; set => curve = value; }
    }
}
