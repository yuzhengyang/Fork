using Azylee.YeahWeb.HttpUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.TencentWebAPI.PictureAI
{
    public class PictureScener
    {
        public static string GetInfo(int app_id, int time_stamp, string nonce_str, string sign, int format, int topk, string image)
        {
            try
            {
                string url = $"https://api.ai.qq.com/fcgi-bin/vision/vision_scener?";
                StringBuilder param = new StringBuilder();
                param.Append($"app_id={app_id}");
                param.Append($"&time_stamp={time_stamp}");
                param.Append($"&nonce_str={nonce_str}");
                param.Append($"&sign={sign}");
                param.Append($"&format={format}");
                param.Append($"&topk={topk}");
                param.Append($"&image={image}");
                string rs = HttpTool.Post(url, param.ToString());

            }
            catch { }
            return null;
        }
    }
}
