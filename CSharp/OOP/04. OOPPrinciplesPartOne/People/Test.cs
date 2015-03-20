namespace People
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public    class Test
    {
    public    static void Main()
        {
            List<Student> classOfStudents = new List<Student>();
            classOfStudents.Add(new Student("Svetla", "Draganova", 3));
            classOfStudents.Add(new Student("Georgi", "Ivanov", 9));
            classOfStudents.Add(new Student("Ivan", "Petrov", 3));
            classOfStudents.Add(new Student("Chavdar", "Kamenov", 10));
            classOfStudents.Add(new Student("Ivan", "Kozhuharov", 10));
            classOfStudents.Add(new Student("Georgi", "Stoyanov", 1));
            classOfStudents.Add(new Student("Ivan", "Kovachev", 6));
            classOfStudents.Add(new Student("Stefan", "Petrov", 6));
            classOfStudents.Add(new Student("Martin", "Atanasov", 12));
            classOfStudents.Add(new Student("Veronika", "Govedarova", 2));

            foreach (var student in classOfStudents)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine();

            var orderedStudents = classOfStudents.OrderBy(gr => gr.Grade);
            foreach (var student in orderedStudents)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine();



            List<Worker> someWorkers = new List<Worker>();
            someWorkers.Add(new Worker("Simeon", "Petrov", 993, 12));
            someWorkers.Add(new Worker("Severin", "Lakov", 809, 15));
            someWorkers.Add(new Worker("Kliment", "Evgeniev", 384, 3));
            someWorkers.Add(new Worker("Aleksandar", "Simeonov", 828, 1));
            someWorkers.Add(new Worker("Teodor", "Hristov", 675, 4));
            someWorkers.Add(new Worker("Andrey", "Sotirov", 688, 17));
            someWorkers.Add(new Worker("Eleonora", "Viktorova", 589, 8));
            someWorkers.Add(new Worker("Zafir", "Kaloyanov", 904, 18));
            someWorkers.Add(new Worker("Plamen", "Antonov", 947, 8));
            someWorkers.Add(new Worker("Fabian", "Kornelov", 970, 15));

            foreach (var worker in someWorkers)
            {
                Console.WriteLine(worker);
            }
            Console.WriteLine();

            var sortedWorkers =
                from workers in someWorkers
                orderby workers.MoneyPerHour()
                select workers;

            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine(worker);
            }

            Console.WriteLine();

            List<Human> people = new List<Human>();
            people.AddRange(classOfStudents);
            people.AddRange(someWorkers);

            var sortedPeople = people.OrderBy(l => l.LastName).OrderBy(f => f.FirstName);

            foreach (var person in sortedPeople)
            {
                Console.WriteLine(person.FirstName + " " + person.LastName);
            }
        }
    }
}