using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public int IDStudyGroup { get; set; }
        public int IDUser { get; set; }
        public string Phone { get; set; }
        public string IDGender { get; set; }
        public string FIO 
        {
            get 
            {
                return $"{LastName} {FirstName} {Patronymic}";
            }    
        }
    }
}
