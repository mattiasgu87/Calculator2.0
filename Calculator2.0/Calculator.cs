using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator2
{
    public class Calculator
    {
        public static double UseAdditionOnArray(double[] array)
        {
            double sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        public static double UseSubtractionOnArray(double[] array)
        {
            double sum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                sum -= array[i];
            }

            return sum;
        }

        public static double UseSubtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double UseAddition(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double UseMultiplication(double num1, double num2)
        {
            return num1 * num2;
        }

        public static bool UseDivision(double num1, double num2, out double result)
        {
            bool divisionSuccess = false;

            if (num2 != 0.0)
            {
                //Not dividing by zero, divide and return that division was a success!
                divisionSuccess = true;
                result = num1 / num2;
            }
            else
                result = double.NaN;

            return divisionSuccess;
        }
    }
}
