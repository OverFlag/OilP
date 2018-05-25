using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    class Detail_Information
    {
        /*型号*/
        private string model_no;
        /*制造商*/
        private string manufacturer;
        /*工况名*/
        private string step_name;
        /*转速*/
        private string round_speed;
        /*柴油轨压*/
        private string diesel_oil_rail_pressure;
        /*流量标准值*/
        private string flow_standard;
        /*流量偏差*/
        private string flow_deviation;
        /*回油标准*/
        private string oil_h_standard;
        /*回油偏差*/
        private string oil_h_deviation;
        /*ZME电压*/
        private string zme_v;
        /*ZME电流*/
        private string zme_a;
        /*DRV电流*/
        private string drv_a;
        /*HPI进油压力*/
        private string hpi_oil_in_pressure;
        /*机油压力*/
        private string engine_oil_pressure;
        /*泵腔压力*/
        private string pump_pressure;
        /*电机转向*/
        private string motor_steering;
        /*测量时间*/
        private string test_time;
        /*驱动源类型*/
        private string drive_source_type;
        /*喷油1脉宽*/
        private string pulse_width_1;
        /*喷油2脉宽*/
        private string pulse_width_2;
        /*齿数*/
        private string tooth_number;
        /*特征齿*/
        private string characteristic_tooth;
        /*触发阀个数*/
        private string trigger_valve_number;
        /*驱动1*/
        private string driver_1;
        /*驱动2*/
        private string driver_2;
        /*起始角1*/
        private string start_angle_1;
        /*起始角2*/
        private string start_angel_2;
        /*终止角1*/
        private string end_angle;
        /*终止角1触发角度*/
        private string end_angle_degree_1;
        /* 终止角2*/
        private string end_angle_2;
        /*终止角2触发角度*/
        private string end_angle_degree_2;
        /*曲线*/
        private string curve;
        /* 供应电压(杜没用)*/
        private string supply_voltage;
        /*A使能*/
        private string a_make;
        /*A类型*/
        private string a_type;
        /* A驱动频率*/
        private string a_driver;
        /* A控制模式*/
        private string a_cotrol_model;
        /*A控制电流*/
        private string a_control_electricity;
        /*A占空比*/
        private string a_duty_cycle;
        /*ZME1使能*/
        private string zme_make_1;
        /*ZME1类型*/
        private string zme_type_1;
        /*ZME1驱动频率*/
        private string zme_driver_1;
        /*ZME1控制模式*/
        private string zme_control_1;
        /* ZME1控制电流*/
        private string zme_control_electricity_1;
        /*ZME1占空比*/
        private string zme_control_duty_cycle_1;
        /*ZME2使能*/
        private string zme_make_2;
        /*ZME2类型*/
        private string zme_type_2;
        /*ZME2驱动频率*/
        private string zme_driver_2;
        /*ZME2控制模式*/
        private string zme_control_2;
        /*ZME2控制电流*/
        private string zme_control_electricity_2;
        /*ZME2占空比*/
        private string zme_control_duty_cycle_2;
        /*C使能*/
        private string c_make;
        /*C类型*/
        private string c_type;
        /*C驱动频率*/
        private string c_driver;
        /*C控制模式*/
        private string c_control;
        /*C控制电流*/
        private string c_control_electricity;
        /*C占空比*/
        private string c_duty_cycle;    
        /*修正系数*/
        private string correction_factor;
        /*Period*/
        private string period;
        /*供油*/
        private string supply_oil;
        /*背压*/
        private string back_pressure;
        /*上升行程*/
        private string up_trip;
        /*响应时间*/
        private string response_time;
        /*响应时间偏差*/
        private string response_time_deviation;
        /*电阻*/
        private string resistance;
        /*电阻偏差*/
        private string resistance_deviation;
        /*控制持续时间(杜没用)*/
        private string control_last_time;
        /*ZME电流*/
        private string zme_electricity;

        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Step_name { get => step_name; set => step_name = value; }
        public string Round_speed { get => round_speed; set => round_speed = value; }
        public string Diesel_oil_rail_pressure { get => diesel_oil_rail_pressure; set => diesel_oil_rail_pressure = value; }
        public string Flow_standard { get => flow_standard; set => flow_standard = value; }
        public string Flow_deviation { get => flow_deviation; set => flow_deviation = value; }
        public string Oil_h_standard { get => oil_h_standard; set => oil_h_standard = value; }
        public string Oil_h_deviation { get => oil_h_deviation; set => oil_h_deviation = value; }
        public string Zme_v { get => zme_v; set => zme_v = value; }
        public string Zme_a { get => zme_a; set => zme_a = value; }
        public string Drv_a { get => drv_a; set => drv_a = value; }
        public string Hpi_oil_in_pressure { get => hpi_oil_in_pressure; set => hpi_oil_in_pressure = value; }
        public string Engine_oil_pressure { get => engine_oil_pressure; set => engine_oil_pressure = value; }
        public string Pump_pressure { get => pump_pressure; set => pump_pressure = value; }
        public string Motor_steering { get => motor_steering; set => motor_steering = value; }
        public string Test_time { get => test_time; set => test_time = value; }
        public string Drive_source_type { get => drive_source_type; set => drive_source_type = value; }
        public string Pulse_width_1 { get => pulse_width_1; set => pulse_width_1 = value; }
        public string Pulse_width_2 { get => pulse_width_2; set => pulse_width_2 = value; }
        public string Tooth_number { get => tooth_number; set => tooth_number = value; }
        public string Characteristic_tooth { get => characteristic_tooth; set => characteristic_tooth = value; }
        public string Trigger_valve_number { get => trigger_valve_number; set => trigger_valve_number = value; }
        public string Driver_1 { get => driver_1; set => driver_1 = value; }
        public string Driver_2 { get => driver_2; set => driver_2 = value; }
        public string Start_angle_1 { get => start_angle_1; set => start_angle_1 = value; }
        public string Start_angel_2 { get => start_angel_2; set => start_angel_2 = value; }
        public string End_angle { get => end_angle; set => end_angle = value; }
        public string End_angle_degree_1 { get => end_angle_degree_1; set => end_angle_degree_1 = value; }
        public string End_angle_2 { get => end_angle_2; set => end_angle_2 = value; }
        public string End_angle_degree_2 { get => end_angle_degree_2; set => end_angle_degree_2 = value; }
        public string Curve { get => curve; set => curve = value; }
        public string Supply_voltage { get => supply_voltage; set => supply_voltage = value; }
        public string A_make { get => a_make; set => a_make = value; }
        public string A_type { get => a_type; set => a_type = value; }
        public string A_driver { get => a_driver; set => a_driver = value; }
        public string A_cotrol_model { get => a_cotrol_model; set => a_cotrol_model = value; }
        public string A_control_electricity { get => a_control_electricity; set => a_control_electricity = value; }
        public string A_duty_cycle { get => a_duty_cycle; set => a_duty_cycle = value; }
        public string Zme_make_1 { get => zme_make_1; set => zme_make_1 = value; }
        public string Zme_type_1 { get => zme_type_1; set => zme_type_1 = value; }
        public string Zme_driver_1 { get => zme_driver_1; set => zme_driver_1 = value; }
        public string Zme_control_1 { get => zme_control_1; set => zme_control_1 = value; }
        public string Zme_control_electricity_1 { get => zme_control_electricity_1; set => zme_control_electricity_1 = value; }
        public string Zme_control_duty_cycle_1 { get => zme_control_duty_cycle_1; set => zme_control_duty_cycle_1 = value; }
        public string Zme_make_2 { get => zme_make_2; set => zme_make_2 = value; }
        public string Zme_type_2 { get => zme_type_2; set => zme_type_2 = value; }
        public string Zme_driver_2 { get => zme_driver_2; set => zme_driver_2 = value; }
        public string Zme_control_2 { get => zme_control_2; set => zme_control_2 = value; }
        public string Zme_control_electricity_2 { get => zme_control_electricity_2; set => zme_control_electricity_2 = value; }
        public string Zme_control_duty_cycle_2 { get => zme_control_duty_cycle_2; set => zme_control_duty_cycle_2 = value; }
        public string C_make { get => c_make; set => c_make = value; }
        public string C_type { get => c_type; set => c_type = value; }
        public string C_driver { get => c_driver; set => c_driver = value; }
        public string C_control { get => c_control; set => c_control = value; }
        public string C_control_electricity { get => c_control_electricity; set => c_control_electricity = value; }
        public string C_duty_cycle { get => c_duty_cycle; set => c_duty_cycle = value; }
        public string Correction_factor { get => correction_factor; set => correction_factor = value; }
        public string Period { get => period; set => period = value; }
        public string Supply_oil { get => supply_oil; set => supply_oil = value; }
        public string Back_pressure { get => back_pressure; set => back_pressure = value; }
        public string Up_trip { get => up_trip; set => up_trip = value; }
        public string Response_time { get => response_time; set => response_time = value; }
        public string Response_time_deviation { get => response_time_deviation; set => response_time_deviation = value; }
        public string Resistance { get => resistance; set => resistance = value; }
        public string Resistance_deviation { get => resistance_deviation; set => resistance_deviation = value; }
        public string Control_last_time { get => control_last_time; set => control_last_time = value; }
        public string Zme_electricity { get => zme_electricity; set => zme_electricity = value; }
    }
}
