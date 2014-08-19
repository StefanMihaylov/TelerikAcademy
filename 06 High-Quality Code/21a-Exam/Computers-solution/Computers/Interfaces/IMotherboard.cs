// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMotherboard.cs" company="Telerik">
//   Telerik Academy 2014
// </copyright>
// <summary>
//   Interface representing information about computer motherboard actions.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Computers.Interfaces
{
    public interface IMotherboard : IStorable, IDrawable
    {
        /// <summary>
        /// Get the singe integer value from the RAM memmory
        /// </summary>
        /// <returns>the integer value that is loaded from the RAM</returns>
        int LoadRamValue();

        /// <summary>
        /// Set the singe integer value to the RAM memmory
        /// </summary>
        /// <param name="value">the integer that is saved to the RAM</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Display text message on the display
        /// </summary>
        /// <param name="data">The string message that is displayed on the screen</param>
        void DrawOnVideoCard(string data);
    }
}
