using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    class CONFIG_Model
    {
        private string name;
        private string value;

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
