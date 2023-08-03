using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maui_project_rest.Util
{
    public class HttpHelper
    {

        public static HttpClient GetHttpClient(string BaseAddress = null, int? port = null)
        {
            var _client = default(HttpClient);
            if (!port.HasValue)
                port = 80;
            if (string.IsNullOrWhiteSpace(BaseAddress)) 
                BaseAddress =
                  DeviceInfo.Platform == DevicePlatform.Android ? $"https://10.0.2.2:{port}" : $"https://localhost:{port}/";

            #if DEBUG
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            _client = new HttpClient(handler.GetPlatformMessageHandler());
            #else
            _client = new HttpClient();
            #endif

            _client.BaseAddress = new Uri(BaseAddress);
            return _client;

        }

    }
}
