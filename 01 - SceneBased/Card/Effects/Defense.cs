using CardEffectsSceneBased.Battle;
using CardEffectsSceneBased.Card.Effects.Abstract;
using Godot;

namespace CardEffectsSceneBased.Card.Effects
{
    public class Defense : CardEffect
    {
        [Export] public int DefenseValue { get; set; }

        public override void Execute(BattleControl battle)
        {
            battle.Player.Defense += DefenseValue;
        }
    }
}