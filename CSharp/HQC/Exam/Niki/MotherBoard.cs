namespace Computers
{
    using Contracts;

    /// <summary>
    /// Represents a motherboard containing CPU, RAM, harddrive and videocard
    /// </summary>
    public class MotherBoard : IMotherboard
    {
        /// <summary>
        /// Create new motherboard
        /// </summary>
        /// <param name="cpu">ICPU processor of any kind</param>
        /// <param name="ram">IRam ram memmory</param>
        /// <param name="hardDrive">IHardDrive storage</param>
        /// <param name="videoCard">IVideoCard videocard</param>
        public MotherBoard(ICPU cpu, IRam ram, IHardDrive hardDrive, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrive = hardDrive;
            this.Videocard = videoCard;
        }

        public ICPU Cpu { get; set; }

        public IRam Ram { get; set; }

        public IVideoCard Videocard { get; set; }

        public IHardDrive HardDrive { get; set; }

        /// <summary>
        /// Loads a value from the ram and returns it
        /// </summary>
        /// <returns>Value from ram</returns>
        public int LoadRamValue()
        {
            int loadedValue = this.Ram.LoadValue();
            return loadedValue;
        }

        /// <summary>
        /// Saves value in ram
        /// </summary>
        /// <param name="value">Value to be saved in ram</param>
        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }

        /// <summary>
        /// Draws on the videocard the data
        /// </summary>
        /// <param name="data">Data to be drawn on the videocard</param>
        public void DrawOnVideoCard(string data)
        {
            this.Videocard.Draw(data);
        }
    }
}