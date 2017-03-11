namespace _06_math_utilities
{
    using System;
    using System.Linq;
    class Startup
    {
        static void Main()
        {
            var input = Console.ReadLine();                

            while (input != "End")
            {
               var parts = input
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var command = parts[0];
                var firstNum = double.Parse(parts[1]);
                var secondNum = double.Parse(parts[2]);

                if (command == "Sum")
                {
                    Console.WriteLine("{0:F2}", MathUtil.Sum(firstNum, secondNum));
                }
                else if (command == "Subtract")
                {
                    Console.WriteLine("{0:F2}", MathUtil.Subtract(firstNum, secondNum));
                }
                else if (command == "Multiply")
                {
                    Console.WriteLine("{0:F2}", MathUtil.Multiply(firstNum, secondNum));
                }
                else if (command == "Divide")
                {
                    Console.WriteLine("{0:F2}", MathUtil.Divide(firstNum, secondNum));
                }
                else
                {
                    Console.WriteLine("{0:F2}", MathUtil.Percentage(firstNum, secondNum));
                }

                input = Console.ReadLine();
            }
        }
    }
}
