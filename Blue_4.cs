using System;
using System.Linq;

namespace Lab_6;

public class Blue_4
{
    public struct Team
    {
        private string _name;
        private int[] _scores;

        public string Name => _name;

        public int[] Scores
        {
            get
            {
                if (_scores == null) return null;
                int[] copy = new int[_scores.Length];
                Array.Copy(_scores, copy, _scores.Length);
                return copy;
            }
        }

        public int TotalScore
        {
            get
            {
                if (_scores == null) return 0;
                return _scores.Sum();
            }
        }

        public Team(string name)
        {
            _name = name;
            _scores = new int[0];
        }

        public void PlayMatch(int result)
        {
            if (_scores == null) return;
            int[] newScores = new int[_scores.Length + 1];
            Array.Copy(_scores, newScores, _scores.Length);
            newScores[_scores.Length] = result;
            _scores = newScores;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {_name}, TotalScore: {TotalScore}");
            Console.WriteLine("Scores:");
            foreach(var score in _scores) Console.WriteLine(score);
        }
    }

    public struct Group
    {
        private string _name;
        private Team[] _teams;
        public string Name => _name;
        public int _teamIndex = 0;
        public Team[] Teams => _teams;
        public Group(string name)
        {
            _name = name;
            _teams = new Team[12];
        }

        public void Add(Team team)
        {
            if (_teamIndex >= 12) return;
            _teams[_teamIndex] = team;
            _teamIndex++;
        }

        public void Add(Team[] teams)
        {
            if (teams == null || teams.Length == 0 || _teamIndex >= 12) return;
            int teamsToAdd = Math.Min(12 - _teamIndex, teams.Length);
            for (int i = 0; _teamIndex < 12 && i < teams.Length; i++, _teamIndex++)
            {
                _teams[_teamIndex] = teams[i];
            }
        }

        public void Sort()
        {
            if (_teams == null) return;
            for (int i = 1; i < _teams.Length; i++)
            {
                var current = _teams[i];
                int j = i - 1;
                while (j >= 0 && _teams[j].TotalScore < current.TotalScore)
                {
                    _teams[j + 1] = _teams[j];
                    j--;
                }
                _teams[j + 1] = current;
            }
        }

        public static Group Merge(Group group1, Group group2, int size)
        {
            Group result = new Group("Финалисты");
            int i = 0, j = 0;
            int n = size / 2;
            while (i < n && j < n)
            {
                if (group1.Teams[i].TotalScore >= group2.Teams[j].TotalScore)
                {
                    result.Add(group1.Teams[i++]);
                }
                else
                {
                    result.Add(group2.Teams[j++]);
                }
            }
    
            while (i < n)
                result.Add(group1.Teams[i++]);
    
            while (j < n)
                result.Add(group2.Teams[j++]);

            return result;
        }


        public void Print()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine("Команды:");
            foreach(var x in Teams) Console.WriteLine($"{x.Name}, {x.TotalScore}");
        }
    }
}