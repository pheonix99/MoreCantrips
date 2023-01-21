using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCantrips.Cantrips
{
    class IceSpells
    {
        public static void Make()
        {
            var icon = BlueprintTool.Get<BlueprintAbility>("c83447189aabc72489164dfc246f3a36").Icon;
            

            string castGUid = "7B35B5CDD43046B28C4A0415C8E1799B";
    
            string touchGUID = "D51FCCAA33244489BAD0B69A14B157CC";

            AttackCantripFactory.ConfigureTouch(() => { return Settings.IsEnabled("FrostyTouch"); }, "FrostyTouch", castGUid, touchGUID, Kingmaker.Enums.Damage.DamageEnergyType.Cold, icon, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, "274fbd84b4c9d794bb5fe677472292b1");
        }
    }
}
