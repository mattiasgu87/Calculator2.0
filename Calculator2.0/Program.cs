using System;

namespace Calculator2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator! +-x/");

            bool running = true;
            char menuChoice;

            while (running)
            {
                PrintInstructions();
                Char.TryParse(Console.ReadLine(), out menuChoice);

                switch (menuChoice)
                {
                    case '0':
                        Console.WriteLine("\nYou chose to exit the program. Bye!");
                        running = false;
                        break;

                    case '+':
                        Console.WriteLine("\nYou chose +, Addition");

                        if (ChooseTwoOrMultipleValues())
                            PerformAdditionArray();
                        else
                            PerformAddition();
                        break;

                    case '-':
                        Console.WriteLine("\nYou chose -, Subtraction");

                        if (ChooseTwoOrMultipleValues())
                            PerformSubtractionArray();
                        else
                            PerformSubtraction();
                        break;

                    case 'x':
                        Console.WriteLine("\nYou chose x, Multiplication");
                        PerformMultiplication();
                        break;

                    case '/':
                        Console.WriteLine("\nYou chose /, Division");
                        PerformDivision();
                        break;

                    default:
                        Console.WriteLine("\ninvalid menu choice!");
                        break;
                }
            }
        }

        static void PrintInstructions()
        {
            Console.WriteLine("\nWhat do you want to calculate?");
            Console.WriteLine("You have the following options: \n" +
                                "+\n" +
                                "-\n" +
                                "x\n" +
                                "/\n" +
                                "0 : Exit program");
        }

        static double GetDouble()
        {
            double inputDouble = 0;
            bool readSuccess = false;

            while (!readSuccess)
            {
                Console.WriteLine("Write a number: ");

                readSuccess = Double.TryParse(Console.ReadLine(), out inputDouble);
            }

            return inputDouble;
        }

        static double[] GetDoubleArray()
        {
            var input = Console.ReadLine();

            string[] numbers = input.Split(" ");

            double[] numberArray = new double[numbers.Length];
            for (int i = 0; i < numbers.Length; i++)
            {
                //If value can't be parsed to a double, it will stay as NotANumber
                double num = double.NaN;

                Double.TryParse(numbers[i], out num);
                numberArray[i] = num;
            }

            return numberArray;
        }

        static bool ChooseTwoOrMultipleValues()
        {
            bool chooseMoreThanTwoNumbers = false;

            Console.WriteLine("Do you want to perform calculations with two or more than two numbers?");
            Console.WriteLine("\nm: More than two numbers");
            Console.WriteLine("Everything else: Just two numbers");

            char additionChoice;

            Char.TryParse(Console.ReadLine(), out additionChoice);

            switch (additionChoice)
            {
                case 'm':
                    chooseMoreThanTwoNumbers = true;
                    break;

                default:
                    chooseMoreThanTwoNumbers = false; //already false but for visibility
                    break;
            }

            return chooseMoreThanTwoNumbers;
        }

        static void PerformAddition()
        {
            Console.WriteLine("Give the program 2 numbers to add together:");

            double add1 = GetDouble();
            double add2 = GetDouble();

            Console.WriteLine("{0} {1} {2} {3} {4}", add1, "+", add2, "=", Calculator.UseAddition(add1, add2));
        }

        static void PerformAdditionArray()
        {
            Console.WriteLine("Give the program numbers to add, separated by ' ' (non-numbers will be treated as zero):");

            double[] numberArray = GetDoubleArray();

            Console.WriteLine("Result: ");
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(" + ");
                }
                Console.Write(numberArray[i]);
            }

            Console.Write(" = " + Calculator.UseAdditionOnArray(numberArray) + "\n");
        }

        static void PerformSubtraction()
        {
            Console.WriteLine("Give the program 2 numbers to subtract:");

            double sub1 = GetDouble();
            double sub2 = GetDouble();

            Console.WriteLine("{0} {1} {2} {3} {4}", sub1, "-", sub2, "=", Calculator.UseSubtraction(sub1, sub2));
        }

        static void PerformSubtractionArray()
        {
            Console.WriteLine("Give the program numbers to subtract, separated by ' ' (non-numbers will be treated as zero):");

            double[] numberArray = GetDoubleArray();

            Console.WriteLine("Result: ");
            for (int i = 0; i < numberArray.Length; i++)
            {
                if (i > 0)
                {
                    Console.Write(" - ");
                }
                Console.Write(numberArray[i]);
            }

            Console.Write(" = " + Calculator.UseSubtractionOnArray(numberArray) + "\n");
        }

        static void PerformMultiplication()
        {
            Console.WriteLine("Give the program 2 numbers to multiply:");

            double mult1 = GetDouble();
            double mult2 = GetDouble();

            Console.WriteLine("{0} {1} {2} {3} {4}", mult1, "x", mult2, "=", Calculator.UseMultiplication(mult1, mult2));
        }

        static void PerformDivision()
        {
            Console.WriteLine("Give the program 2 numbers to divide:");

            bool divideByZero = true;
            double div1 = GetDouble();
            double div2 = double.NaN;
            double result = double.NaN;

            while (divideByZero)
            {
                div2 = GetDouble();
                if (Calculator.UseDivision(div1, div2, out result))
                    divideByZero = false;
                else
                    Console.WriteLine("You can't divide by zero! Try a different number!");
            }

            Console.WriteLine("{0} {1} {2} {3} {4}", div1, "/", div2, "=", result);
        }
    }
}
