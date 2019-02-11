using System.Collections.Generic;
using System.Net.Http;
using Noobow.Commons.Constants;

namespace Noobow.Commons.Utils
{
    public static class LineUtil
    {
        public static void PushMe(string message,HttpClient hc)
        {
            var content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "message", message }
            });
            hc.PostAsync(EndpointConstant.NOTIFY_ME_ENDPOINT, content);
        }
    }
}
