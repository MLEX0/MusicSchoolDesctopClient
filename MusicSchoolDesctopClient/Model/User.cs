using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int IDRole { get; set; }
        public string UserImagePath { get; set; } = null;
    }
}
