using System;
using System.Collections.Generic;
using System.Text;

namespace School_program
{
    class ScheduleManager
    {
        private List<string> classes;
        private List<Subject> subjects;
        private List<Teacher> teachers;
        private List<string> rooms;
        private Dictionary<string, Dictionary<string, LessonSlot>> schedule;

        private string[] days = { "Понеделник", "Вторник", "Сряда", "Четвъртък", "Петък" };
        private int totalHoursPerDay = 6;

        public ScheduleManager(List<string> classes, List<Subject> subjects, List<Teacher> teachers, List<string> rooms)
        {
            this.classes = classes;
            this.subjects = subjects;
            this.teachers = teachers;
            this.rooms = rooms;
            this.schedule = new Dictionary<string, Dictionary<string, LessonSlot>>();
        }

        public void GenerateSchedule()
        {
            Random rand = new Random();

            foreach (string className in classes)
            {
                for (int day = 0; day < days.Length; day++)
                {
                    for (int hour = 1; hour <= totalHoursPerDay; hour++)
                    {
                        Subject subject = subjects[rand.Next(subjects.Count)];
                        Teacher teacher = subject.Teacher;
                        string room = rooms[rand.Next(rooms.Count)];
                        string timeKey = $"{days[day]}_{hour}";

                        LessonSlot newSlot = new LessonSlot(className, subject, teacher, room, days[day], hour);

                        if (!IsConflict(newSlot))
                        {
                            schedule[GetKey(className, days[day], hour)] = new Dictionary<string, LessonSlot>
                        {
                            { "slot", newSlot }
                        };
                        }
                        else
                        {
                            Console.WriteLine($"Конфликт за {className}, {days[day]} {hour}-ти час. Пропускане.");
                        }
                    }
                }
            }
        }

        private bool IsConflict(LessonSlot newSlot)
        {
            foreach (var entry in schedule.Values)
            {
                LessonSlot slot = entry["slot"];
                if (slot.Day == newSlot.Day && slot.Hour == newSlot.Hour)
                {
                    if (slot.Teacher.Name == newSlot.Teacher.Name)
                        return true;

                    if (slot.Room == newSlot.Room)
                        return true;

                    if (slot.ClassName == newSlot.ClassName)
                        return true;
                }
            }
            return false;
        }

        private string GetKey(string className, string day, int hour)
        {
            return $"{className}_{day}_{hour}";
        }

        public void PrintSchedule()
        {
            foreach (var entry in schedule)
            {
                var slot = entry.Value["slot"];
                Console.WriteLine($"{slot.Day}, {slot.Hour}-ти час – {slot.ClassName}: {slot.Subject.Name} ({slot.Teacher.Name}), стая {slot.Room}");
            }
        }
    }
}


