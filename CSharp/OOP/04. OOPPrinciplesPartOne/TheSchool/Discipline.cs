namespace TheSchool
{
    using System;
    using System.Text;

    public class Discipline : IComment
    {
        private string name;
        private int lecturesCount;
        private int exercisesCount;
        private string listOfComments;

        public Discipline(string name, int lecturesCount, int exercisesCount)
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
                if (value < 1)
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

        public string ListOfComments
        {
            get { return this.listOfComments; }
        }

        public void AddComment(string input)
        {
            StringBuilder currentList = new StringBuilder(this.listOfComments);
            currentList.AppendLine(input);
            this.listOfComments = currentList.ToString();
        }
    }
}