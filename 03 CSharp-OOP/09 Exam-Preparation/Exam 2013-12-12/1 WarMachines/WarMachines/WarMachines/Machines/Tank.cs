namespace WarMachines.Machines
{
    using System;
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank
    {
        private const double TankHealthPoints = 100.0;
        private const double ExtraDefenseInDefenseMode = 30.0;
        private const double ExtraAttackInDefenseMode = -40.0;

        public Tank(string inputName, double inputAttack, double inputDefense)
            : base(inputName, inputAttack, inputDefense)
        {
            this.HealthPoints = TankHealthPoints;
            this.DefenseMode = false;
            ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.AttackPoints -= ExtraAttackInDefenseMode;
                this.DefensePoints -= ExtraDefenseInDefenseMode;
            }
            else
            {
                this.AttackPoints += ExtraAttackInDefenseMode;
                this.DefensePoints += ExtraDefenseInDefenseMode;
            }
            this.DefenseMode = !this.DefenseMode;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(base.ToString());
            result.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode? "ON" : "OFF"));
            return result.ToString().TrimEnd();
        }
    }
}
