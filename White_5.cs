using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    public class White_5
    {
        public struct Match
        {
            private int _goals;
            private int _misses;
            public int Goals => _goals;
            public int Misses => _misses;
            public int Difference => Goals - Misses;
            public int Score => Goals > Misses ? 3 : Goals == Misses ? 1 : 0;
            public Match(int goals, int misses)
            {
                if (goals < 0|| misses < 0)
                {
                    _goals = 0;
                    _misses = 0;
                    return;
                }
                else
                {
                    _goals = goals;
                    _misses = misses;
                }
               
            }
            public void Print()
            {
                Console.WriteLine($"{_goals} {_misses} {Score}");
            }
        }
        public abstract class Team
        {
            private string _name;
            private Match[] _matches;
            public string Name => _name;
            public Match[] Matches => _matches;
            public int TotalScore
            {
                get
                {
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Score;
                    }
                    return total;
                }
            }
            public int TotalDifference
            {
                get
                {
                    if (_matches == null || _matches.Length == 0) return 0;
                    int total = 0;
                    foreach (var match in _matches)
                    {
                        total += match.Difference;
                    }
                    return total;
                }
            }
            public Team(string name)
            {
                _name = name;
                _matches = new Match[0];
            }
            public virtual void PlayMatch(int goals, int misses)
            {
                if (_matches == null) return;
                Match newMatch = new Match(goals, misses);
                Match[] newMatches = new Match[_matches.Length + 1];
                for (int i = 0; i < _matches.Length; i++)
                {
                    newMatches[i] = _matches[i];
                }
                newMatches[newMatches.Length - 1] = newMatch;
                _matches = newMatches;
            }
            public static void SortTeams(Team[] teams)
            {
                if (teams == null) return;
                if (teams.Length == 0) return;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - i - 1; j++)
                    {
                        if ((teams[j].TotalScore < teams[j + 1].TotalScore) ||
                         (teams[j].TotalScore == teams[j + 1].TotalScore && teams[j].TotalDifference < teams[j + 1].TotalDifference))
                        {
                            Team tmp = teams[j];
                            teams[j] = teams[j + 1];
                            teams[j + 1] = tmp;
                        }
                    }
                }
            }
            public void Print()
            {
                Console.WriteLine($"{_name} {TotalScore} {TotalDifference}");
            }
        }
        public class ManTeam : Team
        {
            private ManTeam _derby;

            public ManTeam Derby => _derby;

            public ManTeam(string name, ManTeam derby = null) : base(name)
            {
                _derby = derby;
            }
            public void PlayMatch(int goals, int misses, ManTeam team = null)
            {
                if (team == _derby)
                {
                    goals++;
                }
                base.PlayMatch(goals, misses);
            }
        }
        public class WomanTeam : Team
        {
            private int[] _penalties;
            public int[] Penalties => _penalties;
            public int TotalPenalties
            {
                get
                {
                    int a = 0;
                    foreach (var penalty in _penalties)
                    {
                        a += penalty;
                    }
                    return a;
                }
            }
            public WomanTeam(string name) : base(name)
            {
                _penalties = new int[0];
            }
            public override void PlayMatch(int goals, int misses)
            {
                base.PlayMatch(goals, misses);

                if (misses > goals)
                {
                    int penalty = misses - goals;
                    int[] penalties1 = new int[_penalties.Length + 1];

                    for (int i = 0; i < _penalties.Length; i++)
                    {
                        penalties1[i] = _penalties[i];
                    }

                    penalties1[penalties1.Length - 1] = penalty;
                    _penalties = penalties1;
                }
            }
        }
    }
}
