using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Prison prison = new Prison();
        }
    }

    class Prison
    {
        private List<Prisoner> _prisoners = new List<Prisoner> {new Prisoner("Олег", "Антиправительственное"), new Prisoner("Евгений", "Экономическое"), new Prisoner("Даниил", "Уголовное"),new Prisoner("Евгений", "Антиправительственное") };
        private List<Prisoner> _notAmnestied;

        public Prison()
        {
            ShowPrisoners(_prisoners);
            _notAmnestied = Amnesty();
            Console.WriteLine("После амнистии\n");
            ShowPrisoners(_notAmnestied);
        }

        private List<Prisoner> Amnesty()
        {
            var amnestied = from Prisoner prisoner in _prisoners where prisoner.Crime != ("Антиправительственное") select prisoner;
            return amnestied.ToList();
        }

        private void ShowPrisoners(List<Prisoner> list)
        {
            Console.WriteLine("В тюрьме сидят:");

            foreach (var prisoner in list)
            {
                Console.WriteLine($"{prisoner.Name} преступление : {prisoner.Crime}\n");
            }
        }
    }

    class Prisoner
    {
        public string Name { get; private set;}
        public string Crime { get; private set; }

        public Prisoner(string name, string crime)
        {
            Name = name;
            Crime = crime;
        }
    }
}
