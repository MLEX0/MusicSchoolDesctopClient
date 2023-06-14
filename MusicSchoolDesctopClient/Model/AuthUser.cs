using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class AuthUser
    {
        public string token { get; set; }
        public string message { get; set; } = null;
        public string IdUser { get; set; }
        public string IDRole { get; set; }
        public string UserImage { get; set; }
    }
}
