namespace WarMachines.Machines
{
    using System;
    using System.Text;
    using WarMachines.Interfaces;

    public class Fighter: Machine, IFighter
    {
        private const double FighterHealthPoints = 200.0;

        public Fighter(string inputName, double inputAttack, double inputDefense, bool stealthMode)
            : base(inputName, inputAttack, inputDefense)
        {
            this.HealthPoints = FighterHealthPoints;
            this.StealthMode = stealthMode;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = !this.StealthMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));
            return result.ToString().TrimEnd();
        }
    }
}
