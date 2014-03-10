using System;
using System.Collections.Generic;
using System.Linq;

namespace Infestation
{
    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            return attackableUnits.Where(unit => unit.Power <= this.Aggression).
                                   OrderByDescending(unit => unit.Health).
                                   FirstOrDefault();
        }
    }
}
