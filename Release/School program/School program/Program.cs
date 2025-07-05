using System;
using System.Collections.Generic;

namespace School_program
{
    class Program
    {
        static void Main(string[] args)
        {          
            Console.Write("Teacher count? ");
            int teacherCount = int.Parse(Console.ReadLine());
            var teachers = new List<Teacher>();
            

            for (int i = 0; i < teacherCount; i++)
            {
                Console.Write($"Name {i + 1}: ");
                string teacherName = Console.ReadLine();
                teachers.Add(new Teacher(teacherName));
            }
           
            Console.Write("Subject count? ");
            int subjectCount = int.Parse(Console.ReadLine());
            var subjects = new List<Subject>();

            for (int i = 0; i < subjectCount; i++)
            {
                Console.Write($"Subject name {i + 1}: ");
                string subjectName = Console.ReadLine();

                Console.Write($"Teacher for \"{subjectName}\": ");
                string teacherName = Console.ReadLine();

                var foundTeacher = teachers.Find(t => t.Name.Equals(teacherName, StringComparison.OrdinalIgnoreCase));
                if (foundTeacher == null)
                {                  
                    foundTeacher = new Teacher(teacherName);
                    teachers.Add(foundTeacher);
                }

                subjects.Add(new Subject(subjectName, foundTeacher));
            }

            Console.Write("Number of classes: ");
            int classCount = int.Parse(Console.ReadLine());
            var classes = new List<string>();

            for (int i = 0; i < classCount; i++)
            {
                Console.Write($"Class name #{i + 1}: ");
                string className = Console.ReadLine();
                classes.Add(className);
            } 

            Console.Write("Rooms count? ");
            int roomCount = int.Parse(Console.ReadLine());
            var rooms = new List<string>();

            for (int j = 0; j < roomCount; j++)
            {
                Console.Write($"Room name #{j + 1}: ");
                rooms.Add(Console.ReadLine());
            }

            
            var manager = new ScheduleManager(classes, subjects, teachers, rooms);
            manager.GenerateSchedule();
            manager.PrintSchedule();
        }
    }
}



