namespace School
{
    using System;

    public class Discipline : Comment
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;

        public Discipline(string name, int lscturesCount, int exercisesCount)
        {
            this.Name = name;
            this.LecturesCount = lecturesCount;
            this.ExercisesCount = exercisesCount;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Lecture name cannot be null or empty!");
                }

                this.name = value;
            }
        }

        public int LecturesCount
        {
            get
            {
                return this.lecturesCount;
            }

            set
            {
                if (value <0)
                {
                    throw new ArgumentException("Lectures count cannot be less than 1!");
                }

                this.lecturesCount = value;
            }
        }

        public int ExercisesCount
        {
            get
            {
                return this.exercisesCount;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Exercises count cannot be less than 1!");
                }

                this.exercisesCount = value;
            }
        }
    }
}