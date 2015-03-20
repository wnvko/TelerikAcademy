namespace People
{
    using System;

    public class Worker : Human
    {
        private const int WorkDaysInWeek = 5;
        private decimal weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName)
            : base(firstName, lastName)
        { }

        public Worker(string firstName, string lastName, decimal weekSalary)
            : this(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
        }

        public Worker(string firstName, string lastName, int workHoursPerDay)
            : this(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName, decimal weekSalary, int workHoursPerDay)
            : this(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }

        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value < 0m)
                {
                    throw new ArgumentException("Salary cannot be negative!");
                }

                this.weekSalary = value;
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value < 0 || value > 24)
                {
                    throw new ArgumentException("Work hours per day have to be between 0 and 24!");
                }

                this.workHoursPerDay = value;
            }
        }

        public decimal MoneyPerHour()
        {
            decimal moneyPerHour = Decimal.Zero;

            if (WeekSalary == 0 || WorkHoursPerDay == 0)
            {
                throw new ArgumentException("Please set both week salary and work hours per day value!");
            }

            moneyPerHour = this.WeekSalary / (this.WorkHoursPerDay * WorkDaysInWeek);
            return moneyPerHour;
        }

        public override string ToString()
        {
            decimal moneyPerHour = Decimal.Zero;
            if (WeekSalary != 0 && WorkHoursPerDay != 0)
            {
                moneyPerHour = this.MoneyPerHour();
            }

            return string.Format("{0,-10} {1,-10} earns {2,6:F2} per hour", this.FirstName, this.LastName, moneyPerHour);
        }
    }
}
