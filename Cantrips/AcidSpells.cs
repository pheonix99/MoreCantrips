using BlueprintCore.Utils;
using Kingmaker.Blueprints.Facts;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCantrips.Cantrips
{
    class AcidSpells
    {
        public static void Make()
        {
            
            string castGUID = "6D85B4E4E8D7418BBC6E4676E863CB5C";
            string touchGUID = "A230B2701FE34ED1B50DABDE6E878466";
            var icon = BlueprintTool.Get<BlueprintUnitFact>("1a40fc88aeac9da4aa2fbdbb88335f5d").Icon;

            AttackCantripFactory.ConfigureTouch(() => { return Settings.IsEnabled("LesserCorrosiveTouch"); }, "LesserCorrosiveTouch", castGUID, touchGUID, Kingmaker.Enums.Damage.DamageEnergyType.Acid, icon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Conjuration, "524f5d0fecac019469b9e58ce1b8402d");
        }
    }
}
