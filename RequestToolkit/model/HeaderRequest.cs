using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToolkit.model
{
    public class HeaderRequest
    {
        private List<HeaderObject> headers;
        public List<HeaderObject> Headers { get => headers; set => headers = value; }

        public HeaderRequest()
        {
            headers = new List<HeaderObject>();
        }

        public void ConvertHeader(String strHeader)
        {
            if (headers == null)
                headers = new List<HeaderObject>();
            else
                headers.Clear();
            String[] strHeaders = strHeader.Split('\n');
            if (String.IsNullOrEmpty(strHeader))
            {
                throw new Exception(ErrorContent.ERROR_EMPTY);
            }
            if (strHeaders.Length <= 0)
            {
                throw new Exception(ErrorContent.ERROR_ZERO_LENGTH);
            }

            foreach(String itemHeader in strHeaders)
            {
                String[] strKeyValue = itemHeader.Split(':');
                HeaderObject header = new HeaderObject();
                if (strKeyValue.Length <= 1)
                {
                    header.Key = "";
                    header.Value = "";
                }
                header.Key = strKeyValue[0].Trim();
                header.Value = strKeyValue[1].Trim();
                headers.Add(header);
            }
        }
        public void AddHeader(Chilkat.Http http)
        {
            if (headers.Count <= 0)
            {
                throw new Exception(ErrorContent.ERROR_ZERO_LENGTH);
            }
            foreach(HeaderObject headerObject in headers)
            {
                http.SetRequestHeader(headerObject.Key, headerObject.Value);
            }
        }
        public void AddHeader(Chilkat.HttpRequest httpRequest)
        {
            if (headers.Count <= 0)
            {
                throw new Exception(ErrorContent.ERROR_ZERO_LENGTH);
            }
            foreach (HeaderObject headerObject in headers)
            {
                httpRequest.AddHeader(headerObject.Key, headerObject.Value);
            }
        }
    }
}
