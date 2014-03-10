namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using WarMachines.Interfaces;

    public abstract class Machine : IMachine
    {
        // fields
        private string name;
        private IPilot pilot;
        private IList<string> targets;

        // constructor
        public Machine(string inputName, double inputAttack, double inputDefense)
        {
            this.Name = inputName;
            this.AttackPoints = inputAttack;
            this.DefensePoints = inputDefense;
            this.targets = new List<string>();
        }

        // properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Machine name cannot be empty");
                }

                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get { return this.pilot; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Machine pilot cannot be null");
                }
                this.pilot = value;
            }
        }

        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets
        {
            get
            {
                return new List<string>(this.targets);
            }
        }
      
        public void Attack(string target)
        {
            if (string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException("Machine target name cannot be empty");
            }
            this.targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format("- {0}", this.Name));
            result.AppendLine(string.Format(" *Type: {0}",this.GetType().Name));
            result.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            result.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            result.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            string targetNames;
            if (this.targets.Count == 0)
            {
                targetNames = "None";
            }
            else
            {
                targetNames = string.Join(", ", this.targets);
            }
            result.AppendLine(string.Format(" *Targets: {0}", targetNames));

            return result.ToString().TrimEnd();
        }
    }
}
