using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Enums.Damage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PhoenixsCantrips.Spells;

namespace MoreCantrips.Cantrips
{
    static class AttackCantripFactory
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AttackCantripFactory));

        public static void ConfigureBeam(Func<bool> enabled, string name, string guid, DamageEnergyType damage, Blueprint<BlueprintProjectileReference> projectile, Sprite icon, SpellSchool school = SpellSchool.Evocation)
        {
            Logger.Log($"Creating Ranged Cantrip: {name}");
            SpellDescriptor[] descriptor = new SpellDescriptor[] { };

            if (damage == DamageEnergyType.Fire)
                descriptor = new SpellDescriptor[] { SpellDescriptor.Fire };
            else if (damage == DamageEnergyType.Acid)
                descriptor = new SpellDescriptor[] { SpellDescriptor.Acid };
            else if (damage == DamageEnergyType.Cold)
                descriptor = new SpellDescriptor[] { SpellDescriptor.Cold };
            else if (damage == DamageEnergyType.Sonic)
                descriptor = new SpellDescriptor[] { SpellDescriptor.Sonic };
            else if (damage == DamageEnergyType.Electricity)
                descriptor = new SpellDescriptor[] { SpellDescriptor.Electricity };

            if (enabled.Invoke())
            {
                var cantrip = AbilityConfigurator.NewSpell(name, guid,school, false, descriptor);
                cantrip.SetDisplayName(name + ".Name");
                if (Settings.ScalingOn())
                    cantrip.SetDescription(name + ".Desc2");
                else
                    cantrip.SetDescription(name + ".Desc");
                cantrip.AddCantripComponent();
                cantrip.SetIcon(icon);

                cantrip.AddAbilityDeliverProjectile(needAttackRoll: true, projectiles: new List<Blueprint<BlueprintProjectileReference>>() { projectile }, weapon: "f6ef95b1f7bb52b408a5b345a330ffe8", lineWidth: new(5f));
                var action = ActionsBuilder.New().DealDamage(damageType: new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = damage }, value: ContextDice.Value(damage == DamageEnergyType.Sonic ? Kingmaker.RuleSystem.DiceType.D2 : Kingmaker.RuleSystem.DiceType.D3, diceCount: ContextValues.Constant(1), bonus: ContextValues.Constant(0)));
                cantrip.AddAbilityEffectRunAction(actions: action);

                cantrip.SetCanTargetEnemies(true);

                cantrip.SetCanTargetSelf(true);
                cantrip.SetRange(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityRange.Close);
                cantrip.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Directional);
                cantrip.SetEffectOnEnemy(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityEffectOnUnit.Harmful);
                cantrip.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
                cantrip.SetSpellResistance(true);

                if (damage != DamageEnergyType.Sonic)
                {
                    cantrip.AddToSpellLists(0, new SpellList[] { SpellList.Magus, SpellList.Wizard });
                }
                var made = cantrip.Configure();

                PhoenixsCantrips.Spells.RegisterCantrips.RegisterRay(damage, guid);
                Logger.Log($"Finished Ranged Cantrip: {name}");


            }
            else
            {
                AbilityConfigurator.New(name, guid).Configure();


            }


        }

        public static void ConfigureTouch(Func<bool> enabled, string name,  string spellGUID, string touchGUid, DamageEnergyType damage, Sprite icon, SpellSchool school = SpellSchool.Evocation, string touchprefabasset = null)
        {
            Logger.Log($"Creating Melee Cantrip: {name}");
            string castSysName = name + "Cast";
            SpellDescriptor[] descriptor = new SpellDescriptor[] { };


            if (enabled.Invoke())
            {
                var touch = AbilityConfigurator.NewSpell(name, touchGUid, school, false, descriptor);
                touch.SetDisplayName(name + ".Name");
                if (Settings.ScalingOn())
                    touch.SetDescription(name + ".Desc2");
                else
                    touch.SetDescription(name + ".Desc");
                var action = ActionsBuilder.New().DealDamage(damageType: new Kingmaker.RuleSystem.Rules.Damage.DamageTypeDescription() { Type = Kingmaker.RuleSystem.Rules.Damage.DamageType.Energy, Energy = damage }, value: ContextDice.Value(damage == DamageEnergyType.Sonic ? Kingmaker.RuleSystem.DiceType.D3 : Kingmaker.RuleSystem.DiceType.D4, diceCount: ContextValues.Constant(1), bonus: ContextValues.Constant(0)));
                touch.AddAbilityEffectRunAction(actions: action);
                touch.AddAbilityDeliverTouch(touchWeapon: "bb337517547de1a4189518d404ec49d4");
                touch.SetIcon(icon);
                touch.SetCanTargetEnemies(true);
                touch.SetCanTargetFriends(true);
                touch.SetCanTargetSelf(true);
                touch.SetSpellResistance(true);
                touch.SetEffectOnEnemy(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityEffectOnUnit.Harmful);
                touch.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Touch);
                touch.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);
                if (touchprefabasset != null)
                {
                    touch.AddAbilitySpawnFx(Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.SelectedTarget, delay: 0.0f, orientationAnchor: Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxAnchor.None, orientationMode: Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxOrientation.Copy, weaponTarget: Kingmaker.UnitLogic.Abilities.Components.Base.AbilitySpawnFxWeaponTarget.None, prefabLink: touchprefabasset);
                }
                touch.Configure();


                var cantrip = AbilityConfigurator.NewSpell(name + "Cast", spellGUID, Kingmaker.Blueprints.Classes.Spells.SpellSchool.Evocation, false, descriptor);
                cantrip.SetDisplayName(name + ".Name");
                if (Settings.ScalingOn())
                    cantrip.SetDescription(name + ".Desc2");
                else
                    cantrip.SetDescription(name + ".Desc");
                cantrip.AddCantripComponent();
                cantrip.SetIcon(icon);
                cantrip.AddAbilityEffectStickyTouch(touchDeliveryAbility: name);
                cantrip.SetCanTargetEnemies(true);
                cantrip.SetCanTargetFriends(true);
                cantrip.SetCanTargetSelf(true);
                cantrip.SetSpellResistance(true);


                cantrip.SetEffectOnEnemy(Kingmaker.UnitLogic.Abilities.Blueprints.AbilityEffectOnUnit.Harmful);
                cantrip.SetAnimation(Kingmaker.Visual.Animation.Kingmaker.Actions.UnitAnimationActionCastSpell.CastAnimationStyle.Self);
                cantrip.SetActionType(Kingmaker.UnitLogic.Commands.Base.UnitCommand.CommandType.Standard);

                if (damage != DamageEnergyType.Sonic)
                {
                    cantrip.AddToSpellLists(0, new SpellList[] { SpellList.Magus, SpellList.Wizard });
                }

                var made = cantrip.Configure();
                RegisterCantrips.RegisterTouch(damage, spellGUID);

                Logger.Log($"Finished Melee Cantrip: {name}");

            }
            else
            {
                AbilityConfigurator.New(name, touchGUid).Configure();

                AbilityConfigurator.New(castSysName, spellGUID).Configure();
            }
        }



    }
}
