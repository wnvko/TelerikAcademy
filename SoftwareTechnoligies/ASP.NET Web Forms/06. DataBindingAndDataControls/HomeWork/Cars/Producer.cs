namespace Cars
{
    using System.Collections.Generic;

    public class Producer
    {
        public Producer()
        {
            this.Models = new List<string>();
        }

        public string Name { get; set; }

        public List<string> Models { get; set; }

        public void AddModels(string[] models)
        {
            for (int index = 0; index < models.Length; index++)
            {
                this.Models.Add(models[index]);
            }
        }
    }
}