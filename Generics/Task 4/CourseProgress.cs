using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_HW.Task_4
{
    internal class CourseProgress(string courseName, int currentRating = 0, string currentTopic = "Нет")
    {
        public string CourseName { get; set; } = courseName;            // Название курса
        public int CurrentRating { get; set; } = currentRating;         // Текущая оценка
        public List<string> CompletedTopics { get; set; } = [];         // Завершённые темы
        public string CurrentTopic { get; set; } = currentTopic;        // Текущая тема
    }
}
