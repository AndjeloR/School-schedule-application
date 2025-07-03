using System;
using System.Collections.Generic;
using System.Text;

namespace School_program
{
    class LessonSlot
    {
        // Наложи се да направя този клас щото примерния код за ScheduleManager който Chat GPT даде го изискваше
        public string ClassName { get; set; }
        public Subject Subject { get; set; }
        public Teacher Teacher { get; set; }
        public string Room { get; set; }
        public string Day { get; set; }
        public int Hour { get; set; }

        public LessonSlot(string className, Subject subject, Teacher teacher, string room, string day, int hour)
        {
            ClassName = className;
            Subject = subject;
            Teacher = teacher;
            Room = room;
            Day = day;
            Hour = hour;
        }
    }
}

