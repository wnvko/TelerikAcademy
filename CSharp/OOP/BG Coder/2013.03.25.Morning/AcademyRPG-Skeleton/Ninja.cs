using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IGatherer
    {
        private int lumberGathered = 0;
        private int stoneGathered = 0;
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }
        public int AttackPoints
        {
            get { return this.lumberGathered + this.stoneGathered * 2; }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            int targetWithMaxHitPoints = int.MinValue;
            int returnValue = -1;
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    if (availableTargets[i].HitPoints > targetWithMaxHitPoints)
                    {
                        returnValue = i;
                    }
                }
            }

            return returnValue;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.stoneGathered = resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Lumber)
            {
                this.lumberGathered = resource.Quantity;
                return true;
            }

            return false;
        }
    }
}