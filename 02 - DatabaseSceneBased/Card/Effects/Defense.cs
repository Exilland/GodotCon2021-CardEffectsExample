using Exilland.GodotCon.CardEffects.Battle;
using Exilland.GodotCon.CardEffects.Card.Effects.Abstract;
using Godot;

namespace Exilland.GodotCon.CardEffects.Card.Effects
{
    public class Defense : CardEffect
    {
        [Export] public int DefenseValue { get; set; }

        public override void Execute(BattleControl battle)
        {
            battle.Player.Defense += DefenseValue;
            GD.Print($"Increased my defense for {DefenseValue}");
        }
    }
}
