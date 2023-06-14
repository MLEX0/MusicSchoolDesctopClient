using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicSchoolDesctopClient.Model
{
    public class TeacherSchedule
    {
        public int IDLesson { get; set; }
        public string GroupNumber { get; set; }
        public int WeekDayNumber { get; set; }
        public DateTime LessonDate { get; set; }
        public string DayOfWeek { get; set; }
        public TimeSpan StartTime { get; set; }
        public string SubjectName { get; set; }
        public int ClassroomNumber { get; set; }
        public int Floor { get; set; }

        public string StringDate 
        { 
            get 
            {
                return $"{LessonDate.Date.ToShortDateString()} {StartTime.Hours}:{StartTime.Minutes}";
            } 
        }
    }
}
