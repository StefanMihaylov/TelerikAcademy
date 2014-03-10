using System;
using System.Collections.Generic;
using System.Linq;


namespace Infestation
{
    public class Parasite : Unit
    {
        public const int ParasitePower = 1;
        public const int ParasiteAggression = 1;
        public const int ParasiteHealth = 1;

        public Parasite(string id)
            : base(id, UnitClassification.Biological, Parasite.ParasiteHealth, Parasite.ParasitePower, Parasite.ParasiteAggression)
        {
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.Where(unit => (unit.Id != this.Id)).OrderBy(unit => unit.Health).FirstOrDefault();
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            var interaction = base.DecideInteraction(units);
            if (interaction != Interaction.PassiveInteraction)
            {
                return new Interaction(interaction.SourceUnit, interaction.TargetUnit, InteractionType.Infest);
            }
            return Interaction.PassiveInteraction;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id)
            {
                return true;
            }
            return false;
        }
    }
}
