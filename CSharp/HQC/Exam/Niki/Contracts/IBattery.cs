namespace Computers.Contracts
{
    public interface IBattery
    {
        int PercentCharge { get; set; }

        void Charge(int inputAmount);
    }
}
