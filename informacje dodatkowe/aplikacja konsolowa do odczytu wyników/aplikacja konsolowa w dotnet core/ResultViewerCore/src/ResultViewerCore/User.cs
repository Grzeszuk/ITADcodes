using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultViewerCore
{
    public class User
    {
        public string username { get; set; }
        public int points { get; set; }
        public string usedQrCodes { get; set; }
        public string hashcode { get; set;}
    }

    public class UserResponse
    {
        public List<User> list { get; set; } = new List<User>();
    }
}
