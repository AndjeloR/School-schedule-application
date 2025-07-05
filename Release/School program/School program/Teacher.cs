using System;
using System.Collections.Generic;
using System.Text;

namespace School_program
{
    class Teacher
    {
        private string name;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Teacher(string name)
        {
            Name = name;
        }
    }
}
