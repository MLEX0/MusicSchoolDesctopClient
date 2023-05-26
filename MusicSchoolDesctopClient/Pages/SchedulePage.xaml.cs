using MusicSchoolDesctopClient.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicSchoolDesctopClient.Pages
{
    /// <summary>
    /// Логика взаимодействия для SchedulePage.xaml
    /// </summary>
    public partial class SchedulePage : Page
    {
        public SchedulePage()
        {
            InitializeComponent();

            List<SheduleClass> list = new List<SheduleClass>();
            SheduleClass s1 = new SheduleClass();
            s1.Numg = "МУЗ-1";
            s1.WeeDNum = 1;
            s1.SubjectNum = 1;
            s1.Subject = "Сольфеджио";
            s1.StartTime = TimeSpan.Parse("12:30:00");
            s1.ClassRoom = 11;
            s1.Floor = 1;
            list.Add(s1);
            s1 = new SheduleClass();
            s1.Numg = "МУЗ-1";
            s1.Subject = "﻿Сольфеджио";
            s1.WeeDNum = 1;
            s1.SubjectNum = 2;
            s1.StartTime = TimeSpan.Parse("18:15:00");
            s1.ClassRoom = 11;
            s1.Floor = 1;
            list.Add(s1);
            s1 = new SheduleClass();
            s1.Numg = "ИЗО-2";
            s1.Subject = "﻿Декоративно-прикладное искусство";
            s1.SubjectNum = 3;
            s1.WeeDNum = 2;
            s1.StartTime = TimeSpan.Parse("17:30:00");
            s1.ClassRoom = 11;
            s1.Floor = 1;
            list.Add(s1);
            s1 = new SheduleClass();
            s1.Numg = "ХОРЕО-1";
            s1.Subject = "﻿Гимнастика";
            s1.SubjectNum = 4;
            s1.WeeDNum = 3;
            s1.StartTime = TimeSpan.Parse("19:45:00");
            s1.ClassRoom = 30;
            s1.Floor = 3;
            list.Add(s1);

            s1 = new SheduleClass();
            s1.Numg = "ХОРЕО-1";
            s1.Subject = "﻿Гимнастика";
            s1.SubjectNum = 4;
            s1.WeeDNum = 5;
            s1.StartTime = TimeSpan.Parse("19:45:00");
            s1.ClassRoom = 30;
            s1.Floor = 3;
            list.Add(s1);

            s1 = new SheduleClass();
            s1.Numg = "ИЗО-2";
            s1.Subject = "﻿Основы изобразительной грамоты";
            s1.SubjectNum = 5;
            s1.WeeDNum = 4;
            s1.StartTime = TimeSpan.Parse("17:30:00");
            s1.ClassRoom = 11;
            s1.Floor = 1;
            list.Add(s1);


            List<string> time = new List<string>() { "9:00:00", "9:45:00", "10:30:00", "11:15:00", "12:00:00", "12:45:00", "13:30:00", "13:15:00",
                "14:00:00", "14:45:00", "15:30:00"
            , "16:15:00", "17:00:00", "17:45:00", "18:30:00", "19:15:00", "20:00:00", "20:45:00", "21:30:00", "22:15:00", "23:00:00"
            };

            foreach (SheduleClass s in list)
            {
                int positionRow = 0;
                Elements.Schedule shedule = new Elements.Schedule();
                shedule.numGroup.Text = s.Numg;
                shedule.claaRoom.Text = s.Floor.ToString();
                shedule.Floor.Text = s.Floor.ToString();
                shedule.startTime.Text = s.StartTime.ToString();
                shedule.subject.Text = s.Subject;



                SheduleGrid.Children.Add(shedule);

                var temp = (time.Where(i => TimeSpan.Parse(i) >= s.StartTime && TimeSpan.Parse(i) <= s.StartTime.Add(new TimeSpan(00, 45, 0))).FirstOrDefault());
                positionRow = time.IndexOf(temp);

                Grid.SetColumn(shedule, s.WeeDNum);

                Grid.SetRow(shedule, positionRow);
                string str = s.Subject;

                switch (s.SubjectNum)
                {
                    case 1:
                        shedule.mainBorder.Background = Brushes.Red;
                        break;

                    case 2:
                        shedule.mainBorder.Background = Brushes.Green;
                        break;

                    case 3:
                        shedule.mainBorder.Background = Brushes.Purple;
                        break;

                    case 4:
                        shedule.mainBorder.Background = Brushes.Blue;
                        break;

                    case 5:
                        shedule.mainBorder.Background = Brushes.Yellow;
                        break;


                }
                if (str == "Сольфеджио")
                {
                    shedule.mainBorder.Background = Brushes.Blue;
                }

            }




        }
    }

    public partial class SheduleClass
    {
        public string Numg { get; set; }
        public int WeeDNum { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public string Subject { get; set; }
        public int SubjectNum { get; set; }
        public Nullable<int> ClassRoom { get; set; }
        public Nullable<int> Floor { get; set; }
    }
}
