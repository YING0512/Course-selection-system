﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_selection_system
{
    internal class Course
    {
        public string CourseName { get; set; }
        public string Type { get; set; }
        public int Point { get; set; }
        public string OpeniingClass { get; set; }
        Teacher Tutor { get; set; }
        public Course(Teacher tutor)
        {
            Tutor = tutor;
        }
    }
}
