namespace WarMachines
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;

    using WarMachines.Interfaces;

    public class Pilot: IPilot
    {
        // fields
        private string name;
        private IList<IMachine> engagedMachines;

        // Constructor
        public Pilot(string pilotName)
        {
            this.Name = pilotName;
            this.engagedMachines = new List<IMachine>();
        }


        // properties
        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Pilot name cannot be empty");
                }
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            if (machine == null)
            {
                throw new ArgumentNullException("Engaged machine cannot be null");
            }
            this.engagedMachines.Add(machine);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();

            string machineNumber; 
            if (engagedMachines.Count == 0)
            {
                machineNumber = "no";
            }
            else
            {
                machineNumber = engagedMachines.Count.ToString();
            }

            string pluralMacine;
            if (engagedMachines.Count == 1)
            {
                pluralMacine = "machine";
            }
            else
            {
                pluralMacine = "machines";
            }
            
            result.Append(string.Format("{0} - {1} {2}", this.Name,machineNumber, pluralMacine));

            if (engagedMachines.Count > 0)
            {
                result.AppendLine();
                var sortedMachines = engagedMachines.OrderBy(m => m.HealthPoints).ThenBy(m => m.Name);
                foreach (var machine in sortedMachines)
                {
                    result.AppendLine(machine.ToString());
                }
            }
            
            return result.ToString().TrimEnd();
        }
    }
}
