using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnapSpotService.DataObjects
{
    public class Spot_Media
    {
        public int Spot_MediaId { get; set; }
        public int MediaId { get; set; }
        public int SpotId { get; set; }
        public virtual Spot Spot { get; set; }
        public virtual Media Media{ get; set; }


    }
}