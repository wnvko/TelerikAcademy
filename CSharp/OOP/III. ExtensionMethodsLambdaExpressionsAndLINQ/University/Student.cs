namespace University
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    class Student
    {
        static string[] firstNames = new string[20]{"Albena", "Valentin", "Dimitar", "Zhechka", "Ivan", "Kosio", "Leda", "Marin", "Nelly",
                                        "Ogi", "Pesho","Ruslan","Stefy","Tedy","Unufri","Hristina","Tzveti","Chavdar","Yuly","Yana"};
        static string[] lastNames = new string[20]{"Albenov", "Valentinov", "Dimitrov", "Zhechkov", "Ivanov", "Kosiov", "Ledov", "Marinov", "Nellyov",
                                        "Ogov", "Peshov","Ruslanov","Stefanov","Teodorov","Unufriov","Hristinov","Tzvetov","Chavdarov","Yulyov","Yanov"};
        static string[] emails = new string[4] { "@google.com", "@abv.bg", "@yahoo.com", "@mail.bg" };
        static Random rnd = new Random();

        private string firstName;
        private string lastName;
        private int fn;
        private string tel;
        private string email;
        private List<int> marks;
        private int groupNumber;
        private Group group;

        public Student(string firstName, string lastName, int fn, string tel, string email, List<int> marks, int groupNumber, Group group)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FN = fn;
            this.Tel = tel;
            this.Email = email;
            this.marks = new List<int>();
            this.marks = marks;
            this.GroupNumber = groupNumber;
            this.Group = group;
        }

        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public int FN
        {
            get { return this.fn; }
            set { this.fn = value; }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public List<int> Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }

        public int GroupNumber
        {
            get { return this.groupNumber; }
            set { this.groupNumber = value; }
        }

        public Group Group
        {
            get { return this.group; }
            set { this.group = value; }
        }


        public static Student RandomStudent()
        {
            string firstName = firstNames[rnd.Next(0, 20)];
            string lastName = lastNames[rnd.Next(0, 20)];

            int fn = rnd.Next(1000, 10000);
            fn = fn * 100 + rnd.Next(1, 10);

            int phone = rnd.Next(100000, 1000000);
            int code = rnd.Next(1, 6);
            string tel = string.Format("0{0} {1}", code, phone);

            string email = string.Format("{0}.{1}{2}", firstName, lastName, emails[rnd.Next(0, 4)]);

            List<int> marks = new List<int>() { rnd.Next(2, 7), rnd.Next(2, 7), rnd.Next(2, 7), rnd.Next(2, 7) };

            int groupNumber = rnd.Next(0, 5);
            Group group = new Group(groupNumber);
            Student randomStudent = new Student(firstName, lastName, fn, tel, email, marks, groupNumber, group);
            return randomStudent;
        }
    }
}
