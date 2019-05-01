using Azylee.Jsons;
using Azylee.YeahWeb.HttpUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.dwz
{
    public static class DwzTool
    {
        /// <summary>
        /// 短网址生成接口
        /// </summary>
        /// <param name="token">由数字和字母组成的32位字符</param>
        /// <param name="url">长网址</param>
        /// <returns></returns>
        public static DwzResponseModel Create(string token,string url )
        {
            try
            {
                string address = $"https://dwz.cn/admin/v2/create";
                CookieCollection cookie = new CookieCollection();
                DwzRequestModel data = new DwzRequestModel();
                Dictionary<string, string> header = new Dictionary<string, string>();
                data.url = url;
                header.Add("Token", token);

                string rs = HttpToolPlus.PostJson(address, ref cookie, data, Encoding.UTF8, header);
                DwzResponseModel obj = Json.String2Object<DwzResponseModel>(rs);
                if (obj != null) return obj;
            }
            catch { }
            return null; 
        }
    }
}
