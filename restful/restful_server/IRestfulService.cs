using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace RestfulServer
{
    [ServiceContract()]
    public interface IRestfulService
    {
        /// <summary>
        /// 执行服务
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "ShowMessage/{msg}", Method = "POST",
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        string ShowMessage(string msg);
    }
}
