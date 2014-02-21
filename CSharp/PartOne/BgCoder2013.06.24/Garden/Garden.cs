namespace Garden
{
    using System;

    class Garden
    {
        static void Main()
        {
            decimal priceTomato = 0.5m;
            decimal priceCucumber = 0.4m;
            decimal pricePotato = 0.25m;
            decimal priceCarrot = 0.6m;
            decimal priceCabbage = 0.3m;
            decimal priceBeans = 0.4m;
            decimal totalAmount = 0.0m;
            decimal totalArea = 0.0m;

            decimal seedsTomato = decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + priceTomato * seedsTomato;
            decimal areaTomato = decimal.Parse(Console.ReadLine());
            totalArea = totalArea + areaTomato;

            decimal seedsCucumber= decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + priceCucumber * seedsCucumber;
            decimal areaCucumber= decimal.Parse(Console.ReadLine());
            totalArea = totalArea + areaCucumber;

            decimal seedsPotato= decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + pricePotato * seedsPotato;
            decimal areaPotato = decimal.Parse(Console.ReadLine());
            totalArea = totalArea + areaPotato;
            
            decimal seedsCarrot= decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + priceCarrot * seedsCarrot;
            decimal areaCarrot = decimal.Parse(Console.ReadLine());
            totalArea = totalArea + areaCarrot;

            decimal seedsCabage = decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + priceCabbage * seedsCabage;
            decimal areaCabage = decimal.Parse(Console.ReadLine());
            totalArea = totalArea + areaCabage;
            
            decimal seedsBeans = decimal.Parse(Console.ReadLine());
            totalAmount = totalAmount + priceBeans * seedsBeans;

            decimal areaBeans = 250 - totalArea;
            if (areaBeans > 0)
            {
                Console.WriteLine("Total costs: {0}", totalAmount);
                Console.WriteLine("Beans area: {0:F0}", areaBeans);
            }
            else
            {
                if (areaBeans == 0)
                {
                    Console.WriteLine("Total costs: {0}", totalAmount);
                    Console.WriteLine("No area for beans");
                }
                else
                {
                    Console.WriteLine("Total costs: {0}", totalAmount);
                    Console.WriteLine("Insufficient area");
                }
            }
        }
    }
}
