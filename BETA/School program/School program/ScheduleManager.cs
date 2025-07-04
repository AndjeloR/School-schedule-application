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

        private Dictionary<string, Dictionary<string, LessonSlot[]>> schedule;

        private string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" };
        private int hoursPerDay = 6;

        public ScheduleManager(List<string> classes, List<Subject> subjects, List<Teacher> teachers, List<string> rooms)
        {
            this.classes = classes;
            this.subjects = subjects;
            this.teachers = teachers;
            this.rooms = rooms;
            schedule = new Dictionary<string, Dictionary<string, LessonSlot[]>>();

            foreach (string className in classes)
            {
                schedule[className] = new Dictionary<string, LessonSlot[]>();
                foreach (string day in days)
                {
                    schedule[className][day] = new LessonSlot[hoursPerDay];
                }
            }
        }

        public void GenerateSchedule()
        {
            Random rand = new Random();

            foreach (string day in days)
            {
                for (int hour = 0; hour < hoursPerDay; hour++)
                {
                    foreach (string className in classes)
                    {
                        bool placed = false;
                        int attempts = 0;

                        while (!placed && attempts < 100)
                        {
                            Subject subject = subjects[rand.Next(subjects.Count)];
                            Teacher teacher = subject.Teacher;
                            string room = rooms[rand.Next(rooms.Count)];

                            LessonSlot newSlot = new LessonSlot(className, subject, teacher, room, day, hour + 1);

                            if (!IsConflict(newSlot))
                            {
                                schedule[className][day][hour] = newSlot;
                                placed = true;
                            }

                            attempts++;
                        }

                        if (!placed)
                        {
                            Console.WriteLine($"❌ Неуспех при добавяне на предмет за {className}, {day}, час {hour + 1}");
                        }
                    }
                }
            }
        }

        private bool IsConflict(LessonSlot slot)
        {
            foreach (var classSchedule in schedule)
            {
                foreach (var daySchedule in classSchedule.Value)
                {
                    if (daySchedule.Key == slot.Day)
                    {
                        LessonSlot[] lessons = daySchedule.Value;
                        LessonSlot other = lessons[slot.Hour - 1];

                        if (other != null)
                        {
                            if (other.Teacher.Name == slot.Teacher.Name)
                                return true;
                            if (other.Room == slot.Room)
                                return true;
                            if (other.ClassName == slot.ClassName)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public void PrintSchedule()
        {
            foreach (string className in classes)
            {
                Console.WriteLine($"---{className}---");

                foreach (string day in days)
                {
                    Console.WriteLine($"{day}:");

                    for (int hour = 0; hour < hoursPerDay; hour++)
                    {
                        LessonSlot slot = schedule[className][day][hour];
                        if (slot != null)
                        {
                            Console.WriteLine($"{hour + 1}: {slot.Subject.Name} ({slot.Teacher.Name}) - room {slot.Room}");
                        }
                        else
                        {
                            Console.WriteLine($"{hour + 1} subject: ---");
                        }
                    }
                }
            }
        }

        
    }
}


