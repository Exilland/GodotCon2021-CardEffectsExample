using Exilland.GodotCon.CardEffects.Battle;
using Exilland.GodotCon.CardEffects.Card.Effects.Abstract;
using Godot;

namespace Exilland.GodotCon.CardEffects.Card.Effects
{
    public class Attack : CardEffect
    {
        [Export] public int AttackValue { get; set; }

        public override void Execute(BattleControl battle)
        {
            battle.Enemy.Health -= AttackValue;
        }
    }
}
