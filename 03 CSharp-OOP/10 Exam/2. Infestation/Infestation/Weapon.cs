using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class Weapon : Supplement
    {
        public const int UnitPowerValue = 10;
        public const int UnitAggressionValue = 3;

        public Weapon()
            : base(0, 0, 0)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.PowerEffect = UnitPowerValue;
                this.AggressionEffect = UnitAggressionValue;
            }
        }
    }
}
