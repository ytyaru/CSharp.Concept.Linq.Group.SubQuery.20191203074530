using System;
using System.Collections.Generic;
using System.Linq;

namespace Concept.Linq.Lesson0 {
    class Human {
        public string Name { get; }
        public int Age { get; }
        public Human(string name, int age) => (Name, Age) = (name, age);
    }
    class Main {
        public void Run() {
            List<Human> humans = CreateHumans();
            Show(Query(humans));
        }
        private List<Human> CreateHumans() {
            return new List<Human> {
                new Human("A", 0), new Human("B", 1),
                new Human("A", 2), new Human("B", 3),
                new Human("A", 4), new Human("B", 5),
            };
        }
        private IEnumerable<dynamic> Query(in List<Human> humans) {
            return from h in humans
                   group h by h.Name into g
                   select new {
                       Name = g.Key,
                       MaxAge = (from h2 in g select h2.Age).Max(),
                   };
        }
        private void Show(in IEnumerable<dynamic> groups) {
            foreach (var g in groups) {
                Console.WriteLine($"Name={g.Name}, MaxAge={g.MaxAge}");
            }
        }
    }
}
