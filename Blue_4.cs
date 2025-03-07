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
        public Team[] Teams => _teams;
        public Group(string name)
        {
            _name = name;
            _teams = new Team[0];
        }

        public void Add(Team team)
        {
            if (_teams == null) _teams = new Team[0];
            if (_teams.Length == 12) return;
            Team[] newTeams = new Team[_teams.Length + 1];
            Array.Copy(_teams, newTeams, _teams.Length);
            newTeams[_teams.Length] = team;
            _teams = newTeams;
        }
        public void Add(Team[] teams)
        {
            if (_teams.Length == 12 || teams.Length == 0) return;
            Team[] newTeams = new Team[Math.Min(12, _teams.Length + teams.Length)];
            Array.Copy(_teams, newTeams, _teams.Length);
            Array.Copy(teams, 0, newTeams, _teams.Length, Math.Min(12 - _teams.Length, teams.Length));
            _teams = newTeams;
        }

        public void Sort()
        {
            if (_teams == null) return;
            for (int i = 0; i < _teams.Length; i++)
            {
                for (int j = 0; j < _teams.Length - i - 1; j++)
                {
                    if (_teams[j].TotalScore < _teams[j + 1].TotalScore)
                        (_teams[j], _teams[j + 1]) = (_teams[j + 1], _teams[j]);
                }
            }
        }

        public static Group Merge(Group group1, Group group2, int size)
        {
            Group newGroup = new Group("Финалисты");
            int k = 0, index1 = 0, index2 = 0;
            while (k < size && index1 < group1.Teams.Length && index2 < group2.Teams.Length)
            {
                if (group1.Teams[index1].TotalScore > group2.Teams[index2].TotalScore)
                {
                    newGroup.Add(group1.Teams[index1]);
                    index1++;
                }
                else
                {
                    newGroup.Add(group2.Teams[index2]);
                    index2++;
                }
                k++;
            }

            while (k < size && index1 < group1.Teams.Length)
            {
                newGroup.Add(group1.Teams[index1]);
                index1++;
                k++;
            }

            while (k < size && index2 < group2.Teams.Length)
            {
                newGroup.Add(group2.Teams[index2]);
                index2++;
                k++;
            }
            
            return newGroup;
        }

        public void Print()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine("Комманды:");
            foreach(var x in Teams) Console.WriteLine($"{x.Name}, {x.TotalScore}");
        }
    }
}