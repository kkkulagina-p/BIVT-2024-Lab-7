using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_1
    {
        public class Participant
        {
            private string _surname;
            private string _club;
            private double _firstJump;
            private double _secondJump;
            private static int _jumpers;
            private static int _disqualified;
            private static double _normal;
            public string Surname
            {
                get
                {
                    if (_surname == null) return default;
                    return _surname;
                }
            }
            public string Club
            {
                get
                {
                    if (_club == null) return default;
                    return _club;
                }
            }
            public double FirstJump => _firstJump;
            public double SecondJump => _secondJump;
            public double JumpSum => _firstJump + _secondJump;
            public static int Jumpers => _jumpers;
            public static int Disqualified => _disqualified;

            public Participant(string surname, string club)
            {
                _surname = surname;
                _club = club;
                _firstJump = 0;
                _secondJump = 0;
                _jumpers++;
            }
            static Participant()
            {
                _normal = 5;
                _disqualified = 0;
                _jumpers = 0;
            }
            public void Jump(double result)
            {
                if (_firstJump == 0) _firstJump = result;
                else if (_secondJump == 0) _secondJump = result;
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0) return;
                for (int i = 0; i < array.Length - 1; i++)
                {
                    for (int j = 0; j < array.Length - i - 1; j++)
                    {
                        if (array[j].JumpSum < array[j + 1].JumpSum)
                        {
                            Participant temp = array[j];
                            array[j] = array[j + 1];
                            array[j + 1] = temp;
                        }
                    }
                }
            }
            public static void Disqualify(ref Participant[] participants)
            {
                if (participants == null) return;
                _jumpers = 0;
                int[] index = new int[0];
                for (int i = 0; i < participants.Length; i++)
                {
                    if (participants[i].FirstJump >= _normal || participants[i].SecondJump >= _normal)
                    {
                        _jumpers++;
                    }
                    else
                    {
                        _disqualified++;
                        Array.Resize(ref index, index.Length + 1);
                        index[index.Length - 1] = i;
                    }
                }
                Participant[] participants1 = new Participant[0];
                for (int i = 0; i < participants.Length; i++)
                {

                    if (!index.Contains(i))
                    {
                        Array.Resize(ref participants1, participants1.Length + 1);
                        participants1[participants1.Length - 1] = participants[i];
                    }
                }
                participants = participants1;
            }
            public void Print()
            {
                Console.WriteLine($"{_surname} {_club} {_firstJump} {_secondJump} {JumpSum}");
            }
        }
    }
}
