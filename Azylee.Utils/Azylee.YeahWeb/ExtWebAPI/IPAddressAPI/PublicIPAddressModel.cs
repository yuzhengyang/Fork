using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Azylee.YeahWeb.ExtWebAPI.IPAddressAPI
{
    public class PublicIPAddressModel
    {
        public string IP { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public PublicIPAddressModel()
        {

        }
        public PublicIPAddressModel(string ip, string id, string name)
        {
            this.IP = ip;
            this.ID = id;
            this.Name = name;
        }
    }
}
