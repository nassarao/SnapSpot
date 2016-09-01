using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Spatial;

namespace SnapSpotService.DataObjects
{
    public class Spot
    {
        
        public int SpotId { get; set; }
        public string Name { get; set; }

        public DbGeography Geography { get; set; }
        public DateTime CreationDate { get; set; }
        public int SnapSpotUserId { get; set; }
        public virtual SnapSpotUser SnapSpotUser { get; set; }



    }
}