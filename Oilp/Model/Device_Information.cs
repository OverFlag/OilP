﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    class Device_Information
    {
        private string model_no;
        private string manufacturer;
        private string version;
        private DateTime create_time;
        private string type;
        private string description;
        private string reserved_field;

        public string Model_no { get => model_no; set => model_no = value; }
        public string Manufacturer { get => manufacturer; set => manufacturer = value; }
        public string Version { get => version; set => version = value; }
        public DateTime Create_time { get => create_time; set => create_time = value; }
        public string Type { get => type; set => type = value; }
        public string Description { get => description; set => description = value; }
        public string Reserved_field { get => reserved_field; set => reserved_field = value; }
    }
}