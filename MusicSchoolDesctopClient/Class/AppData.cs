using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicSchoolDesctopClient.Api;

namespace MusicSchoolDesctopClient.Class
{
    public class AppData
    {
        public static Api.ApiController Context { get; set; } = new Api.ApiController();
        public static void updateContext()
        {
            Context = new Api.ApiController();
        }
    }
}
