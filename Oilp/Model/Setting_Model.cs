using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class Setting_Model
    {
        private string name;
        private string value;
        private string command;

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public string Command { get => command; set => command = value; }
    }
}
