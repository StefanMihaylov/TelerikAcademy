using System;
using System.Collections.Generic;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer
    {
        private bool isStoneGathered;

        public Giant(string name, Point position)
            : base(name, position, 0)
        {
            this.HitPoints = 200;
            this.isStoneGathered = false;
        }

        public int AttackPoints
        {
            get
            {
                int attack = 150;
                if (isStoneGathered)
                {
                    return attack + 100;
                }
                else
                {
                    return attack;
                }
            }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.isStoneGathered = true;
                return true;
            }
            return false;
        }
    }
}
