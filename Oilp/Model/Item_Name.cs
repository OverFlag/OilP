using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OilP.Model
{
    public class Item_Name
    {
        private string name;
        private string language;
        private string type;
        private string op;

        public string Name { get => name; set => name = value; }
        public string Language { get => language; set => language = value; }
        public string Type { get => type; set => type = value; }
        public string Op { get => op; set => op = value; }
    }
}
