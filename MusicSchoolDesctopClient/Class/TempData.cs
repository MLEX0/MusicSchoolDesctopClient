using MusicSchoolDesctopClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Class
{
    public class TempData
    {
        public static string UserToken { get; set; }
        public static Teacher TeacherUser { get; set; } = null;
        public static string UserID { get; set; }
        public static string UserRoleID { get; set; }
        public static string UserImage { get; set; }
    }
}
