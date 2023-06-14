using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MusicSchoolDesctopClient.Model;
using MusicSchoolDesctopClient.Class;
using System.Net;

namespace MusicSchoolDesctopClient.Api
{
    public class ApiController
    {
        public static HttpClient client = new HttpClient();

        public async Task RunAsync()
        {
            // Update port # in the following line.
            client.BaseAddress = new Uri("http://localhost:80/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthUser> Authorization(User user)
        {
            AuthUser authUser = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("auth/login", user);
            authUser = await response.Content.ReadAsAsync<AuthUser>();
            return authUser;
        }
        public async Task<Teacher> GetTeacherByID(string IDUser)
        {
            Teacher teacher = null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TempData.UserToken);
            HttpResponseMessage response = await client.GetAsync($"user/teacher/{IDUser}");
            teacher = await response.Content.ReadAsAsync<Teacher>();

            return teacher;
        }

        public async Task<List<TeacherSchedule>> GetTeacherScheduleByID(int IDTeacher)
        {
            List<TeacherSchedule> teacherSchedule = null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TempData.UserToken);
            HttpResponseMessage response = await client.GetAsync($"schedule/teacher/{IDTeacher}");
            teacherSchedule = await response.Content.ReadAsAsync<List<TeacherSchedule>>();

            return teacherSchedule;
        }

        public async Task<List<StudentGrade>> GetLessonMarksByID(int IDLesson)
        {
            List<StudentGrade> marks = null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TempData.UserToken);
            HttpResponseMessage response = await client.GetAsync($"mark/lesson/{IDLesson}");
            marks = await response.Content.ReadAsAsync<List<StudentGrade>>();

            return marks;
        }

        public async Task<List<Student>> GetStudentsByLessonID(int IDLesson)
        {
            List<Student> students = null;
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TempData.UserToken);
            HttpResponseMessage response = await client.GetAsync($"mark/student/{IDLesson}");
            students = await response.Content.ReadAsAsync<List<Student>>();

            return students;
        }
        public async Task<Grade> AddMark(Grade grade)
        {
            Grade newGrade = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("mark/add/", grade);
            newGrade = await response.Content.ReadAsAsync<Grade>();
            return newGrade;
        }
        public async Task<Grade> EditMark(Grade grade)
        {
            Grade editGrade = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("mark/edit/", grade);
            editGrade = await response.Content.ReadAsAsync<Grade>();
            return editGrade;
        }

        public Byte[] GetImage(string path)
        {
            path = path.TrimStart("uploads\\\\".ToCharArray());
            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("Authorization", $"Bearer {TempData.UserToken}");
                byte[] data = webClient.DownloadData($"http://localhost:80/uploads/{path}");
                return data;
            }
        }
    }
}
