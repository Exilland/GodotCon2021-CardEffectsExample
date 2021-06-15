using CardEffectsSceneBased.Battle;
using CardEffectsSceneBased.Card.Effects.Abstract;
using Godot;

namespace CardEffectsSceneBased.Card.Effects
{
    public class Attack : CardEffect
    {
        [Export] public int AttackValue { get; set; }

        public override void Execute(BattleControl battle)
        {
            //battle.Enemy.Health -= AttackValue;
        }
    }
}