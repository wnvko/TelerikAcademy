namespace HangMan.Interfaces
{
    public interface IPlayer
    {
        string Name
        {
            get;
            set;
        }

        int Mistakes
        {
            get;
            set;
        }

        int CompareTo(IPlayer other);
    }
}