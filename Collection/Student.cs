using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection
{
    public class Student
    {
        public Student(string _fullName, int _numberOfGroup, int[] _scores)
        {
            fullName = _fullName;
            numberOfGroup = _numberOfGroup;
            scores = _scores;
        }
        public string fullName { get; set; }
        public int numberOfGroup  { get; set; }
        public int [] scores;

    }
}
