using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class StudentGrade
    {
        public int IDStudentGrade { get; set; }
        public int IDStudent { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int IDGrade { get; set; }
        public string GroupNumber { get; set; }
    }

}
