using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SnapSpotService.DataObjects
{
    public class SnapSpotUser
    {
        public int SnapSpotUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreationDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}