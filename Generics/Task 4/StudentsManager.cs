using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 4
// Разработайте систему управления учебными курсами и студентами

// В системе необходимо:
// Хранить данные о студентах и их прогрессе в рамках различных курсов с помощью класса Dictionary<Student, List<CourseProgress>>, где:
// Student — класс, содержащий информацию о студенте (ФИО, ID, группа).
// CourseProgress — класс, отражающий прогресс студента в конкретном курсе (название курса, текущий балл, завершенные темы, текущая тема)

// Реализовать функциональность:
// Добавления нового студента или обновления информации о существующем студенте.
// Добавления курса к студенту и обновления его прогресса.
// Поиска и фильтрации студентов по различным критериям (например, по группе, статусу прогресса в курсе, текущему баллу).
// Сортировки студентов в зависимости от их успеваемости.

namespace Generics_HW.Task_4
{
    internal class StudentsManager
    {
        private readonly Dictionary<Student, List<CourseProgress>> dict = [];
        public IReadOnlyDictionary<Student, List<CourseProgress>> Dict => dict;


        public void AddStudent(Student student)
        {
            dict.Add(student, []);
        }

        // В общем, теперь Hash код студента основывается только на его Id, так что остальное можно менять безопасно
        public bool ChangeStudent(int studentId, Student newStudent)
        {
            Student? key = dict.Keys.FirstOrDefault(s => s.Id == studentId);
            if (key == null)
                return false;

            key.Change(newStudent);
            return true;
        }

        public bool AddCourse(Student student, CourseProgress newCourse)
        {
            if(dict.TryGetValue(student, out List<CourseProgress>? couseList) == false)
                return false;

            else
                couseList.Add(newCourse);
            

            return true;
        }


        public bool UpdateProgress(Student student, string newTopic)
        {
            if (dict.TryGetValue(student, out List<CourseProgress>? couseList) == false)
                return false;

            CourseProgress currentCourse = couseList[^1];
            currentCourse.CompletedTopics.Add(currentCourse.CurrentTopic);
            currentCourse.CurrentTopic = newTopic;

            return true;
        }

        public List<Student> SortStudentByRating()
        {
            List<KeyValuePair<Student, List<CourseProgress>>> notSortedStudents = [.. dict];

            // Берём последний курс, если он существует
            notSortedStudents.Sort((a, b) =>
            {
                int ra = (a.Value is not null && a.Value.Count > 0 ? a.Value[^1].CurrentRating : 0);
                int rb = (b.Value is not null && b.Value.Count > 0 ? b.Value[^1].CurrentRating : 0);
            });
        }
    }
}
