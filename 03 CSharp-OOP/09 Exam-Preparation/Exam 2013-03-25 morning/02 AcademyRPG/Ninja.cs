using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IGatherer, IFighter
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
            this.AttackPoints = 0;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get { return int.MaxValue; } }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int index = -1;
            int max = int.MinValue;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0 && availableTargets[i].Owner != this.Owner &&
                    availableTargets[i].HitPoints > max)
                {
                    max = availableTargets[i].HitPoints;
                    index = i;
                }
            }

            return index;
        }
    }
}
