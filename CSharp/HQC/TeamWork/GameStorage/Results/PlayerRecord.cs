namespace HangMan
{
    using HangMan.Interfaces;

    public class PlayerRecord : IRecord
    {
        public PlayerRecord(string name, string mistakes)
        {
            this.Name = name;
            this.Mistakes = mistakes;
        }

        public string Name { get; set; }

        public string Mistakes { get; set; }

        public string BuildRecord()
        {
            return this.Name + ":" + this.Mistakes;
        }

        public override string ToString()
        {
            return this.Name + " - " + this.Mistakes + " mistakes";
        }
    }
}
