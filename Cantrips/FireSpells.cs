using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreCantrips.Cantrips
{
    class FireSpells
    {
        public static void Make()
        {
            //  8cc159ce94d29fe46a94b80ce549161f
           
            string fireboltGUID = "69E2769505B34A548E0D9A5F21E3D5B4";
            var fireboltIcon = BlueprintTool.Get<BlueprintAbility>("42a65895ba0cb3a42b6019039dd2bff1").Icon;//MoltenOrb
            //var fireboltIcon = BlueprintTool.Get<BlueprintAbility>("4ecdf240d81533f47a5279f5075296b9").Icon; //Fire Domain base
            string scorchingProj = "8cc159ce94d29fe46a94b80ce549161f";//Scorching ray projectile


            AttackCantripFactory.ConfigureBeam(() => { return Settings.IsEnabled("Firebolt"); }, "Firebolt", fireboltGUID, Kingmaker.Enums.Damage.DamageEnergyType.Fire, scorchingProj, fireboltIcon);

            string burningTouchGUID = "25C60A4F408C4B2D97E4B9BC784E7F2F";
            var burningTouchIcon = BlueprintTool.Get<BlueprintAbility>("4783c3709a74a794dbe7c8e7e0b1b038").Icon;//Burning Hands
            string burningTouchGUID2 = "D3118971CE464C32982ED356B8971966";
            AttackCantripFactory.ConfigureTouch(() => { return Settings.IsEnabled("BurningTouch"); }, "BurningTouch", burningTouchGUID, burningTouchGUID2, Kingmaker.Enums.Damage.DamageEnergyType.Fire, burningTouchIcon);
        }
    }
}
