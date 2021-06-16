using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RequestToolkit.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToolkit.controller
{

    public class API
    {

        private Chilkat.Http http = new Chilkat.Http();
        private HeaderRequest headerRequest = new HeaderRequest();
        private bool isSaveCookie;
        private bool isFollowLink;

        public bool IsSaveCookie { get => isSaveCookie; set => isSaveCookie = value; }
        public bool IsFollowLink { get => isFollowLink; set => isFollowLink = value; }

        public API(bool isSaveCookie, bool isFollowLink)
        {
            http.SaveCookies = isSaveCookie;
            http.SendCookies = isSaveCookie;
            http.CookieDir = "memory";
            http.FollowRedirects = isFollowLink;
        }
        public void ActionSaveCookie(bool isSaveCookie)
        {
            http.SaveCookies = isSaveCookie;
            http.SendCookies = isSaveCookie;
            http.CookieDir = "memory";
            if (!isSaveCookie)
                http.ClearInMemoryCookies();
        }
        public void ActionFollowRedirects(bool isFollowLink)
        {
            http.FollowRedirects = isFollowLink;
        }
        public static API Build(bool isSaveCookie, bool isFollowLink)
        {
            API api = new API(isSaveCookie, isFollowLink);
            return api;
        }
        public Chilkat.HttpResponse POST(string content_type,DataRequest data)
        {
            switch (content_type)
            {
                case "application/json":
                    return RequestJSON(data.Url, data.HeaderRequest, data.BodyRequest);
                case "application/x-www-form-urlencoded":
                    return RequestUrlEncode(data.Url, data.HeaderRequest, data.BodyRequest);
                case "multipart/form-data":
                    return RequestFormData(data.Url, data.HeaderRequest, data.BodyRequest);
                case "text/plane; charset=utf-8":
                    return RequestTextPlane(data.Url, data.HeaderRequest, data.BodyRequest);
                default:
                    throw new Exception(ErrorContent.ERROR_CONTENT_TYPE_NO_MATCH);
            }
        }
        public Chilkat.HttpResponse Get(String url, String header)
        {
            try
            {
                if (!String.IsNullOrEmpty(header))
                {
                    headerRequest.ConvertHeader(header);
                    headerRequest.AddHeader(http);
                }
                Chilkat.HttpResponse responserequest = http.QuickRequest("GET", url);
                return responserequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Chilkat.HttpResponse RequestJSON(String url, String header, String json)
        {
            try
            {
                string jsonParameter = json.Trim();
                try
                {
                    JObject keyValues = JObject.Parse(jsonParameter);
                }
                catch(Exception ex)
                {
                    throw new Exception(ErrorContent.ERROR_JSON_FORMAT);
                }
                if (!String.IsNullOrEmpty(header))
                {
                    headerRequest.ConvertHeader(header);
                    headerRequest.AddHeader(http);
                }
                Chilkat.HttpResponse responserequest = http.PostJson2(url, ContentType.JSON, jsonParameter);
                if(responserequest == null)
                {
                    throw new Exception(ErrorContent.ERROR_REUQEST_NULL);
                }
                return responserequest;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Chilkat.HttpResponse RequestFormData(String url, String header, String body)
        {
            try
            {
                StringBuilder path = new StringBuilder();
                StringBuilder host = new StringBuilder();
                int count = 0;
                foreach (char item in url.ToCharArray())
                {
                    if (item == '/')
                    {
                        count++;
                    }
                    if (count >= 3)
                    {
                        path.Append(item);
                        continue;
                    }
                    if (count == 2)
                    {
                        if (item == '/')
                            continue;
                        host.Append(item);
                    }
                }
                Chilkat.HttpRequest requestHttp = new Chilkat.HttpRequest();
                if (!String.IsNullOrEmpty(header))
                {
                    headerRequest.ConvertHeader(header);
                    headerRequest.AddHeader(requestHttp);
                }
                requestHttp.HttpVerb = "POST";
                requestHttp.Path = path.ToString();
                requestHttp.ContentType = ContentType.FORM_DATA;
                List<string> lstParameter = new List<string>(body.Split('\n'));
                foreach (string itemParameter in lstParameter)
                {
                    String[] item = itemParameter.Split(new char[] { ':' }, 2);
                    if (itemParameter.Trim() == String.Empty)
                        continue;
                    try
                    {
                        String key = item[1].Split(new char[] { '=' }, 2)[0].Trim();
                        String value = item[1].Split(new char[] { '=' }, 2)[1].Trim();
                        if (item[0].ToLower().Equals("file"))
                        {
                            requestHttp.AddFileForUpload(key, value);
                        }
                        else
                        {
                            requestHttp.AddParam(key, value);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                Chilkat.HttpResponse httpResponse = http.SynchronousRequest(host.ToString(), url.StartsWith("https") ? 443 : 80, url.StartsWith("https") ? true : false, requestHttp);
                if (httpResponse == null)
                {
                    throw new Exception(ErrorContent.ERROR_REUQEST_NULL);
                }
                return httpResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Chilkat.HttpResponse RequestUrlEncode(String url, String header, String body)
        {
            try
            {
                Chilkat.HttpRequest httpRequest = new Chilkat.HttpRequest();
                if (!String.IsNullOrEmpty(header))
                {
                    headerRequest.ConvertHeader(header);
                    headerRequest.AddHeader(httpRequest);
                }
                httpRequest.HttpVerb = "POST";
                httpRequest.ContentType = ContentType.URL_ENCODE;
                
                List<string> lstParameter = new List<string>(body.Split('&'));
                foreach (string itemParameter in lstParameter)
                {
                    if (itemParameter.Trim() == String.Empty)
                        continue;
                    httpRequest.AddParam(itemParameter.Split('=')[0].Trim(), itemParameter.Split('=')[1].Trim());
                }
                Chilkat.HttpResponse httpResponse = http.PostUrlEncoded(url, httpRequest);
                if (httpResponse == null)
                {
                    throw new Exception(ErrorContent.ERROR_REUQEST_NULL);
                }
                return httpResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Chilkat.HttpResponse RequestTextPlane(String url, String header, String body)
        {
            try
            {
                string jsonParameter = body.Trim();
                if (!String.IsNullOrEmpty(header))
                {
                    headerRequest.ConvertHeader(header);
                    headerRequest.AddHeader(http);
                }
                Chilkat.HttpResponse httpResponse = http.PostJson2(url, ContentType.TEXT, jsonParameter);
                if (httpResponse == null)
                {
                    throw new Exception(ErrorContent.ERROR_REUQEST_NULL);
                }
                return httpResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
