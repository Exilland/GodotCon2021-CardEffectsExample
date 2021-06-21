using Exilland.GodotCon.CardEffects.Battle;
using Exilland.GodotCon.CardEffects.Card.Effects.Abstract;

namespace Exilland.GodotCon.CardEffects.Card.Effects
{
    public class IfFullHealth : CardEffect
    {
        public override void Execute(BattleControl battle)
        {
            if (battle.Player.Health == 20)
            {
                ThenBranch()?.Execute(battle);
            }
            else
            {
                ElseBranch()?.Execute(battle);
            }
        }

        private CardEffect? ThenBranch()
        {
            if (GetChildCount() < 1)
            {
                return null;
            }
            return GetChildOrNull<CardEffect>(0);
        }

        private CardEffect? ElseBranch()
        {
            if (GetChildCount() < 2)
            {
                return null;
            }
            return GetChildOrNull<CardEffect>(1);
        }
    }
}