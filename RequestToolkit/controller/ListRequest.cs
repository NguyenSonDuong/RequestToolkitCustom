using RequestToolkit.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestToolkit.controller
{
    public class ListRequest
    {
        private List<DataRequest> dataRequests;
        API api;
        private bool isSaveCookie = true;
        private bool isFollow = true;
        public List<DataRequest> Headers { get => dataRequests; set => dataRequests = value; }
        public bool IsSaveCookie { get => isSaveCookie; set => isSaveCookie = value; }
        public bool IsFollow { get => isFollow; set => isFollow = value; }

        public ListRequest()
        {
            dataRequests = new List<DataRequest>();
            
        }
        public void InitApi()
        {
            api = new API(this.isSaveCookie, this.isFollow);
        }
        
        public void InitApi(bool isSaveCookie, bool isFollow)
        {
            api = new API(isSaveCookie, isFollow);
        }

        public void Run()
        {
            foreach(DataRequest dataRequest in dataRequests)
            {
                if (dataRequest.IsPost)
                {
                    if (dataRequest.PostRequest >= 0)
                    {
                        DataRequest data = dataRequests[dataRequest.PostRequest];
                        
                    }
                    api.POST(dataRequest.Content_type, dataRequest);
                }
                else
                {

                }
            }
        }
    }
}
