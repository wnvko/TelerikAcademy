namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HoldingPenExtended : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Dog":
                case "Human":
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    base.InsertUnit(tank);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    base.InsertUnit(marine);
                    break;
                case "Parasite":
                    {
                        var parasite = new Parasite(commandWords[2]);
                        base.InsertUnit(parasite);
                        break;
                    }
                case "Queen":
                    {
                        var queen = new Queen(commandWords[2]);
                        base.InsertUnit(queen);
                        break;
                    }
                default:
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var targetUnit = base.GetUnit(commandWords[2]);

            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    {
                        var powerCatalyst = new PowerCatalyst();
                        targetUnit.AddSupplement(powerCatalyst);
                        break;
                    }
                case "HealthCatalyst":
                    {
                        var healthCatalyst = new HealthCatalyst();
                        targetUnit.AddSupplement(healthCatalyst);
                        break;
                    }
                case "AggressionCatalyst":
                    {
                        var aggressionCatalyst = new AggressionCatalyst();
                        targetUnit.AddSupplement(aggressionCatalyst);
                        break;
                    }
                case "WeaponrySkill":
                    {
                        break;
                    }
                case "Weapon":
                    {
                        if (targetUnit != null && targetUnit.GetType().Name == "Marine")
                        {
                            var weapon = new Weapon();
                            targetUnit.AddSupplement(weapon);
                        }

                        break;
                    }
                case "InfestationSpores":
                    {
                        break;
                    }
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {

            switch (interaction.InteractionType)
            {
                case InteractionType.Attack:
                    {
                        base.ProcessSingleInteraction(interaction);
                        break;
                    }
                case InteractionType.Infest:
                    {
                        Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                        Unit sourceUnit = this.GetUnit(interaction.SourceUnit);
                        
                        if (sourceUnit.UnitClassification == UnitClassification.Biological &&
                            targetUnit.UnitClassification == UnitClassification.Biological)
                        {
                            this.GetInfest(targetUnit);
                        }

                        if (sourceUnit.UnitClassification == UnitClassification.Psionic &&
                            (targetUnit.UnitClassification == UnitClassification.Psionic ||
                            targetUnit.UnitClassification == UnitClassification.Mechanical))
                        {
                            this.GetInfest(targetUnit);
                        }

                        break;
                    }

                default:
                    break;
            }
        }

        private void GetInfest(Unit targetUnit)
        {
            if (true)
            {
                var infestationSpores = new InfestationSpores();
                targetUnit.AddSupplement(infestationSpores);
            }
        }
    }
}
