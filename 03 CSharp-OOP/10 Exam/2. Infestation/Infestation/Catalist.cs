namespace Infestation
{
    public abstract class Catalist : Supplement
    {
        protected const int PowerCatalystValue  = 3;
        protected const int HealthCatalystValue = 3;
        protected const int AggressionCatalystValue = 3;

        public Catalist(int powerEffect, int healthEffect, int aggressionEffect)
            : base(powerEffect, healthEffect, aggressionEffect)
        {

        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            
        }
    }
}
