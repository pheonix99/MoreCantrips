using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCantrips.Cantrips
{
    class SonicSpells
    {
        public static void Make()
        {
            //  8cc159ce94d29fe46a94b80ce549161f
           
            string painfulNoteGUID = "EA38928D3CF342CAB80A335D2AE44D72";
       
            var painfulNoteGuid = BlueprintTool.Get<BlueprintAbility>("8e7cfa5f213a90549aadd18f8f6f4664").Icon;//EarPiercingscream
            var airbullet = "e093b08cd4cafe946962b339faf2310a";

            AttackCantripFactory.ConfigureBeam(() => { return Settings.IsEnabled("PainfulNote"); }, "PainfulNote", painfulNoteGUID, Kingmaker.Enums.Damage.DamageEnergyType.Sonic, airbullet, painfulNoteGuid);
       
            string dissonantTouchCast = "58DD4D975D904D1DA0F2DCD51BF5BECF";
            var dissonantTouchIcon = BlueprintTool.Get<BlueprintActivatableAbility>("287e0c88af08f3e4ba4aca52566f33a7").Icon;
          
            string dissonantTouch = "F1863B76AE55418C9EABA6C232BED44C";
            AttackCantripFactory.ConfigureTouch(() => { return Settings.IsEnabled("DissonantTouch"); }, "DissonantTouch", dissonantTouchCast, dissonantTouch, Kingmaker.Enums.Damage.DamageEnergyType.Sonic, dissonantTouchIcon);
        }
    }
}
