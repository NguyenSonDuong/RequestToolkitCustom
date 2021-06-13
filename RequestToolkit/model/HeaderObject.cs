using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToolkit.model
{
    public class HeaderObject
    {
        private String key;
        private String value;

        public string Key { get => key; set => key = value; }
        public string Value { get => value; set => this.value = value; }
    }
}
