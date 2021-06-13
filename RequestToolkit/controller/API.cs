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
        }
        public void ActionFollowRedirects(bool isFollowLink)
        {
            http.FollowRedirects = isFollowLink;
        }
        public static API Build(bool isSaveCookie,bool isFollowLink)
        {
            API api = new API(isSaveCookie, isFollowLink);
            return api;
        }

        public Chilkat.HttpResponse Get(String url, String header)
        {
            if (!String.IsNullOrEmpty(header))
            {
                headerRequest.ConvertHeader(header);
                headerRequest.AddHeader(http);
            }
            Chilkat.HttpResponse responserequest = http.QuickRequest("GET", url);
            return responserequest;
        }
        
    }
}
