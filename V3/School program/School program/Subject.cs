using System;
using System.Collections.Generic;
using System.Text;

namespace School_program
{
    class Subject
    {      
        public string Name { get; set; }
        public Teacher Teacher { get; set; }

        public Subject(string name, Teacher teacher)
        {
            Name = name;
            Teacher = teacher;
        }

        //public Subject(string name)
        //{
        //    this.name = name;
        //}
        // ne ponq za ko e tui ot gore, mai e metod
    }
}
