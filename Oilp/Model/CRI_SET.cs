using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class CRI_SET
    {
        private string oil_tank_T;
        private string fuel_P;
        private string fuel_I;
        private string fuel_D;
        private string oil_P;
        private string oil_I;
        private string oil_D;
        private string RY_T;
        private string JY_T;
        private string RY_T_deviation;
        private string JY_T_deviation;
        private string flow_c1_r1;
        private string flow_c1_r2;
        private string flow_c1_r3;
        private string flow_c1_r4;
        private string flow_c1_r5;
        private string flow_c1_r6;
        private string flow_c2_r1;
        private string flow_c2_r2;
        private string flow_c2_r3;
        private string flow_c2_r4;
        private string flow_c2_r5;
        private string flow_c2_r6;
        private string flow_c3_r1;
        private string flow_c3_r2;
        private string flow_c3_r3;
        private string flow_c3_r4;
        private string flow_c3_r5;
        private string flow_c3_r6;
        private string flow_c4_r1;
        private string flow_c4_r2;
        private string flow_c4_r3;
        private string flow_c4_r4;
        private string flow_c4_r5;
        private string flow_c4_r6;
        private string fuel_1_rail_pressure;
        private string fuel_2_rail_pressure;
        private string fuel_3_rail_pressure;
        private string fuel_4_rail_pressure;
        private string fuel_5_rail_pressure;
        private string fuel_6_rail_pressure; 
        private string fuel_7_rail_pressure;
        private string oil_1_rail_pressure;
        private string oil_2_rail_pressure;
        private string oil_3_rail_pressure;
        private string oil_4_rail_pressure;
        private string oil_5_rail_pressure;
        private string gu_version;
        private string sys_version;
        private string oilk;
        private string pumpinjk;
        private string pumpRek;
        private string fuel_heat;
        private string rail_pressure_group;


        public string Oil_tank_T { get => oil_tank_T; set => oil_tank_T = value; }
        public string Fuel_P { get => fuel_P; set => fuel_P = value; }
        public string Fuel_I { get => fuel_I; set => fuel_I = value; }
        public string Fuel_D { get => fuel_D; set => fuel_D = value; }
        public string Oil_P { get => oil_P; set => oil_P = value; }
        public string Oil_I { get => oil_I; set => oil_I = value; }
        public string Oil_D { get => oil_D; set => oil_D = value; }
        public string RY_T1 { get => RY_T; set => RY_T = value; }
        public string JY_T1 { get => JY_T; set => JY_T = value; }
        public string RY_T_deviation1 { get => RY_T_deviation; set => RY_T_deviation = value; }
        public string JY_T_deviation1 { get => JY_T_deviation; set => JY_T_deviation = value; }
        public string Flow_c1_r1 { get => flow_c1_r1; set => flow_c1_r1 = value; }
        public string Flow_c1_r2 { get => flow_c1_r2; set => flow_c1_r2 = value; }
        public string Flow_c1_r3 { get => flow_c1_r3; set => flow_c1_r3 = value; }
        public string Flow_c1_r4 { get => flow_c1_r4; set => flow_c1_r4 = value; }
        public string Flow_c1_r5 { get => flow_c1_r5; set => flow_c1_r5 = value; }
        public string Flow_c1_r6 { get => flow_c1_r6; set => flow_c1_r6 = value; }
        public string Flow_c2_r1 { get => flow_c2_r1; set => flow_c2_r1 = value; }
        public string Flow_c2_r2 { get => flow_c2_r2; set => flow_c2_r2 = value; }
        public string Flow_c2_r3 { get => flow_c2_r3; set => flow_c2_r3 = value; }
        public string Flow_c2_r4 { get => flow_c2_r4; set => flow_c2_r4 = value; }
        public string Flow_c2_r5 { get => flow_c2_r5; set => flow_c2_r5 = value; }
        public string Flow_c2_r6 { get => flow_c2_r6; set => flow_c2_r6 = value; }
        public string Flow_c3_r1 { get => flow_c3_r1; set => flow_c3_r1 = value; }
        public string Flow_c3_r2 { get => flow_c3_r2; set => flow_c3_r2 = value; }
        public string Flow_c3_r3 { get => flow_c3_r3; set => flow_c3_r3 = value; }
        public string Flow_c3_r4 { get => flow_c3_r4; set => flow_c3_r4 = value; }
        public string Flow_c3_r5 { get => flow_c3_r5; set => flow_c3_r5 = value; }
        public string Flow_c3_r6 { get => flow_c3_r6; set => flow_c3_r6 = value; }
        public string Flow_c4_r1 { get => flow_c4_r1; set => flow_c4_r1 = value; }
        public string Flow_c4_r2 { get => flow_c4_r2; set => flow_c4_r2 = value; }
        public string Flow_c4_r3 { get => flow_c4_r3; set => flow_c4_r3 = value; }
        public string Flow_c4_r4 { get => flow_c4_r4; set => flow_c4_r4 = value; }
        public string Flow_c4_r5 { get => flow_c4_r5; set => flow_c4_r5 = value; }
        public string Fuel_1_rail_pressure { get => fuel_1_rail_pressure; set => fuel_1_rail_pressure = value; }
        public string Fuel_2_rail_pressure { get => fuel_2_rail_pressure; set => fuel_2_rail_pressure = value; }
        public string Fuel_3_rail_pressure { get => fuel_3_rail_pressure; set => fuel_3_rail_pressure = value; }
        public string Fuel_4_rail_pressure { get => fuel_4_rail_pressure; set => fuel_4_rail_pressure = value; }
        public string Fuel_5_rail_pressure { get => fuel_5_rail_pressure; set => fuel_5_rail_pressure = value; }
        public string Fuel_6_rail_pressure { get => fuel_6_rail_pressure; set => fuel_6_rail_pressure = value; }
        public string Fuel_7_rail_pressure { get => fuel_7_rail_pressure; set => fuel_7_rail_pressure = value; }
        public string Oil_1_rail_pressure { get => oil_1_rail_pressure; set => oil_1_rail_pressure = value; }
        public string Oil_2_rail_pressure { get => oil_2_rail_pressure; set => oil_2_rail_pressure = value; }
        public string Oil_3_rail_pressure { get => oil_3_rail_pressure; set => oil_3_rail_pressure = value; }
        public string Oil_4_rail_pressure { get => oil_4_rail_pressure; set => oil_4_rail_pressure = value; }
        public string Oil_5_rail_pressure { get => oil_5_rail_pressure; set => oil_5_rail_pressure = value; }
        public string Fuel_heat { get => fuel_heat; set => fuel_heat = value; }
        public string Rail_pressure_group { get => rail_pressure_group; set => rail_pressure_group = value; }
        public string Flow_c4_r6 { get => flow_c4_r6; set => flow_c4_r6 = value; }
        public string Gu_version { get => gu_version; set => gu_version = value; }
        public string Sys_version { get => sys_version; set => sys_version = value; }
        public string Oilk { get => oilk; set => oilk = value; }
        public string Pumpinjk { get => pumpinjk; set => pumpinjk = value; }
        public string PumpRek { get => pumpRek; set => pumpRek = value; }
    }
}
