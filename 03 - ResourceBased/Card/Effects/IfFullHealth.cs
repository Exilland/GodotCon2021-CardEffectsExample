using Exilland.GodotCon.CardEffects.Battle;
using Exilland.GodotCon.CardEffects.Card.Effects.Abstract;
using Godot;

namespace Exilland.GodotCon.CardEffects.Card.Effects
{
    public class IfFullHealth : CardEffect
    {
        [Export] public CardEffect? ThenEffect { get; set; }
        [Export] public CardEffect? ElseEffect { get; set; }
        public override void Execute(BattleControl battle)
        {
            if (battle.Player.Health == 20)
            {
                ThenEffect?.Execute(battle);
            }
            else
            {
                ElseEffect?.Execute(battle);
            }
        }

    }
}