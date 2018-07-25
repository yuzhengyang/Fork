using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI
{
    public class IPLocationModel
    {
        /// <summary>
        /// 经度（东经西经，纵向）
        /// </summary>
        public double Longitude { get; set; }
        /// <summary>
        /// 纬度（北纬南纬，横向）
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// 结构化地址信息
        /// </summary>
        public string FormattedAddress { get; set; }
        /// <summary>
        /// 所在商圈信息
        /// </summary>
        public string Business { get; set; }
        /// <summary>
        /// 结合POI的语义化结果描述
        /// </summary>
        public string SematicDescription { get; set; }
        public Component Component { get; set; }
        public FirstPOI FirstPOI { get; set; }
        /// <summary>
        /// 对比两个位置是否相似
        /// </summary>
        /// <param name="loc"></param>
        /// <returns></returns>
        public bool Like(IPLocationModel loc)
        {
            try
            {
                if (this != null && loc != null && FirstPOI != null && loc.FirstPOI != null)//模型不为空
                    if (FirstPOI.Address == loc.FirstPOI.Address)//判断语义化地址相同
                        return true;//判定为相同地点
            }
            catch { }
            return false;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(FirstPOI?.Address + ",");
            sb.Append(SematicDescription ?? "");
            return sb.ToString();
        }
    }
    /// <summary>
    /// 地址组成
    /// </summary>
    public class Component
    {
        public string Country { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Town { get; set; }
        public string AdCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
        public string Direction { get; set; }
        public string Distance { get; set; }
    }
    /// <summary>
    /// 首选信息点
    /// </summary>
    public class FirstPOI
    {
        public string Address { get; set; }
        public string Name { get; set; }
    }
}
