namespace GSMTest
{
    using System;
    using MobilePhone;

    class Test
    {
        static void Main(string[] args)
        {
            GSM[] phones = new GSM[3];
            phones[0] = new GSM("Samsung", "GalaxyS", 500.00m, "Jhon", "Smith", "Li-Ion", 730, 16, BatteryType.LiIon, 6d, 2000000);
            phones[1] = new GSM("Sony", "Xperia");
            //phones[2] = new GSM(); // try to instance parameterless GSM - compile error
            phones[2] = GSM.IPhone4s;
            //phones[2].Model = "Samsung"; //try to change ReadOnly field - compile error

            phones[1].OwnerFirstName = "Peter";
            phones[1].OwnerSecondName = "Pan";

            phones[2].DisplayNumberOfColors = -20; // try to set negative numbers of colors - throw exeption
            phones[1].DisplayNumberOfColors = 500;
            phones[1].BatteryModel = "7m";

            foreach (var phone in phones)
            {
                Console.WriteLine(phone);
                Console.WriteLine();
            }
        }
    }
}
