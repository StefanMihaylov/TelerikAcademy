using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Queen : Unit
    {
        public const int QueenPower = 1;
        public const int QueenAggression = 1;
        public const int QueenHealth = 30;

        public Queen(string id)
            : base(id, UnitClassification.Psionic, Queen.QueenHealth, Queen.QueenPower, Queen.QueenAggression)
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
