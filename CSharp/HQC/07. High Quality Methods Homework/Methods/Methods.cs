namespace Methods
{
    using System;

    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(DigitToString(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            double x1 = 3;
            double y1 = -1;
            double x2 = 3;
            double y2 = 2.5;

            bool horizontal = IsHorizontal(y1, y2);
            bool vertical = IsVertical(x1, x2);
            double distance = CalcDistance(x1, y1, x2, y2);

            Console.WriteLine(distance);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }

        private static double CalcTriangleArea(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
            return area;
        }

        private static string DigitToString(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    {
                        return "Invalid number!";
                    }
            }
        }

        private static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("Empty or null string is not acceptable input");
            }

            int maxNumber = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        private static void PrintAsNumber(object number, string format)
        {
            double parsedNumber;
            bool isNumber = true;
            isNumber = double.TryParse(number.ToString(), out parsedNumber);

            if (!isNumber)
            {
                throw new ArgumentException("Input object is not a number");
            }

            if (format == "f")
            {
                Console.WriteLine("{0:f2}", parsedNumber);
                return;
            }

            if (format == "%")
            {
                Console.WriteLine("{0:p0}", parsedNumber);
                return;
            }

            if (format == "r")
            {
                Console.WriteLine("{0,8}", parsedNumber);
                return;
            }

            Console.WriteLine("Unsupported format");
        }

        private static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        private static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        private static bool IsVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }
    }
}