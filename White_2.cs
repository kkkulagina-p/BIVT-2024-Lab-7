using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_2
    {
        public class Participant
        {
            static readonly double _normal=7;
            private string _surname;
            private string _name;
            private double _firstJump;
            private double _secondJump;
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

            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double BestJump => Math.Max(_firstJump, _secondJump);
            public bool IsPassed
            {
                get
                {
                    return (BestJump >= _normal);
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _firstJump = 0;
                _secondJump = 0;
            }
            public Participant(string name, string surname,double firstJump,double secondJump)
            {
                _name = name;
                _surname = surname;
                _firstJump = firstJump;
                _secondJump = secondJump;
            }
            static Participant()
            {
                _normal = 3;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                bool y;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    y = false;
                    for (int j = 0; j < array.Length - 1 - i; j++)
                    {
                        if (array[j].BestJump < array[j + 1].BestJump)
                        {
                            (array[j], array[j + 1]) = (array[j + 1], array[j]);
                            y = true;
                        }
                    }
                    if (!y) break;
                }
            }
            public void Jump(double result)
            {
                if (_firstJump == 0) _firstJump = result;
                else if (_secondJump == 0) _secondJump = result;
            }
            public static Participant[] GetPassed(Participant[] participants)
            {
                if (participants == null) return null;
                Participant[] participants1 = new Participant[0]; 
                for(int i = 0;i< participants.Length; i++)
                {
                    if (participants[i].IsPassed)
                    {
                        Array.Resize(ref participants1, participants1.Length+1);
                        participants1[participants1.Length-1] = participants[i];
                    }
                }
                return participants1;
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {_surname} {_firstJump} {_secondJump} {BestJump}");
            }
        }
    }
}
