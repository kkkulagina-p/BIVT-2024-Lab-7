using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_3
    {
        public class Student
        {
            private string _name;
            private string _surname;
            protected int[] _marks;
            protected int _skipped;
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Name
            {
                get
                {
                    if (_name == null) return default;
                    return _name;
                }
            }
            public double AvgMark
            {
                get
                {
                    if (_marks == null || _marks.Length == 0) return 0;
                    return (double)_marks.Sum() / _marks.Length;
                }
            }
            public int Skipped => _skipped;
            public Student(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[0];
                _skipped = 0;
            }
            protected Student(Student student)
            {
                if(student == null||student._marks==null) return;
                _name = student._name;
                _surname = student._surname;
                _marks = new int[student._marks.Length];
                Array.Copy(student._marks, _marks, student._marks.Length);
                _skipped = student._skipped;
            }
            public void Lesson(int mark)
            {
                if (mark == 0) _skipped++;
                else
                {
                    if (_marks == null) return;
                    int[] new_marks = new int[_marks.Length + 1];
                    for (int i = 0; i < _marks.Length; i++)
                    {
                        new_marks[i] = _marks[i];
                    }
                    new_marks[new_marks.Length - 1] = mark;
                    _marks = new_marks;
                }
            }

            public static void SortBySkipped(Student[] array)
            {
                if (array == null || array.Length == 0) return;
                bool y;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].Skipped < array[j + 1].Skipped)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {AvgMark} {_skipped}");
            }

        }
        public class Undergraduate: Student
        {
            public Undergraduate(string name, string surname): base(name, surname) { }
            public Undergraduate( Student student ) : base(student) { }
            public void WorkOff(int mark)
            {
                if (_skipped > 0)
                {
                    _skipped--;
                    Lesson(mark);
                }
                else
                {
                    for(int i=0;i<_marks.Length;i++)
                    {
                        if (_marks[i] == 2)
                        {
                            _marks[i] = mark;
                            break;
                        }
                    }
                }
            }
        }
    }
}
