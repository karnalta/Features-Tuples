using System;

namespace Features_Tuples
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tuple declaration
            var tuple1 = (25, "John Doe");
            Console.WriteLine(tuple1.Item1);
            Console.WriteLine(tuple1.Item2);

            var tuple2 = (Position: 25, Name: "John Doe");
            Console.WriteLine(tuple2.Position);
            Console.WriteLine(tuple2.Name);

            ValueTuple<int, string> tuple3 = (25, "John Doe");
            Console.WriteLine(tuple3.Item1);
            Console.WriteLine(tuple3.Item2);

            (int Position, string Name) tuple4 = (25, "John Doe");
            Console.WriteLine(tuple4.Position);
            Console.WriteLine(tuple4.Name);

            Console.WriteLine();

            // Tuple deconstruction
            int position;
            string name;
            (position, name) = tuple1;
            Console.WriteLine(position);
            Console.WriteLine(name);

            var (a, b) = tuple2;
            Console.WriteLine(a);
            Console.WriteLine(b);

            (int c, string d) = tuple3;
            Console.WriteLine(c);
            Console.WriteLine(d);

            Console.WriteLine();

            // Tuple method
            var result = GetDriver();
            Console.WriteLine(result.Position);
            Console.WriteLine(result.Name);

            (int x, object y) = GetDriver();
            Console.WriteLine(x);
            Console.WriteLine(y);

            (_, string onlyName) = GetDriver();
            Console.WriteLine(onlyName);

            // Tuple with lambda expression
            (string Description, Func<int, int, int> Func) lambdaTuple = ("Add numbers", (u, i) => u + i);
            Console.WriteLine($"Operation : {lambdaTuple.Description} = {lambdaTuple.Func(8, 2)}");

            // Class with tuple constructor / deconstructor
            var myClass = new TypeWithDeconstruct("Harry", "Potter");
            var (l, m) = myClass;
            Console.WriteLine($"{l} {m}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Method returning a tuple.
        /// </summary>
        /// <returns></returns>
        static (int Position, string Name) GetDriver()
        {
            return (20, "Jane Doe");
        }
    }

    class TypeWithDeconstruct
    {
        public string FirstName { get; }
        public string LastName { get; }

        /// <summary>
        /// Inline constructor using tuple for assignation.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        public TypeWithDeconstruct(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);

        /// <summary>
        /// Desconstruct into a tuple
        /// </summary>
        /// <param name="FirstName">The first name.</param>
        /// <param name="LastName">The last name.</param>
        public void Deconstruct(out string nameA, out string nameB)
        {
            nameA = FirstName;
            nameB = LastName;
        }
    }
}