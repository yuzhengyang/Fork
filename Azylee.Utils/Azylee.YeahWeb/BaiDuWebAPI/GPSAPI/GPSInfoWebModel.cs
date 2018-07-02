using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.BaiDuWebAPI.GPSAPI
{
    public class GPSInfoWebModel
    {
        public int status { get; set; }
        public BaiduGPSInfoWebResult result { get; set; }
        public GPSInfoModel ToGPSInfoModel()
        {
            GPSInfoModel model = null;
            if (result != null && result .addressComponent!= null)
            {
                model = new GPSInfoModel();
                model.Country = result.addressComponent.country;
                model.Province = result.addressComponent.province;
                model.City = result.addressComponent.city;
                model.District = result.addressComponent.district;
                model.Street = result.addressComponent.street;
                model.Address = result.formatted_address;
            }  
            return model;
        }
    }

    public class BaiduGPSInfoWebResult
    {
        public Location location { get; set; }
        public string formatted_address { get; set; }
        public string business { get; set; }
        public AddressComponent addressComponent { get; set; }
        public IList<object> pois { get; set; }
        public IList<object> roads { get; set; }
        public IList<object> poiRegions { get; set; }
        public string sematic_description { get; set; }
        public int cityCode { get; set; }
    }
    public class Location
    {
        public double lng { get; set; }
        public double lat { get; set; }
    }

    public class AddressComponent
    {
        public string country { get; set; }
        public int country_code { get; set; }
        public string country_code_iso { get; set; }
        public string country_code_iso2 { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public int city_level { get; set; }
        public string district { get; set; }
        public string town { get; set; }
        public string adcode { get; set; }
        public string street { get; set; }
        public string street_number { get; set; }
        public string direction { get; set; }
        public string distance { get; set; }
    }


}
