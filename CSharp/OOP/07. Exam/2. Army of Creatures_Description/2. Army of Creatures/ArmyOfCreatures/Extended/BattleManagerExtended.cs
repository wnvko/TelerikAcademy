﻿namespace ArmyOfCreatures.Extended
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ArmyOfCreatures.Logic;
    using ArmyOfCreatures.Logic.Battles;

    public class BattleManagerExtended : BattleManager
    {
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;

        public BattleManagerExtended(ICreaturesFactory creaturesFactory, ILogger logger)
            : base(creaturesFactory, logger)
        {
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier != null && creaturesInBattle != null)
            {
                if (creatureIdentifier.ArmyNumber == 3)
                {
                    this.thirdArmyCreatures.Add(creaturesInBattle);
                    return;
                }
            }

            base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            if (identifier != null)
            {
                if (identifier.ArmyNumber == 3)
                {
                    return this.thirdArmyCreatures.FirstOrDefault(x => x.Creature.GetType().Name == identifier.CreatureType);
                }
            }

            return base.GetByIdentifier(identifier);
        }
    }
}
