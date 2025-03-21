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
        private int _jumpIndex;


        public string Name => _name;
        public string Surname => _surname;

        public int[,] Marks
        {
            get
            {
                if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0) return null;
                int[,] copy = new int[_marks.GetLength(0), _marks.GetLength(1)];
                Array.Copy(_marks, copy, _marks.Length);
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
            _jumpIndex = 0;
        }

        public void Jump(int[] result)
        {
            if (_marks == null || _marks.GetLength(0) == 0 || _marks.GetLength(1) == 0 || result == null) return;
            if (result.Length == 0 || _jumpIndex > 1 || _jumpIndex < 0) return;
            int count = Math.Min(5, result.Length);
            for (int i = 0; i < count; i++)
            {
                _marks[_jumpIndex, i] = result[i];
            }
            _jumpIndex++;
        }

        public static void Sort(Participant[] array)
        {
            if (array == null || array.Length < 2) return;

            for (int i = 1; i < array.Length; i++)
            {
                var current = array[i];
                int j = i - 1;
                while (j >= 0 && array[j].TotalScore < current.TotalScore)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = current;
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