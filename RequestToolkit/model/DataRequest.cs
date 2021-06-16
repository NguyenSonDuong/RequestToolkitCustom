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

        private List<TypeReplate> typeReplates;
        private bool isPost;
        private String content_type;
        private int postRequest = -1;

        public string Url { get => url; set => url = value; }
        public string HeaderRequest { get => headerRequest; set => headerRequest = value; }
        public string BodyRequest { get => bodyRequest; set => bodyRequest = value; }
        public string Responsive { get => responsive; set => responsive = value; }
        public string HeaderResponsive { get => headerResponsive; set => headerResponsive = value; }
        public int PostRequest { get => postRequest; set => postRequest = value; }
        public string Content_type { get => content_type; set => content_type = value; }
        public bool IsPost { get => isPost; set => isPost = value; }
        public List<TypeReplate> TypeReplates { get => typeReplates; set => typeReplates = value; }

        public String GetData(String regex,String type, int pos = 0)
        {
            if (type.Equals(RequestKey.HEADER))
            {
                return Regex.Match(HeaderResponsive, regex).Groups[pos].ToString();
            }else if (type.Equals(RequestKey.URL))
            {
                return Regex.Match(Url, regex).Groups[pos].ToString();
            }
            else if (type.Equals(RequestKey.RESPONSIVE))
            {
                return Regex.Match(Responsive, regex).Groups[pos].ToString();
            }
            return null;
        }
        public void SetData(String regex, String data ,String type)
        {
            Regex regexObj = new Regex(regex);
            if (type.Equals(RequestKey.HEADER))
            {
                HeaderRequest = regexObj.Replace(HeaderRequest, data);
            }
            else if (type.Equals(RequestKey.URL))
            {
                Url = regexObj.Replace(Url, data);
            }
            else if (type.Equals(RequestKey.BODY)) 
            {
                BodyRequest = regexObj.Replace(BodyRequest, data);
            }
        }

    }
}
