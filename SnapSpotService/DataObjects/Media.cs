using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnapSpotService.DataObjects
{
    public class Media
    {
        public int MediaId { get; set; }
        public string FilePath { get; set; }
        public string Tags { get; set; }
        public DateTime CreationDate { get; set; }
        public int Size { get; set; }
        public int Flags { get; set; }
        public int Likes { get; set; }
        public int LiveTime { get; set; }
        public string FileType { get; set; }
        public bool Anonymous { get; set; }
        public int SnapSpotUserId { get; set; }
        public virtual SnapSpotUser SnapSpotUser { get; set; }

    }
}