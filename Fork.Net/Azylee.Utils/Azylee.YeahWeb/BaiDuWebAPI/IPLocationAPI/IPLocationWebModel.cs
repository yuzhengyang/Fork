using Azylee.Core.DataUtils.CollectionUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.IPLocationAPI
{
    public class IPLocationWebModel
    {
        /// <summary>
        /// 
        /// </summary>
        public IpLoc ipLoc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Rgc rgc { get; set; }
        public IPLocationModel ToIPLocationModel()
        {
            IPLocationModel model = null;
            try
            {
                if (rgc != null)
                {
                    model = new IPLocationModel();
                    model.FirstPOI = new FirstPOI();
                    model.Component = new Component();
                    if (rgc.result != null)
                    {
                        model.FormattedAddress = rgc.result.formatted_address;
                        model.Business = rgc.result.business;
                        model.SematicDescription = rgc.result.sematic_description;
                        if (rgc.result.location != null)
                        {
                            model.Latitude = rgc.result.location.lat;
                            model.Longitude = rgc.result.location.lng;
                        }
                        if (ListTool.HasElements(rgc.result.pois))
                        {
                            model.FirstPOI.Address = rgc.result.pois[0].addr;
                            model.FirstPOI.Name = rgc.result.pois[0].name;
                        }
                        if (rgc.result.addressComponent != null)
                        {
                            model.Component.Country = rgc.result.addressComponent.country;
                            model.Component.Province = rgc.result.addressComponent.province;
                            model.Component.City = rgc.result.addressComponent.city;
                            model.Component.District = rgc.result.addressComponent.district;
                            model.Component.Town = rgc.result.addressComponent.town;
                            model.Component.AdCode = rgc.result.addressComponent.adcode;
                            model.Component.Street = rgc.result.addressComponent.street;
                            model.Component.StreetNumber = rgc.result.addressComponent.street_number;
                            model.Component.Direction = rgc.result.addressComponent.direction;
                            model.Component.Distance = rgc.result.addressComponent.distance;
                        }
                    }
                }
            }
            catch { }
            return model;
        }
        public class IpLoc
        {
            /// <summary>
            /// 
            /// </summary>
            public Content content { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public IPResult result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int time { get; set; }
        }
        public class Content
        {
            /// <summary>
            /// 
            /// </summary>
            public IPLocation location { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string locid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int radius { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int confidence { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int ip_type { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public IPPoint point { get; set; }
        }
        public class IPResult
        {
            /// <summary>
            /// 
            /// </summary>
            public int error { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string loc_time { get; set; }
        }
        public class IPLocation
        {
            /// <summary>
            /// 
            /// </summary>
            public int lat { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int lng { get; set; }
        }
        public class IPPoint
        {
            /// <summary>
            /// 
            /// </summary>
            public int x { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int y { get; set; }
        }
        public class Rgc
        {
            /// <summary>
            /// 
            /// </summary>
            public string status { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Result result { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string message { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int time { get; set; }
        }
        public class Result
        {
            /// <summary>
            /// 
            /// </summary>
            public Location location { get; set; }
            /// <summary>
            /// 山东省青岛市城阳区
            /// </summary>
            public string formatted_address { get; set; }
            /// <summary>
            /// 棘洪滩
            /// </summary>
            public string business { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public AddressComponent addressComponent { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<PoisItem> pois { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> roads { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public List<string> poiRegions { get; set; }
            /// <summary>
            /// 中车青岛四方机车车辆股份有限公司西北296米
            /// </summary>
            public string sematic_description { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int cityCode { get; set; }
        }
        public class Location
        {
            /// <summary>
            /// 
            /// </summary>
            public double lng { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double lat { get; set; }
        }
        public class AddressComponent
        {
            /// <summary>
            /// 中国
            /// </summary>
            public string country { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int country_code { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string country_code_iso { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string country_code_iso2 { get; set; }
            /// <summary>
            /// 山东省
            /// </summary>
            public string province { get; set; }
            /// <summary>
            /// 青岛市
            /// </summary>
            public string city { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public int city_level { get; set; }
            /// <summary>
            /// 城阳区
            /// </summary>
            public string district { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string town { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string adcode { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string street { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string street_number { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string direction { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string distance { get; set; }
        }

        public class Point
        {
            /// <summary>
            /// 
            /// </summary>
            public double x { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public double y { get; set; }
        }

        public class Parent_poi
        {
            /// <summary>
            /// 
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string addr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Point point { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string direction { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string distance { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
        }

        public class PoisItem
        {
            /// <summary>
            /// 山东省青岛市城阳区棘洪滩街道锦宏东路88号
            /// </summary>
            public string addr { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string cp { get; set; }
            /// <summary>
            /// 西北
            /// </summary>
            public string direction { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string distance { get; set; }
            /// <summary>
            /// 中车青岛四方机车车辆股份有限公司
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 公司企业
            /// </summary>
            public string poiType { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Point point { get; set; }
            /// <summary>
            /// 公司企业;公司
            /// </summary>
            public string tag { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string tel { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string uid { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string zip { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public Parent_poi parent_poi { get; set; }
        }
    }
}