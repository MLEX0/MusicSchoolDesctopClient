using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class Teacher
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Birthday { get; set; }
        public int IDUser { get; set; }
        public string Phone { get; set; }
        public string IDGender { get; set; }
    }
}
