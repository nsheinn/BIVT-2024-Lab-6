using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.JavaScript;

namespace Lab_6;

public class Blue_3
{
    public struct Participant
    {
        
        private string _name;
        private string _surname;
        private int[] _penaltyTimes;
        
        public string Name => _name;
        public string Surname => _surname;

        public int[] PenaltyTimes
        {
            get
            {
                if (_penaltyTimes == null) return null;
                int[]copy = new int[_penaltyTimes.Length];
                Array.Copy( _penaltyTimes, copy, _penaltyTimes.Length);
                return copy;
            }
        }

        public int TotalTime
        {
            get
            {
                if (_penaltyTimes == null) return 0;
                return _penaltyTimes.Sum();
            }
        }

        public bool IsExpelled
        {
            get
            {
                if (_penaltyTimes == null) return false;
                foreach (var time in _penaltyTimes) if (time == 10) return true;
                return false;
            }
        }

        public Participant(string name, string surname)
        {
            _name = name;
            _surname = surname;
            _penaltyTimes = new int[0];
        }

        public void PlayMatch(int time)
        {
            if (_penaltyTimes == null) return;
            int[] newPenalty = new int[_penaltyTimes.Length + 1];
            Array.Copy(_penaltyTimes, newPenalty, _penaltyTimes.Length);
            newPenalty[_penaltyTimes.Length] = time;
            _penaltyTimes = newPenalty;
        }

        public static void Sort(Participant[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].TotalTime > array[j + 1].TotalTime)
                        (array[j], array[j+1]) = (array[j+1], array[j]);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine($"Name: {_name}, Surname: {_surname}, TotalTime: {TotalTime}, IsExpelled: {IsExpelled}, PenaltyTime: ");
            foreach (var x in _penaltyTimes) Console.Write($"{x} ");
            Console.WriteLine();
        }
    }
}