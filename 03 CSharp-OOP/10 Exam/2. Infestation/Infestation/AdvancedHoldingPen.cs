using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infestation
{
    public class AdvancedHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "Parasite":
                    var parasite = new Parasite(commandWords[2]);
                    this.InsertUnit(parasite);
                    break;
                case "Queen":
                    var queen = new Queen(commandWords[2]);
                    this.InsertUnit(queen);
                    break;
                case "Marine":
                    var marine = new Marine(commandWords[2]);
                    this.InsertUnit(marine);
                    break;
                    break;
                case "Tank":
                    var tank = new Tank(commandWords[2]);
                    this.InsertUnit(tank);
                    break;
            }

            base.ExecuteInsertUnitCommand(commandWords);
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            Unit unit;
            switch (commandWords[1])
            {
                case "PowerCatalyst":
                    unit = this.GetUnit(commandWords[2]);
                    unit.AddSupplement(new PowerCatalyst());
                    break;
                case "HealthCatalyst":
                    unit = this.GetUnit(commandWords[2]);
                    unit.AddSupplement(new HealthCatalyst());
                    break;
                case "AggressionCatalyst":
                    unit = this.GetUnit(commandWords[2]);
                    unit.AddSupplement(new AggressionCatalyst());
                    break;
                case "Weapon":
                    unit = this.GetUnit(commandWords[2]);
                    unit.AddSupplement(new Weapon());
                    break;
                default:
                    break;
            }
        }

        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    
                    Unit targetUnit = this.GetUnit(interaction.TargetUnit);
                    Unit sourceUnit = this.GetUnit(interaction.SourceUnit);
                    UnitClassification targetType = targetUnit.UnitClassification;
                    UnitClassification sourceType = sourceUnit.UnitClassification;

                    if (sourceType == InfestationRequirements.RequiredClassificationToInfest(targetType))
                    {
                        targetUnit.AddSupplement(new InfestationSpores());
                    }
                    break;
            }

            base.ProcessSingleInteraction(interaction);
        }
    }
}
