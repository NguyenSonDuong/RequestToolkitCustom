using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RequestToolkit.model
{
    public class DataRequest
    {
        String url;
        String header;
        String body;
        String responsive;
        public String GetData(String regex,String type, int pos = 0)
        {
            if (type.Equals(RequestKey.HEADER))
            {
                return Regex.Match(header, regex).Groups[pos].ToString();
            }else if (type.Equals(RequestKey.URL))
            {
                return Regex.Match(url, regex).Groups[0].ToString();
            }
            else if (type.Equals(RequestKey.RESPONSIVE))
            {
                return Regex.Match(responsive, regex).Groups[0].ToString();
            }
            else if (type.Equals(RequestKey.BODY))
            {
                return Regex.Match(body, regex).Groups[0].ToString();
            }
        }
    }
}
