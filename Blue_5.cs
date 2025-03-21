using System;
using System.Reflection;

namespace Lab_6;

public class Blue_5
{
    public struct Sportsman
    {
        private string _name;
        private string _surname;
        private int _place = 0;
        
        public string Name => _name;
        public string Surname => _surname;
        public int Place => _place;

        public Sportsman (string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public void SetPlace(int place)
        {
            if (place <= 0) return;
            if (_place == 0) _place = place;
        }

        public void Print()
        {
            Console.WriteLine($"{Name} {Surname} - {Place}");
        }
    }

    public struct Team
    {
        private string _name;
        private Sportsman[] _sportsmen;
        private int _index = 0;
        public string Name => _name;

        public Sportsman[] Sportsmen => _sportsmen;
        // {
        //     get
        //     {
        //         if(_sportsmen == null) return new Team[0];
        //         Team[] copy = new Team[_sportsmen.Length];
        //         Array.Copy(_sportsmen, copy, _sportsmen.Length);
        //         return copy;
        //     }   
        // }

        public int SummaryScore
        {
            get
            {
                if (_sportsmen == null) return 0;
                int[] scores = new int[]{0,5,4,3,2,1};
                int sum = 0;
                foreach (var x in _sportsmen)
                    if (1 <= x.Place && x.Place <= 5)
                    {
                        sum+=scores[x.Place];
                    }
                return sum;
            }
        }

        public int TopPlace
        {
            get
            {
                if (_sportsmen == null) return 0;
                int max = int.MaxValue;
                foreach (var x in _sportsmen) if (x.Place != 0) max = Math.Min(max, x.Place);
                return max == int.MaxValue ? 18 : max;
            }
        }

        public Team(string name)
        {
            _name = name;
            _sportsmen = new Sportsman[6];
        }

        public void Add(Sportsman sportsman)
        {
            if (_sportsmen == null) return;
            if (_index < _sportsmen.Length)
            {
                _sportsmen[_index] = sportsman;
                _index++;
            }
        }

        public void Add(Sportsman[] sportsmen)
        {
            if (sportsmen == null || _sportsmen == null || sportsmen.Length == 0) return;
            int addCount = Math.Min(_sportsmen.Length - _index, sportsmen.Length);
            Array.Copy(sportsmen, 0, _sportsmen, _index, addCount);
            _index += addCount;
        }

        public static void Sort(Team[] teams)
        {
            if (teams == null || teams.Length == 0) return;
            for (int i = 0; i < teams.Length; i++)
            {
                for (int j = 0; j < teams.Length - i - 1; j++)
                {
                    if (teams[j].SummaryScore < teams[j + 1].SummaryScore)
                        (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                    else if (teams[j].SummaryScore == teams[j + 1].SummaryScore && teams[j].TopPlace > teams[j + 1].TopPlace)
                            (teams[j], teams[j + 1]) = (teams[j + 1], teams[j]);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"Team name: {Name}. Team Summary Score: {SummaryScore}. Team Top Place: {TopPlace}");
            Console.WriteLine("Sportsmen:");
            foreach (var x in _sportsmen)
            {
                Console.WriteLine($"{x.Name} {x.Surname}. Место - {x.Place}");
            }
        }
    }
}