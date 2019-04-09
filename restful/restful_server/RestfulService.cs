using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Activation;
using System.ServiceModel;

namespace RestfulServer {
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple, IncludeExceptionDetailInFaults = true)]
    class RestfulService : IRestfulService {
        #region IRestfulService 成员

        public string ShowMessage(string msg) {
            msg = DateTime.Now.ToString()+"  " + msg;
            Console.WriteLine(msg);
            return msg;
        }

        #endregion
    }
}
