using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

public class Blue_2
{
    public struct Participant
    {
        private string _name;
        private string _surname;
        private int[,] _marks;
        private int _jumpIndex = 0;


        public string Name => _name;
        public string Surname => _surname;

        public int[,] Marks
        {
            get
            {
                int[,] copy = new int[2, 5];
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                for (int i = 0; i < _marks.GetLength(0); i++)
                    for (int j = 0; j < _marks.GetLength(1); j++) 
                        copy[i, j] = _marks[i, j];
                return copy;
            }
        }
        public int TotalScore
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return 0;
                int sum = 0;
                foreach (var mark in _marks) sum += mark;
                return sum;
            }
        }
        
        public Participant(string name, string surname)
        {
            _name = name; 
            _surname = surname;
            _marks = new int[2, 5];
        }

        public void Jump(int[] result)
        {
            if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0 || result.Length == 0) return;
            if (result == null || _jumpIndex > 1) return;
            for (int i = 0; i < result.Length; i++)
            {
                _marks[_jumpIndex, i] = result[i];
            }
            _jumpIndex++;
        }

        public static void Sort(Participant[] array)
        {
            if (array == null || array.Length == 0) return;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j].TotalScore < array[j + 1].TotalScore)
                    {
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                    };
                }
            }
        }
            
        public void Print(Participant participant)
        {
            Console.WriteLine($"Name: {participant.Name}, Surname: {participant.Surname}, TotalScore: {participant.TotalScore}, Marks:");
            Console.Write("1 Jump: ");
            for (int i = 0; i < participant.Marks.GetLength(1); i++) Console.WriteLine($"{participant.Marks[0, i]} ");
            Console.Write("2 Jump: ");
            for (int i = 0 ; i < participant.Marks.GetLength(1); i++) Console.WriteLine($"{participant.Marks[1, i]} ");
        }
    }
}