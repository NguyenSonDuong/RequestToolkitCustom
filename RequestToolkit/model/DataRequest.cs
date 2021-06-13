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
        private String url;
        private String headerRequest;
        private String bodyRequest;
        private String responsive;
        private String headerResponsive;
        public String GetData(String regex,String type, int pos = 0)
        {
            if (type.Equals(RequestKey.HEADER))
            {
                return Regex.Match(headerResponsive, regex).Groups[pos].ToString();
            }else if (type.Equals(RequestKey.URL))
            {
                return Regex.Match(url, regex).Groups[pos].ToString();
            }
            else if (type.Equals(RequestKey.RESPONSIVE))
            {
                return Regex.Match(responsive, regex).Groups[pos].ToString();
            }
            return null;
        }
        public String SetData(String regex,String data ,String type, int pos = 0)
        {
            Regex regexObj = new Regex(regex);
            if (type.Equals(RequestKey.HEADER))
            {
                return R
            }
            else if (type.Equals(RequestKey.URL))
            {
                return Regex.Match(url, regex).Groups[pos].ToString();
            }
            else if (type.Equals(RequestKey.RESPONSIVE))
            {
                return Regex.Match(responsive, regex).Groups[pos].ToString();
            }
            return null;
        }

    }
}
