using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class InfestationSpores : Supplement
    {
        public const int InfestationSporesPowerValue = -1;
        public const int InfestationSporesAggressionValue = 20;

        public InfestationSpores()
            : base(InfestationSporesPowerValue, 0, InfestationSporesAggressionValue)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if ( (otherSupplement is InfestationSpores))
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        } 
    }
}
