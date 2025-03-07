using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6;

public class Blue_1
{
    public struct Response
    {
        private string _name;
        private string _surname;
        private int _votes = 0;
        
        public string Name => _name;
        public string Surname => _surname;
        public int Votes => _votes;

        public Response(string name, string surname)
        {
            _name = name;
            _surname = surname;
        }

        public int CountVotes(Response[] responses)
        {
            if (responses == null || responses.Length == 0) return 0;
            int count = 0;
            foreach (var response in responses)
            {
                if (response.Name == this.Name &&
                    response.Surname == this.Surname)
                {
                    count++;
                }

                _votes = count;
            } 
            return count;
        }
        public void Print()
        {
            Console.WriteLine($"Имя: {Name}, фамилия: {Surname}, количество голосов: {Votes}");
        }
    }
}