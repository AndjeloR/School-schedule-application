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
            var teacher4 = new Teacher("November");
            var teacher5 = new Teacher("Hei");
            var teacher6 = new Teacher("Gendo");

            var subjects = new List<Subject>
        {
            new Subject("Math", teacher1),
            new Subject("Physics", teacher2),
            new Subject("Bulgarian", teacher3),
            new Subject("Chilling010", teacher4),
            new Subject("Beingcool101", teacher5),
            new Subject("Piloting101", teacher6)

        };

            var classes = new List<string> { "8A", "8B" };
            var teachers = new List<Teacher> { teacher1, teacher2, teacher3 };
            var rooms = new List<string> { "101", "102", "103" };

            ScheduleManager manager = new ScheduleManager(classes, subjects, teachers, rooms);
            manager.GenerateSchedule();
            manager.PrintSchedule();

            //Проблема с тая БЕТА версия е че подрежда часовете по МНОГО тъп начин
        }
    }
}
