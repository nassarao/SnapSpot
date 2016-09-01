using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnapSpotService.DataObjects
{
    public class Spot_User
    {
        public int Spot_UserId { get; set; }
        public int Userid { get; set; }
        public int SpotId { get; set; }
        public virtual Spot Spot { get; set; }
        public virtual SnapSpotUser SnapSpotUser { get; set; }

    }
}