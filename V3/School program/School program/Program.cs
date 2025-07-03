using System;
using System.Collections.Generic;

namespace School_program
{
    class Program
    {
        static void Main(string[] args)
        {
            var teacher1 = new Teacher("Ivanov");
            var teacher2 = new Teacher("Petrova");
            var teacher3 = new Teacher("Georgieva");

            var subjects = new List<Subject>
        {
            new Subject("Math", teacher1),
            new Subject("Physics", teacher2),
            new Subject("Bulgarian", teacher3)
        };

            var classes = new List<string> { "8A", "8B" };
            var teachers = new List<Teacher> { teacher1, teacher2, teacher3 };
            var rooms = new List<string> { "101", "102", "103" };

            ScheduleManager manager = new ScheduleManager(classes, subjects, teachers, rooms);
            manager.GenerateSchedule();
            manager.PrintSchedule();
        }
    }
}
