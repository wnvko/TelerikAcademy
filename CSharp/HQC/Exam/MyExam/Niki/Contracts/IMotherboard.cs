namespace Computers
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface representing a motherboard methods
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads a value from the ram and returns it
        /// </summary>
        /// <returns>Value from ram</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves value in ram
        /// </summary>
        /// <param name="value">Value to be saved in ram</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws on the videocard the data
        /// </summary>
        /// <param name="data">Data to be drawn on the videocard</param>
        void DrawOnVideoCard(string data);
    }
}
