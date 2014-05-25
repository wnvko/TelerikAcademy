namespace Conditional
{
    using System;
    using Kitchen;

    public class ConditionalStatements
    {
        public const int MIN_X = 0;
        public const int MIN_Y = 0;
        public const int MAX_X = 800;
        public const int MAX_Y = 400;

        public int x = 10;
        public int y = 20;

        public bool shouldVisitCell = true;

        public bool IsPointInRange(int x, int y)
        {
            bool isXinRange = MIN_X < x && x < MAX_X;
            bool isYinRange = MIN_Y < y && y < MAX_Y;
            
            bool ispointInRange = isXinRange && isYinRange;
            return ispointInRange;
        }

        public void VisitCell(int x, int y, bool shouldVisitCell)
        {
            if (IsPointInRange(x, y) && shouldVisitCell)
            {
                // do something in cell..
            }
            else
            {
                // do something else...
            }
        }

        public static void Main()
        {
            Potato potato = new Potato();
            Chef chef = new Chef();

            if (potato != null)
            {
                if (potato.IsGood && potato.HasBeenPeeled)
                {
                    chef.Cook(potato);
                }
                else
                {
                    // take new potato and peel it...
                }
            }
            else
            {
                // take some potato...
            }
        }
    }
}
