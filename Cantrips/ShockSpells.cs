using BlueprintCore.Utils;
using Kingmaker.Blueprints.Facts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCantrips.Cantrips
{
    class ShockSpells
    {
        public static void Make()
        {
            
            string castGUID = "9B405733B7B842C0A06CE14DC08030D2";
            string touchGUID = "2FD3A8231D554CFAB08A88865DC1A97D";
            var icon = BlueprintTool.Get<BlueprintUnitFact>("ab395d2335d3f384e99dddee8562978f").Icon;

            AttackCantripFactory.ConfigureTouch(() => { return Settings.IsEnabled("LesserShockingGrasp"); }, "LesserShockingGrasp", castGUID, touchGUID, Kingmaker.Enums.Damage.DamageEnergyType.Electricity, icon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, "3ab291fca61cf3b4da311da82340ee9e");
        }
    }
}
